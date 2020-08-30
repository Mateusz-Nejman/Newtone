using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Languages;
using Newtone.Mobile.Logic;
using static Android.Support.V4.Media.App.NotificationCompat;

namespace Newtone.Mobile.Media
{
    public class MobileMediaPlayer : IBasePlayer
    {
        #region Properties
        public static bool EntityClicked { get; set; }
        private MediaPlayer MediaPlayer { get; set; }
        #endregion
        #region Constructors
        public MobileMediaPlayer()
        {
            MediaPlayer = new MediaPlayer();
            MediaPlayer.SetAudioStreamType(Stream.Music);
            MediaPlayer.Completion += MediaPlayer_Completion;
            MediaPlayer.Prepared += MediaPlayer_Prepared;
            EntityClicked = false;
            
        }
        #endregion
        #region Private Methods
        private void MediaPlayer_Prepared(object sender, EventArgs e)
        {
            Play();
        }

        private void MediaPlayer_Completion(object sender, EventArgs e)
        {
            if (MediaPlayer.CurrentPosition > 0 && !EntityClicked)
                GlobalData.Current.MediaPlayer.Next();
            EntityClicked = false;
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