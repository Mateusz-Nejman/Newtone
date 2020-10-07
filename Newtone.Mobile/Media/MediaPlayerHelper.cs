using Android.Support.V4.Media.Session;
using Xamarin.Forms.Platform.Android;

namespace Newtone.Mobile.Media
{
    public static class MediaPlayerHelper
    {
        #region Public Methods
        public static void Play()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.Play();
        }

        public static void Pause()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.Pause();
        }

        public static void Stop()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.Stop();
        }

        public static void Next()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.SkipToNext();
        }

        public static void Prev()
        {
            MediaControllerCompat.GetMediaController(MainActivity.Instance ?? MediaPlayerService.Instance.GetActivity())?.GetTransportControls()?.SkipToPrevious();
        }
        #endregion
    }
}