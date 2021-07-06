using Nejman.Newtone.Core.Exceptions;
using Nejman.Newtone.Core.External;
using Nejman.Newtone.Core.Implementations;
using Nejman.Newtone.Core.IO;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nejman.Newtone.Core.Data
{
    public static class DownloadAction
    {
        private static Task downloadTask;
        public static IEnumerable<DownloadModel> Get()
        {
            return CoreGlobal.Downloads.Values;
        }

        public static int GetBadgeCount()
        {
            return CoreGlobal.Downloads.Count;
        }

        public static double GetProgress(string name)
        {
            if(!CoreGlobal.Downloads.ContainsKey(name))
            {
                return 0;
            }

            return CoreGlobal.Downloads[name].Progress;
        }

        public async static Task Add(string elementsBuffer)
        {
            string[] elements = elementsBuffer.Split(new[] { CoreGlobal.SEPARATOR }, StringSplitOptions.None);
            var urlType = YoutubeExplodeIntegration.CheckLink(elements[1]);
            var playlistId = "";
            var playlistName = "";
            ObservableBridge<MediaSource> playlistItems = new ObservableBridge<MediaSource>();

            if (urlType.ContainsKey(YoutubeExplodeIntegration.Query.Playlist) && urlType.ContainsKey(YoutubeExplodeIntegration.Query.Video))
            {
                if(await MessageImplementation.Current.Show(Localization.Localization.Question,Localization.Localization.PlaylistOrTrack,Localization.Localization.Track, Localization.Localization.Playlist) == Localization.Localization.Track)
                {
                    playlistId = "";
                }
                else
                {
                    playlistId = urlType[YoutubeExplodeIntegration.Query.Playlist];

                    if(await MessageImplementation.Current.Show(Localization.Localization.Question,Localization.Localization.PlaylistDownload,Localization.Localization.Yes,Localization.Localization.No) == Localization.Localization.Yes)
                    {
                        var playlist = await YoutubeExplodeIntegration.GetPlaylistName(playlistId);
                        var newPlaylistName = await PlaylistsAction.SelectPlaylist(playlist);
                        playlistName = string.IsNullOrWhiteSpace(newPlaylistName) ? "" : newPlaylistName;
                        await YoutubeExplodeIntegration.Search("https://www.youtube.com/playlist?list=" + playlistId, playlistItems);
                    }
                }
            }

            if(playlistId == "")
            {
                Add(elements[1], elements[0], elements[1], "", "");
            }
            else
            {
                Add(playlistItems.GetItems(), playlistName, playlistId);
            }
        }

        public static void Add(IEnumerable<MediaSource> models, string playlist, string playlistId)
        {
            foreach(var model in models)
            {
                Add(model.ID, model.Title, model.Path, playlist, playlistId);
            }
        }

        public static void Add(string id, string title, string url, string playlist, string playlistId)
        {
            if(CoreGlobal.Downloads.ContainsKey(id))
            {
                return;
            }

            if(CoreGlobal.DownloadedIds.Contains(id))
            {
                string filename = "";

                CoreGlobal.AudioTags.Keys.ForEach(key =>
                {
                    var item = CoreGlobal.AudioTags[key];

                    if(item.Id == id)
                    {
                        filename = key;
                    }
                });

                if(!string.IsNullOrWhiteSpace(playlist))
                {
                    Playlists.Add(playlist, filename);
                }

                return;
            }

            CoreGlobal.Downloads.Add(id, new DownloadModel()
            {
                Id = id,
                Url = url,
                Title = title,
                PlaylistName = playlist,
                Progress = 0,
                PlaylistID = playlistId
            });

            if(downloadTask == null)
            {
                downloadTask = Task.Run(async () => await TaskAction());
            }
        }

        private async static Task TaskAction()
        {
            if (CoreGlobal.Downloads.Count == 0)
            {
                downloadTask = null;
                return;
            }
            string currentId = "";

            try
            {
                string id = CoreGlobal.Downloads.Keys.First();
                currentId = id;
                var model = CoreGlobal.Downloads[id];

                string filename = await Download(id);

                if(!string.IsNullOrWhiteSpace(model.PlaylistName))
                {
                    Playlists.Add(model.PlaylistName, filename);
                }

                CoreGlobal.Downloads.Remove(id);
            }
            catch(Exception e)
            {
                await MessageImplementation.Current.Show(Localization.Localization.Warning, e.Message, "", Localization.Localization.Cancel);
                CoreGlobal.Downloads.Remove(currentId);
            }

            await TaskAction();
        }

        private async static Task<string> Download(string id)
        {
            var mediaSource = await YoutubeExplodeIntegration.GetVideo(id);

            string fileName = mediaSource.Title
                .Replace('/', '_').
                Replace('\\', '_').
                Replace(':', '_').
                Replace('*', '_').
                Replace('"', '_').
                Replace('<', '_').
                Replace('>', '_').
                Replace('|', '_');
            FileInfo fileInfo = new FileInfo(Path.Combine(CoreGlobal.MusicPath, fileName + (CoreGlobal.MediaFormat == MediaFormat.m4a ? ".m4a" : ".opus")));

            if(CoreGlobal.DownloadedIds.Contains(id))
            {
                return fileInfo.Name;
            }

            Progress<double> progress = new Progress<double>(value =>
            {
                SetProgress(id, value);
            });

            await YoutubeExplodeIntegration.DownloadFile(mediaSource.ID, fileInfo.FullName, progress);

            string[] splitted = mediaSource.Title.Split(new string[] { " - ", " – ", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries);
            string artist = splitted.Length == 1 ? mediaSource.Artist : splitted[0];
            string title = splitted[splitted.Length == 1 ? 0 : 1];

            byte[] image = null;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    image = wc.DownloadData(mediaSource.ImageUrl);
                }
            }
            catch
            {
                //If can't download image, ignore
            }

            if (CoreGlobal.AudioTags.ContainsKey(fileInfo.FullName))
            {
                string f = fileInfo.FullName;
                CoreGlobal.AudioTags[f].Author = artist;
                CoreGlobal.AudioTags[f].Title = title;
                CoreGlobal.AudioTags[f].Image = image;
                CoreGlobal.AudioTags[f].Id = mediaSource.ID;

                CoreGlobal.AudioTags[f].TempDuration = CoreGlobal.MediaFormat == MediaFormat.m4a ? TimeSpan.FromMilliseconds(0) : (mediaSource.Duration);
            }
            else
            {
                CoreGlobal.AudioTags.Add(fileInfo.FullName, new MediaSourceTag() { Author = artist, Title = title, Image = image, Id = mediaSource.ID, TempDuration = CoreGlobal.MediaFormat == MediaFormat.ogg ? mediaSource.Duration : TimeSpan.FromMilliseconds(0) });
            }

            MediaSource container = AudiosLoader.GetSource(fileInfo.FullName);
            Tracks.Add(container);
            DataFile.Save();
            DataFile.SaveTags();
            SnackbarImplementation.Current.Show(Localization.Localization.FileDownloaded + " " + artist + " - " + title);

            return fileInfo.FullName;

        }

        private static void SetProgress(string id, double progress)
        {
            if(CoreGlobal.Downloads.ContainsKey(id))
            {
                CoreGlobal.Downloads[id].Progress = progress;
            }
        }
    }
}
