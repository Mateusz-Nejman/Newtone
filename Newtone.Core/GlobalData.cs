using Nejman.NSEC2;
using Newtone.Core.Languages;
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
        public Dictionary<string, MediaSourceTag> AudioTags { get; set; }
        public List<string> DownloadedIds { get; set; }
        public Dictionary<string, List<string>> Artists { get; set; }
        public Dictionary<string, List<string>> Playlists { get; set; }
        public Dictionary<string, string> WebToLocalPlaylists { get; set; }
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

        public AsyncEndController AsyncEndController { get; } = new AsyncEndController();

        public List<string> ExcludedPaths { get; set; }
        public List<string> IncludedPaths { get; set; }
        public string CurrentLanguage { get; set; }
        public MessageGenerator Messenger { get; set; }
        public bool ArtistsNeedRefresh { get; set; }
        public bool PlaylistsNeedRefresh { get; set; }
        public bool HistoryNeedRefresh { get; set; }
        public int IncludedPathsToSkip { get; set; }
        #endregion
        #region Public Methods
        public void Initialize()
        {
            Artists = new Dictionary<string, List<string>>();
            Audios = new Dictionary<string, Newtone.Core.Media.MediaSource>();
            AudioTags = new Dictionary<string, MediaSourceTag>();
            DownloadedIds = new List<string>();
            CurrentPlaylist = new List<Newtone.Core.Media.MediaSource>();
            WebToLocalPlaylists = new Dictionary<string, string>();
            DataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);

            History = new List<Newtone.Core.Models.HistoryModel>();
            LastTracks = new Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST];
            MostTracks = new Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST];

            PlayerMode = PlayerMode.All;
            Playlists = new Dictionary<string, List<string>>();

            ExcludedPaths = new List<string>();
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
                            if (File.Exists(filepath))
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
                    byte[] playerModeData = nsec.Get("autoDownload");
                    AutoDownload = System.Text.Encoding.UTF8.GetString(playerModeData) == "true";
                }

                if (!AudioFromIntent)
                {
                    int playlistPosition = 0;

                    if (nsec.Exists("playlistPosition"))
                    {
                        byte[] playlistPositionData = nsec.Get("playlistPosition");
                        string playlistPositionBuffer = System.Text.Encoding.ASCII.GetString(playlistPositionData);
                        playlistPosition = int.Parse(playlistPositionBuffer);
                    }

                    if (nsec.Exists("playlist"))
                    {
                        byte[] playlistData = nsec.Get("playlist");
                        string[] files = System.Text.Encoding.UTF8.GetString(playlistData).Split(':', StringSplitOptions.RemoveEmptyEntries);

                        CurrentPlaylist = new List<MediaSource>();

                        if (playlistPosition < files.Length && Audios.ContainsKey(files[playlistPosition]))
                        {
                            PlaylistPosition = playlistPosition;
                            MediaSource = Audios[files[playlistPosition]];
                            MediaPlayer.Load(files[playlistPosition]);
                        }

                        files.ForEach(filepath =>
                        {
                            if (File.Exists(filepath) && Audios.ContainsKey(filepath))
                            {
                                CurrentPlaylist.Add(Audios[filepath]);
                            }
                        });
                    }
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

            nsec.AddFile("playlistPosition", System.Text.Encoding.ASCII.GetBytes(PlaylistPosition.ToString()));

            if (CurrentPlaylist.Count > 0)
            {
                buffer = "";

                CurrentPlaylist.ForEach(mediaSource =>
                {
                    string item = mediaSource.FilePath;
                    buffer += item + ';';
                });
                nsec.AddFile("playlist", System.Text.Encoding.UTF8.GetBytes(buffer));
            }
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

                    if (!string.IsNullOrWhiteSpace(mediaSource.Id))
                        bufferItem += SEPARATOR + mediaSource.Id;

                    bufferItem += "\n";
                    buffer += bufferItem;
                    counter += 1;
                });

                nsec.AddFile("tags", System.Text.Encoding.UTF8.GetBytes(buffer));

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

                string[] tags = System.Text.Encoding.UTF8.GetString(nsec.Get("tags")).Split('\n', StringSplitOptions.RemoveEmptyEntries);
                tags.ForEach(tagItem =>
                {
                    string[] values = tagItem.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

                    MediaSourceTag tag = new MediaSourceTag()
                    {
                        Author = values[1],
                        Title = values[2],
                        Image = nsec.Get(values[3]).Length > 0 ? nsec.Get(values[3]) : null,
                        Id = values.Length > 4 ? values[4] : null
                    };

                    if (values.Length > 4 && !DownloadedIds.Contains(values[4]) && File.Exists(values[0]))
                        DownloadedIds.Add(values[4]);
  
                    AudioTags.Add(values[0], tag);
                });

                nsec.Dispose();
            }
        }
        #endregion
    }
}
