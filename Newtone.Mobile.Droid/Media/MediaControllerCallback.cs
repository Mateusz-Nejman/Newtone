using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;

namespace Newtone.Mobile.Droid.Media
{
    public class MediaControllerCallback : MediaControllerCompat.Callback
    {
        #region Public Methods
        public override void OnMetadataChanged(MediaMetadataCompat metadata)
        {
            base.OnMetadataChanged(metadata);
        }

        public override void OnPlaybackStateChanged(PlaybackStateCompat state)
        {
            base.OnPlaybackStateChanged(state);
        }
        #endregion
    }
}