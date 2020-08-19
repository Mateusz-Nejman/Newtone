﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;
using Java.Util;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Mobile.Processing;
using static Android.Support.V4.Media.App.NotificationCompat;
using static Android.Support.V4.Media.MediaBrowserCompat;

namespace Newtone.Mobile.Media
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
            MediaButtonReceiver.HandleIntent(Global.MediaSession, intent);
            return base.OnStartCommand(intent, flags, startId);
        }
        public override void OnCreate()
        {
            base.OnCreate();
            Instance = this;
            ConsoleDebug.WriteLine("[Android Media] Service OnCreate");

            Global.MediaSession = new MediaSessionCompat(BaseContext, "newtone");
            var intent = new Intent(BaseContext, typeof(MainActivity));
            var pi = PendingIntent.GetActivity(BaseContext, 99 /*request code*/,
                         intent, PendingIntentFlags.UpdateCurrent);
            Global.MediaSession.SetSessionActivity(pi);
            Global.MediaSession.SetFlags(MediaSessionCompat.FlagHandlesTransportControls | MediaSessionCompat.FlagHandlesMediaButtons | MediaSessionCompat.FlagHandlesQueueCommands);
            Global.MediaSession.SetCallback(new MediaSessionCallback());

            stateBuilder = new PlaybackStateCompat.Builder()
                .SetActions(PlaybackStateCompat.ActionPlay | PlaybackStateCompat.ActionPlayPause | PlaybackStateCompat.ActionPlayFromSearch | PlaybackStateCompat.ActionPlayFromUri
                | PlaybackStateCompat.ActionPrepare | PlaybackStateCompat.ActionPrepareFromSearch | PlaybackStateCompat.ActionPrepareFromUri);

            Global.MediaSession.SetPlaybackState(stateBuilder.Build());

            //TODO SetCallback

            SessionToken = Global.MediaSession.SessionToken;
        }
        public override BrowserRoot OnGetRoot(string clientPackageName, int clientUid, Bundle rootHints)
        {
            ConsoleDebug.WriteLine("[Android Media] Service OnGetRoot "+clientPackageName);
            var emptyBundle = new Bundle();
            emptyBundle.PutBoolean("android.media.browse.SEARCH_SUPPORTED", true);
            return new BrowserRoot("newtone root", rootHints);
        }

        public override void OnLoadChildren(string parentId, Result result)
        {

            //TODO
            ConsoleDebug.WriteLine("[Android Media] Service OnLoadChildren");

            result.SendResult(null);
        }

        public Notification GetNotification()
        {
            if(Global.MediaSession != null && Global.MediaSession.Controller != null && GlobalData.Current.MediaSource != null)
            {
                MediaControllerCompat controller = Global.MediaSession.Controller;

                NotificationCompat.Builder builder = new NotificationCompat.Builder(BaseContext, "newtone");

                Bitmap bitmap;

                if (GlobalData.Current.MediaSource.Image == null || GlobalData.Current.MediaSource.Image.Length == 0)
                    bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.EmptyTrack);
                else
                    bitmap = BitmapFactory.DecodeByteArray(GlobalData.Current.MediaSource.Image, 0, GlobalData.Current.MediaSource.Image.Length);
                builder
                    .SetContentTitle(GlobalData.Current.MediaSource.Title)
                    .SetContentText(GlobalData.Current.MediaSource.Artist)

                    .SetContentIntent(controller.SessionActivity)
                    .SetDeleteIntent(MediaButtonReceiver.BuildMediaButtonPendingIntent(BaseContext, PlaybackStateCompat.ActionStop))
                    .SetVisibility(NotificationCompat.VisibilityPublic)
                    .SetSmallIcon(Resource.Drawable.PlayIconNotification)
                    .SetOngoing(true)
                    .SetLargeIcon(bitmap)
                    .AddAction(new NotificationCompat.Action(Resource.Drawable.PrevIconNotification, "prev", MediaButtonReceiver.BuildMediaButtonPendingIntent(BaseContext, PlaybackStateCompat.ActionSkipToPrevious)))
                    .AddAction(new NotificationCompat.Action(Global.PlaybackState == PlaybackStateCompat.StatePlaying ? Resource.Drawable.PauseIconNotification : Resource.Drawable.PlayIconNotification, "pause", MediaButtonReceiver.BuildMediaButtonPendingIntent(BaseContext, Global.PlaybackState == PlaybackStateCompat.StatePlaying ? PlaybackStateCompat.ActionPause : PlaybackStateCompat.ActionPlay)))
                    .AddAction(new NotificationCompat.Action(Resource.Drawable.NextIconNotification, "next", MediaButtonReceiver.BuildMediaButtonPendingIntent(BaseContext, PlaybackStateCompat.ActionSkipToNext)))
                    .SetStyle(new MediaStyle()
                    .SetMediaSession(Global.MediaSession.SessionToken)
                    .SetShowActionsInCompactView(0)
                    .SetShowCancelButton(true)
                    .SetCancelButtonIntent(MediaButtonReceiver.BuildMediaButtonPendingIntent(BaseContext, PlaybackStateCompat.ActionStop)));

                return builder.Build();
            }

            return null;
        }
        public void ShowNotification()
        {
            var n = GetNotification();
            if (n != null)
            {
                StartForeground(0, n);
                Global.NotificationManager?.Notify(0, n);
            }
            
        }
        #endregion
    }
}