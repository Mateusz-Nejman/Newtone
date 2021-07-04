using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;
using AndroidX.Media;
using AndroidX.Media.Session;
using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nejman.Newtone.Droid.Media
{
    [Service]
    [IntentFilter(new String[] { "android.media.browse.MediaBrowserService" })]
    public class MediaPlayerService : MediaBrowserServiceCompat
    {
        #region Properties
        public static MediaPlayerService Instance { get; set; }
        #endregion


        #region Public Methods
        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            MediaButtonReceiver.HandleIntent(DroidGlobal.MediaSession, intent);

            return StartCommandResult.Sticky;
        }
        public override void OnCreate()
        {
            base.OnCreate();
            Instance = this;
            DroidGlobal.MediaSession = new MediaSessionCompat(BaseContext, "newtone");
            var intent = new Intent(BaseContext, typeof(MainActivity));
            var pi = PendingIntent.GetActivity(BaseContext, 99 /*request code*/,
                         intent, PendingIntentFlags.UpdateCurrent);
            DroidGlobal.MediaSession.SetSessionActivity(pi);
            DroidGlobal.MediaSession.SetFlags(MediaSessionCompat.FlagHandlesTransportControls | MediaSessionCompat.FlagHandlesMediaButtons | MediaSessionCompat.FlagHandlesQueueCommands);
            DroidGlobal.MediaSession.SetCallback(new MediaSessionCallback());

            DroidGlobal.MediaSession.SetPlaybackState(DroidGlobal.StateBuilder?.Build());
            SessionToken = DroidGlobal.MediaSession.SessionToken;
            NotificationImplementation.Current.Show(CoreGlobal.CurrentSource, CoreGlobal.MediaPlayer.IsPlaying);
        }
        public override BrowserRoot OnGetRoot(string clientPackageName, int clientUid, Bundle rootHints)
        {
            var emptyBundle = new Bundle();
            emptyBundle.PutBoolean("android.media.browse.SEARCH_SUPPORTED", true);
            return new BrowserRoot("newtone root", emptyBundle);
        }

        public override void OnLoadChildren(string parentId, Result result)
        {
            result.SendResult(null);
        }
        #endregion
    }
}