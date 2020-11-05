using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AVFoundation;
using Foundation;
using Newtone.Core;
using Newtone.Core.Media;
using UIKit;

namespace Newtone.Mobile.IOS.Media
{
    public class MobileMediaPlayer : IBasePlayer
    {
        #region Fields
        private bool checkSafeTime = true;
        private bool prepared = false;
        #endregion
        #region Properties
        private AVAudioPlayer MediaPlayer { get; set; }
        #endregion
        #region Constructors
        public MobileMediaPlayer()
        {

        }
        #endregion
        #region Private Methods
        private void MediaPlayer_Completion(object sender, AVStatusEventArgs e)
        {
            GlobalData.Current.MediaPlayer.Next();
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
            return MediaPlayer != null ? MediaPlayer.CurrentTime : 0;
        }

        public double GetDuration()
        {
            return MediaPlayer != null ? MediaPlayer.Duration : 0;
        }

        public bool GetIsPlaying()
        {
            return MediaPlayer != null && MediaPlayer.Playing;
        }

        public float GetVolume()
        {
            return MediaPlayer != null ? MediaPlayer.Volume : 0;
        }

        public void Load(string filename)
        {
            Reset();

            MediaPlayer = AVAudioPlayer.FromUrl(NSUrl.FromFilename(filename));
        }

        public void Pause()
        {
            MediaPlayer?.Pause();
            MediaPlayer.FinishedPlaying += MediaPlayer_Completion;
        }

        public void Play()
        {
            MediaPlayer?.Play();
        }

        public void Prepare()
        {
            MediaPlayer.FinishedPlaying += MediaPlayer_Completion;
            MediaPlayer.PrepareToPlay();
            Prepared(GlobalData.Current.MediaPlayer);
        }

        public void Prepared(CrossPlayer player)
        {
            player?.PlayerController?.Prepared(player);
        }

        public void Reset()
        {
            Stop();

            if(MediaPlayer != null)
            {
                MediaPlayer.Dispose();
                MediaPlayer = null;
            }
        }

        public void Seek(double seek)
        {
            if (MediaPlayer == null)
                return;

            MediaPlayer.CurrentTime = seek;
        }

        public void SetNotification(bool isPlaying)
        {
            //TODO
        }

        public void SetVolume(float volume)
        {
            if (MediaPlayer == null)
                return;

            MediaPlayer.Volume = Math.Min(1, Math.Max(0, volume));
        }

        public void Stop()
        {
            MediaPlayer?.Stop();
            Seek(0);
        }
        #endregion
    }
}