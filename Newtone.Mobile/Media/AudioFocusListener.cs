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
using Newtone.Core;
using Newtone.Core.Logic;

namespace Newtone.Mobile.Media
{
    public class AudioFocusListener : Java.Lang.Object, AudioManager.IOnAudioFocusChangeListener
    {
        #region Public Methods
        public void OnAudioFocusChange([GeneratedEnum] AudioFocus focusChange)
        {
            ConsoleDebug.WriteLine("[Android Media] OnAudioFocusChange " + focusChange);
            if (GlobalData.Current.MediaPlayer != null)
            {
                if (focusChange == AudioFocus.Loss && GlobalData.Current.MediaPlayer.CurrentPosition > 10)
                    MediaPlayerHelper.Pause();

                if (focusChange == AudioFocus.LossTransientCanDuck)
                    GlobalData.Current.MediaPlayer.SetVolume(0.1f);

                if (focusChange == AudioFocus.Gain)
                    GlobalData.Current.MediaPlayer.SetVolume(1f);

                if (focusChange == AudioFocus.LossTransient)
                    MediaPlayerHelper.Pause();
            }
        }
        #endregion
    }
}