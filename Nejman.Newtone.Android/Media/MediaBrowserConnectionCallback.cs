using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;

namespace Nejman.Newtone.Droid.Media
{
    public class MediaBrowserConnectionCallback : MediaBrowserCompat.ConnectionCallback
    {
        #region Public Methods
        public override void OnConnected()
        {
            base.OnConnected();
            MediaSessionCompat.Token token = DroidGlobal.MediaBrowser.SessionToken;
            MediaControllerCompat mediaController = new MediaControllerCompat(MainActivity.Handler, token);
            MediaControllerCompat.SetMediaController(MainActivity.Handler, mediaController);

            mediaController.RegisterCallback(DroidGlobal.ControllerCallback);

        }
        #endregion
    }
}