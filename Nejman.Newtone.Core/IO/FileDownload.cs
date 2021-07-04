using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nejman.Newtone.Core.IO
{
    public class FileDownload
    {
        private readonly string url;
        private readonly IProgress<double> progress;
        private readonly string filename;
        private bool completed;
        public FileDownload(string url, IProgress<double> progress, string filename)
        {
            this.url = url;
            this.progress = progress;
            this.filename = filename;
        }
        public async Task StartDownload()
        {
            completed = false;
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadDataCompleted += Client_DownloadDataCompleted;
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                client.DownloadFileAsync(new Uri(url), filename);
            }

            while(true)
            {
                await Task.Delay(100);

                if(completed)
                {
                    return;
                }
            }
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            completed = true;
        }

        private void Client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            completed = true;
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progress.Report(e.ProgressPercentage);
        }
    }
}
