using NAudio.Wave;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Desktop.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Newtone.Desktop.Media
{
    public class DesktopMediaPlayer : IBasePlayer
    {
        private WaveOutEvent MediaPlayer { get; set; }
        private AudioFileReader CurrentFile { get; set; }
        public static bool IsStoppedByUser { get; set; }

        public DesktopMediaPlayer()
        {
            MediaPlayer = new WaveOutEvent();
            MediaPlayer.PlaybackStopped += MediaPlayer_PlaybackStopped;
        }

        private void MediaPlayer_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            //ConsoleDebug.WriteLine("Position: " + CurrentFile.Position);
            //ConsoleDebug.WriteLine("Length: " + CurrentFile.Length);
            //ConsoleDebug.WriteLine("Exception null: " + (e.Exception == null));
            Console.WriteLine("PlaybackStopped " + MediaPlayer.PlaybackState+" "+CurrentFile.Position);
            if(e.Exception == null && ((MediaPlayer.PlaybackState == PlaybackState.Playing && CurrentFile.Position > CurrentFile.Length - 2000) || (MediaPlayer.PlaybackState == PlaybackState.Stopped && CurrentFile.Position > CurrentFile.Length - 2000)))
            {
                CurrentFile.Position = 0;
                GlobalData.MediaPlayer.Next();
                GlobalData.MediaPlayer.Play();
            }
        }

        public void AfterNext()
        {
            
        }

        public void AfterPrev()
        {
            
        }

        public void Error(string text)
        {
            //ConsoleDebug.WriteLine(text);
        }

        public bool GetCanSeek()
        {
            return MediaPlayer != null;
        }

        public double GetCurrentPosition()
        {
            return CurrentFile != null ? CurrentFile.CurrentTime.TotalSeconds : 0; //TODO
        }

        public double GetDuration()
        {
            return CurrentFile.TotalTime.TotalSeconds; //TODO
        }

        public bool GetIsPlaying()
        {
            return CurrentFile != null && MediaPlayer.PlaybackState == PlaybackState.Playing;
        }

        public void Load(string filename)
        {
            Stop();
            Reset();
            CurrentFile = new AudioFileReader(filename);
        }

        public void Pause()
        {
            MediaPlayer.Pause();
        }

        public void Play()
        {
            MediaPlayer.Play();
        }

        public void Prepare()
        {
            MediaPlayer.Init(CurrentFile); //TODO
        }

        public void Reset()
        {
            if(CurrentFile != null)
                CurrentFile.Dispose();
            CurrentFile = null;
        }

        public void Seek(double seek)
        {
            //ConsoleDebug.WriteLine("Seek to " + TimeSpan.FromSeconds(seek).ToString());
            CurrentFile.SetPosition(seek);
        }

        public void SetNotification(MediaSource container)
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


    }
}
