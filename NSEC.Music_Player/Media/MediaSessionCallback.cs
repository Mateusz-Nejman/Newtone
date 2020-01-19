using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media.Session;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NSEC.Music_Player.Media
{
    public class MediaSessionCallback : MediaSession.Callback
    {
        public override void OnPlay()
        {
            base.OnPlay();
        }
    }

}