using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newtone.Core.Media
{
    public interface IBasePlayer
    {
        bool GetIsPlaying();
        double GetDuration();
        double GetCurrentPosition();
        bool GetCanSeek();
        void Load(string filename);
        void Play();
        void Stop();
        void Pause();
        void Reset();
        void Seek(double seek);
        void SetVolume(float volume);
        float GetVolume();
        void SetNotification(MediaSource container);
        void Error(string text);
        void Prepare();
        void AfterPrev();
        void AfterNext();
    }
}
