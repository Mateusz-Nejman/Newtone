using System.Threading.Tasks;

namespace Nejman.Newtone.Core.Contracts
{
    public interface IMessage
    {
        void Show(string message);
        Task<string> Show(string title, string message, string accept, string cancel);
        Task<string> Show(string title, string cancel, string[] buttons);
        Task<string> ShowPrompt(string title, string message, string accept, string cancel, string placeholder, string initialValue);
    }
}
