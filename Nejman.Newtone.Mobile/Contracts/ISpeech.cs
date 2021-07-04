using System.Threading.Tasks;

namespace Nejman.Newtone.Mobile.Contracts
{
    public interface ISpeech
    {
        void Initialize();
        void StartSpeech();
        void OpenSearchPage(string search);
    }
}
