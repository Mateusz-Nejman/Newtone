using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;

namespace NSEC.Music_Player.Media
{
    public class AudioFocusListener : Java.Lang.Object, AudioManager.IOnAudioFocusChangeListener
    {

        public void OnAudioFocusChange([GeneratedEnum] AudioFocus focusChange)
        {
            ///TODO
            Console.WriteLine("OnAudioFocusChange " + focusChange.ToString());

            if(Global.MediaPlayer != null)
            {
                if (focusChange == AudioFocus.Loss)
                    Global.MediaPlayer.Stop();

                if (focusChange == AudioFocus.LossTransient)
                    Global.MediaPlayer.SetVolume(0.1f);

                if (focusChange > 0)
                    Global.MediaPlayer.SetVolume(1f);
            }
        }
    }
}