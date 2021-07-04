using Nejman.Newtone.Core.External;
using Nejman.Newtone.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace Nejman.Newtone.Core.Media
{
    public class WebPlayerController : IPlayerController
    {
        public async Task Completed(MediaPlayer player)
        {
            await player.Next();
        }

        public async Task Load(MediaPlayer player, string path)
        {
            player.IsLoading = true;
            player.Reset();

            path = await YoutubeExplodeIntegration.GetAudioUrl(path);

            await MediaPlayerImplementation.Current.Load(path);
        }

        public Task Loaded(MediaPlayer player)
        {
            return Task.FromResult((Task)null);
        }

        public Task Prepared(MediaPlayer player)
        {
            player.Play();
            player.IsLoading = false;
            return Task.FromResult((Task)null);
        }
    }
}
