using Nejman.Newtone.Core.Data;
using Nejman.Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using NSEC = Nejman.NSEC2.NSEC2;

namespace Nejman.Newtone.Core.IO
{
    internal class DataFile
    {
        public const string SEPARATOR = "[NSEC2_SEPARATOR]";
        private static bool blockSave = false;
        private static bool blockLoad = false;
        public static void Save()
        {
            if(blockSave)
            {
                return;
            }

            blockSave = true;
            Directory.CreateDirectory(CoreGlobal.DataPath);
            NSEC nsec = new NSEC("gruby idzie");
            string buffer = "";

            if (CoreGlobal.CurrentLanguage != null)
                nsec.AddFile("language", System.Text.Encoding.ASCII.GetBytes(CoreGlobal.CurrentLanguage));

            if (PlaylistsAction.GetPlaylists().Count > 0)
            {
                PlaylistsAction.GetPlaylists().ForEach(playlistModel =>
                {
                    var playlistName = playlistModel.Name;
                    var playlist = PlaylistsAction.GetPlaylist(playlistName);

                    if (playlist.Count > 0)
                    {
                        string playlistItem = playlistName + SEPARATOR;


                        playlist.ForEach(item =>
                        {
                            playlistItem += item.Path + ';';
                        });

                        buffer += playlistItem + '\n';
                    }
                });
                nsec.AddFile("playlists", System.Text.Encoding.UTF8.GetBytes(buffer));

                buffer = "";
            }

            int playerMode = (int)CoreGlobal.PlaybackMode;
            buffer = playerMode.ToString();
            nsec.AddFile("playerMode", System.Text.Encoding.UTF8.GetBytes(buffer));
            buffer = "";

            if (CoreGlobal.History.Count > 0)
            {
                buffer = "";

                CoreGlobal.History.ForEach(model =>
                {
                    buffer += "yt" + SEPARATOR + model + "\n";
                });

                nsec.AddFile("history", System.Text.Encoding.UTF8.GetBytes(buffer));
            }

            if (CoreGlobal.IncludedPaths.Count > CoreGlobal.IncludedPathsToSkip)
            {
                buffer = "";

                CoreGlobal.IncludedPaths.Skip(CoreGlobal.IncludedPathsToSkip).ForEach(elem =>
                {
                    buffer += elem + "\n";
                });

                nsec.AddFile("includedPaths", System.Text.Encoding.UTF8.GetBytes(buffer));
            }

            File.WriteAllBytes(CoreGlobal.DataPath + "/newtone.nsec2", nsec.Save());
            File.Copy(CoreGlobal.DataPath + "/newtone.nsec2", CoreGlobal.DataPath + "/newtoneCopy.nsec2", true);

            nsec.Dispose();
            blockSave = false;
        }

        public static void Load()
        {
            if(blockLoad)
            {
                return;
            }

            blockLoad = true;
            Directory.CreateDirectory(CoreGlobal.MusicPath);
            if (File.Exists(CoreGlobal.DataPath + "/newtone.nsec2"))
            {
                FileInfo configInfo = new FileInfo(CoreGlobal.DataPath + "/newtone.nsec2");
                if (configInfo.Length == 0 && File.Exists(CoreGlobal.DataPath + "/newtoneCopy.nsec2"))
                {
                    File.Copy(CoreGlobal.DataPath + "/newtoneCopy.nsec2", CoreGlobal.DataPath + "/newtone.nsec2", true);
                }

                FileStream stream = File.OpenRead(CoreGlobal.DataPath + "/newtone.nsec2");
                NSEC nsec = new NSEC("gruby idzie");
                nsec.Load(stream);
                if (nsec.Exists("language"))
                {
                    CoreGlobal.CurrentLanguage = System.Text.Encoding.ASCII.GetString(nsec.Get("language"));
                    Localization.Localization.RefreshLanguage();
                }

                if (nsec.Exists("playlists"))
                {
                    string buffer = System.Text.Encoding.UTF8.GetString(nsec.Get("playlists"));
                    string[] playlists = buffer.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    playlists.ForEach(playlistBuffer =>
                    {
                        List<string> playlist = new List<string>();
                        string[] parts = playlistBuffer.Split(new[] { SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);
                        string name = parts[0];
                        string[] items = parts[1].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                        items.ForEach(filepath =>
                        {
                            if (File.Exists(filepath) || filepath.Length == 11)
                            {
                                playlist.Add(filepath);
                            }
                        });

                        if (playlist.Count > 0)
                        {
                            PlaylistsAction.Add(name, playlist, false);
                        }
                    });

                    CoreGlobal.PlaylistsRefresh.OnNext("");
                }

                if (nsec.Exists("playerMode"))
                {
                    byte[] playerModeData = nsec.Get("playerMode");
                    int playerMode = int.Parse(System.Text.Encoding.UTF8.GetString(playerModeData));
                    CoreGlobal.PlaybackMode = (PlaybackMode)playerMode;
                }

                if (nsec.Exists("history"))
                {
                    byte[] historyData = nsec.Get("history");
                    string[] historyElems = System.Text.Encoding.UTF8.GetString(historyData).Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    CoreGlobal.History.Clear();

                    historyElems.ForEach(elem =>
                    {
                        string[] text = elem.Split(new[] { SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);
                        if (text.Length >= 2 && CoreGlobal.History.FindIndex(model => model == text[1]) == -1)
                            CoreGlobal.History.Add(text[1]);
                    });
                }

                if (nsec.Exists("includedPaths"))
                {
                    byte[] pathData = nsec.Get("includedPaths");
                    string[] paths = System.Text.Encoding.UTF8.GetString(pathData).Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    paths.ForEach(item =>
                    {
                        if (Directory.Exists(item) && !CoreGlobal.IncludedPaths.Contains(item))
                            CoreGlobal.IncludedPaths.Add(item);
                    });
                }

                nsec.Dispose();
            }

            blockLoad = false;
        }

        public static void SaveTags()
        {
            if (CoreGlobal.AudioTags.Count > 0)
            {
                NSEC nsec = new NSEC("gruby idzie");
                nsec.SetDebug(false);

                int counter = 0;
                string buffer = "";

                CoreGlobal.AudioTags.Keys.ForEach(filepath =>
                {
                    MediaSourceTag mediaSource = CoreGlobal.AudioTags[filepath];

                    string name = "image" + counter;
                    nsec.AddFile(name, mediaSource.Image ?? (new byte[0]));

                    string bufferItem = filepath + SEPARATOR + mediaSource.Author + SEPARATOR + mediaSource.Title + SEPARATOR + name;

                    bufferItem += SEPARATOR + mediaSource.Id;

                    if (mediaSource.TempDuration == null)
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

                File.WriteAllBytes(CoreGlobal.DataPath + "/newtoneTags.nsec2", nsec.Save());
            }
        }

        public static void LoadTags()
        {

            if (File.Exists(CoreGlobal.DataPath + "/newtoneTags.nsec2"))
            {
                CoreGlobal.AudioTags.Clear();
                FileStream fileStream = File.OpenRead(CoreGlobal.DataPath + "/newtoneTags.nsec2");
                NSEC nsec = new NSEC("gruby idzie");
                nsec.Load(fileStream);
                nsec.SetDebug(false);

                string[] tags = System.Text.Encoding.UTF8.GetString(nsec.Get(nsec.Exists("data") ? "data" : "tags")).Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                tags.ForEach(tagItem =>
                {
                    string[] values = tagItem.Split(new[] { SEPARATOR }, StringSplitOptions.None);

                    MediaSourceTag tag = new MediaSourceTag()
                    {
                        Author = values[1],
                        Title = values[2],
                        Id = values.Length > 4 ? values[4] : null,
                        TempDuration = values.Length > 5 ? TimeSpan.FromMilliseconds(double.Parse(values[5])) : TimeSpan.Zero
                    };

                    nsec.TryGet(values[3], out byte[] data);
                    tag.Image = data;

                    if (values.Length > 4 && !CoreGlobal.DownloadedIds.Contains(values[4]) && File.Exists(values[0]))
                        CoreGlobal.DownloadedIds.Add(values[4]);

                    CoreGlobal.AudioTags.Add(values[0], tag);
                });

                nsec.Dispose();
            }
        }
    }
}
