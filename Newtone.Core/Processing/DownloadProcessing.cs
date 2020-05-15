using Newtone.Core.Loaders;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Newtone.Core.Processing
{
    public static class DownloadProcessing
    {
        private static Task downloadTask;

        public static Dictionary<string, DownloadModel> Downloads { get; } = new Dictionary<string, DownloadModel>();

        public static int BadgeCount
        {
            get
            {
                return Downloads.Count;
            }
        }

        public static IEnumerable<DownloadModel> GetModels()
        {
            return Downloads.Values;
        }

        public static Dictionary<string, DownloadModel> GetDownloads()
        {
            return Downloads;
        }

        public static void Add(string id, string title, string url, string playlist)
        {
            if (id == "")
                YoutubeExplodeExtensions.TryParseVideoId(url, out id);

            if(!Downloads.ContainsKey(id) && !GlobalData.DownloadedIds.Contains(id))
            {
                Downloads.Add(id, new DownloadModel()
                {
                    Id = id,
                    Url = url,
                    Title = title,
                    PlaylistName = playlist,
                    Progress = 0.0
                });

                if(downloadTask == null)
                {
                    downloadTask = new Task(async () => await TaskAction());
                    downloadTask.Start();
                    Console.WriteLine("Task started");
                }
            }
        }

        private static void SetProgress(string id, double progress)
        {
            if(Downloads.ContainsKey(id))
            {
                Downloads[id].Progress = progress;
            }
        }
        private async static Task TaskAction()
        {
            try
            {
                foreach(var id in Downloads.Keys.ToList())
                {
                    DownloadModel model = Downloads[id];
                    string filename = await Download(id);

                    if (!string.IsNullOrWhiteSpace(model.PlaylistName))
                    {
                        if (!GlobalData.Playlists.ContainsKey(model.PlaylistName))
                            GlobalData.Playlists.Add(model.PlaylistName, new List<string>());

                        if (!GlobalData.Playlists[model.PlaylistName].Contains(filename))
                        {
                            GlobalData.Playlists[model.PlaylistName].Add(filename);
                            GlobalData.SaveConfig();
                        }
                    }
                    Downloads.Remove(id);
                }

                if (Downloads.Count > 0)
                    await TaskAction();
                else
                    downloadTask = null;
            }
            catch(Exception e)
            {
                ConsoleDebug.WriteLine("TaskAction Error");
                ConsoleDebug.WriteLine(e);

            }
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
            FileInfo fileInfo = new FileInfo(GlobalData.MusicPath + "/" + fileName + ".m4a");

            if (GlobalData.DownloadedIds.Contains(id))
                return fileInfo.FullName;

            IStreamInfo streamInfo = null;
            foreach (var item in manifest.GetAudio())
            {
                if(item.AudioCodec.Contains("mp4a"))
                {
                    if (streamInfo == null)
                        streamInfo = item;

                    if (streamInfo.Bitrate.BitsPerSecond < item.Bitrate.BitsPerSecond)
                        streamInfo = item;
                }
                
            }
            await client.Videos.Streams.DownloadAsync(streamInfo, GlobalData.MusicPath + "/" + fileName + ".m4a", progress);
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

            }
            ConsoleDebug.WriteLine(fileInfo.FullName);
            if (GlobalData.AudioTags.ContainsKey(fileInfo.FullName))
            {
                string f = fileInfo.FullName;
                GlobalData.AudioTags[f].Author = artist;
                GlobalData.AudioTags[f].Title = title;
                GlobalData.AudioTags[f].Image = picture;
                GlobalData.AudioTags[f].Id = video.Id;
            }
            else
            {
                GlobalData.AudioTags.Add(fileInfo.FullName, new MediaSourceTag() { Author = artist, Title = title, Image = picture, Id = video.Id });
            }

            MediaSource container = MediaProcessing.GetSource(fileInfo.FullName);
            //if (container == null)
                //ConsoleDebug.WriteLine("Container null" +container.FilePath);
            GlobalLoader.AddTrack(container);
            GlobalData.SaveConfig();
            GlobalData.SaveTags();
            //CacheString.Save();
            //SnackbarBuilder.Show(Localization.Ready);
            //TODO

            return fileInfo.FullName;
        }
    }
}
