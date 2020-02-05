using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Nejman.NSEC2;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;
using static Android.Support.V4.Media.App.NotificationCompat;

namespace NSEC.Music_Player
{
    public static class Global
    {
        /*
         * Constants
         */
        public const string password = "gruby idzie";
        public const int maxTracksInLastList = 5;

        /*
         * Audio Controllers
         */
        public static CustomMediaPlayer MediaPlayer { get; set; }
        public static Android.Media.AudioManager AudioManager { get; set; }

        /*
         * Track Containers
         */
        public static Dictionary<string, MediaProcessing.MediaTag> Audios { get; set; }
        public static Dictionary<string, MediaProcessing.MediaTag> AudioTags { get; set; }
        public static Dictionary<string, List<string>> Artists { get; set; }
        public static string AudioPlayerTrack { get; set; }
        public static List<Track> CurrentPlaylist { get; set; }
        public static int CurrentPlaylistPosition { get; set; }
        public static int CurrentQueuePosition { get; set; }
        public static List<Track> CurrentQueue { get; set; }
        public static MediaProcessing.MediaTag CurrentTrack { get; set; }
        public static Dictionary<string, List<Track>> Playlists { get; set; }
        public static TrackCounter[] LastTracks { get; set; }
        public static TrackCounter[] MostTracks { get; set; }
        public static bool AudioFromIntent { get; set; }

        /*
         * Global app variables
         */
        public static PlayerMode PlayerMode { get; set; }
        public static bool LastPlayerClick { get; set; }
        public static string DataPath { get; set; }
        public static string MusicPath { get; set; }
        public static MainActivity Context { get; set; }
        public static NotificationManager NotificationManager { get; set; }
        public static PowerManager PowerManager { get; set; }
        public static PowerManager.WakeLock WakeLock { get; set; }
        public static ImageSource EmptyTrack { get; set; }
        public static Dictionary<string, DownloadModel> Downloads { get; set; }
        /*
         * Global app controllers
         */
        public static AsyncEndController asyncEndController = new AsyncEndController();

        public static void LoadConfig()
        {
            if (File.Exists(DataPath + "/data.nsec2"))
            {
                MainActivity.Loaded = true;
                NSEC2 nsec = new NSEC2(password);
                FileStream fileStream = File.OpenRead(DataPath + "/data.nsec2");
                nsec.Load(fileStream);
                BinaryFormatter bf = new BinaryFormatter();
                if (nsec.Exists("playlists"))
                {
                    byte[] playlistsData = nsec.Get("playlists");
                    Dictionary<string, List<object[]>> playlistSerialize = (Dictionary<string, List<object[]>>)bf.Deserialize(new MemoryStream(playlistsData));
                    Playlists.Clear();

                    foreach (string playlistName in playlistSerialize.Keys)
                    {
                        List<object[]> playlist = playlistSerialize[playlistName];
                        List<Track> newPlaylist = new List<Track>();

                        foreach (object[] playlistTrack in playlist)
                        {
                            MediaProcessing.MediaTag trackContainer = (MediaProcessing.MediaTag)playlistTrack[3];
                            Console.WriteLine("Global.LoadConfig load " + trackContainer.FilePath + " -> " + File.Exists(trackContainer.FilePath));

                            if (File.Exists(trackContainer.FilePath))
                            {

                                Track track = new Track() { Text = (string)playlistTrack[0], Description = (string)playlistTrack[1], Container = trackContainer, Id = (string)playlistTrack[4] };
                                newPlaylist.Add(track);
                            }
                        }

                        Playlists.Add(playlistName, new List<Track>(newPlaylist));
                        newPlaylist.Clear();
                    }
                }

                if (nsec.Exists("lastTracks"))
                {
                    byte[] lastTracksData = nsec.Get("lastTracks");
                    string[] lastTracks = Encoding.UTF8.GetString(lastTracksData).Split(':', StringSplitOptions.RemoveEmptyEntries);
                    List<TrackCounter> lastTracksList = new List<TrackCounter>();
                    for (int a = 0; a < lastTracks.Length; a++)
                    {
                        TrackCounter trackCounter = TrackCounter.FromString(lastTracks[a]);
                        if (File.Exists(trackCounter.Track))
                            lastTracksList.Add(trackCounter);
                    }

                    LastTracks = lastTracksList.ToArray();
                }

                if (nsec.Exists("mostTracks"))
                {
                    byte[] mostTracksData = nsec.Get("mostTracks");
                    string[] mostTracks = Encoding.UTF8.GetString(mostTracksData).Split(':', StringSplitOptions.RemoveEmptyEntries);
                    List<TrackCounter> mostTrackList = new List<TrackCounter>();

                    for (int a = 0; a < mostTracks.Length; a++)
                    {
                        TrackCounter trackCounter = TrackCounter.FromString(mostTracks[a]);
                        if (File.Exists(trackCounter.Track) && a < maxTracksInLastList)
                            mostTrackList.Add(trackCounter);
                    }

                    mostTrackList = mostTrackList.OrderByDescending(o => o.Count).ToList();

                    MostTracks = mostTrackList.ToArray();
                }

                if (nsec.Exists("playerMode"))
                {
                    byte[] playerModeData = nsec.Get("playerMode");
                    int playerMode = int.Parse(Encoding.ASCII.GetString(playerModeData));
                    PlayerMode = (PlayerMode)playerMode;
                }

                if(!AudioFromIntent)
                {
                    int cpp = 0;

                    if (nsec.Exists("currentPlaylistPosition"))
                    {
                        byte[] currentPlaylistPositionData = nsec.Get("currentPlaylistPosition");
                        string cpps = Encoding.ASCII.GetString(currentPlaylistPositionData);
                        cpp = int.Parse(cpps);
                        Console.WriteLine("LoadConfig cpp " + cpp);
                    }

                    if (nsec.Exists("currentPlaylist"))
                    {
                        byte[] currentPlaylistData = nsec.Get("currentPlaylist");
                        string[] files = Encoding.UTF8.GetString(currentPlaylistData).Split(':', StringSplitOptions.RemoveEmptyEntries);
                        CurrentPlaylist = new List<Track>();

                        if (cpp >= files.Length)
                            cpp = -1;
                        else
                        {
                            if (Audios.ContainsKey(files[cpp]))
                            {
                                CurrentPlaylistPosition = cpp;
                                CurrentTrack = Audios[files[cpp]];
                                AudioPlayerTrack = CurrentTrack.FilePath;
                                MediaPlayer.Load(FileProcessing.GetStreamFromFile(files[cpp]), files[cpp]);
                            }
                        }
                        for (int a = 0; a < files.Length; a++)
                        {
                            Console.WriteLine($"LoadConfig {a}. {files[a]}");
                            if (File.Exists(files[a]) && Audios.ContainsKey(files[a]))
                            {
                                CurrentPlaylist.Add(TrackProcessing.GetTrack(files[a]));
                            }
                        }
                    }
                }
            }
        }

        public static void SaveConfig()
        {
            NSEC2 nsec = new NSEC2(password);
            nsec.SetDebug(false);
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();


            Dictionary<string, List<object[]>> playlists = new Dictionary<string, List<object[]>>();
            foreach (string playlistName in Playlists.Keys)
            {
                List<object[]> playlistSerialize = new List<object[]>();
                List<Track> playlist = Playlists[playlistName];

                foreach (Track playlistTrack in playlist)
                {
                    playlistSerialize.Add(playlistTrack.Serialize());
                }

                playlists.Add(playlistName, playlistSerialize);
            }
            bf.Serialize(memoryStream, playlists);
            byte[] playlistsData = memoryStream.ToArray();
            nsec.AddFile("playlists", playlistsData);


            string lastTracks = "";
            for (int a = 0; a < LastTracks.Length; a++)
                lastTracks += LastTracks[a].ToString();
            byte[] lastTracksData = Encoding.UTF8.GetBytes(lastTracks);

            string mostTracks = "";
            for (int a = 0; a < MostTracks.Length; a++)
                mostTracks += MostTracks[a].ToString();
            byte[] mostTracksData = Encoding.UTF8.GetBytes(mostTracks);

            nsec.AddFile("lastTracks", lastTracksData);
            nsec.AddFile("mostTracks", mostTracksData);

            byte[] playerModeData = Encoding.ASCII.GetBytes(((int)PlayerMode).ToString());
            Console.WriteLine("SaveConfig " + System.Globalization.CultureInfo.CurrentUICulture.Name);

            nsec.AddFile("playerMode", playerModeData);

            if (CurrentPlaylist.Count > 0)
            {
                byte[] currentPlaylistPositionData = Encoding.ASCII.GetBytes(CurrentPlaylistPosition.ToString());
                nsec.AddFile("currentPlaylistPosition", currentPlaylistPositionData);

                string currentPlaylistString = "";
                for (int a = 0; a < CurrentPlaylist.Count; a++)
                {
                    currentPlaylistString += CurrentPlaylist[a].Container.FilePath + ":";
                }

                nsec.AddFile("currentPlaylist", Encoding.UTF8.GetBytes(currentPlaylistString));
            }

            SaveTags();

            File.WriteAllBytes(DataPath + "/data.nsec2", nsec.Save());
        }

        public static void SaveTags()
        {
            if (AudioTags.Count > 0)
            {
                NSEC2 nsec = new NSEC2(password);
                nsec.SetDebug(false);
                BinaryFormatter bf = new BinaryFormatter();
                using MemoryStream memoryStream = new MemoryStream();
                bf.Serialize(memoryStream, AudioTags);
                nsec.AddFile("tags", memoryStream.ToArray());

                File.WriteAllBytes(DataPath + "/tags.nsec2", nsec.Save());
            }
        }

        public static void LoadTags()
        {
            if (File.Exists(DataPath + "/tags.nsec2"))
            {
                NSEC2 nsec = new NSEC2(password);
                nsec.SetDebug(false);
                FileStream fileStream = File.OpenRead(DataPath + "/tags.nsec2");
                nsec.Load(fileStream);

                using MemoryStream memoryStream = new MemoryStream(nsec.Get("tags"));
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                AudioTags = (Dictionary<string, MediaProcessing.MediaTag>)binaryFormatter.Deserialize(memoryStream);
                fileStream.Dispose();
            }
        }
    }
}
