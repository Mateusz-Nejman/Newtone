using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Newtone.Core.Media
{
    public class WebPlayerController : IPlayerController
    {
        public void Completed(CrossPlayer player)
        {
            player.Next();
        }

        public void Load(CrossPlayer player, string filepath)
        {
            Console.WriteLine(filepath);
            player.Reset(); //Stop & reset
            YoutubeClient client = new YoutubeClient();
            StreamManifest manifest = null;
            Task.Run(async () =>
            {
                manifest = await client.Videos.Streams.GetManifestAsync(filepath);
            }).Wait();
            player.BasePlayer.Load(manifest.GetAudioOnly().WithHighestBitrate().Url);
        }

        public void Prepared(CrossPlayer player)
        {
            player.Play();
        }
    }
}
