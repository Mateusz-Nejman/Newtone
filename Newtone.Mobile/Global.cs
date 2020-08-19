﻿using System;
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
using Android.Support.V4.App;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;
using Nejman.NSEC2;
using Newtone.Core;
using Newtone.Mobile.Logic;
using Newtone.Mobile.Media;
using Newtone.Mobile.Models;
using Newtone.Mobile.Processing;
using Xamarin.Forms;

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
        public static NotificationCompat.CarExtender CarExtender { get; set; }
        public static int PlaybackState { get; set; }
        #endregion
        #region Public Methods
        public static void SetNotificationData(int state)
        {
            PlaybackState = state;
            MediaSession.SetMetadata(GlobalData.Current.MediaSource.ToMetadata());
            StateBuilder.SetState(state, (long)GlobalData.Current.MediaPlayer.CurrentPosition, 1.0f);
            MediaSession.SetPlaybackState(StateBuilder.Build());
        }
        #endregion
    }
}