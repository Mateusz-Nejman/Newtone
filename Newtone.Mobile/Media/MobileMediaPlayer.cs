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
            Console.WriteLine("Start Prepared");
            Prepared(GlobalData.Current.MediaPlayer);
            prepared = true;
            Seek(0);
            Console.WriteLine("End Prepared");
            Console.WriteLine("Current position: " + MediaPlayer.CurrentPosition);
        }

        private void MediaPlayer_Completion(object sender, EventArgs e)
        {
            Console.WriteLine("Completion " + MediaPlayer.CurrentPosition + " " + (!checkSafeTime) + " " + prepared);
            if (MediaPlayer.CurrentPosition > 0 && prepared)
                GlobalData.Current.MediaPlayer.Next();
        }

        private void UpdateMetadata()
        {
            Global.MediaSession.SetMetadata(GlobalData.Current.MediaSource?.ToMetadata());
            Global.MediaSession.SetPlaybackState(Global.StateBuilder?.Build());
        }
        #endregion
        #region Public Methods
        public void AfterNext()
        {
            UpdateMetadata();
        }

        public void AfterPrev()
        {
            UpdateMetadata();
        }

        public bool GetCanSeek()
        {
            return true;
        }

        public double GetCurrentPosition()
        {
            return MediaPlayer.CurrentPosition / 1000.0d;
        }

        public double GetDuration()
        {
            return MediaPlayer.Duration / 1000.0d;
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
            Console.WriteLine("Start load");
            checkSafeTime = true;
            prepared = false;
            MediaPlayer.Reset();
            MediaPlayer.SetDataSource(filename);
            MediaPlayerService.Instance.SetNotificationData(PlaybackStateCompat.StatePaused);
            Console.WriteLine("End load");
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
            MediaPlayer.PrepareAsync();
        }

        public void Prepared(CrossPlayer player)
        {
            player.PlayerController?.Prepared(player);
        }

        public void Reset()
        {
            MediaPlayer.Reset();
        }

        public void Seek(double seek)
        {
            Console.WriteLine("Seek to " + seek);
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