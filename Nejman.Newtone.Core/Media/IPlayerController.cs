using System.Threading.Tasks;

namespace Nejman.Newtone.Core.Media
{
    public interface IPlayerController
    {
        Task Load(MediaPlayer player, string path);
        Task Loaded(MediaPlayer player);
        Task Prepared(MediaPlayer player);
        Task Completed(MediaPlayer player);
    }
}
