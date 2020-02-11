using Android.App;
using Android.Graphics.Drawables.Shapes;
using Android.Support.Design.Widget;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.CustomViews;
using NSEC.Music_Player.Views.Tabs;
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
        public static Page Page;
        public async static Task Download(string url)
        {
            string playlistId = "";
            YoutubeClient client = new YoutubeClient();

            if (url.Contains("list="))
            {
                if (url.Contains("v="))
                {
                    bool answer = await Page.DisplayAlert(Localization.Question, Localization.PlaylistOrTrack+"?", Localization.Track, Localization.Playlist);
                    if(answer)
                    {
                        playlistId = "";
                    }
                    else
                    {
                        playlistId = YoutubeClient.ParsePlaylistId(url);
                    }
                }
                else
                    playlistId = YoutubeClient.ParsePlaylistId(url);
            }


            if(playlistId == "")
            {
                Console.WriteLine("YoutubeProcessing download one "+url);
                string id = YoutubeClient.ParseVideoId(url);
                Video video = await client.GetVideoAsync(id);
                DownloadProcessing.AddToDownloadTask(id, video.Title);
            }
            else
            {
                Console.WriteLine("YoutubeProcessing download many");
                Playlist playlist = await client.GetPlaylistAsync(playlistId);
                
                foreach(Video video in playlist.Videos)
                {
                    Console.WriteLine("YoutubeProcessing download many "+video.Id);
                    DownloadProcessing.AddToDownloadTask(video.Id, video.Title);
                }
            }
        }


        public async static Task DownloadVideoId(string id)
        {
            string url = "https://www.youtube.com/watch?v="+id;

            await DownloadVideo(url);
        }
        private async static Task DownloadVideo(string url)
        {
            string id = YoutubeClient.ParseVideoId(url);
            try
            {

                Console.WriteLine("URL: " + url);
                if (!Directory.Exists(Global.MusicPath))
                    Directory.CreateDirectory(Global.MusicPath);

                

                YoutubeClient client = new YoutubeClient();

                Video video = await client.GetVideoAsync(id);
                MediaStreamInfoSet streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);
                MuxedStreamInfo streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();

                foreach (MuxedStreamInfo msi in streamInfoSet.Muxed)
                {
                    if (msi.Resolution.Height < streamInfo.Resolution.Height)
                        streamInfo = msi;
                }

                Progress<double> progress = new Progress<double>(progressValue =>
                {
                    DownloadProcessing.SetProgress(id, progressValue);
                });
                await client.DownloadMediaStreamAsync(streamInfo, Global.MusicPath + "/data.bin" + id, progress);
                Console.WriteLine("YoutubeProcessing await Convert");
                var type = await ConvertToMP3(video.Title, id);
                Console.WriteLine("YoutubeProcessing await Convert end");
                if (File.Exists(Global.MusicPath + "/data.bin" + id))
                    File.Delete(Global.MusicPath + "/data.bin" + id);

                Page.Dispatcher.BeginInvokeOnMainThread(async () => {
                    bool answer = Global.AutoTags ? true : await Page.DisplayAlert(Localization.Question, Localization.YoutubeAddTags + "?", "OK", Localization.Cancel);
                        
                    if (answer)
                    {
                        //Global.MusicPath + "/" + video.Title + "."+type.ToString()
                        string[] splitted = video.Title.Split(new string[] { " - ", " – ", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries);
                        string artist = splitted.Length == 1 ? video.Author : splitted[0];
                        string title = splitted[splitted.Length == 1 ? 0 : 1];


                        string userArtist = Global.AutoTags ? "" : await Page.DisplayPromptAsync(Localization.Artist, artist, "OK", Localization.Cancel, artist);
                        string userTitle = Global.AutoTags ? "" : await Page.DisplayPromptAsync(Localization.Title, title, "OK", Localization.Cancel, title);

                        userArtist = userArtist == "" || userArtist == null ? artist : userArtist;
                        userTitle = userTitle == "" || userTitle == null ? title : userTitle;
                        byte[] picture = null;
                        try
                        {
                            using WebClient wc = new WebClient();
                            picture = wc.DownloadData(video.Thumbnails.StandardResUrl);
                        }
                        catch
                        {
                            
                        }

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
                });

                MediaProcessing.MediaTag container = MediaProcessing.GetTags(Global.MusicPath + "/" + video.Title + "." + type.ToString());
                Helpers.AddTrack(container);
                Global.SaveConfig();
                SnackbarBuilder.Show(Localization.YoutubeReady);
            }
            catch
            {
                DownloadProcessing.SetProgress(id, -1.0);
                //Console.WriteLine("YoutubeProcessing.cs -> " + e);
                SnackbarBuilder.Show(Localization.YoutubeError);
            }
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
