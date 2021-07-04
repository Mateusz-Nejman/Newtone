using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Nejman.Newtone.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nejman.Newtone.Droid.Implementations
{
    public class SnackbarImplementation : ISnackbar
    {
        public void Show(string message)
        {
            MainActivity.Handler.RunOnUiThread(() => Toast.MakeText(MainActivity.Handler, message, ToastLength.Short).Show());
        }
    }
}