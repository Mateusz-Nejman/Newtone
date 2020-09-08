using Android.Support.V4.Media.Session;

namespace Newtone.Mobile.Media
{
    public static class MediaPlayerHelper
    {
        #region Public Methods
        public static void Play()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance)?.GetTransportControls()?.Play();
        }

        public static void Pause()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance)?.GetTransportControls()?.Pause();
        }

        public static void Stop()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance)?.GetTransportControls()?.Stop();
        }

        public static void Next()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance)?.GetTransportControls()?.SkipToNext();
        }

        public static void Prev()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance)?.GetTransportControls()?.SkipToPrevious();
        }
        #endregion
    }
}