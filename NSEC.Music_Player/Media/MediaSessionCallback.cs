using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;
using Newtone.Core;
using Newtone.Core.Logic;

namespace NSEC.Music_Player.Media
{
    public class MediaSessionCallback:MediaSessionCompat.Callback
    {
        public override void OnPlay()
        {
            ConsoleDebug.WriteLine("[Android Media] MeSeCa OnPlay");
            AudioManager am = (AudioManager)MainActivity.Instance.GetSystemService(Context.AudioService);

            AudioAttributes attrs = new AudioAttributes.Builder()
                .SetContentType(AudioContentType.Music).Build();

            Global.AudioFocusRequest = new AudioFocusRequestClass.Builder(AudioManager.AudiofocusGain)
                .SetOnAudioFocusChangeListener(Global.AudioFocusListener)
                .SetAudioAttributes(attrs)
                .Build();

            AudioFocusRequest result = am.RequestAudioFocus(Global.AudioFocusRequest);
            Console.Write("OnPlay result " + result);
            if(result == AudioFocusRequest.Granted)
            {
                MainActivity.Instance.StartService(new Intent(MainActivity.Instance, Java.Lang.Class.FromType(typeof(MediaPlayerService))));
                Global.MediaSession.Active = true;
                GlobalData.MediaPlayer.Play();
                MediaPlayerService.Instance.StartForeground(0, MediaPlayerService.Instance.GetNotification());
            }
                
        }

        public override void OnStop()
        {
            ConsoleDebug.WriteLine("[Android Media] MeSeCa OnStop");
            AudioManager am = (AudioManager)MainActivity.Instance.GetSystemService(Context.AudioService);
            am.AbandonAudioFocusRequest(Global.AudioFocusRequest);

            MediaPlayerService.Instance.StopSelf();
            Global.MediaSession.Active = false;
            GlobalData.MediaPlayer.Stop();
            MediaPlayerService.Instance.StopForeground(false);
        }

        public override void OnPause()
        {
            ConsoleDebug.WriteLine("[Android Media] MeSeCa OnPause");
            GlobalData.MediaPlayer.Pause();
            MediaPlayerService.Instance.StopForeground(false);
        }

        public override void OnSkipToNext()
        {
            ConsoleDebug.WriteLine("[Android Media] OnSkipToNext");
            GlobalData.MediaPlayer.Next();
        }

        public override void OnSkipToPrevious()
        {
            ConsoleDebug.WriteLine("[Android Media] OnSkipToPrev");
            GlobalData.MediaPlayer.Prev();
        }

        public override bool OnMediaButtonEvent(Intent mediaButtonEvent)
        {
            KeyEvent ev = (KeyEvent)mediaButtonEvent.GetParcelableExtra(Intent.ExtraKeyEvent);

            ConsoleDebug.WriteLine("[Android Media] OnMediaButtonEvent " + ev.Action);

            if(ev.Action == KeyEventActions.Up)
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
            
            return true;
        }
    }
}