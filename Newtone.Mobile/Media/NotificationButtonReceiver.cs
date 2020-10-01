
using Android.App;
using Android.Content;
using Android.Views;
using AndroidX.Media.Session;

namespace Newtone.Mobile.Media
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    [IntentFilter(new[] { "android.intent.action.MEDIA_BUTTON" })]
    public class NotificationButtonReceiver:MediaButtonReceiver
    {
        #region Public Methods
        public override void OnReceive(Context context, Intent intent)
        {
            if(intent != null)
            {
                KeyEvent ev = (KeyEvent)intent.GetParcelableExtra(Intent.ExtraKeyEvent);

                if (ev == null)
                    return;

                if (ev.Action == KeyEventActions.Down)
                {
                    if (ev.KeyCode == Keycode.MediaPlay)
                    {
                        MediaPlayerHelper.Play();
                    }
                    else if (ev.KeyCode == Keycode.MediaPause)
                    {
                        MediaPlayerHelper.Pause();
                    }
                    else if (ev.KeyCode == Keycode.MediaPrevious)
                    {
                        MediaPlayerHelper.Prev();
                    }
                    else if (ev.KeyCode == Keycode.MediaNext)
                    {
                        MediaPlayerHelper.Next();
                    }
                }
            }
        }
        #endregion
    }
}