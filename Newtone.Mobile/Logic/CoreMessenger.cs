using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Mobile.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.Logic
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
            SnackbarBuilder.Show(message);
        }
    }
}