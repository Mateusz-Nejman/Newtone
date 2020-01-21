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

namespace NSEC.Music_Player.Views.CustomViews
{
    public class SnackbarBuilder
    {
        public static void Show(string text)
        {
            var view = Global.Context.FindViewById(Android.Resource.Id.Content);
            var snack = Snackbar.Make(view, text, Snackbar.LengthLong);
            snack.Show();
        }
    }
}