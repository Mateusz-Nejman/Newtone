using Newtone.Core;
using Newtone.Desktop.Logic;
using System.Windows;

namespace Newtone.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly static KeyboardListener listener = new KeyboardListener();
        public App()
        {
            listener.KeyUp += Listener_KeyUp;
        }

        private void Listener_KeyUp(object sender, RawKeyEventArgs args)
        {
            var key = args.Key;

            if (key == System.Windows.Input.Key.MediaPlayPause)
            {
                if (GlobalData.Current.MediaPlayer.IsPlaying)
                    GlobalData.Current.MediaPlayer.Pause();
                else
                    GlobalData.Current.MediaPlayer.Play();
            }
            else if (key == System.Windows.Input.Key.MediaStop)
            {
                GlobalData.Current.MediaPlayer.Stop();
            }
            else if (key == System.Windows.Input.Key.MediaNextTrack)
            {
                GlobalData.Current.MediaPlayer.Next();
                GlobalData.Current.MediaPlayer.Play();
            }
            else if (key == System.Windows.Input.Key.MediaPreviousTrack)
            {
                GlobalData.Current.MediaPlayer.Prev();
                GlobalData.Current.MediaPlayer.Play();
            }
        }
    }
}
