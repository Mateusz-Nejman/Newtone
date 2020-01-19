using Nejman.NSEC2;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Services;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace NSEC.Music_Player
{
    public static class Global
    {
        public const string password = "gruby idzie";
        public static string DataPath { get; set; }
        public static AsyncEndController asyncEndController = new AsyncEndController();
        public static Dictionary<string, List<Logic.MP3Processing.Container>> Audios = new Dictionary<string, List<Logic.MP3Processing.Container>>();
        //public static ISimpleAudioPlayer AudioPlayer { get; set; }

        public static CustomMediaPlayer MediaPlayer { get; set; }
        public static string AudioPlayerTrack { get; set; }
        public static List<Track> CurrentPlaylist { get; set; }
        public static int CurrentPlaylistPosition { get; set; }

        public static int CurrentQueuePosition { get; set; }
        public static List<Track> CurrentQueue { get; set; }
        public static MP3Processing.Container CurrentTrack { get; set; }

        public static string[] Directories { get; set; }

        public static Dictionary<string, List<Track>> Playlists = new Dictionary<string, List<Track>>();

        public static TrackCounter[] LastTracks { get; set; }
        public static TrackCounter[] MostTracks { get; set; }

        public static void LoadConfig()
        {
            LastTracks = new TrackCounter[0];
            MostTracks = new TrackCounter[0];
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

                    Global.AudioPlayerTrack = CurrentPlaylist[0].Id;
                    if (Global.MediaPlayer != null)
                        Global.MediaPlayer.Stop();
                    Global.MediaPlayer.Load(FileProcessing.GetStreamFromFile(configContainer.Container.FilePath));
                    Global.AudioPlayerTrack = CurrentPlaylist[0].Id;
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
                            Console.WriteLine("LOAD "+trackContainer.FilePath+" -> "+File.Exists(trackContainer.FilePath));

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
                        if (File.Exists(trackCounter.Track) && a < 5)
                            mostTrackList.Add(trackCounter);
                    }

                    mostTrackList = mostTrackList.OrderByDescending(o => o.Count).ToList();

                    MostTracks = mostTrackList.ToArray();
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

            File.WriteAllBytes(DataPath + "/config.nsec2", nsec.Save());
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
