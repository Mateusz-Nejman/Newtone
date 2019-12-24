using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Services;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static ISimpleAudioPlayer AudioPlayer { get; set; }
        public static string AudioPlayerTrack { get; set; }
        public static List<Track> CurrentPlaylist { get; set; }
        public static int CurrentPlaylistPosition { get; set; }
        public static MP3Processing.Container CurrentTrack { get; set; }

        public static string[] Directories { get; set; }

        public static Dictionary<string, List<Track>> Playlists = new Dictionary<string, List<Track>>();

        public static void AudioPlayer_PlaybackEnded(object sender, EventArgs e)
        {
            AudioPlayer.Stop();
            CurrentPlaylistPosition += 1;

            if (CurrentPlaylistPosition == CurrentPlaylist.Count)
                CurrentPlaylistPosition = 0;

            Track track = CurrentPlaylist[CurrentPlaylistPosition];
            CurrentTrack = track.Container;
            Global.AudioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            Global.AudioPlayer.PlaybackEnded += AudioPlayer_PlaybackEnded;
            Global.AudioPlayer.Load(FileProcessing.GetStreamFromFile(CurrentTrack.FilePath));
            Global.AudioPlayerTrack = track.Id;
            Global.AudioPlayer.Play();
            SaveConfig();
        }

        public static void LoadConfig()
        {
            if(File.Exists(DataPath+"/config.nsec"))
            {
                NSEC.Container container = new Container(DataPath + "/config.nsec", password);
                BinaryFormatter bf = new BinaryFormatter();
                byte[] containerData = container.GetFile("config");
                ConfigContainer configContainer = (ConfigContainer)bf.Deserialize(new MemoryStream(containerData));
                CurrentTrack = configContainer.Container;
                

                if(File.Exists(CurrentTrack.FilePath))
                {
                    CurrentPlaylistPosition = configContainer.Position;

                    CurrentPlaylist = new List<Track>();
                    CurrentPlaylist.Add(new Track()
                    {
                        Text = (string)configContainer.Track[0],
                        Description = (string)configContainer.Track[1],
                        Tag = (string)configContainer.Track[2],
                        Container = (MP3Processing.Container)configContainer.Track[3],
                        Id = (string)configContainer.Track[4]
                    });
                    CurrentPlaylistPosition = 0;

                    if (Global.AudioPlayer != null)
                        Global.AudioPlayer.Stop();
                    var stream = FileProcessing.GetStreamFromFile(CurrentTrack.FilePath);
                    Global.AudioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    Global.AudioPlayer.Load(stream);
                    Global.AudioPlayer.PlaybackEnded += Global.AudioPlayer_PlaybackEnded;
                    Global.AudioPlayerTrack = CurrentPlaylist[0].Id;
                }
                

                if(container.Exists("playlists"))
                {
                    byte[] playlistsData = container.GetFile("playlists");
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

            }
        }

        public static void SaveConfig()
        {
            NSEC.Container container = new Container(password);
            container.SetMobile(true, DataPath);

            object[] track = CurrentPlaylist == null ? null : CurrentPlaylist[CurrentPlaylistPosition].Serialize();

            ConfigContainer configContainer = new ConfigContainer() {
                Container = CurrentTrack,
                Track = track,
                Position = CurrentPlaylistPosition
            };
            BinaryFormatter bf = new BinaryFormatter();

            MemoryStream memoryStream = new MemoryStream();
            bf.Serialize(memoryStream, configContainer);
            byte[] containerData = memoryStream.ToArray();
            container.AddFile("config", containerData);

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
            container.AddFile("playlists", playlistsData);

            File.WriteAllBytes(DataPath + "/config.nsec", container.Save(false));
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
