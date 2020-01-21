using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Support.V4.App;
using Nejman.NSEC2;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
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
        public static Dictionary<string, List<MP3Processing.Container>> Audios { get; set; }
        public static string AudioPlayerTrack { get; set; }
        public static List<Track> CurrentPlaylist { get; set; }
        public static int CurrentPlaylistPosition { get; set; }
        public static int CurrentQueuePosition { get; set; }
        public static List<Track> CurrentQueue { get; set; }
        public static MP3Processing.Container CurrentTrack { get; set; }
        public static Dictionary<string, List<Track>> Playlists { get; set; }
        public static TrackCounter[] LastTracks { get; set; }
        public static TrackCounter[] MostTracks { get; set; }

        /*
         * Global app variables
         */
        public static PlayerMode PlayerMode { get; set; }
        public static bool LastPlayerClick { get; set; }
        public static string DataPath { get; set; }
        public static string[] Directories { get; set; }
        public static MainActivity Context { get; set; }
        public static NotificationManager NotificationManager { get; set; }
        /*
         * Global app controllers
         */
        public static AsyncEndController asyncEndController = new AsyncEndController();

        public static void LoadConfig()
        {
            if(File.Exists(DataPath+"/config.nsec2"))
            {
                NSEC2 nsec = new NSEC2(password);
                FileStream fileStream = File.OpenRead(DataPath + "/config.nsec2");
                nsec.Load(fileStream);
                BinaryFormatter bf = new BinaryFormatter();
                byte[] containerData = nsec.Get("config");
                ConfigContainer configContainer = (ConfigContainer)bf.Deserialize(new MemoryStream(containerData));
                CurrentTrack = configContainer.Container;
                

                if(File.Exists(CurrentTrack.FilePath))
                {
                    CurrentPlaylistPosition = configContainer.Position;

                    CurrentPlaylist = new List<Track>
                    {
                        new Track()
                        {
                            Text = (string)configContainer.Track[0],
                            Description = (string)configContainer.Track[1],
                            Tag = (string)configContainer.Track[2],
                            Container = (MP3Processing.Container)configContainer.Track[3],
                            Id = (string)configContainer.Track[4]
                        }
                    };
                    CurrentPlaylistPosition = 0;

                    AudioPlayerTrack = CurrentPlaylist[0].Id;
                    if (MediaPlayer != null)
                        MediaPlayer.Stop();
                    MediaPlayer.Load(FileProcessing.GetStreamFromFile(configContainer.Container.FilePath));
                    AudioPlayerTrack = CurrentPlaylist[0].Id;
                }
                

                if(nsec.Exists("playlists"))
                {
                    byte[] playlistsData = nsec.Get("playlists");
                    Dictionary<string, List<object[]>> playlistSerialize = (Dictionary<string, List<object[]>>)bf.Deserialize(new MemoryStream(playlistsData));
                    Playlists.Clear();
                    
                    foreach(string playlistName in playlistSerialize.Keys)
                    {
                        List<object[]> playlist = playlistSerialize[playlistName];
                        List<Track> newPlaylist = new List<Track>();

                        foreach(object[] playlistTrack in playlist)
                        {
                            MP3Processing.Container trackContainer = (MP3Processing.Container)playlistTrack[3];
                            Console.WriteLine("Global.LoadConfig load "+trackContainer.FilePath+" -> "+File.Exists(trackContainer.FilePath));

                            if(File.Exists(trackContainer.FilePath))
                            {
                                
                                Track track = new Track() { Text = (string)playlistTrack[0], Description = (string)playlistTrack[1], Tag = (string)playlistTrack[2], Container = trackContainer, Id = (string)playlistTrack[4] };
                                newPlaylist.Add(track);
                            }
                        }

                        Playlists.Add(playlistName, new List<Track>(newPlaylist));
                        newPlaylist.Clear();
                    }
                }

                if(nsec.Exists("lastTracks"))
                {
                    byte[] lastTracksData = nsec.Get("lastTracks");
                    string[] lastTracks = Encoding.UTF8.GetString(lastTracksData).Split(':',StringSplitOptions.RemoveEmptyEntries);
                    List<TrackCounter> lastTracksList = new List<TrackCounter>();
                    for(int a = 0; a < lastTracks.Length; a++)
                    {
                        TrackCounter trackCounter = TrackCounter.FromString(lastTracks[a]);
                        if (File.Exists(trackCounter.Track))
                            lastTracksList.Add(trackCounter);
                    }

                    LastTracks = lastTracksList.ToArray();
                }

                if(nsec.Exists("mostTracks"))
                {
                    byte[] mostTracksData = nsec.Get("mostTracks");
                    string[] mostTracks = Encoding.UTF8.GetString(mostTracksData).Split(':', StringSplitOptions.RemoveEmptyEntries);
                    List<TrackCounter> mostTrackList = new List<TrackCounter>();

                    for(int a = 0; a < mostTracks.Length; a++)
                    {
                        TrackCounter trackCounter = TrackCounter.FromString(mostTracks[a]);
                        if (File.Exists(trackCounter.Track) && a < maxTracksInLastList)
                            mostTrackList.Add(trackCounter);
                    }

                    mostTrackList = mostTrackList.OrderByDescending(o => o.Count).ToList();

                    MostTracks = mostTrackList.ToArray();
                }

                if(nsec.Exists("playerMode"))
                {
                    byte[] playerModeData = nsec.Get("playerMode");
                    int playerMode = int.Parse(Encoding.ASCII.GetString(playerModeData));
                    PlayerMode = (PlayerMode)playerMode;
                }

            }
        }

        public static void SaveConfig()
        {
            NSEC2 nsec = new NSEC2(password);
            nsec.SetDebug(false);

            object[] track = CurrentPlaylist?[CurrentPlaylistPosition].Serialize();

            ConfigContainer configContainer = new ConfigContainer() {
                Container = CurrentTrack,
                Track = track,
                Position = CurrentPlaylistPosition
            };
            BinaryFormatter bf = new BinaryFormatter();

            MemoryStream memoryStream = new MemoryStream();
            bf.Serialize(memoryStream, configContainer);
            byte[] containerData = memoryStream.ToArray();
            nsec.AddFile("config", containerData);

            memoryStream = new MemoryStream();

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
            byte[] languageData = Encoding.ASCII.GetBytes("pl-PL");

            nsec.AddFile("playerMode", playerModeData);
            nsec.AddFile("language", languageData);

            File.WriteAllBytes(DataPath + "/config.nsec2", nsec.Save());
        }

        public static void SetNotification(string title, string desc, bool play)
        {
            PendingIntent prevIntentP = PendingIntent.GetBroadcast(Context, 1, new Intent("prev"), PendingIntentFlags.CancelCurrent);
            PendingIntent playIntentP = PendingIntent.GetBroadcast(Context, 0, new Intent("play"), PendingIntentFlags.Immutable);
            PendingIntent pauseIntentP = PendingIntent.GetBroadcast(Context, 0, new Intent("pause"), PendingIntentFlags.Immutable);
            PendingIntent nextIntentP = PendingIntent.GetBroadcast(Context, 0, new Intent("next"), PendingIntentFlags.Immutable);

            NotificationCompat.Action actionPrev = new NotificationCompat.Action(Resource.Drawable.prevIconNotification, "Prev", prevIntentP);
            NotificationCompat.Action actionPlay = new NotificationCompat.Action(!play ? Resource.Drawable.playiconNotification : Resource.Drawable.pauseIconNotification, "Play", !play ? playIntentP : pauseIntentP);
            NotificationCompat.Action actionNext = new NotificationCompat.Action(Resource.Drawable.nextIconNotification, "Next", nextIntentP);


            NotificationCompat.Builder builder = new NotificationCompat.Builder(Context, "nsec music_player notification").
                SetContentTitle(title).
                SetContentText(desc).
                SetSmallIcon(Resource.Drawable.playIconWhite).
                AddAction(actionPrev).
                AddAction(actionPlay).
                AddAction(actionNext).
                SetContentIntent(prevIntentP).
                SetStyle(new MediaStyle()).
                SetLargeIcon(BitmapFactory.DecodeResource(Context.Resources, Resource.Drawable.emptyTrack)).
                SetVisibility(NotificationCompat.VisibilityPublic).SetOngoing(true);
            Notification notification = builder.Build();

            //Instance.StartService(prevIntent);
            NotificationManager.Notify(0, notification);
        }

        [Serializable]
        private class ConfigContainer
        {
            public MP3Processing.Container Container { get; set; }
            public object[] Track { get; set; }
            public int Position { get; set; }
        }
    }
}
