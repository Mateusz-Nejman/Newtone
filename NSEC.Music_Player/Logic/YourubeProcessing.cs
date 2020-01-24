using Android.App;
using Android.Graphics.Drawables.Shapes;
using Android.Support.Design.Widget;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Views.CustomViews;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using YoutubeExplode;
using YoutubeExplode.Models;
using YoutubeExplode.Models.MediaStreams;

namespace NSEC.Music_Player.Logic
{
    public static class YoutubeProcessing
    {
        public async static Task Download(string url, Button button, ProgressBar progressBar, Label progressLabel)
        {
            progressLabel.Text = "Rozpoczynanie pobierania...";
            Console.WriteLine("URL: " + url);
            if (!Directory.Exists(Global.MusicPath))
                Directory.CreateDirectory(Global.MusicPath);
            try
            {
                string id = YoutubeClient.ParseVideoId(url);
                Console.WriteLine("video id: " + id);
                YoutubeClient client = new YoutubeClient();
                Console.WriteLine("youtube client initialized");
                Video video = await client.GetVideoAsync(id);
                Console.WriteLine("video info");
                MediaStreamInfoSet streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);
                Console.WriteLine("streamInfoSet");
                MuxedStreamInfo streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
                Console.WriteLine("streamInfo");

                Console.WriteLine(streamInfo == null);

                string ext = streamInfo.Container.GetFileExtension();

                Console.WriteLine(ext);
                // Download stream to file

                Progress<double> progress = new Progress<double>(progressValue =>
                {
                    progressLabel.Text = Localization.YoutubeDownloading+" " + string.Format("{0:0.00}", progressValue * 100.0) + "%";
                    progressBar.Progress = progressValue;
                });

                Console.WriteLine("Start download");
                await client.DownloadMediaStreamAsync(streamInfo, Global.MusicPath + "/data.bin", progress);
                Console.WriteLine("End download");

                progressLabel.Text = Localization.YoutubeConvert;
                progressBar.Progress = 0;
                await ConvertToMP3(video.Title);
                if (File.Exists(Global.MusicPath + "/data.bin"))
                    File.Delete(Global.MusicPath + "/data.bin");

                MediaProcessing.MediaTag container = MediaProcessing.GetTags(Global.MusicPath + "/" + video.Title + ".mp3");
                Helpers.AddTrack(container);
                SnackbarBuilder.Show(Localization.YoutubeReady);
                progressLabel.Text = Localization.YoutubeReady;
                //File.WriteAllBytes(Global.DataPath+"/data.bin", video.GetBytes());
            }
            catch (Exception e)
            {
                Console.WriteLine("YoutubeProcessing.cs -> " + e);
                SnackbarBuilder.Show(Localization.YoutubeError);
                progressLabel.Text = Localization.YoutubeError;
            }


            button.IsEnabled = true;
        }

        public async static Task ConvertToMP3(string name)
        {
            //await Xamarin.MP4Transcoder.Transcoder.For960x540Format().
            //await FFMpeg.Xamarin.FFMpegLibrary.Run(App.Context, " -i "+ Global.DataPath + "/data.bin"+" -vn -f mp3 -ab 192k "+ Global.DataPath + "/"+name+".mp3");
            //IConversion conversion = Conversion.ExtractAudio(Global.DataPath + "/data.bin", Global.DataPath + "/" + name + ".mp3");
            //await conversion.Start();

            await Task.Run(() => {
                var outputType = MediaProcessing.GetAudio(Global.MusicPath + "/data.bin", Global.MusicPath + "/" + name);
            if (outputType == MediaProcessing.MediaOutputType.mp3)
                    File.Copy(Global.MusicPath + "/" + name, Global.MusicPath + "/" + name + ".mp3", true);
            else if(outputType == MediaProcessing.MediaOutputType.m4a)
                    File.Copy(Global.MusicPath + "/" + name, Global.MusicPath + "/" + name + ".m4a", true);
                File.Delete(Global.MusicPath + "/" + name);
            });
        }
    }
}
