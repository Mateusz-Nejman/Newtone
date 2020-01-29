using Android.App;
using Android.Graphics.Drawables.Shapes;
using Android.Support.Design.Widget;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.CustomViews;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;
using YoutubeExplode;
using YoutubeExplode.Models;
using YoutubeExplode.Models.MediaStreams;

namespace NSEC.Music_Player.Logic
{
    public static class YoutubeProcessing
    {
        public async static Task Download(string url, Button button, ProgressBar progressBar, Label progressLabel, Page page)
        {
            Global.Downloads.Add(url, new Models.DownloadModel() { Url = url, Progress = 0.0, Name = Localization.YoutubeDownloadTitle, Download = true });
            progressLabel.Text = Localization.YoutubeStart;
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

                foreach (MuxedStreamInfo msi in streamInfoSet.Muxed)
                {
                    if (msi.Resolution.Height < streamInfo.Resolution.Height)
                        streamInfo = msi;
                }
                Console.WriteLine("streamInfo");

                Console.WriteLine(streamInfo == null);

                string ext = streamInfo.Container.GetFileExtension();

                Console.WriteLine(ext);
                // Download stream to file

                Progress<double> progress = new Progress<double>(progressValue =>
                {
                    Global.Downloads[url].Name = video.Title;
                    Global.Downloads[url].Progress = progressValue;

                    double newProgress = 0.0;

                    foreach (DownloadModel model in Global.Downloads.Values)
                    {
                        newProgress += model.Progress;
                    }

                    newProgress /= Global.Downloads.Count;
                    progressLabel.Text = Localization.YoutubeDownloadFiles + " (" + Global.Downloads.Count + ") " + string.Format("{0:0.00}", newProgress * 100.0) + "%";
                    progressBar.Progress = newProgress;
                });

                Console.WriteLine("Start download");
                await client.DownloadMediaStreamAsync(streamInfo, Global.MusicPath + "/data.bin" + id, progress);
                Console.WriteLine("End download");

                progressLabel.Text = Localization.YoutubeConvert;
                progressBar.Progress = 0;
                var type = await ConvertToMP3(video.Title, id);
                if (File.Exists(Global.MusicPath + "/data.bin" + id))
                    File.Delete(Global.MusicPath + "/data.bin" + id);

                if (true)
                {
                    bool answer = await page.DisplayAlert(Localization.Question, Localization.YoutubeAddTags + "?", "OK", Localization.Cancel);
                    if (answer)
                    {
                        //Global.MusicPath + "/" + video.Title + "."+type.ToString()
                        string[] splitted = video.Title.Split(new string[] { " - ", " – ", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries);
                        string artist = splitted.Length == 1 ? video.Author : splitted[0];
                        string title = splitted[splitted.Length == 1 ? 0 : 1];



                        string userArtist = await page.DisplayPromptAsync(Localization.Artist, artist, "OK", Localization.Cancel, artist);
                        string userTitle = await page.DisplayPromptAsync(Localization.Title, title, "OK", Localization.Cancel, title);

                        userArtist = userArtist == "" ? artist : userArtist;
                        userTitle = userTitle == "" ? title : userTitle;

                        using WebClient wc = new WebClient();
                        byte[] picture = wc.DownloadData(video.Thumbnails.StandardResUrl);

                        if (Global.AudioTags.ContainsKey(Global.MusicPath + "/" + video.Title + "." + type.ToString()))
                        {
                            string f = Global.MusicPath + "/" + video.Title + "." + type.ToString();
                            Global.AudioTags[f].Artist = userArtist;
                            Global.AudioTags[f].Title = userTitle;
                            Global.AudioTags[f].Picture = picture;
                        }
                        else
                        {
                            Global.AudioTags.Add(Global.MusicPath + "/" + video.Title + "." + type.ToString(), new MediaProcessing.MediaTag() { Artist = userArtist, Title = userTitle, Picture = picture });
                        }
                    }
                }
                MediaProcessing.MediaTag container = MediaProcessing.GetTags(Global.MusicPath + "/" + video.Title + "." + type.ToString());
                Helpers.AddTrack(container);
                Global.SaveConfig();
                SnackbarBuilder.Show(Localization.YoutubeReady);
                progressLabel.Text = Localization.YoutubeReady;
                //File.WriteAllBytes(Global.DataPath+"/data.bin", video.GetBytes());
            }
            catch
            {
                //Console.WriteLine("YoutubeProcessing.cs -> " + e);
                SnackbarBuilder.Show(Localization.YoutubeError);
                progressLabel.Text = Localization.YoutubeError;
            }


            Global.Downloads.Remove(url);
            button.IsEnabled = true;
        }

        public async static Task<MediaProcessing.MediaOutputType> ConvertToMP3(string name, string id)
        {
            //await Xamarin.MP4Transcoder.Transcoder.For960x540Format().
            //await FFMpeg.Xamarin.FFMpegLibrary.Run(App.Context, " -i "+ Global.DataPath + "/data.bin"+" -vn -f mp3 -ab 192k "+ Global.DataPath + "/"+name+".mp3");
            //IConversion conversion = Conversion.ExtractAudio(Global.DataPath + "/data.bin", Global.DataPath + "/" + name + ".mp3");
            //await conversion.Start();

            return await Task.Run(() => {
                var outputType = MediaProcessing.GetAudio(Global.MusicPath + "/data.bin" + id, Global.MusicPath + "/" + id);
                if (outputType == MediaProcessing.MediaOutputType.mp3)
                    File.Copy(Global.MusicPath + "/" + id, Global.MusicPath + "/" + name + ".mp3", true);
                else if (outputType == MediaProcessing.MediaOutputType.m4a)
                    File.Copy(Global.MusicPath + "/" + id, Global.MusicPath + "/" + name + ".m4a", true);
                File.Delete(Global.MusicPath + "/" + id);

                return outputType;
            });
        }
    }
}
