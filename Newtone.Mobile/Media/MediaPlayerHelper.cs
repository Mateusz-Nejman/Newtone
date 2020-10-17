using Android.Support.V4.Media.Session;
using Xamarin.Forms.Platform.Android;

namespace Newtone.Mobile.Media
{
    public static class MediaPlayerHelper
    {
        #region Public Methods
        public static void Play()
        {
            if (CanBeUsed())
                MediaControllerCompat.GetMediaController(MainActivity.Instance ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.Play();
        }

        public static void Pause()
        {
            if (CanBeUsed())
                MediaControllerCompat.GetMediaController(MainActivity.Instance ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.Pause();
        }

        public static void Stop()
        {
            if (CanBeUsed())
                MediaControllerCompat.GetMediaController(MainActivity.Instance ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.Stop();
        }

        public static void Next()
        {
            if (CanBeUsed())
                MediaControllerCompat.GetMediaController(MainActivity.Instance ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.SkipToNext();
        }

        public static void Prev()
        {
            if (CanBeUsed())
                MediaControllerCompat.GetMediaController(MainActivity.Instance ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.SkipToPrevious();
        }

        private static bool CanBeUsed()
        {
            return MainActivity.Instance != null || MediaPlayerService.Instance?.GetActivity() != null;
        }
        #endregion
    }
}