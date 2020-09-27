﻿using System;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Newtone.Core.Media
{
    public class WebPlayerController : IPlayerController
    {
        #region Public Methods
        public void Completed(CrossPlayer player)
        {
            player.Next();
        }

        public void Load(CrossPlayer player, string filepath)
        {
            player.Reset(); //Stop & reset
            YoutubeClient client = new YoutubeClient();
            StreamManifest manifest = null;
            Task.Run(async () =>
            {
                manifest = await client.Videos.Streams.GetManifestAsync(filepath);
                foreach(var item in manifest.GetAudioOnly())
                {
                    Console.WriteLine(item.Size + " " + item.Bitrate + " " + item.AudioCodec);
                }
                player.BasePlayer.Load(manifest.GetAudioOnly().Where(info => info.AudioCodec.Contains("mp4a")).OrderByDescending(info => info.Bitrate.BitsPerSecond).First().Url);
            }).Wait();
            
        }

        public void Prepared(CrossPlayer player)
        {
            player.Play();
            player.IsLoading = false;
        }
        #endregion
    }
}
