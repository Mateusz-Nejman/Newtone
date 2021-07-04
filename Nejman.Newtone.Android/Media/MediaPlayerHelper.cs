using Android.Support.V4.Media.Session;
using Xamarin.Forms.Platform.Android;

namespace Nejman.Newtone.Droid.Media
{
    public static class MediaPlayerHelper
    {
        #region Public Methods
        public static void Play()
        {
            if(!CanBeUsed())
            {
                return;
            }
            
            MediaControllerCompat.GetMediaController(MainActivity.Handler ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.Play();
        }

        public static void Pause()
        {
            if (!CanBeUsed())
            {
                return;
            }

            MediaControllerCompat.GetMediaController(MainActivity.Handler ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.Pause();
        }

        public static void Stop()
        {
            if (!CanBeUsed())
            {
                return;
            }

            MediaControllerCompat.GetMediaController(MainActivity.Handler ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.Stop();
        }

        public static void Next()
        {
            if (!CanBeUsed())
            {
                return;
            }

            MediaControllerCompat.GetMediaController(MainActivity.Handler ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.SkipToNext();
        }

        public static void Prev()
        {
            if (!CanBeUsed())
            {
                return;
            }

            MediaControllerCompat.GetMediaController(MainActivity.Handler ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.SkipToPrevious();
        }

        private static bool CanBeUsed()
        {
            return MainActivity.Handler != null || MediaPlayerService.Instance?.GetActivity() != null;
        }
        #endregion
    }
}