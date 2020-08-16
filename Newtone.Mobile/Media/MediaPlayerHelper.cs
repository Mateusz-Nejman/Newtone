using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;
using Newtone.Core.Logic;

namespace Newtone.Mobile.Media
{
    public static class MediaPlayerHelper
    {
        #region Public Methods
        public static void Play()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance)?.GetTransportControls()?.Play();
        }

        public static void Pause()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance)?.GetTransportControls()?.Pause();
        }

        public static void Stop()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance)?.GetTransportControls()?.Stop();
        }

        public static void Next()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance)?.GetTransportControls()?.SkipToNext();
        }

        public static void Prev()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance)?.GetTransportControls()?.SkipToPrevious();
        }
        #endregion
    }
}