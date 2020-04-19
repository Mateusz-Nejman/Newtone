using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NSEC.Music_Player.Views.Custom.Gestures
{
    public class PressGestureMask : Xamarin.Forms.Image
    {
        public event EventHandler LongPressed;
        public event EventHandler Pressed;

        public void HandleLongPress(object sender, EventArgs e)
        {
            LongPressed?.Invoke(sender, e);

        }

        public void HandlePress(object sender, EventArgs e)
        {
            Pressed?.Invoke(sender, e);

        }
    }
}