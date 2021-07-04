using System.Threading.Tasks;

namespace Newtone.Core.Speech
{
    public interface ITalkBase
    {
        void Talk(string text);
        Task TalkAsync(string text);
    }
}
