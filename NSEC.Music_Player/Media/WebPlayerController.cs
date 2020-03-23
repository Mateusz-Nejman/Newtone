using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace NSEC.Music_Player.Media
{
    public class WebPlayerController : IPlayerController
    {
        public void Completed(CustomMediaPlayer player)
        {
            player.Next();
        }

        public void Load(CustomMediaPlayer player, string filepath)
        {
            player.MediaPlayer.Stop();
            player.MediaPlayer.Reset();
            YoutubeClient client = new YoutubeClient();
            MediaStreamInfoSet msi = null;
            Task.Run(async () =>
            {
                msi = await client.GetVideoMediaStreamInfosAsync(filepath);
            }).Wait();
            player.MediaPlayer.SetDataSource(msi.Audio.First().Url);
        }

        public void Prepared(CustomMediaPlayer player)
        {
            player.Play();
        }
    }
}