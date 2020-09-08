﻿using NAudio.Wave;
using Newtone.Core;
using Newtone.Core.Media;
using Newtone.Desktop.Logic;

namespace Newtone.Desktop.Media
{
    public class DesktopMediaPlayer : IBasePlayer
    {
        #region Properties
        private WaveOutEvent MediaPlayer { get; set; }
        private WaveStream CurrentFile { get; set; }
        public static bool IsStoppedByUser { get; set; }
        public bool IsPrepared { get; set; } = false;
        #endregion
        #region Constructors
        public DesktopMediaPlayer()
        {
            MediaPlayer = new WaveOutEvent();
            MediaPlayer.PlaybackStopped += MediaPlayer_PlaybackStopped;
        }
        #endregion
        #region Private Methods
        private void MediaPlayer_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if(e.Exception == null && CurrentFile != null && ((MediaPlayer.PlaybackState == PlaybackState.Playing && CurrentFile.Position > CurrentFile.Length - 2000) || (MediaPlayer.PlaybackState == PlaybackState.Stopped && CurrentFile.Position > CurrentFile.Length - 2000)))
            {
                CurrentFile.Position = 0;
                GlobalData.Current.MediaPlayer.Next();
                GlobalData.Current.MediaPlayer.Play();
            }
        }
        #endregion
        #region Public Methods

        public void AfterNext()
        {
            
        }

        public void AfterPrev()
        {
            
        }

        public void Error(string text)
        {
        }

        public bool GetCanSeek()
        {
            return MediaPlayer != null;
        }

        public double GetCurrentPosition()
        {
            return CurrentFile != null ? CurrentFile.CurrentTime.TotalSeconds : 0;
        }

        public double GetDuration()
        {
            return CurrentFile != null ? CurrentFile.TotalTime.TotalSeconds : 0;
        }

        public bool GetIsPlaying()
        {
            return CurrentFile != null && MediaPlayer.PlaybackState == PlaybackState.Playing;
        }

        public void Load(string filename)
        {
            IsPrepared = false;
            Stop();
            Reset();
            if (filename.StartsWith("http"))
                CurrentFile = new MediaFoundationReader(filename);
            else
                CurrentFile = new AudioFileReader(filename);
        }

        public void Pause()
        {
            if(IsPrepared)
                MediaPlayer.Pause();
        }

        public void Play()
        {
            if(IsPrepared)
                MediaPlayer.Play();
        }

        public void Prepare()
        {
            MediaPlayer.Init(CurrentFile); //TODO
            IsPrepared = true;
        }

        public void Reset()
        {
            if(CurrentFile != null)
                CurrentFile.Dispose();
            CurrentFile = null;
        }

        public void Seek(double seek)
        {
            CurrentFile.SetPosition(seek);
        }

        public void SetNotification(bool isPlaying)
        {
            //TODO
        }

        public void SetVolume(float volume)
        {
            MediaPlayer.Volume = volume;
        }

        public float GetVolume()
        {
            return MediaPlayer.Volume;
        }

        public void Stop()
        {
            MediaPlayer.Stop();
        }
#endregion

    }
}
