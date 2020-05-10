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
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using static Android.Support.V4.Media.App.NotificationCompat;

namespace NSEC.Music_Player.Media
{
    public class MobileMediaPlayer : IBasePlayer
    {
        private MediaPlayer MediaPlayer { get; set; }

        private long CurrentPosition
        {
            get
            {
                return (long)GetCurrentPosition() * 1000;
            }
        }

        public MobileMediaPlayer()
        {
            MediaPlayer = new MediaPlayer();
            MediaPlayer.SetAudioStreamType(Stream.Music);
            MediaPlayer.Completion += MediaPlayer_Completion;
            MediaPlayer.Prepared += MediaPlayer_Prepared;
            
        }

        private void MediaPlayer_Prepared(object sender, EventArgs e)
        {
            Console.WriteLine("MediaPlayer Prepared");
            Play();
        }

        private void MediaPlayer_Completion(object sender, EventArgs e)
        {
            Console.WriteLine("MediaPlayer Completion");
            if (MediaPlayer.CurrentPosition > 0 && MediaPlayer.CurrentPosition <= MediaPlayer.Duration)
                GlobalData.MediaPlayer.Next();
        }

        public void AfterNext()
        {
            //throw new NotImplementedException();
            Global.MediaSession.SetMetadata(GlobalData.MediaSource.ToMetadata());
            //Global.StateBuilder.SetState(PlaybackStateCompat.StateSkippingToNext, CurrentPosition, 1.0f);
            //Global.MediaSession.SetPlaybackState(Global.StateBuilder.Build());
        }

        public void AfterPrev()
        {

            //TODO
            //throw new NotImplementedException();
            Global.MediaSession.SetMetadata(GlobalData.MediaSource.ToMetadata());
            //Global.StateBuilder.SetState(PlaybackStateCompat.StateSkippingToPrevious, CurrentPosition, 1.0f);
            //Global.MediaSession.SetPlaybackState(Global.StateBuilder.Build());
        }

        public void Error(string text)
        {
            if (text == GlobalData.ERROR_FILE_EXISTS)
                SnackbarBuilder.Show(Localization.SnackFileExists);
            else if (text == GlobalData.ERROR_CORRUPTED)
                SnackbarBuilder.Show(Localization.FileCorrupted);
            else
                SnackbarBuilder.Show(text);
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
            Global.MediaSession.SetMetadata(GlobalData.MediaSource.ToMetadata());
            Global.StateBuilder.SetState(PlaybackStateCompat.StatePaused, CurrentPosition, 1.0f);
            Global.MediaSession.SetPlaybackState(Global.StateBuilder.Build());
        }

        public void Play()
        {
            MediaPlayer.Start();
            Global.MediaSession.SetMetadata(GlobalData.MediaSource.ToMetadata());
            Global.StateBuilder.SetState(PlaybackStateCompat.StatePlaying, CurrentPosition, 1.0f);
            Global.MediaSession.SetPlaybackState(Global.StateBuilder.Build());
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
        }

        public void SetNotification(MediaSource container)
        {
            ConsoleDebug.WriteLine("Set Notification1 "+(MediaPlayerService.Instance == null ? "null" : "not null"));
            MediaPlayerService.Instance.ShowNotification();
        }

        public void SetVolume(float volume)
        {
            MediaPlayer.SetVolume(volume, volume);
        }

        public void Stop()
        {
            MediaPlayer?.Stop();
            Global.MediaSession.SetMetadata(GlobalData.MediaSource.ToMetadata());
            Global.StateBuilder.SetState(PlaybackStateCompat.StateStopped, CurrentPosition, 1.0f);
            Global.MediaSession.SetPlaybackState(Global.StateBuilder.Build());
        }
    }
}