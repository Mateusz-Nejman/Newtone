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
using Newtone.Core.Logic;

namespace Newtone.Mobile.Media
{
    public class MediaBrowserConnectionCallback:MediaBrowserCompat.ConnectionCallback
    {
        #region Public Methods
        public override void OnConnected()
        {
            base.OnConnected();
            ConsoleDebug.WriteLine("[Android Media] MeBroCoCa OnConnected");

            MediaSessionCompat.Token token = Global.MediaBrowser.SessionToken;

            MediaControllerCompat mediaController = new MediaControllerCompat(MainActivity.Instance, token);

            MediaControllerCompat.SetMediaController(MainActivity.Instance, mediaController);

            //TODO transport controls
            // Display the initial state
            MediaMetadataCompat metadata = mediaController.Metadata;
            PlaybackStateCompat pbState = mediaController.PlaybackState;

            // Register a Callback to stay in sync
            mediaController.RegisterCallback(Global.ControllerCallback);

        }
        #endregion
    }
}