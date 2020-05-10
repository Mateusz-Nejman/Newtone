using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;
using Newtone.Core.Logic;

namespace NSEC.Music_Player.Media
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    [IntentFilter(new[] { "android.intent.action.MEDIA_BUTTON" })]
    public class NotificationButtonReceiver:MediaButtonReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            KeyEvent ev = (KeyEvent)intent.GetParcelableExtra(Intent.ExtraKeyEvent);

            if(ev.Action == KeyEventActions.Down)
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
}