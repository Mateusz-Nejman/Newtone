using Android.Media;
using Android.Runtime;
using Newtone.Core;

namespace Newtone.Mobile.Media
{
    public class AudioFocusListener : Java.Lang.Object, AudioManager.IOnAudioFocusChangeListener
    {
        #region Public Methods
        public void OnAudioFocusChange([GeneratedEnum] AudioFocus focusChange)
        {
            if (GlobalData.Current.MediaPlayer != null && !GlobalData.Current.IgnoreAutoFocus)
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