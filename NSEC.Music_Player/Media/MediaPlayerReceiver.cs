using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NSEC.Music_Player.Media
{
    [Service]
    public class MediaPlayerReceiver : BroadcastReceiver
    {
        public MediaPlayerReceiver()
        {
        }

        public override void OnReceive(Context context, Intent intent)
        {

            if (intent.Action == "prev")
                Global.MediaPlayer.Prev();
            else if (intent.Action == "next")
                Global.MediaPlayer.Next();
            else if (intent.Action == "play")
                Global.MediaPlayer.Play();
            else if (intent.Action == "pause")
                Global.MediaPlayer.Pause();
            else if (intent.Action == "open")
            {

            }
            else if (intent.Action == "close")
            {
                Global.NotificationManager.CancelAll();
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            }
            Console.WriteLine("MediaPlayerReceiver " + intent.Action);
        }
    }
}