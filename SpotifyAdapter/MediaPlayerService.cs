using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;

namespace SpotifyAdapter
{
    [Service]
    [IntentFilter(new String[] { "android.media.browse.MediaBrowserService" })]
    public class MediaPlayerService : MediaBrowserServiceCompat
    {
        #region Fields
        private PlaybackStateCompat.Builder stateBuilder;
        #endregion
        #region Properties
        public static MediaPlayerService Instance { get; set; }
        #endregion


        #region Public Methods
        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            return base.OnStartCommand(intent, flags, startId);
        }
        public override void OnCreate()
        {
            base.OnCreate();
            Instance = this;
            Console.WriteLine("[Android Media] Service OnCreate");

            MainActivity.MediaSession = new MediaSessionCompat(BaseContext, "newtone");
            var intent = new Intent(BaseContext, typeof(MainActivity));
            var pi = PendingIntent.GetActivity(BaseContext, 99 /*request code*/,
                         intent, PendingIntentFlags.UpdateCurrent);
            MainActivity.MediaSession.SetSessionActivity(pi);
            MainActivity.MediaSession.SetFlags(MediaSessionCompat.FlagHandlesTransportControls | MediaSessionCompat.FlagHandlesMediaButtons | MediaSessionCompat.FlagHandlesQueueCommands);
            MainActivity.MediaSession.SetCallback(new MediaSessionCallback());

            stateBuilder = new PlaybackStateCompat.Builder()
                .SetActions(PlaybackStateCompat.ActionPlay | PlaybackStateCompat.ActionPlayPause | PlaybackStateCompat.ActionPlayFromSearch | PlaybackStateCompat.ActionPlayFromUri
                | PlaybackStateCompat.ActionPrepare | PlaybackStateCompat.ActionPrepareFromSearch | PlaybackStateCompat.ActionPrepareFromUri);
        }
        public override BrowserRoot OnGetRoot(string clientPackageName, int clientUid, Bundle rootHints)
        {
            Console.WriteLine("[Android Media] Service OnGetRoot " + clientPackageName);
            Console.WriteLine("Query: "+rootHints.GetString("query", ""));
            var emptyBundle = new Bundle();
            emptyBundle.PutBoolean("android.media.browse.SEARCH_SUPPORTED", true);
            return new BrowserRoot("newtone root", emptyBundle);
        }

        public override void OnLoadChildren(string parentId, Result result)
        {

            //TODO
            Console.WriteLine("[Android Media] Service OnLoadChildren");

            result.SendResult(null);
        }
        #endregion
    }
}