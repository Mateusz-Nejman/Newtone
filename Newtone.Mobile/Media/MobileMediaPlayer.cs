using System;
using Android.Media;
using Android.Support.V4.Media.Session;
using Newtone.Core;
using Newtone.Core.Media;

namespace Newtone.Mobile.Media
{
    public class MobileMediaPlayer : IBasePlayer
    {
        #region Fields
        private bool checkSafeTime = true;
        private bool prepared = false;
        #endregion
        #region Properties
        private MediaPlayer MediaPlayer { get; set; }
        #endregion
        #region Constructors
        public MobileMediaPlayer()
        {
            MediaPlayer = new MediaPlayer();
            MediaPlayer.SetAudioStreamType(Stream.Music);
            MediaPlayer.Completion += MediaPlayer_Completion;
            MediaPlayer.Prepared += MediaPlayer_Prepared;
        }
        #endregion
        #region Private Methods
        private void MediaPlayer_Prepared(object sender, EventArgs e)
        {
            prepared = true;
            Play();
            if (checkSafeTime)
            {
                if (GetCurrentPosition() > (GetDuration() / 2))
                {
                    Seek(0);
                }

                checkSafeTime = false;
            }

        }

        private void MediaPlayer_Completion(object sender, EventArgs e)
        {
            if (MediaPlayer.CurrentPosition > 0 && !checkSafeTime && prepared)
                GlobalData.Current.MediaPlayer.Next();
        }
        #endregion
        #region Public Methods
        public void AfterNext()
        {
            Global.MediaSession.SetMetadata(GlobalData.Current.MediaSource?.ToMetadata());
            Global.MediaSession.SetPlaybackState(Global.StateBuilder?.Build());
        }

        public void AfterPrev()
        {
            Global.MediaSession.SetMetadata(GlobalData.Current.MediaSource?.ToMetadata());
            Global.MediaSession.SetPlaybackState(Global.StateBuilder?.Build());
        }

        public bool GetCanSeek()
        {
            return true;
        }

        public double GetCurrentPosition()
        {
            return MediaPlayer.CurrentPosition / 1000;
        }

        public double GetDuration()
        {
            return MediaPlayer.Duration / 1000;
        }

        public bool GetIsPlaying()
        {
            return MediaPlayer.IsPlaying;
        }

        public float GetVolume()
        {
            return 1.0f;
        }

        public void Load(string filename)
        {
            checkSafeTime = true;
            prepared = false;
            MediaPlayer.Reset();
            MediaPlayer.SetDataSource(filename);
        }

        public void Pause()
        {
            MediaPlayer.Pause();
            if(GlobalData.Current.MediaSource != null)
            {
                MediaPlayerService.Instance.SetNotificationData(PlaybackStateCompat.StatePaused);
            }
            
        }

        public void Play()
        {
            MediaPlayer.Start();
            MediaPlayerService.Instance.SetNotificationData(PlaybackStateCompat.StatePlaying);
        }

        public void Prepare()
        {
            MediaPlayer.Prepare();
        }

        public void Reset()
        {
            MediaPlayer.Reset();
        }

        public void Seek(double seek)
        {
            MediaPlayer.SeekTo((int)seek * 1000);
            MediaPlayerService.Instance.ShowNotification();
        }

        public void SetNotification(bool isPlaying)
        {
            MediaPlayerService.Instance.ShowNotification();
        }

        public void SetVolume(float volume)
        {
            MediaPlayer.SetVolume(volume, volume);
        }

        public void Stop()
        {
            MediaPlayer?.Stop();
            MediaPlayerService.Instance.SetNotificationData(PlaybackStateCompat.StateStopped);
        }
        #endregion
    }
}