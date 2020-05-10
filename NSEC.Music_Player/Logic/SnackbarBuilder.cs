using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace NSEC.Music_Player.Logic
{
    public class SnackbarBuilder
    {
        public static void Show(string text)
        {
            Toast.MakeText(MainActivity.Instance, text, ToastLength.Short).Show();
        }
    }
}