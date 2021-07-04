using Foundation;
using MediaPlayer;
using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Contracts;
using Nejman.Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace Nejman.Newtone.iOS.Implementations
{
    public class NotificationImplementation : NSObject, INotification
    {
        public void Show(MediaSource mediaSource, bool isPlaying)
        {
            InvokeOnMainThread(() => {
                UIApplication.SharedApplication.BeginReceivingRemoteControlEvents();
            });

            if (mediaSource == null)
            {
                MPNowPlayingInfoCenter.DefaultCenter.NowPlaying = null;
                return;
            }

            var item = new MPNowPlayingInfo();
            var mediaPlayer = Core.Implementations.MediaPlayerImplementation.Current as MediaPlayerImplementation;

            item.Title = mediaSource.Title;
            item.Artist = mediaSource.Artist;
            item.ElapsedPlaybackTime = CoreGlobal.MediaPlayer.CurrentPosition;
            item.PlaybackDuration = CoreGlobal.MediaPlayer.Duration;
            item.PlaybackQueueIndex = 0;
            item.PlaybackQueueCount = 0;
            item.PlaybackRate = mediaPlayer == null ? 0 : mediaPlayer.MediaPlayer.Rate;
            if (mediaSource.Image != null)
                item.Artwork = new MPMediaItemArtwork(UIImage.LoadFromData(NSData.FromArray(mediaSource.Image)));

            MPNowPlayingInfoCenter.DefaultCenter.NowPlaying = item;
        }
    }
}