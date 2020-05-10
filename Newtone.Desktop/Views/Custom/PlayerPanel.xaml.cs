using Newtone.Core;
using Newtone.Core.Media;
using Newtone.Desktop.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Newtone.Desktop.Views.Custom
{
    /// <summary>
    /// Logika interakcji dla klasy PlayerPanel.xaml
    /// </summary>
    public partial class PlayerPanel : UserControl
    {
        private Timer Timer { get; set; }
        private bool IsPlayImage = true;
        private string PlayedTrack = "";
        private PlayerMode playerMode = PlayerMode.All;
        public PlayerPanel()
        {
            InitializeComponent();

            Timer = new Timer();
            Timer.Elapsed += Timer_Elapsed;
            Timer.Interval = 500;
            Timer.Start();
            trackSlider.ValueChanged += TrackSlider_ValueChanged;
        }

        private void TrackSlider_ValueChanged(object sender, AudioSliderControl.ValueChangedArgs e)
        {
            if (GlobalData.MediaPlayer.IsPlaying)
            {
                GlobalData.MediaPlayer.Seek(e.Value);
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() => {
                if(PlayedTrack != GlobalData.MediaSourcePath)
                {
                    trackImage.Source = ImageProcessing.FromArray(GlobalData.MediaSource.Image ?? Properties.Resources.EmptyTrack);

                    backgroundImageGrid.Visibility = GlobalData.MediaSource.Image == null ? Visibility.Hidden : Visibility.Visible;

                    if(GlobalData.MediaSource.Image != null)
                    {
                        backgroundImage.Source = ImageProcessing.FromArray(GlobalData.MediaSource.Image);
                    }

                    PlayedTrack = GlobalData.MediaSourcePath;
                }
                if(IsPlayImage && GlobalData.MediaPlayer.IsPlaying)
                {
                    playButtonImage.Source = ImageProcessing.FromArray(Properties.Resources.PauseIcon);
                    IsPlayImage = false;
                }

                if(!IsPlayImage && !GlobalData.MediaPlayer.IsPlaying)
                {
                    playButtonImage.Source = ImageProcessing.FromArray(Properties.Resources.PlayIcon);
                    IsPlayImage = true;
                }
                if (GlobalData.MediaPlayer.IsPlaying)
                {
                    trackSlider.Max = GlobalData.MediaPlayer.Duration;
                    trackSlider.SetValue(GlobalData.MediaPlayer.CurrentPosition);
                    artistLabel.Text = GlobalData.MediaSource.Artist;
                    trackLabel.Text = GlobalData.MediaSource.Title;
                }

                if(GlobalData.PlayerMode != playerMode)
                {
                    if (GlobalData.PlayerMode == PlayerMode.All)
                        modeButtonImage.Source = ImageProcessing.FromArray(Properties.Resources.RepeatIcon);
                    else if (GlobalData.PlayerMode == PlayerMode.One)
                        modeButtonImage.Source = ImageProcessing.FromArray(Properties.Resources.RepeatOneIcon);
                    else
                        modeButtonImage.Source = ImageProcessing.FromArray(Properties.Resources.RandomIcon);

                    playerMode = GlobalData.PlayerMode;
                }
            });
        }
        private void ButtonPrev_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.MediaPlayer.Prev();
            if (!IsPlayImage)
                GlobalData.MediaPlayer.Play();
        }

        private void ButtonPlayPause_Click(object sender, RoutedEventArgs e)
        {
            if(GlobalData.MediaSource != null)
            {
                if (GlobalData.MediaPlayer.IsPlaying)
                    GlobalData.MediaPlayer.Pause();
                else
                    GlobalData.MediaPlayer.Play();
            }
            
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("ButtonNext");
            GlobalData.MediaPlayer.Next();
            if (!IsPlayImage)
                GlobalData.MediaPlayer.Play();
        }

        private void VolumeUp_Click(object sender, RoutedEventArgs e)
        {
            float currentVolume = GlobalData.MediaPlayer.GetVolume();

            currentVolume += 0.1f;

            if (currentVolume > 1f)
                currentVolume = 1f;

            GlobalData.MediaPlayer.SetVolume(currentVolume);

            GlobalData.SaveConfig();
        }

        private void VolumeDown_Click(object sender, RoutedEventArgs e)
        {
            float currentVolume = GlobalData.MediaPlayer.GetVolume();

            currentVolume -= 0.1f;

            if (currentVolume < 0)
                currentVolume = 0;

            GlobalData.MediaPlayer.SetVolume(currentVolume);

            GlobalData.SaveConfig();
        }

        private void ButtonMode_Click(object sender, RoutedEventArgs e)
        {
            int oldMode = (int)GlobalData.PlayerMode;
            int newMode = oldMode + 1;
            if (newMode == 3)
                newMode = 0;

            GlobalData.PlayerMode = (PlayerMode)newMode;
            GlobalData.SaveConfig();
        }

        private void ThumbButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetContainer(new FullScreenWindow());
        }
    }
}
