using Android.Content;
using Android.Speech;
using Nejman.Newtone.Mobile;
using Nejman.Newtone.Mobile.Contracts;
using Nejman.Newtone.Mobile.ViewModels;
using Nejman.Newtone.Mobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nejman.Newtone.Droid.Implementations
{
    public class SpeechImplementation : ISpeech
    {
        public void Initialize()
        {
            //
        }

        public void OpenSearchPage(string search)
        {
            ShellHelpers.GoTo($"{nameof(SearchPage)}?{nameof(SearchViewModel.SearchQuery)}={search}");
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
                MainActivity.Handler.StartActivityForResult(voiceIntent, 100);

            }
            catch (ActivityNotFoundException)
            {
                Intent browserIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://market.android.com/details?id=com.google.android.googlequicksearchbox"));
                MainActivity.Handler.StartActivity(browserIntent);
            }
        }
    }
}