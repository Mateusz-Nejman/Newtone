using System.Threading.Tasks;

namespace Nejman.Newtone.Core.Contracts
{
    public interface IMediaPlayer
    {
        bool GetIsPlaying();
        double GetDuration();
        double GetCurrentPosition();
        bool GetCanSeek();
        Task Load(string path);
        void Play();
        void PlatformPlay();
        void Stop();
        void Pause();
        void Reset();
        void Seek(double seek);
        void SetVolume(float volume);
        float GetVolume();
        void Prepare();
        Task Prepared();
        void AfterPrev();
        void AfterNext();
    }
}
