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
    public class MediaControllerCallback:MediaControllerCompat.Callback
    {
        #region Public Methods
        public override void OnMetadataChanged(MediaMetadataCompat metadata)
        {
            base.OnMetadataChanged(metadata);
            ConsoleDebug.WriteLine("[Android Media] MeCoCa OnMetadataChanged");
        }

        public override void OnPlaybackStateChanged(PlaybackStateCompat state)
        {
            base.OnPlaybackStateChanged(state);
            ConsoleDebug.WriteLine("[Android Media] MeCoCa OnPlaybackStateChanged");
        }
        #endregion
    }
}