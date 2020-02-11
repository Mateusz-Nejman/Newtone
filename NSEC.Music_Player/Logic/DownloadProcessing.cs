using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NSEC.Music_Player.Models;
using YoutubeExplode;

namespace NSEC.Music_Player.Logic
{
    public static class DownloadProcessing
    {
        private static Task downloadTask;
        private readonly static Dictionary<string, DownloadModel> downloads = new Dictionary<string, DownloadModel>();

        public static bool AllCompleted { get; private set; }
        public static int DownloadedFiles { get; private set; }

        public static int MaxFiles { get; private set; }

        public static Dictionary<string, DownloadModel> GetDownloads()
        {
            return downloads;
        }

        public static void AddToDownloadTask(string id, string title)
        {
            AllCompleted = false;
            Console.WriteLine("DownloadProcessing AddToDownloadTask " + id);
            if (!downloads.ContainsKey(id))
                downloads.Add(id, new DownloadModel() { Name = title, Progress = 0.0, Download = true });

            MaxFiles = downloads.Count;
            if (downloadTask == null)
            {
                Console.WriteLine("DownloadProcessing Task");
                downloadTask = new Task(async () => { await TaskAction(); });
                downloadTask.Start();
            }
        }

        public static void SetProgress(string id, double progress)
        {
            if(downloads.ContainsKey(id))
            {
                downloads[id].Progress = progress;
            }
        }

        public static string GetGlobalProgress()
        {
            double progress = 0.0d;
            int count = 0;

            foreach(DownloadModel model in downloads.Values)
            {
                if (model.Download)
                {
                    progress += model.Progress;
                    count += 1;
                }
            }
            
            return count == 0 || progress == 0.0d ? "" : string.Format("{0:0.00}", ((progress / (double)count) * 100.0)) + "%";
        }

        private async static Task TaskAction()
        {
            Console.WriteLine("DownloadProcessing Task Start "+downloads.Count);
            foreach(string id in downloads.Keys.ToList())
            {

                DownloadModel model = downloads[id];

                if(model.Download)
                {
                    Console.WriteLine("DownloadProcessing " + id);
                    await YoutubeProcessing.DownloadVideoId(id);
                    DownloadedFiles += 1;
                }

            }
            DownloadedFiles = 0;
            MaxFiles = 0;
            AllCompleted = true;
            downloads.Clear();
            Console.WriteLine("DownloadProcessing Task Stop");
            downloadTask.Dispose();
            downloadTask = null;
        }
    }
}