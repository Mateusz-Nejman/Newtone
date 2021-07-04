using Android.Content;
using Android.Net;
using Android.Speech;
using Newtone.Core.Speech;
using Newtone.Mobile.UI.Views;
using System.Threading.Tasks;

namespace Newtone.Mobile.Droid.Speech
{
    public class SpeechDroid : ISpeechBase
    {
        public void Initialize()
        {
            //
        }

        public async Task OpenSearchPageAsync(string search)
        {
            await UI.Global.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(search), search));
        }

        public void StartSpeech()
        {
            try
            {
                var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
                voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "W czym mogę pomóc?");
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
                voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
                MainActivity.Instance.StartActivityForResult(voiceIntent, 100);

            }
            catch (ActivityNotFoundException)
            {
                Intent browserIntent = new Intent(Intent.ActionView,Uri.Parse("https://market.android.com/details?id=com.google.android.googlequicksearchbox"));
                MainActivity.Instance.StartActivity(browserIntent);
            }
        }
    }
}