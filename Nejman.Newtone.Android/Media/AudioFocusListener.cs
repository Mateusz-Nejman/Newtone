using Android.Media;
using Android.Runtime;
using Nejman.Newtone.Core;
using Nejman.Newtone.Mobile;

namespace Nejman.Newtone.Droid.Media
{
    public class AudioFocusListener : Java.Lang.Object, AudioManager.IOnAudioFocusChangeListener
    {
        #region Public Methods
        public void OnAudioFocusChange([GeneratedEnum] AudioFocus focusChange)
        {
            if (!Global.TV)
            {
                if (focusChange == AudioFocus.Loss && CoreGlobal.MediaPlayer.CurrentPosition > 10)
                {
                    MediaPlayerHelper.Pause();
                }

                if (focusChange == AudioFocus.LossTransientCanDuck)
                {
                    CoreGlobal.MediaPlayer.SetVolume(0.1f);
                }

                if (focusChange == AudioFocus.Gain)
                {
                    CoreGlobal.MediaPlayer.SetVolume(1f);
                    
                    if(!CoreGlobal.MediaPlayer.IsPlaying)
                    {
                        CoreGlobal.MediaPlayer.Play();
                    }
                }

                if (focusChange == AudioFocus.LossTransient)
                {
                    MediaPlayerHelper.Pause();
                }
            }
        }
        #endregion
    }
}