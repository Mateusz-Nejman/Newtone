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
        void SetNotification(bool isPlaying);
        void Prepare();
        void Prepared(CrossPlayer player);
        void AfterPrev();
        void AfterNext();
    }
}
