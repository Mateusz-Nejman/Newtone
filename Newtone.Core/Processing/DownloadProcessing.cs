using Newtone.Core.Languages;
using Newtone.Core.Loaders;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Newtone.Core.Processing
{
    public static class DownloadProcessing
    {
        #region Fields
        private static Task downloadTask;
        #endregion
        #region Properties
        public static Dictionary<string, DownloadModel> Downloads { get; } = new Dictionary<string, DownloadModel>();

        public static int BadgeCount
        {
            get
            {
                return Downloads.Count;
            }
        }
        #endregion
        #region Public Methods
        public static IEnumerable<DownloadModel> GetModels()
        {
            return Downloads.Values;
        }

        public static Dictionary<string, DownloadModel> GetDownloads()
        {
            return Downloads;
        }

        public static void AddRange(IEnumerable<Video> playlist, string playlistName, string playlistId, bool withRemove = false)
        {
            Debug.WriteLine("Add range " + playlistName + " " + playlistId);

            string currentItem = null;

            if (playlistId != "")
            {
                if (!GlobalData.Current.WebToLocalPlaylists.ContainsKey(playlistId))
                {
                    GlobalData.Current.WebToLocalPlaylists.Add(playlistId, playlistName);
                }
                else
                {
                    GlobalData.Current.WebToLocalPlaylists[playlistId] = playlistName;
                }
            }

            GlobalData.Current.SaveConfig();
            foreach (var video in playlist)
            {
                if(Downloads.ContainsKey(video.Id))
                {
                    currentItem = video.Id;
                }
                else
                {
                    if(GlobalData.Current.DownloadedIds.Contains(video.Id))
                    {
                        string filename = "";

                        GlobalData.Current.AudioTags.Keys.ForEach(key =>
                        {
                            var item = GlobalData.Current.AudioTags[key];
                            if (item.Id == video.Id)
                                filename = key;
                        });

                        if(currentItem == null)
                        {
                            if (!string.IsNullOrWhiteSpace(playlistName))
                            {
                                if (!GlobalData.Current.Playlists.ContainsKey(playlistName))
                                    GlobalData.Current.Playlists.Add(playlistName, new List<string>());

                                if (!GlobalData.Current.Playlists[playlistName].Contains(filename) && !string.IsNullOrWhiteSpace(filename))
                                {
                                    GlobalData.Current.Playlists[playlistName].Add(filename);
                                    GlobalData.Current.SaveConfig();
                                }
                            }
                        }
                        else
                        {
                            if(!Downloads[currentItem].TracksToAddAfterDownload.ContainsKey(playlistName))
                            {
                                Downloads[currentItem].TracksToAddAfterDownload.Add(playlistName, filename);
                            }
                        }
                    }
                    else
                    {
                        Downloads.Add(video.Id, new DownloadModel()
                        {
                            Id = video.Id,
                            Url = video.Url,
                            Title = video.Title,
                            PlaylistName = playlistName,
                            Progress = 0.0,
                            PlaylistID = playlistId
                        });

                        currentItem = video.Id;

                        if (downloadTask == null)
                        {
                            downloadTask = new Task(async () => await TaskAction());
                            downloadTask.Start();
                        }
                    }
                }
            }

            if(withRemove && GlobalData.Current.Playlists.ContainsKey(playlistName))
            {
                List<string> ids = playlist.Select(item => item.Id.ToString()).ToList();
                
                foreach(var path in GlobalData.Current.Playlists[playlistName].ToList())
                {
                    if(GlobalData.Current.AudioTags.ContainsKey(path) && !ids.Contains(GlobalData.Current.AudioTags[path].Id))
                    {
                        GlobalData.Current.Playlists[playlistName].Remove(path);
                    }
                }

                GlobalData.Current.SaveConfig();
            }
        }

        public static void Add(string id, string title, string url, string playlist, string playlistId = "")
        {
            Debug.WriteLine("Add " + id + " " + title);
            if (id == "")
                YoutubeExplodeExtensions.TryParseVideoId(url, out id);

            if(!Downloads.ContainsKey(id))
            {
                if(GlobalData.Current.DownloadedIds.Contains(id))
                {
                    string filename = "";

                    GlobalData.Current.AudioTags.Keys.ForEach(key =>
                    {
                        var item = GlobalData.Current.AudioTags[key];
                        if (item.Id == id)
                            filename = key;
                    });

                    if (!string.IsNullOrWhiteSpace(playlist))
                    {
                        if (!GlobalData.Current.Playlists.ContainsKey(playlist))
                            GlobalData.Current.Playlists.Add(playlist, new List<string>());

                        if (!GlobalData.Current.Playlists[playlist].Contains(filename) && !string.IsNullOrWhiteSpace(filename))
                        {
                            GlobalData.Current.Playlists[playlist].Add(filename);
                            GlobalData.Current.SaveConfig();
                        }
                    }
                }
                else
                {
                    Downloads.Add(id, new DownloadModel()
                    {
                        Id = id,
                        Url = url,
                        Title = title,
                        PlaylistName = playlist,
                        Progress = 0.0,
                        PlaylistID = playlistId
                    });

                    if (downloadTask == null)
                    {
                        downloadTask = new Task(async () => await TaskAction());
                        downloadTask.Start();
                    }
                }
                
            }
        }
        #endregion
        #region Private Methods

        private static void SetProgress(string id, double progress)
        {
            if(Downloads.ContainsKey(id))
            {
                Downloads[id].Progress = progress;
            }
        }
        private async static Task TaskAction()
        {
            string currentId = "";
            try
            {
                if (Downloads.Keys.Count > 0)
                {
                    string id = Downloads.Keys.First();
                    currentId = id;
                    DownloadModel model = Downloads[id];
                    string filename = await Download(id);

                    GlobalLoader.ReplaceSavedTrack(id, filename);

                    if (!string.IsNullOrWhiteSpace(model.PlaylistName))
                    {
                        if (!GlobalData.Current.Playlists.ContainsKey(model.PlaylistName))
                            GlobalData.Current.Playlists.Add(model.PlaylistName, new List<string>());

                        if (!GlobalData.Current.Playlists[model.PlaylistName].Contains(filename))
                        {
                            GlobalData.Current.Playlists[model.PlaylistName].Add(filename);

                            foreach (var key in model.TracksToAddAfterDownload.Keys)
                            {
                                GlobalData.Current.Playlists[key].Add(model.TracksToAddAfterDownload[key]);
                            }
                        }

                        if (model.PlaylistID != "")
                        {
                            if (!GlobalData.Current.WebToLocalPlaylists.ContainsKey(model.PlaylistID))
                            {
                                GlobalData.Current.WebToLocalPlaylists.Add(model.PlaylistID, model.PlaylistName);
                            }
                            else
                            {
                                GlobalData.Current.WebToLocalPlaylists[model.PlaylistID] = model.PlaylistName;
                            }
                        }

                        GlobalData.Current.SaveConfig();
                        GlobalData.Current.PlaylistsNeedRefresh = true;
                    }
                    Downloads.Remove(id);
                }
            }
            catch (Exception)
            {
                GlobalData.Current.Messenger.Show(MessageGenerator.EMessageType.Error, Localization.YoutubeError);
                Downloads.Remove(currentId);
            }

            if (Downloads.Count > 0)
                await TaskAction();
            else
                downloadTask = null;
        }
        private static async Task<string> Download(string id)
        {
            
            YoutubeClient client = new YoutubeClient();
            Video video = await client.Videos.GetAsync(id);
            if (Downloads[id].Title == "")
                Downloads[id].Title = video.Title;
            StreamManifest manifest = await client.Videos.Streams.GetManifestAsync(id);

            Progress<double> progress = new Progress<double>(value =>
            {
                SetProgress(id, value);
            });


            string fileName = video.Title
                .Replace('/', '_').
                Replace('\\', '_').
                Replace(':', '_').
                Replace('*', '_').
                Replace('"', '_').
                Replace('<', '_').
                Replace('>', '_').
                Replace('|', '_');
            FileInfo fileInfo = new FileInfo(Path.Combine(GlobalData.Current.MusicPath, fileName + (GlobalData.Current.MediaFormat == MediaFormat.m4a ? ".m4a" : ".opus")));

            if (GlobalData.Current.DownloadedIds.Contains(id))
                return fileInfo.FullName;

            IStreamInfo streamInfo = null;

            manifest.GetAudio().ForEach(item =>
            {
                Console.WriteLine(item.AudioCodec);
                if (item.AudioCodec.Contains(GlobalData.Current.MediaFormat == MediaFormat.m4a ? "mp4a" : "opus"))
                {
                    if (streamInfo == null)
                        streamInfo = item;

                    if (streamInfo.Bitrate.BitsPerSecond > item.Bitrate.BitsPerSecond)
                        streamInfo = item;
                }
            });
            await client.Videos.Streams.DownloadAsync(streamInfo, Path.Combine(GlobalData.Current.MusicPath, fileName + (GlobalData.Current.MediaFormat == MediaFormat.m4a ? ".m4a" : ".opus")), progress);
            string[] splitted = video.Title.Split(new string[] { " - ", " – ", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries);
            string artist = splitted.Length == 1 ? video.Author : splitted[0];
            string title = splitted[splitted.Length == 1 ? 0 : 1];

            byte[] picture = null;
            try
            {
                using WebClient wc = new WebClient();
                picture = wc.DownloadData(video.Thumbnails.MediumResUrl);
            }
            catch
            {
                //If can't download image, ignore
            }

            if (GlobalData.Current.AudioTags.ContainsKey(fileInfo.FullName))
            {
                string f = fileInfo.FullName;
                GlobalData.Current.AudioTags[f].Author = artist;
                GlobalData.Current.AudioTags[f].Title = title;
                GlobalData.Current.AudioTags[f].Image = picture;
                GlobalData.Current.AudioTags[f].Id = video.Id;

                GlobalData.Current.AudioTags[f].TempDuration = GlobalData.Current.MediaFormat == MediaFormat.m4a ? TimeSpan.FromMilliseconds(0) : video.Duration;
            }
            else
            {
                GlobalData.Current.AudioTags.Add(fileInfo.FullName, new MediaSourceTag() { Author = artist, Title = title, Image = picture, Id = video.Id, TempDuration = GlobalData.Current.MediaFormat == MediaFormat.ogg ? video.Duration : TimeSpan.FromMilliseconds(0) });
            }

            MediaSource container = MediaProcessing.GetSource(fileInfo.FullName);
            GlobalLoader.AddTrack(container);
            CacheLoader.SaveCache();
            GlobalData.Current.SaveConfig();
            GlobalData.Current.SaveTags();
            GlobalData.Current.Messenger.Show(MessageGenerator.EMessageType.Snackbar, Localization.FileDownloaded + " " + artist + " - " + title);

            return fileInfo.FullName;
        }
        #endregion
    }
}
