using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NSEC.Music_Player.Media
{
    public class LocalPlayerController : IPlayerController
    {
        public void Completed(CustomMediaPlayer player)
        {
            player.Next();
        }

        public void Load(CustomMediaPlayer player, string filepath)
        {
            string path = System.IO.Path.Combine(Global.MusicPath, $"cache.wav");

            if (File.Exists(path))
                File.Delete(path);

            File.Copy(filepath, path, true);
            player.MediaPlayer.SetDataSource(path);
        }

        public void Prepared(CustomMediaPlayer player)
        {
            player.Play();
        }
    }
}