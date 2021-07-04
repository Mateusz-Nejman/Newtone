﻿using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;
using Nejman.Newtone.Droid.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nejman.Newtone.Droid
{
    internal static class DroidGlobal
    {
        #region Properties
        public static MediaBrowserCompat MediaBrowser { get; set; }
        public static MediaSessionCompat MediaSession { get; set; }
        public static MediaBrowserCompat.ConnectionCallback ConnectionCallback { get; set; }
        public static MediaControllerCompat.Callback ControllerCallback { get; set; }
        public static AudioFocusRequestClass AudioFocusRequest { get; set; }
        public static AudioFocusListener AudioFocusListener { get; set; }
        public static NotificationManager NotificationManager { get; set; }
        public static PlaybackStateCompat.Builder StateBuilder { get; set; }
        public static MediaMetadataCompat.Builder MetadataBuilder { get; set; }
        public static ConnectivityManager ConnectivityManager { get; set; }
        public static PowerManager PowerManager { get; set; }
        public static PowerManager.WakeLock WakeLock { get; set; }
        public static AssetManager AssetManager { get; set; }
        #endregion
    }
}