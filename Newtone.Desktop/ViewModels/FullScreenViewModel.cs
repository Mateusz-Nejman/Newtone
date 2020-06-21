using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Desktop.Processing;
using Newtone.Desktop.Views;
using Newtone.Desktop.Views.Custom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using static Newtone.Desktop.ViewModels.MainViewModel;

namespace Newtone.Desktop.ViewModels
{
    public class FullScreenViewModel : PropertyChangedBase
    {
        #region Fields
        private ImageSource image;
        private ImageSource maximizeIcon;
        private ImageSource playIcon;
        private ImageSource modeIcon;
        private string title;
        private string artist;
        private string timeCurrent;
        private string timeMax;
        private Visibility backgroudGridVisibility;
        private double trackSliderMax;
        private double trackSliderValue;

        private bool isPlayImage = true;
        private string playedTrack = "";
        private PlayerMode playerMode = PlayerMode.All;
        private Timer timer;
        #endregion
        #region Properties
        public ImageSource Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged(() => Image);
            }
        }

        public ImageSource MaximizeIcon
        {
            get => maximizeIcon;
            set
            {
                maximizeIcon = value;
                OnPropertyChanged(() => MaximizeIcon);
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(() => Title);
            }
        }

        public string Artist
        {
            get => artist;
            set
            {
                artist = value;
                OnPropertyChanged(() => Artist);
            }
        }

        public Visibility BackgroundGridVisibility
        {
            get => backgroudGridVisibility;
            set
            {
                backgroudGridVisibility = value;
                OnPropertyChanged(() => BackgroundGridVisibility);
            }
        }

        public ImageSource PlayIcon
        {
            get => playIcon;
            set
            {
                playIcon = value;
                OnPropertyChanged(() => PlayIcon);
            }
        }

        public ImageSource ModeIcon
        {
            get => modeIcon;
            set
            {
                modeIcon = value;
                OnPropertyChanged(() => ModeIcon);
            }
        }

        public string TimeCurrent
        {
            get => timeCurrent;
            set
            {
                timeCurrent = value;
                OnPropertyChanged(() => TimeCurrent);
            }
        }

        public string TimeMax
        {
            get => timeMax;
            set
            {
                timeMax = value;
                OnPropertyChanged(() => TimeMax);
            }
        }

        public double TrackSliderMax
        {
            get => trackSliderMax;
            set
            {
                trackSliderMax = value;
                OnPropertyChanged(() => TrackSliderMax);
            }
        }

        public double TrackSliderValue
        {
            get => trackSliderValue;
            set
            {
                trackSliderValue = value;
                OnPropertyChanged(() => TrackSliderValue);
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
                    previousTrack = new ActionCommand(parameter => {
                        GlobalData.MediaPlayer.Prev();
                        if (!isPlayImage)
                            GlobalData.MediaPlayer.Play();
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
                        GlobalData.MediaPlayer.Next();
                        if (!isPlayImage)
                            GlobalData.MediaPlayer.Play();
                    });

                return nextTrack;
            }
        }

        private ICommand playPause;
        public ICommand PlayPause
        {
            get
            {
                if (playPause == null)
                    playPause = new ActionCommand(parameter =>
                    {
                        if (GlobalData.MediaSource != null)
                        {
                            if (GlobalData.MediaPlayer.IsPlaying)
                                GlobalData.MediaPlayer.Pause();
                            else
                                GlobalData.MediaPlayer.Play();
                        }
                    });

                return playPause;
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
                        float currentVolume = GlobalData.MediaPlayer.GetVolume();

                        currentVolume += 0.1f;

                        if (currentVolume > 1f)
                            currentVolume = 1f;

                        GlobalData.MediaPlayer.SetVolume(currentVolume);

                        GlobalData.SaveConfig();
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
                        float currentVolume = GlobalData.MediaPlayer.GetVolume();

                        currentVolume -= 0.1f;

                        if (currentVolume < 0)
                            currentVolume = 0;

                        GlobalData.MediaPlayer.SetVolume(currentVolume);

                        GlobalData.SaveConfig();
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
                        int oldMode = (int)GlobalData.PlayerMode;
                        int newMode = oldMode + 1;
                        if (newMode == 3)
                            newMode = 0;

                        GlobalData.PlayerMode = (PlayerMode)newMode;
                        GlobalData.SaveConfig();
                    });

                return changeMode;
            }
        }

        private ICommand back;
        public ICommand Back
        {
            get
            {
                if (back == null)
                    back = new ActionCommand(parameter =>
                    {
                        MainWindow.Instance.TopBarClick(TitleBarButton.Back);
                    });
                return back;
            }
        }

        private ICommand minimize;
        public ICommand Minimize
        {
            get
            {
                if (minimize == null)
                    minimize = new ActionCommand(parameter =>
                    {
                        MainWindow.Instance.TopBarClick(TitleBarButton.Minimize);
                    });

                return minimize;
            }
        }

        private ICommand maximize;
        public ICommand Maximize
        {
            get
            {
                if (maximize == null)
                    maximize = new ActionCommand(parameter =>
                    {
                        MainWindow.Instance.TopBarClick(TitleBarButton.Maximize);
                    });
                return maximize;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                    close = new ActionCommand(parameter =>
                    {
                        MainWindow.Instance.TopBarClick(TitleBarButton.Close);
                    });
                return close;
            }
        }
        #endregion
        #region Constructors
        public FullScreenViewModel()
        {
            //Tick(null, null);
            timer = new Timer();
            timer.Elapsed += Tick;
            timer.Interval = 200;
            timer.Start();
        }
        #endregion
        #region Private Methods

        private void Tick(object sender, ElapsedEventArgs e)
        {
            FullScreenWindow.MainDispatcher.Invoke(() =>
            {
                try
                {
                    if (playedTrack != GlobalData.MediaSourcePath)
                    {
                        Image = ImageProcessing.FromArray(GlobalData.MediaSource.Image ?? Properties.Resources.EmptyTrack);

                        BackgroundGridVisibility = GlobalData.MediaSource.Image == null ? Visibility.Hidden : Visibility.Visible;

                        playedTrack = GlobalData.MediaSourcePath;
                    }
                    if (isPlayImage && GlobalData.MediaPlayer.IsPlaying)
                    {
                        PlayIcon = ImageProcessing.FromArray(Properties.Resources.PauseIcon);
                        isPlayImage = false;
                    }

                    if (!isPlayImage && !GlobalData.MediaPlayer.IsPlaying)
                    {
                        PlayIcon = ImageProcessing.FromArray(Properties.Resources.PlayIcon);
                        isPlayImage = true;
                    }
                    if (GlobalData.MediaSource != null)
                    {
                        TrackSliderMax = GlobalData.MediaPlayer.Duration;
                        TrackSliderValue = GlobalData.MediaPlayer.CurrentPosition;
                        Artist = GlobalData.MediaSource.Artist;
                        Title = GlobalData.MediaSource.Title;
                        TimeCurrent = TimeSpan.FromSeconds(GlobalData.MediaPlayer.CurrentPosition).ToString("mm':'ss");
                        TimeMax = GlobalData.MediaSource.Duration.ToString("mm':'ss");
                    }

                    if (GlobalData.PlayerMode != playerMode)
                    {
                        if (GlobalData.PlayerMode == PlayerMode.All)
                            ModeIcon = ImageProcessing.FromArray(Properties.Resources.RepeatIcon);
                        else if (GlobalData.PlayerMode == PlayerMode.One)
                            ModeIcon = ImageProcessing.FromArray(Properties.Resources.RepeatOneIcon);
                        else
                            ModeIcon = ImageProcessing.FromArray(Properties.Resources.RandomIcon);

                        playerMode = GlobalData.PlayerMode;
                    }
                }
                catch
                { }
            });
        }
        #endregion
    }
}
