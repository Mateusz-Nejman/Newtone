using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NSEC.Music_Player.Download;
using NSEC.Music_Player.Models;
using Xamarin.Forms;

namespace NSEC.Music_Player.Processing
{
    public static class DownloadProcessing
    {
        private static Task downloadTask;
        private readonly static Dictionary<string, DownloadListModel> downloads = new Dictionary<string, DownloadListModel>();
        private static readonly IDownload YoutubeDownloadInterface = new YoutubeDownload();
        private static readonly IDownload SoundcloudDownloadInterface = new SoundcloudDownload();

        public static bool AllCompleted { get; private set; }
        public static int DownloadedFiles { get; private set; }

        public static int MaxFiles { get; private set; }
        public static int BadgeCount
        {
            get
            {
                return MaxFiles - DownloadedFiles;
            }
        }

        public static Dictionary<string, DownloadListModel> GetDownloads()
        {
            return downloads;
        }

        public static void AddToDownloadTask(string id, string title, bool youtube, string url)
        {
            AllCompleted = false;
            if (!downloads.ContainsKey(id))
                downloads.Add(id, new DownloadListModel()
                {
                    Name = title,
                    Progress = 0.0,
                    Image = youtube ? ImageSource.FromFile("YoutubeIcon.png") : ImageSource.FromFile("SoundcloudIcon.png"),
                    Downloaded = false,
                    Url = youtube ? url : id //TODO
                }); ;

            MaxFiles = downloads.Count;
            if (downloadTask == null)
            {
                downloadTask = new Task(async () => { await TaskAction(); });
                downloadTask.Start();
            }
        }

        public static void SetProgress(string id, double progress)
        {
            if (downloads.ContainsKey(id))
            {
                downloads[id].Progress = progress;
            }
        }

        public static string GetGlobalProgress()
        {
            double progress = 0.0d;
            int count = 0;

            foreach (DownloadListModel model in downloads.Values)
            {
                progress += model.Progress;
                count += 1;
            }

            return count == 0 || progress == 0.0d ? "" : string.Format("{0:0.00}", ((progress / (double)count) * 100.0)) + "%";
        }

        private async static Task TaskAction()
        {
            try
            {
                foreach (string id in downloads.Keys.ToList())
                {

                    DownloadListModel model = downloads[id];

                    await GetDownloadInterface(model.Url).Download(id, model.Url);
                    //await YoutubeProcessing.DownloadVideoId(id);
                    downloads.Remove(id);
                    DownloadedFiles += 1;

                }
            }
            catch
            {
                Console.WriteLine("TaskAction Error");
            }

            if(downloads.Count > 0)
            {
                await TaskAction();
            }
            else
            {
                DownloadedFiles = 0;
                MaxFiles = 0;
                AllCompleted = true;
                downloads.Clear();
                downloadTask.Dispose();
                downloadTask = null;
            }
            
        }

        public static IDownload GetDownloadInterface(string url)
        {
            return url.Contains("youtube") ? YoutubeDownloadInterface : SoundcloudDownloadInterface;
        }
    }
}