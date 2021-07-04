using Nejman.Newtone.Core.Contracts;
using System;
using Android.Media;
using System.Threading.Tasks;
using Nejman.Newtone.Core;
using Nejman.Newtone.Droid.Media;

namespace Nejman.Newtone.Droid.Implementations
{
    internal class MediaPlayerImplementation : IMediaPlayer
    {
        #region Fields
        private bool checkSafeTime = true;
        private bool prepared = false;
        #endregion
        #region Properties
        private MediaPlayer MediaPlayer { get; set; }
        #endregion
        #region Constructors
        public MediaPlayerImplementation()
        {
            MediaPlayer = new MediaPlayer();
            MediaPlayer.SetAudioStreamType(Stream.Music);
            MediaPlayer.Completion += MediaPlayer_Completion;
            MediaPlayer.Prepared += MediaPlayer_Prepared;
        }
        #endregion
        #region Private Methods
        private async void MediaPlayer_Prepared(object sender, EventArgs e)
        {
            await Prepared();
            prepared = true;
            Seek(0);
        }

        private async void MediaPlayer_Completion(object sender, EventArgs e)
        {
            Console.WriteLine("Completion " + MediaPlayer.CurrentPosition + " " + (!checkSafeTime) + " " + prepared);
            if (MediaPlayer.CurrentPosition > 0 && prepared)
                await CoreGlobal.MediaPlayer.Next();
        }

        private void UpdateMetadata()
        {
            DroidGlobal.MediaSession.SetMetadata(CoreGlobal.CurrentSource?.ToMetadata());
            DroidGlobal.MediaSession.SetPlaybackState(DroidGlobal.StateBuilder?.Build());
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
            return MediaPlayer != null;
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

        public async Task Load(string path)
        {
            checkSafeTime = true;
            prepared = false;
            MediaPlayer.Reset();
            await MediaPlayer.SetDataSourceAsync(path);
        }

        public void Pause()
        {
            MediaPlayer.Pause();
        }

        public void PlatformPlay()
        {
            MediaPlayerHelper.Play();
        }

        public void Play()
        {
            MediaPlayer.Start();
        }

        public void Prepare()
        {
            MediaPlayer.PrepareAsync();
        }

        public async Task Prepared()
        {
            await CoreGlobal.MediaPlayer.CurrentController.Prepared(CoreGlobal.MediaPlayer);
        }

        public void Reset()
        {
            MediaPlayer.Reset();
        }

        public void Seek(double seek)
        {
            MediaPlayer.SeekTo((int)seek * 1000);
        }

        public void SetVolume(float volume)
        {
            MediaPlayer.SetVolume(volume, volume);
        }

        public void Stop()
        {
            MediaPlayer?.Stop();
        }
        #endregion
    }
}