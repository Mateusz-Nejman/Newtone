using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.Logic
{
    public class CoreMessenger : ICoreMessage
    {
        public void ShowError(string message)
        {
            ShowMessage(message);
        }

        public void ShowMessage(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await NormalPage.Instance.DisplayAlert(Localization.Warning, message, "OK");
            });
        }

        public void ShowSnackbar(string message)
        {
            Global.Application.ShowSnackbar(message);
        }
    }
}
