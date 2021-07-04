using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;
using Nejman.Newtone.Core;
using Nejman.Newtone.Mobile.Implementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nejman.Newtone.Droid.Media
{
    public class MediaSessionCallback : MediaSessionCompat.Callback
    {
        #region Public Methods
        public override void OnPlay()
        {
            AudioManager am = (AudioManager)MainActivity.Handler.GetSystemService(Context.AudioService);

            AudioAttributes attrs = new AudioAttributes.Builder()
                .SetContentType(AudioContentType.Music).Build();

            DroidGlobal.AudioFocusRequest = new AudioFocusRequestClass.Builder(AudioFocus.Gain)
                .SetOnAudioFocusChangeListener(DroidGlobal.AudioFocusListener)
                .SetAudioAttributes(attrs)
                .Build();

            AudioFocusRequest result = am.RequestAudioFocus(DroidGlobal.AudioFocusRequest);
            if (result == AudioFocusRequest.Granted)
            {
                try
                {
                    if (MediaPlayerService.Instance == null)
                        MainActivity.Handler.ApplicationContext.StartForegroundServiceCompat<MediaPlayerService>();
                    DroidGlobal.MediaSession.Active = true;
                    CoreGlobal.MediaPlayer.Play();
                }
                catch (System.Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("MediaSessionCallback OnPlay Exception " + e);
                    StreamWriter streamWriter = new StreamWriter(CoreGlobal.MusicPath + "/log.txt", true);
                    streamWriter.WriteLine("ERROR from MediaSessionCallback " + DateTime.Now.ToString());
                    streamWriter.WriteLine("Exception: " + e.Message);
                    streamWriter.WriteLine("StackTrace: " + e.StackTrace);
                    streamWriter.WriteLine("Source: " + e.Source);
                    streamWriter.WriteLine("ERROR END");
                    streamWriter.Close();
                }
            }

        }

        public override void OnPlayFromSearch(string query, Bundle extras)
        {
            Task.Run(async () => await SpeechImplementation.Process(query));
        }

        public override void OnStop()
        {
            AudioManager am = (AudioManager)MainActivity.Handler.GetSystemService(Context.AudioService);
            if (DroidGlobal.AudioFocusRequest != null)
                am.AbandonAudioFocusRequest(DroidGlobal.AudioFocusRequest);

            DroidGlobal.MediaSession.Active = false;
            CoreGlobal.MediaPlayer.Pause();
        }

        public override void OnPause()
        {
            CoreGlobal.MediaPlayer.Pause();
        }

        public override void OnSkipToNext()
        {
            Task.Run(async() => await CoreGlobal.MediaPlayer.Next());
        }

        public override void OnSkipToPrevious()
        {
            Task.Run(async() => await CoreGlobal.MediaPlayer.Prev());
        }

        public override bool OnMediaButtonEvent(Intent mediaButtonEvent)
        {
            KeyEvent ev = (KeyEvent)mediaButtonEvent.GetParcelableExtra(Intent.ExtraKeyEvent);

            if (ev.Action == KeyEventActions.Up)
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
        #endregion
    }
}