using System.Threading.Tasks;

namespace Newtone.Core.Speech
{
    public interface ISpeechBase
    {
        void Initialize();
        void StartSpeech();
        Task OpenSearchPageAsync(string search);
    }
}
