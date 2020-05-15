using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.Media.Session;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;
using Nejman.NSEC2;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Processing;
using Xamarin.Forms;

namespace NSEC.Music_Player
{
    public static class Global
    {
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
    }
}