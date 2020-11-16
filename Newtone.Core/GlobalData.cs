using Nejman.NSEC2;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Newtone.Core
{
    public class GlobalData
    {
        #region Constants
        public const string NSEC_HASH = "gruby idzie";
        public const string SEPARATOR = "[NSEC2_SEPARATOR]";
        public const int MAXTRACKSINLASTLIST = 5;

        public const string ERROR_FILE_EXISTS = "error_file_exists";
        public const string ERROR_CORRUPTED = "error_file_corupted";
        public const string ERROR_CONNECTION = "connection_error";
        public const string SYNC_COMPLETED = "NSEC2C";
        public const string SYNC_DISCONNECT = "NSEC2D";

        public const string RECEIVED_MESSAGE = "NSEC2R";
        public const string SYNC_CODE = "NSEC2CD";
        #endregion
        #region Properties
        public static GlobalData Current { get; } = new GlobalData();
        public bool IsDebugMode
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

        public CrossPlayer MediaPlayer { get; set; }

        public Dictionary<string, MediaSource> Audios { get; set; }
        public Dictionary<string, MediaSource> SavedTracks { get; set; }
        public Dictionary<string, MediaSourceTag> AudioTags { get; set; }
        public List<string> DownloadedIds { get; set; }
        public Dictionary<string, List<string>> Artists { get; set; }
        public Dictionary<string, List<string>> Playlists { get; set; }
        public Dictionary<string, string> WebToLocalPlaylists { get; set; }
        public Dictionary<string,string> RecomendedPlaylists { get; set; }
        public List<MediaSource> CurrentPlaylist { get; set; }
        public int PlaylistPosition { get; set; }
        public int QueuePosition { get; set; }
        public MediaSource MediaSource { get; set; }
        public bool AudioFromIntent { get; set; }
        public bool AutoDownload { get; set; }

        public string MediaSourcePath
        {
            get
            {
                return MediaSource == null ? "" : MediaSource.FilePath;
            }
        }

        public List<HistoryModel> History { get; set; }
        public TrackCounter[] LastTracks { get; set; }
        public TrackCounter[] MostTracks { get; set; }

        public PlayerMode PlayerMode { get; set; }
        public string DataPath { get; set; }
        public string MusicPath { get; set; }
        public List<string> ExcludedPaths { get; set; }
        public List<string> IncludedPaths { get; set; }
        public string CurrentLanguage { get; set; }
        public MessageGenerator Messenger { get; set; }
        public bool ArtistsNeedRefresh { get; set; }
        public bool PlaylistsNeedRefresh { get; set; }
        public bool CurrentPlaylistNeedRefresh { get; set; }
        public bool HistoryNeedRefresh { get; set; }
        public int IncludedPathsToSkip { get; set; }
        public bool IgnoreAutoFocus { get; set; }
        public MediaFormat MediaFormat { get; set; } = MediaFormat.m4a;
        #endregion
        #region Public Methods
        public void Initialize()
        {
            Artists = new Dictionary<string, List<string>>();
            Audios = new Dictionary<string, Newtone.Core.Media.MediaSource>();
            SavedTracks = new Dictionary<string, MediaSource>();
            AudioTags = new Dictionary<string, MediaSourceTag>();
            DownloadedIds = new List<string>();
            CurrentPlaylist = new List<Newtone.Core.Media.MediaSource>();
            WebToLocalPlaylists = new Dictionary<string, string>();
            RecomendedPlaylists = new Dictionary<string, string>(); //name, url
            DataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "\\NSEC\\Newtone";
            Console.WriteLine(DataPath);

            History = new List<Newtone.Core.Models.HistoryModel>();
            LastTracks = new Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST];
            MostTracks = new Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST];

            PlayerMode = PlayerMode.All;
            Playlists = new Dictionary<string, List<string>>();

            ExcludedPaths = new List<string>();
            IgnoreAutoFocus = false;
        }

        public void LoadConfig()
        {
            Directory.CreateDirectory(MusicPath);
            if (File.Exists(DataPath + "/newtone.nsec2"))
            {
                FileStream stream = File.OpenRead(DataPath + "/newtone.nsec2");
                NSEC2 nsec = new NSEC2(NSEC_HASH);
                nsec.Load(stream);
                if(nsec.Exists("language"))
                {
                    CurrentLanguage = System.Text.Encoding.ASCII.GetString(nsec.Get("language"));
                    Localization.RefreshLanguage();
                }
                if(nsec.Exists("volume"))
                {
                    string buffer = System.Text.Encoding.ASCII.GetString(nsec.Get("volume"));
                    MediaPlayer.SetVolume(float.Parse(buffer));
                }

                if (nsec.Exists("playlists"))
                {
                    string buffer = System.Text.Encoding.UTF8.GetString(nsec.Get("playlists"));
                    string[] playlists = buffer.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    playlists.ForEach(playlistBuffer =>
                    {
                        List<string> playlist = new List<string>();
                        string[] parts = playlistBuffer.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
                        string name = parts[0];
                        string[] items = parts[1].Split(';', StringSplitOptions.RemoveEmptyEntries);

                        items.ForEach(filepath =>
                        {
                            if (File.Exists(filepath) || filepath.Length == 11)
                            {
                                playlist.Add(filepath);
                            }
                        });

                        if (playlist.Count > 0)
                        {
                            Playlists.Add(name, playlist);
                        }
                    });

                    PlaylistsNeedRefresh = true;
                }

                if (nsec.Exists("mostTracks"))
                {
                    byte[] tracksData = nsec.Get("mostTracks");
                    string[] tracks = System.Text.Encoding.UTF8.GetString(tracksData).Split(':', StringSplitOptions.RemoveEmptyEntries);

                    List<TrackCounter> trackList = new List<TrackCounter>();
                    tracks.ForEach(track =>
                    {
                        TrackCounter counter = TrackCounter.FromString(track);

                        if (counter != null && File.Exists(counter.Media.FilePath) && trackList.Count < MAXTRACKSINLASTLIST)
                        {

                            trackList.Add(counter);
                        }
                    });

                    trackList = trackList.OrderByDescending(o => o.Count).ToList();
                    MostTracks = trackList.ToArray();
                }

                if (nsec.Exists("lastTracks"))
                {
                    byte[] tracksData = nsec.Get("lastTracks");
                    string[] tracks = System.Text.Encoding.UTF8.GetString(tracksData).Split(':', StringSplitOptions.RemoveEmptyEntries);

                    List<TrackCounter> trackList = new List<TrackCounter>();
                    tracks.ForEach(track =>
                    {
                        TrackCounter counter = TrackCounter.FromString(track);

                        if (counter != null && File.Exists(counter.Media.FilePath) && trackList.Count < MAXTRACKSINLASTLIST)
                        {
                            trackList.Add(counter);
                        }
                    });

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

                    historyElems.ForEach(elem =>
                    {
                        string[] text = elem.Split(SEPARATOR);
                        if (text.Length >= 2 && History.FindIndex(model => model.Text == text[1]) == -1)
                            History.Add(new HistoryModel() { Text = text[1] });
                    });
                }

                if(nsec.Exists("includedPaths"))
                {
                    byte[] pathData = nsec.Get("includedPaths");
                    string[] paths = System.Text.Encoding.UTF8.GetString(pathData).Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    paths.ForEach(item =>
                    {
                        if (Directory.Exists(item) && !IncludedPaths.Contains(item))
                            IncludedPaths.Add(item);
                    });
                }

                if(nsec.Exists("webPlaylists"))
                {
                    byte[] pathData = nsec.Get("webPlaylists");
                    string[] elems = System.Text.Encoding.UTF8.GetString(pathData).Split('\n', StringSplitOptions.RemoveEmptyEntries);

                    WebToLocalPlaylists.Clear();
                    elems.ForEach(item =>
                    {
                        string[] datas = item.Split(SEPARATOR);
                        WebToLocalPlaylists.Add(datas[0], datas[1]);
                    });
                }

                if (nsec.Exists("autoDownload"))
                {
                    byte[] autoDownload = nsec.Get("autoDownload");
                    AutoDownload = System.Text.Encoding.UTF8.GetString(autoDownload) == "true";
                }

                if(nsec.Exists("ignoreAutoFocus"))
                {
                    byte[] ignoreAutoFocus = nsec.Get("ignoreAutoFocus");
                    IgnoreAutoFocus = System.Text.Encoding.UTF8.GetString(ignoreAutoFocus) == "true";
                }

                nsec.Dispose();
            }
        }

        public void SaveConfig()
        {
            NSEC2 nsec = new NSEC2(NSEC_HASH);

            string buffer = MediaPlayer.GetVolume().ToString();

            nsec.AddFile("volume", System.Text.Encoding.ASCII.GetBytes(buffer));
            if (CurrentLanguage != null)
                nsec.AddFile("language", System.Text.Encoding.ASCII.GetBytes(CurrentLanguage));


            buffer = "";

            if (Playlists.Count > 0)
            {

                Playlists.Keys.ForEach(playlistName =>
                {
                    List<string> playlist = Playlists[playlistName];

                    if (playlist.Count > 0)
                    {
                        string playlistItem = playlistName + SEPARATOR;


                        playlist.ForEach(item =>
                        {
                            playlistItem += item + ';';
                        });

                        buffer += playlistItem + '\n';
                    }
                });
                nsec.AddFile("playlists", System.Text.Encoding.UTF8.GetBytes(buffer));

                buffer = "";

                WebToLocalPlaylists.Keys.ForEach(playlistId =>
                {
                    string elem = string.Concat(playlistId, SEPARATOR, WebToLocalPlaylists[playlistId],"\n");
                    buffer += elem;
                });

                nsec.AddFile("webPlaylists", System.Text.Encoding.UTF8.GetBytes(buffer));
            }

            int playerMode = (int)PlayerMode;
            buffer = playerMode.ToString();
            nsec.AddFile("playerMode", System.Text.Encoding.UTF8.GetBytes(buffer));
            buffer = "";

            MostTracks.ForEach(counter =>
            {
                if (counter != null)
                    buffer += counter.ToString() + ":";
            });

            nsec.AddFile("mostTracks", System.Text.Encoding.UTF8.GetBytes(buffer));

            buffer = "";

            LastTracks.ForEach(counter =>
            {
                if (counter != null)
                    buffer += counter.ToString() + ":";
            });

            nsec.AddFile("lastTracks", System.Text.Encoding.UTF8.GetBytes(buffer));

            if (History.Count > 0)
            {
                buffer = "";

                History.ForEach(model =>
                {
                    buffer += "yt" + SEPARATOR + model.Text + "\n";
                });

                nsec.AddFile("history", System.Text.Encoding.UTF8.GetBytes(buffer));
            }

            if(IncludedPaths.Count > IncludedPathsToSkip)
            {
                buffer = "";

                IncludedPaths.Skip(IncludedPathsToSkip).ForEach(elem =>
                {
                    buffer += elem + "\n";
                });

                nsec.AddFile("includedPaths", System.Text.Encoding.UTF8.GetBytes(buffer));
            }

            nsec.AddFile("autoDownload", System.Text.Encoding.UTF8.GetBytes(AutoDownload ? "true" : "false"));

            nsec.AddFile("ignoreAutoFocus", System.Text.Encoding.UTF8.GetBytes(IgnoreAutoFocus ? "true" : "false"));

            File.WriteAllBytes(DataPath + "/newtone.nsec2", nsec.Save());

            nsec.Dispose();
        }

        public void SaveTags()
        {
            if (AudioTags.Count > 0)
            {
                NSEC2 nsec = new NSEC2(NSEC_HASH);
                nsec.SetDebug(false);

                int counter = 0;
                string buffer = "";

                AudioTags.Keys.ForEach(filepath =>
                {
                    MediaSourceTag mediaSource = AudioTags[filepath];

                    string name = "image" + counter;
                    nsec.AddFile(name, mediaSource.Image ?? (new byte[0]));

                    string bufferItem = filepath + SEPARATOR + mediaSource.Author + SEPARATOR + mediaSource.Title + SEPARATOR + name;

                    bufferItem += SEPARATOR + mediaSource.Id;

                    if(mediaSource.TempDuration == null)
                    {
                        bufferItem += SEPARATOR + "0";
                    }
                    else
                    {
                        bufferItem += SEPARATOR + mediaSource.TempDuration.TotalMilliseconds;
                    }

                    bufferItem += "\n";
                    buffer += bufferItem;
                    counter += 1;
                });

                nsec.AddFile("data", System.Text.Encoding.UTF8.GetBytes(buffer));

                File.WriteAllBytes(DataPath + "/newtoneTags.nsec2", nsec.Save());
            }
        }

        public void LoadTags()
        {
            
            if (File.Exists(DataPath + "/newtoneTags.nsec2"))
            {
                AudioTags.Clear();
                FileStream fileStream = File.OpenRead(DataPath + "/newtoneTags.nsec2");
                NSEC2 nsec = new NSEC2(NSEC_HASH);
                nsec.Load(fileStream);
                nsec.SetDebug(false);

                string[] tags = System.Text.Encoding.UTF8.GetString(nsec.Get(nsec.Exists("data") ? "data" : "tags")).Split('\n', StringSplitOptions.RemoveEmptyEntries);
                tags.ForEach(tagItem =>
                {
                    string[] values = tagItem.Split(SEPARATOR);
                    Debug.WriteLine("Load tags for " + values[0]);

                    MediaSourceTag tag = new MediaSourceTag()
                    {
                        Author = values[1],
                        Title = values[2],
                        Id = values.Length > 4 ? values[4] : null,
                        TempDuration = values.Length > 5 ? TimeSpan.FromMilliseconds(double.Parse(values[5])) : TimeSpan.Zero
                    };

                    nsec.TryGet(values[3], out byte[] data);
                    tag.Image = data;

                    if (values.Length > 4 && !DownloadedIds.Contains(values[4]) && File.Exists(values[0]))
                        DownloadedIds.Add(values[4]);
  
                    AudioTags.Add(values[0], tag);
                });

                nsec.Dispose();
            }
        }

        public void SaveSavedTracks()
        {
            if(SavedTracks.Count > 0)
            {
                NSEC2 nsec = new NSEC2(NSEC_HASH);
                nsec.SetDebug(false);

                int counter = 0;
                StringBuilder buffer = new StringBuilder();

                SavedTracks.ForEach(keypair =>
                {
                    string imageName = "image" + counter;
                    nsec.AddFile(imageName, keypair.Value.Image ?? new byte[0]);
                    buffer.AppendLine(keypair.Key + SEPARATOR + keypair.Value.Artist + SEPARATOR + keypair.Value.Title+SEPARATOR+imageName);
                    counter++;
                });

                nsec.AddFile("data", Encoding.UTF8.GetBytes(buffer.ToString()));
                File.WriteAllBytes(DataPath + "/newtoneSavedTracks.nsec2", nsec.Save());
                nsec.Dispose();
            }
        }

        public void LoadSavedTracks()
        {
            if(File.Exists(DataPath+"/newtoneSavedTracks.nsec2"))
            {
                NSEC2 nsec = new NSEC2(NSEC_HASH);
                nsec.SetDebug(false);
                nsec.Load(File.OpenRead(DataPath + "/newtoneSavedTracks.nsec2"));
                byte[] bufferData = nsec.Get("data");
                string[] data = Encoding.UTF8.GetString(bufferData).Split('\n', StringSplitOptions.RemoveEmptyEntries);

                foreach(var dataLine in data)
                {
                    string[] elems = dataLine.Split(SEPARATOR);
                    MediaSource newSource = new MediaSource()
                    {
                        FilePath = elems[0],
                        Artist = elems[1],
                        Title = elems[2]
                    };

                    if(nsec.TryGet(elems[3], out byte[] imageData))
                    {
                        newSource.Image = imageData;
                    }

                    SavedTracks.Add(elems[0], newSource);
                }

                nsec.Dispose();
            }
        }
        #endregion
    }
}
