using Nejman.NSEC2;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Newtone.Core
{
    public class GlobalData
    {
        public const string PASSWORD = "gruby idzie";
        public const string SEPARATOR = "[NSEC2_SEPARATOR]";
        public const int MAXTRACKSINLASTLIST = 5;

        public const string ERROR_FILE_EXISTS = "error_file_exists";
        public const string ERROR_CORRUPTED = "error_file_corupted";
        public const string ERROR_CONNECTION = "connection_error";

        public const string RECEIVED_MESSAGE = "NSEC2 Received";

        public static bool IsDebugMode
        {
            get
            {
#if DEBUG
                return true;
#else
    return false;
#endif
            }
        }

        public static CrossPlayer MediaPlayer { get; set; }

        public static Dictionary<string, MediaSource> Audios { get; set; }
        public static Dictionary<string, MediaSourceTag> AudioTags { get; set; }
        public static List<string> DownloadedIds { get; set; }
        public static Dictionary<string, List<string>> Artists { get; set; }
        public static Dictionary<string, List<string>> Playlists { get; set; }
        public static List<MediaSource> CurrentPlaylist { get; set; }
        public static List<MediaSource> CurrentQueue { get; set; }
        public static MediaSource.SourceType PlaylistType { get; set; }
        public static int PlaylistPosition { get; set; }
        public static int QueuePosition { get; set; }
        public static MediaSource MediaSource { get; set; }
        public static bool AudioFromIntent { get; set; }

        public static string MediaSourcePath
        {
            get
            {
                return MediaSource == null ? "" : MediaSource.FilePath;
            }
        }

        public static List<HistoryModel> History { get; set; }
        public static TrackCounter[] LastTracks { get; set; }
        public static TrackCounter[] MostTracks { get; set; }

        public static PlayerMode PlayerMode { get; set; }
        public static string DataPath { get; set; }
        public static string MusicPath { get; set; }

        public static AsyncEndController AsyncEndController = new AsyncEndController();

        public static string LanguageUnknownArtist { get; set; }

        public static List<string> ExcludedPaths { get; set; }
        public static List<string> IncludedPaths { get; set; }

        public static string LoadFirstStart()
        {
            if (!File.Exists(DataPath + "/newtone.first.nsec2"))
                return null;

            FileStream stream = File.OpenRead(DataPath + "/newtone.first.nsec2");
            NSEC2 nsec = new NSEC2(PASSWORD);
            nsec.Load(stream);
            byte[] themeData = nsec.Get("theme");
            string theme = System.Text.Encoding.ASCII.GetString(themeData);
            nsec.Dispose();
            return theme;
        }

        public static void SaveFirstStart(string theme)
        {
            NSEC2 nsec = new NSEC2(PASSWORD);
            nsec.AddFile("theme", System.Text.Encoding.ASCII.GetBytes(theme));
            File.WriteAllBytes(DataPath + "/newtone.first.nsec2", nsec.Save());
            nsec.Dispose();
        }

        public static void LoadConfig()
        {
            Directory.CreateDirectory(MusicPath);
            //ConsoleDebug.WriteLine("LoadConfig");
            if (File.Exists(DataPath + "/newtone.nsec2"))
            {
                FileStream stream = File.OpenRead(DataPath + "/newtone.nsec2");
                NSEC2 nsec = new NSEC2(PASSWORD);
                nsec.Load(stream);

                if(nsec.Exists("volume"))
                {
                    string buffer = System.Text.Encoding.ASCII.GetString(nsec.Get("volume"));
                    MediaPlayer.SetVolume(float.Parse(buffer));
                }

                if (nsec.Exists("playlists"))
                {
                    string buffer = System.Text.Encoding.UTF8.GetString(nsec.Get("playlists"));
                    string[] playlists = buffer.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    //ConsoleDebug.WriteLine("LoadConfig " + playlists.Length);

                    foreach (string playlistBuffer in playlists)
                    {
                        List<string> playlist = new List<string>();
                        string[] parts = playlistBuffer.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
                        string name = parts[0];
                        string[] items = parts[1].Split(';', StringSplitOptions.RemoveEmptyEntries);

                        foreach (string filepath in items)
                        {
                            if (File.Exists(filepath))
                            {
                                playlist.Add(filepath);
                            }
                        }

                        if (playlist.Count > 0)
                        {
                            Playlists.Add(name, playlist);
                        }
                    }
                }

                if (nsec.Exists("mostTracks"))
                {
                    byte[] tracksData = nsec.Get("mostTracks");
                    string[] tracks = System.Text.Encoding.UTF8.GetString(tracksData).Split(':', StringSplitOptions.RemoveEmptyEntries);

                    List<TrackCounter> trackList = new List<TrackCounter>();
                    foreach (string track in tracks)
                    {

                        TrackCounter counter = TrackCounter.FromString(track);

                        if (counter != null && File.Exists(counter.Media.FilePath) && trackList.Count < MAXTRACKSINLASTLIST)
                        {

                            trackList.Add(counter);
                        }
                    }

                    trackList = trackList.OrderByDescending(o => o.Count).ToList();

                    MostTracks = trackList.ToArray();
                }

                if (nsec.Exists("lastTracks"))
                {
                    byte[] tracksData = nsec.Get("lastTracks");
                    string[] tracks = System.Text.Encoding.UTF8.GetString(tracksData).Split(':', StringSplitOptions.RemoveEmptyEntries);

                    List<TrackCounter> trackList = new List<TrackCounter>();
                    foreach (string track in tracks)
                    {
                        TrackCounter counter = TrackCounter.FromString(track);

                        if (counter != null && File.Exists(counter.Media.FilePath) && trackList.Count < MAXTRACKSINLASTLIST)
                        {
                            trackList.Add(counter);
                        }
                    }

                    LastTracks = trackList.ToArray();
                }

                if (nsec.Exists("playerMode"))
                {
                    byte[] playerModeData = nsec.Get("playerMode");
                    int playerMode = int.Parse(System.Text.Encoding.UTF8.GetString(playerModeData));
                    PlayerMode = (PlayerMode)playerMode;
                }

                if (nsec.Exists("history"))
                {
                    byte[] historyData = nsec.Get("history");
                    string[] historyElems = System.Text.Encoding.UTF8.GetString(historyData).Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    History.Clear();
                    foreach (string elem in historyElems)
                    {
                        string[] text = elem.Split(SEPARATOR);
                        if (History.FindIndex(model => model.Text == text[1]) == -1)
                            History.Add(new HistoryModel() { Text = text[1] });
                    }
                }

                if (!AudioFromIntent)
                {
                    int cpp = 0;

                    if (nsec.Exists("playlistPosition"))
                    {
                        byte[] ppData = nsec.Get("playlistPosition");
                        string pp = System.Text.Encoding.ASCII.GetString(ppData);
                        cpp = int.Parse(pp);
                    }

                    if (nsec.Exists("playlist"))
                    {
                        byte[] playlistData = nsec.Get("playlist");
                        string[] files = System.Text.Encoding.UTF8.GetString(playlistData).Split(':', StringSplitOptions.RemoveEmptyEntries);

                        CurrentPlaylist = new List<MediaSource>();

                        if (cpp >= files.Length)
                        {
                            cpp = -1;
                        }
                        else
                        {
                            if (Audios.ContainsKey(files[cpp]))
                            {
                                PlaylistPosition = cpp;
                                MediaSource = Audios[files[cpp]];
                                MediaPlayer.Load(files[cpp]);
                            }
                        }

                        foreach (string filepath in files)
                        {
                            if (File.Exists(filepath) && Audios.ContainsKey(filepath))
                            {
                                CurrentPlaylist.Add(Audios[filepath]);
                            }
                        }
                    }
                }

                nsec.Dispose();
            }
        }

        public static void SaveConfig()
        {
            NSEC2 nsec = new NSEC2(PASSWORD);

            string buffer = MediaPlayer.GetVolume().ToString();

            nsec.AddFile("volume", System.Text.Encoding.ASCII.GetBytes(buffer));


            buffer = "";

            if (Playlists.Count > 0)
            {
                foreach (string playlistName in Playlists.Keys)
                {

                    List<string> playlist = Playlists[playlistName];

                    if (playlist.Count > 0)
                    {
                        string playlistItem = playlistName + SEPARATOR;



                        foreach (string item in playlist)
                        {
                            playlistItem += item + ';';
                        }

                        buffer += playlistItem + '\n';
                    }

                }

                nsec.AddFile("playlists", System.Text.Encoding.UTF8.GetBytes(buffer));
            }

            int playerMode = (int)PlayerMode;
            buffer = playerMode.ToString();
            nsec.AddFile("playerMode", System.Text.Encoding.UTF8.GetBytes(buffer));

            nsec.AddFile("playlistPosition", System.Text.Encoding.ASCII.GetBytes(PlaylistPosition.ToString()));

            if (CurrentPlaylist.Count > 0 && PlaylistType == MediaSource.SourceType.Local)
            {
                buffer = "";
                foreach (MediaSource mediaSource in CurrentPlaylist)
                {
                    string item = mediaSource.FilePath;
                    buffer += item + ';';
                }
                nsec.AddFile("playlist", System.Text.Encoding.UTF8.GetBytes(buffer));
            }
            buffer = "";

            foreach (TrackCounter counter in MostTracks)
            {
                if (counter != null)
                    buffer += counter.ToString() + ":";
            }

            nsec.AddFile("mostTracks", System.Text.Encoding.UTF8.GetBytes(buffer));

            buffer = "";

            foreach (TrackCounter counter in LastTracks)
            {
                if (counter != null)
                    buffer += counter.ToString() + ":";
            }

            nsec.AddFile("lastTracks", System.Text.Encoding.UTF8.GetBytes(buffer));

            if (History.Count > 0)
            {
                buffer = "";

                foreach (var model in History)
                {
                    buffer += "yt" + SEPARATOR + model.Text + "\n";
                }

                nsec.AddFile("history", System.Text.Encoding.UTF8.GetBytes(buffer));
            }

            File.WriteAllBytes(DataPath + "/newtone.nsec2", nsec.Save());

            nsec.Dispose();
        }

        public static void SaveTags()
        {
            ConsoleDebug.WriteLine("SaveTags " + AudioTags.Count);
            if (AudioTags.Count > 0)
            {
                NSEC2 nsec = new NSEC2(PASSWORD);
                nsec.SetDebug(false);

                int counter = 0;
                string buffer = "";
                foreach (string filepath in AudioTags.Keys)
                {
                    MediaSourceTag mediaSource = AudioTags[filepath];

                    string name = "image" + counter;
                    nsec.AddFile(name, mediaSource.Image ?? (new byte[0]));

                    string bufferItem = filepath + SEPARATOR + mediaSource.Author + SEPARATOR + mediaSource.Title + SEPARATOR + name;

                    if (!string.IsNullOrWhiteSpace(mediaSource.Id))
                        bufferItem += SEPARATOR + mediaSource.Id;

                    bufferItem += "\n";
                    buffer += bufferItem;
                    counter += 1;
                }

                nsec.AddFile("tags", System.Text.Encoding.UTF8.GetBytes(buffer));

                File.WriteAllBytes(DataPath + "/newtoneTags.nsec2", nsec.Save());
            }
        }

        public static void LoadTags()
        {
            
            if (File.Exists(DataPath + "/newtoneTags.nsec2"))
            {
                AudioTags.Clear();
                FileStream fileStream = File.OpenRead(DataPath + "/newtoneTags.nsec2");
                NSEC2 nsec = new NSEC2(PASSWORD);
                nsec.Load(fileStream);
                nsec.SetDebug(false);

                string[] tags = System.Text.Encoding.UTF8.GetString(nsec.Get("tags")).Split('\n', StringSplitOptions.RemoveEmptyEntries);
                ConsoleDebug.WriteLine("LoadTags "+tags.Length);

                foreach (string tagItem in tags)
                {
                    string[] values = tagItem.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

                    MediaSourceTag tag = new MediaSourceTag()
                    {
                        Author = values[1],
                        Title = values[2],
                        Image = nsec.Get(values[3]).Length > 0 ? nsec.Get(values[3]) : null,
                        Id = values.Length > 4 ? values[4] : null
                    };

                    if(values.Length > 4)
                    {
                        if (!DownloadedIds.Contains(values[4]))
                            DownloadedIds.Add(values[4]);
                    }

                    ConsoleDebug.WriteLine("LT: "+values[0]);
                    AudioTags.Add(values[0], tag);
                }

                nsec.Dispose();
            }
        }
    }
}
