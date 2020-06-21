using Newtone.Core.Logic;
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
        #region Public Methods
        public void Completed(CrossPlayer player)
        {
            ConsoleDebug.WriteLine("WPC " + player.CurrentPosition + ":" + player.Duration);
            player.Next();
        }

        public void Load(CrossPlayer player, string filepath)
        {
            ConsoleDebug.WriteLine(filepath);
            player.Reset(); //Stop & reset
            YoutubeClient client = new YoutubeClient();
            StreamManifest manifest = null;
            Task.Run(async () =>
            {
                manifest = await client.Videos.Streams.GetManifestAsync(filepath);
            }).Wait();
            ConsoleDebug.WriteLine("URL: " + manifest.GetAudioOnly().WithHighestBitrate().Url);
            player.BasePlayer.Load(manifest.GetAudioOnly().WithHighestBitrate().Url);
        }

        public void Prepared(CrossPlayer player)
        {
            player.Play();
        }
        #endregion
    }
}
