using AVFoundation;
using CoreMedia;
using Foundation;
using MediaPlayer;
using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Contracts;
using System;
using System.Threading.Tasks;
using UIKit;

namespace Nejman.Newtone.iOS.Implementations
{
    public class MediaPlayerImplementation : NSObject, IMediaPlayer
    {
        internal AVPlayer MediaPlayer { get; private set; }

        public MediaPlayerImplementation()
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
                Task.Run(async () => await CoreGlobal.MediaPlayer.Prev());
                return MPRemoteCommandHandlerStatus.Success;
            });

            commandCenter.NextTrackCommand.AddTarget(commandEvent =>
            {
                Task.Run(async () => await CoreGlobal.MediaPlayer.Next());
                return MPRemoteCommandHandlerStatus.Success;
            });

            commandCenter.TogglePlayPauseCommand.AddTarget(commandEvent =>
            {
                if (GetIsPlaying())
                {
                    CoreGlobal.MediaPlayer.Play();
                }
                else
                {
                    CoreGlobal.MediaPlayer.Pause();
                }
                return MPRemoteCommandHandlerStatus.Success;
            });

            commandCenter.PlayCommand.AddTarget(commandEvent =>
            {
                CoreGlobal.MediaPlayer.Play();
                return MPRemoteCommandHandlerStatus.Success;
            });

            commandCenter.PauseCommand.AddTarget(commandEvent =>
            {
                CoreGlobal.MediaPlayer.Pause();
                return MPRemoteCommandHandlerStatus.Success;
            });

            NSNotificationCenter.DefaultCenter.AddObserver(AVPlayerItem.DidPlayToEndTimeNotification, async(notify) =>
            {
                await CoreGlobal.MediaPlayer.Next();
            });
        }
        public void PlatformPlay()
        {
            //TODO MediaPlayerHelper.Play();
        }
        public void AfterNext()
        {
            //Nothing happens
        }

        public void AfterPrev()
        {
            //Nothing happens
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
        public void Pause()
        {
            MediaPlayer?.Pause();
        }

        public void Play()
        {
            MediaPlayer?.Play();

            Task.Run(async () =>
            {
                while (MediaPlayer.Rate != 0 && MediaPlayer.Error == null)
                {
                    var current = CoreGlobal.MediaPlayer.CurrentPosition;
                    var duration = CoreGlobal.CurrentSource.Duration.TotalSeconds;

                    if (current >= duration)
                    {
                        CoreGlobal.MediaPlayer.Next();
                    }
                    await Task.Delay(250);
                }
            });
        }

        public void Prepare()
        {
            Task.Run(async() => await Prepared());
        }
        public async Task Prepared()
        {
            await CoreGlobal.MediaPlayer.CurrentController.Prepared(CoreGlobal.MediaPlayer);
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
            }
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

        public async Task Load(string path)
        {
            await Task.Run(() =>
            {
                Reset();
                MediaPlayer.ReplaceCurrentItemWithPlayerItem(null);

                NSUrl url = path.StartsWith("https://") ? NSUrl.FromString(path) : NSUrl.FromFilename(path);
                NSMutableDictionary dict = new NSMutableDictionary
            {
                { new NSString("AVURLAssetPreferPreciseDurationAndTimingKey"), new NSNumber(true) }
            };
                var playerItem = AVPlayerItem.FromAsset(AVUrlAsset.Create(url, new AVUrlAssetOptions(dict)));
                MediaPlayer.ReplaceCurrentItemWithPlayerItem(playerItem);
            });
        }
    }
}