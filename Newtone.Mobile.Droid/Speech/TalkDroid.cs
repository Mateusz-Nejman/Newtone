using Newtone.Core.Speech;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Newtone.Mobile.Droid.Speech
{
    public class TalkDroid : ITalkBase
    {
        public void Talk(string text)
        {
            Task.Run(async () => await TalkAsync(text));
        }

        public async Task TalkAsync(string text)
        {
            await TextToSpeech.SpeakAsync(text);
        }
    }
}