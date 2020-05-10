using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Newtone.Core.Media
{
    public class LocalPlayerController : IPlayerController
    {
        public void Completed(CrossPlayer player)
        {
            player.Next();
        }

        public void Load(CrossPlayer player, string filepath)
        {
            //string path = System.IO.Path.Combine(GlobalData.MusicPath, $"cache.wav");

            //if (File.Exists(path))
            //    File.Delete(path);

            //File.Copy(filepath, path, true);
            player.BasePlayer.Load(filepath);
        }

        public void Prepared(CrossPlayer player)
        {
            player.Play();
        }
    }
}
