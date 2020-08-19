using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Desktop.Media;
using Newtone.Desktop.Processing;
using Newtone.Desktop.Views;
using Newtone.Desktop.Views.Custom;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Newtone.Desktop.ViewModels.Custom
{
    public class PlayerPanelViewModel:PropertyChangedBase
    {
        #region Fields
        private Timer timer;
        private bool isPlayImage = true;
        private string playedTrack = "";
        private PlayerMode playerMode = PlayerMode.All;
        private ImageSource trackImage;
        private ImageSource playImage;
        private ImageSource modeImage;
        private Visibility spinnerVisibility = Visibility.Hidden;
        private Visibility playButtonVisibility = Visibility.Visible;
        private Visibility backgroundGridVisibility;
        private string artist;
        private string title;
        private double sliderMax;
        private double sliderValue;
        #endregion
        #region Properties
        public Visibility SpinnerVisibility
        {
            get => spinnerVisibility;
            set
            {
                spinnerVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility PlayButtonVisibility
        {
            get => playButtonVisibility;
            set
            {
                playButtonVisibility = value;
                OnPropertyChanged();
            }
        }
        public ImageSource TrackImage
        {
            get => trackImage;
            set
            {
                trackImage = value;
                OnPropertyChanged();
            }
        }
        public Visibility BackgroundGridVisibility
        {
            get => backgroundGridVisibility;
            set
            {
                backgroundGridVisibility = value;
                OnPropertyChanged();
            }
        }
        public ImageSource PlayButtonImage
        {
            get => playImage;
            set
            {
                playImage = value;
                OnPropertyChanged();
            }
        }
        public string Artist
        {
            get => artist;
            set
            {
                artist = value;
                OnPropertyChanged();
            }
        }
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public ImageSource ModeImage
        {
            get => modeImage;
            set
            {
                modeImage = value;
                OnPropertyChanged();
            }
        }
        public double SliderMax
        {
            get => sliderMax;
            set
            {
                sliderMax = value;
                OnPropertyChanged();
            }
        }
        public double SliderValue
        {
            get => sliderValue;
            set
            {
                sliderValue = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand previousTrack;
        public ICommand PreviousTrack
        {
            get
            {
                if (previousTrack == null)
                    previousTrack = new ActionCommand(parameter =>
                    {
                        GlobalData.Current.MediaPlayer.Prev();
                        if (!isPlayImage)
                            GlobalData.Current.MediaPlayer.Play();
                    });

                return previousTrack;
            }
        }
        private ICommand nextTrack;
        public ICommand NextTrack
        {
            get
            {
                if (nextTrack == null)
                    nextTrack = new ActionCommand(parameter =>
                    {
                        GlobalData.Current.MediaPlayer.Next();
                        if (!isPlayImage)
                            GlobalData.Current.MediaPlayer.Play();
                    });

                return nextTrack;
            }
        }
        private ICommand playOrPause;
        public ICommand PlayOrPause
        {
            get
            {
                if (playOrPause == null)
                    playOrPause = new ActionCommand(parameter =>
                    {
                        if (GlobalData.Current.MediaSource != null)
                        {
                            if (GlobalData.Current.MediaPlayer.IsPlaying)
                                GlobalData.Current.MediaPlayer.Pause();
                            else
                                GlobalData.Current.MediaPlayer.Play();
                        }
                    });

                return playOrPause;
            }
        }
        private ICommand volumeUp;
        public ICommand VolumeUp
        {
            get
            {
                if (volumeUp == null)
                    volumeUp = new ActionCommand(parameter =>
                    {
                        float currentVolume = GlobalData.Current.MediaPlayer.GetVolume();

                        currentVolume += 0.1f;

                        if (currentVolume > 1f)
                            currentVolume = 1f;

                        GlobalData.Current.MediaPlayer.SetVolume(currentVolume);

                        GlobalData.Current.SaveConfig();
                    });
                return volumeUp;
            }
        }
        private ICommand volumeDown;
        public ICommand VolumeDown
        {
            get
            {
                if (volumeDown == null)
                    volumeDown = new ActionCommand(parameter =>
                    {
                        float currentVolume = GlobalData.Current.MediaPlayer.GetVolume();

                        currentVolume -= 0.1f;

                        if (currentVolume < 0)
                            currentVolume = 0;

                        GlobalData.Current.MediaPlayer.SetVolume(currentVolume);

                        GlobalData.Current.SaveConfig();
                    });
                return volumeDown;
            }
        }
        private ICommand changeMode;
        public ICommand ChangeMode
        {
            get
            {
                if (changeMode == null)
                    changeMode = new ActionCommand(parameter =>
                    {
                        int oldMode = (int)GlobalData.Current.PlayerMode;
                        int newMode = oldMode + 1;
                        if (newMode == 3)
                            newMode = 0;

                        GlobalData.Current.PlayerMode = (PlayerMode)newMode;
                        GlobalData.Current.SaveConfig();
                    });
                return changeMode;
            }
        }
        private ICommand gotoPlayer;
        public ICommand GotoPlayer
        {
            get
            {
                if (gotoPlayer == null)
                    gotoPlayer = new ActionCommand(parameter =>
                    {
                        MainWindow.Instance.SetContainer(new FullScreenWindow());
                    });
                return gotoPlayer;
            }
        }
        #endregion
        #region Constructors
        public PlayerPanelViewModel()
        {
            timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 200;
            timer.Start();
            PlayButtonImage = ImageProcessing.FromArray(Properties.Resources.PlayIcon);

        }
        #endregion
        #region Private Methods
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MainWindow.MainDispatcher.Invoke(() => {
                try
                {
                    SpinnerVisibility = (!(GlobalData.Current.MediaPlayer.BasePlayer as DesktopMediaPlayer).IsPrepared) && GlobalData.Current.MediaSource != null ? Visibility.Visible : Visibility.Hidden;
                    PlayButtonVisibility = (GlobalData.Current.MediaPlayer.BasePlayer as DesktopMediaPlayer).IsPrepared || GlobalData.Current.MediaSource == null ? Visibility.Visible : Visibility.Hidden;
                    if (playedTrack != GlobalData.Current.MediaSourcePath)
                    {
                        TrackImage = ImageProcessing.FromArray(GlobalData.Current.MediaSource.Image ?? Properties.Resources.EmptyTrack);

                        BackgroundGridVisibility = GlobalData.Current.MediaSource.Image == null ? Visibility.Hidden : Visibility.Visible;

                        playedTrack = GlobalData.Current.MediaSourcePath;
                    }
                    if (isPlayImage && GlobalData.Current.MediaPlayer.IsPlaying)
                    {
                        PlayButtonImage = ImageProcessing.FromArray(Properties.Resources.PauseIcon);
                        isPlayImage = false;
                    }

                    if (!isPlayImage && !GlobalData.Current.MediaPlayer.IsPlaying)
                    {
                        PlayButtonImage = ImageProcessing.FromArray(Properties.Resources.PlayIcon);
                        isPlayImage = true;
                    }
                    if (GlobalData.Current.MediaPlayer.IsPlaying)
                    {
                        Artist = GlobalData.Current.MediaSource.Artist;
                        Title = GlobalData.Current.MediaSource.Title;
                    }
                    if (GlobalData.Current.MediaSource != null)
                    {
                        SliderMax = GlobalData.Current.MediaPlayer.Duration;
                        SliderValue = GlobalData.Current.MediaPlayer.CurrentPosition;
                    }

                    if (GlobalData.Current.PlayerMode != playerMode)
                    {
                        if (GlobalData.Current.PlayerMode == PlayerMode.All)
                            ModeImage = ImageProcessing.FromArray(Properties.Resources.RepeatIcon);
                        else if (GlobalData.Current.PlayerMode == PlayerMode.One)
                            ModeImage = ImageProcessing.FromArray(Properties.Resources.RepeatOneIcon);
                        else
                            ModeImage = ImageProcessing.FromArray(Properties.Resources.RandomIcon);

                        playerMode = GlobalData.Current.PlayerMode;
                    }
                }
                catch
                {

                }
            });
        }
        #endregion
    }
}
