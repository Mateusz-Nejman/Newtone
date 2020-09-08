using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;

namespace Newtone.Mobile.Media
{
    public class MediaBrowserConnectionCallback:MediaBrowserCompat.ConnectionCallback
    {
        #region Public Methods
        public override void OnConnected()
        {
            base.OnConnected();
            MediaSessionCompat.Token token = Global.MediaBrowser.SessionToken;
            MediaControllerCompat mediaController = new MediaControllerCompat(MainActivity.Instance, token);
            MediaControllerCompat.SetMediaController(MainActivity.Instance, mediaController);
            MediaMetadataCompat metadata = mediaController.Metadata;
            PlaybackStateCompat pbState = mediaController.PlaybackState;

            // Register a Callback to stay in sync
            mediaController.RegisterCallback(Global.ControllerCallback);

        }
        #endregion
    }
}