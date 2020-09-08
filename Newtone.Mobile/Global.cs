
using Android.App;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Newtone.Mobile.Media;

namespace Newtone.Mobile
{
    public static class Global
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
        #endregion
    }
}