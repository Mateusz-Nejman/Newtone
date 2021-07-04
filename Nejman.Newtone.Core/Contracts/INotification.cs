using Nejman.Newtone.Core.Media;

namespace Nejman.Newtone.Core.Contracts
{
    public interface INotification
    {
        void Show(MediaSource mediaSource, bool isPlaying);
    }
}
