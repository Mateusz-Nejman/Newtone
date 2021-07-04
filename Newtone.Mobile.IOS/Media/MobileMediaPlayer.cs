using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVFoundation;
using CoreMedia;
using Foundation;
using MediaPlayer;
using Newtone.Core;
using Newtone.Core.Media;
using UIKit;

namespace Newtone.Mobile.IOS.Media
{
    public class MobileMediaPlayer : NSObject, IBasePlayer
    {
        #region Properties
        private AVPlayer MediaPlayer { get; set; }
        #endregion
        #region Constructors
        public MobileMediaPlayer()
        {
            MediaPlayer = new AVPlayer();
            MediaPlayer.AutomaticallyWaitsToMinimizeStalling = false;
            var avSession = AVAudioSession.SharedInstance();
            avSession.SetCategory(AVAudioSessionCategory.Playback);
            avSession.SetActive(true, out NSError activationError);

            var commandCenter = MPRemoteCommandCenter.Shared;
            commandCenter.PreviousTrackCommand.Enabled = true;
            commandCenter.NextTrackCommand.Enabled = true;
            commandCenter.TogglePlayPauseCommand.Enabled = true;
            commandCenter.PlayCommand.Enabled = true;
            commandCenter.PauseCommand.Enabled = true;

            commandCenter.PreviousTrackCommand.AddTarget(commandEvent =>
            {
                GlobalData.Current.MediaPlayer.Prev();
                return MPRemoteCommandHandlerStatus.Success;
            });

            commandCenter.NextTrackCommand.AddTarget(commandEvent =>
            {
                GlobalData.Current.MediaPlayer.Next();
                return MPRemoteCommandHandlerStatus.Success;
            });

            commandCenter.TogglePlayPauseCommand.AddTarget(commandEvent =>
            {
                if (GetIsPlaying())
                    GlobalData.Current.MediaPlayer.Play();
                else
                    GlobalData.Current.MediaPlayer.Pause();
                return MPRemoteCommandHandlerStatus.Success;
            });

            commandCenter.PlayCommand.AddTarget(commandEvent =>
            {
                GlobalData.Current.MediaPlayer.Play();
                return MPRemoteCommandHandlerStatus.Success;
            });

            commandCenter.PauseCommand.AddTarget(commandEvent =>
            {
                GlobalData.Current.MediaPlayer.Pause();
                return MPRemoteCommandHandlerStatus.Success;
            });

            NSNotificationCenter.DefaultCenter.AddObserver(AVPlayerItem.DidPlayToEndTimeNotification, notify =>
            {
                GlobalData.Current.MediaPlayer.Next();
            });
        }
        #endregion
        #region Public Methods
        public void AfterNext()
        {
            //TODO
        }

        public void AfterPrev()
        {
            //TODO
        }

        public bool GetCanSeek()
        {
            return MediaPlayer != null;
        }

        public double GetCurrentPosition()
        {
            return MediaPlayer != null ? MediaPlayer.CurrentTime.Seconds : 0;
        }

        public double GetDuration()
        {
            return MediaPlayer != null && MediaPlayer.CurrentItem != null ? MediaPlayer.CurrentItem.Duration.Seconds : 0;
        }

        public bool GetIsPlaying()
        {
            return MediaPlayer != null && MediaPlayer.Rate != 0 && MediaPlayer.Error == null;
        }

        public float GetVolume()
        {
            return MediaPlayer != null ? MediaPlayer.Volume : 0;
        }

        public void Load(string filename)
        {
            Reset();
            MediaPlayer.ReplaceCurrentItemWithPlayerItem(null);

            NSUrl url = filename.StartsWith("https://") ? NSUrl.FromString(filename) : NSUrl.FromFilename(filename);
            NSMutableDictionary dict = new NSMutableDictionary
            {
                { new NSString("AVURLAssetPreferPreciseDurationAndTimingKey"), new NSNumber(true) }
            };
            var playerItem = AVPlayerItem.FromAsset(AVUrlAsset.Create(url, new AVUrlAssetOptions(dict)));
            MediaPlayer.ReplaceCurrentItemWithPlayerItem(playerItem);
        }

        public void Pause()
        {
            MediaPlayer?.Pause();
            SetNotification(GetIsPlaying());
        }

        public void Play()
        {
            MediaPlayer?.Play();
            SetNotification(GetIsPlaying());

            Task.Run(async () =>
            {
                while (MediaPlayer.Rate != 0 && MediaPlayer.Error == null)
                {
                    var current = GlobalData.Current.MediaPlayer.CurrentPosition;
                    var duration = GlobalData.Current.MediaSource.Duration.TotalSeconds;

                    if(current >= duration)
                    {
                        GlobalData.Current.MediaPlayer.Next();
                    }
                    await Task.Delay(250);
                }
            });
        }

        public void Prepare()
        {
            Prepared(GlobalData.Current.MediaPlayer);
        }

        public void Prepared(CrossPlayer player)
        {
            player?.PlayerController?.Prepared(player);
        }

        public void Reset()
        {
            Stop();
        }

        public void Seek(double seek)
        {
            if (seek < GetDuration())
            {
                MediaPlayer.Seek(CMTime.FromSeconds(seek, 4));
                SetNotification(GetIsPlaying());
            }
        }

        public void SetNotification(bool isPlaying)
        {
            InvokeOnMainThread(() => {
                UIApplication.SharedApplication.BeginReceivingRemoteControlEvents();
            });

            if (GlobalData.Current.MediaSource == null)
            {
                MPNowPlayingInfoCenter.DefaultCenter.NowPlaying = null;
                return;
            }

            var currentSource = GlobalData.Current.MediaSource;
            var item = new MPNowPlayingInfo();

            item.Title = currentSource.Title;
            item.Artist = currentSource.Artist;
            item.ElapsedPlaybackTime = GetCurrentPosition();
            item.PlaybackDuration = GetDuration();
            item.PlaybackQueueIndex = GlobalData.Current.PlaylistPosition;
            item.PlaybackQueueCount = GlobalData.Current.CurrentPlaylist.Count;
            item.PlaybackRate = MediaPlayer == null ? 0 : MediaPlayer.Rate;
            if(currentSource.Image != null)
                item.Artwork = new MPMediaItemArtwork(UIImage.LoadFromData(NSData.FromArray(currentSource.Image)));

            MPNowPlayingInfoCenter.DefaultCenter.NowPlaying = item;
        }

        public void SetVolume(float volume)
        {
            if (MediaPlayer == null)
                return;

            MediaPlayer.Volume = Math.Min(1, Math.Max(0, volume));
        }

        public void Stop()
        {
            Seek(0);
            MediaPlayer?.Pause();
        }

        #endregion
    }
}