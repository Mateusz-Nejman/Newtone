using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Mobile.Logic;
using Newtone.Mobile.Processing;
using Newtone.Mobile.Views;
using Newtone.Mobile.Views.Custom;
using Xamarin.Forms;

namespace Newtone.Mobile.ViewModels
{
    public class FullScreenViewModel:PropertyChangedBase
    {
        #region Fields
        private string title;
        private string artist;
        private ImageSource trackImage;
        private ImageSource trackBlur;
        private string trackCurrentPosition;
        private string trackDuration;
        private ImageSource middleButton; //Play or pause
        private ImageSource modeButton;
        private ImageSource menuButton;
        private bool backgroundGridVisible;
        private double audioSliderMax;
        private double audioSliderValue;

        private bool stopTimer = false;
        private bool isMenuImage = true;
        private bool isPlayImage = true;
        private string playedTrack = "";
        private PlayerMode playerMode = PlayerMode.All;
        private IDisposable loopSubscription;
        #endregion

        #region Properties
        public string Title
        {
            get => title;
            set
            {
                title = value;
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

        public ImageSource TrackImage
        {
            get => trackImage;
            set
            {
                trackImage = value;
                OnPropertyChanged();
            }
        }

        public ImageSource TrackBlur
        {
            get => trackBlur;
            set
            {
                trackBlur = value;
                OnPropertyChanged();
            }
        }

        public string TrackCurrentPosition
        {
            get => trackCurrentPosition;
            set
            {
                trackCurrentPosition = value;
                OnPropertyChanged();
            }
        }

        public string TrackDuration
        {
            get => trackDuration;
            set
            {
                trackDuration = value;
                OnPropertyChanged();
            }
        }

        public bool BackgroundGridVisible
        {
            get => backgroundGridVisible;
            set
            {
                backgroundGridVisible = value;
                OnPropertyChanged();
            }
        }

        public ImageSource MiddleButton //play or pause
        {
            get => middleButton;
            set
            {
                middleButton = value;
                OnPropertyChanged();
            }
        }

        public ImageSource ModeButton
        {
            get => modeButton;
            set
            {
                modeButton = value;
                OnPropertyChanged();
            }
        }

        public ImageSource MenuButton
        {
            get => menuButton;
            set
            {
                menuButton = value;
                OnPropertyChanged();
            }
        }

        public double AudioSliderMax
        {
            get => audioSliderMax;
            set
            {
                if(audioSliderMax != value)
                {
                    audioSliderMax = value;
                    OnPropertyChanged();
                }
            }
        }

        public double AudioSliderValue
        {
            get => audioSliderValue;
            set
            {
                if(audioSliderValue != value)
                {
                    audioSliderValue = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Commands
        private ICommand repeatChange;
        public ICommand RepeatChange
        {
            get
            {
                if (repeatChange == null)
                    repeatChange = new ActionCommand(parameter =>
                    {
                        int oldMode = (int)GlobalData.PlayerMode;
                        int newMode = oldMode + 1;
                        if (newMode == 3)
                            newMode = 0;

                        GlobalData.PlayerMode = (PlayerMode)newMode;
                        GlobalData.SaveConfig();
                    });

                return repeatChange;
            }
        }

        private ICommand previousTrack;
        public ICommand PreviousTrack
        {
            get
            {
                if (previousTrack == null)
                    previousTrack = new ActionCommand(parameter =>
                    {
                        GlobalData.MediaPlayer.Prev();
                        if (!isPlayImage)
                            GlobalData.MediaPlayer.Play();
                    });

                return previousTrack;
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
                        if (GlobalData.MediaSource != null)
                        {
                            if (GlobalData.MediaPlayer.IsPlaying)
                                GlobalData.MediaPlayer.Pause();
                            else
                                GlobalData.MediaPlayer.Play();
                        }
                    });

                return playOrPause;
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

        private ICommand menuButtonCommand;
        public ICommand MenuButtonCommand
        {
            get
            {
                if (menuButtonCommand == null)
                    menuButtonCommand = new ActionCommand(parameter =>
                    {
                        if (GlobalData.MediaSource.Type == Newtone.Core.Media.MediaSource.SourceType.Local)
                        {
                            ContextMenuBuilder.BuildForTrack((Xamarin.Forms.View)parameter, GlobalData.MediaSource.FilePath + GlobalData.SEPARATOR);
                        }
                        else
                        {
                            DownloadProcessing.Add(GlobalData.MediaSource.FilePath, GlobalData.MediaSource.Title, "", "");
                        }
                    });

                return menuButtonCommand;
            }
        }

        private ICommand expandList;
        public ICommand ExpandList
        {
            get
            {
                if (expandList == null)
                    expandList = new ActionCommand(async(parameter) =>
                    {
                        await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new CurrentPlaylistPage(), ""));
                    });
                return expandList;
            }
        }
        #endregion
        #region Constructors
        public FullScreenViewModel()
        {
            MenuButton = ImageSource.FromFile("MenuIcon.png");
            MiddleButton = ImageSource.FromFile("PlayIcon.png");
            ModeButton = ImageSource.FromFile("RepeatIcon.png");
        }
        #endregion
        #region Public Methods

        public void Appearing()
        {
            var src = System.Reactive.Linq.Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(200)).Timestamp();
            loopSubscription = src.Subscribe(time => Tick());
        }

        public void Disappearing()
        {
            loopSubscription?.Dispose();
            loopSubscription = null;
        }

        public void AudioSlider_ValueNewChanged(object sender, AudioSliderControl.ValueChangedArgs e)
        {
            if (GlobalData.MediaPlayer.IsPlaying)
            {
                GlobalData.MediaPlayer.Seek(e.Value);
            }
        }
        #endregion
        #region Private Methods

        private bool Tick()
        {
            TrackCurrentPosition = TimeSpan.FromSeconds(GlobalData.MediaPlayer.CurrentPosition).ToString("mm':'ss");
            TrackDuration = GlobalData.MediaSource.Duration.ToString("mm':'ss");
            Artist = GlobalData.MediaSource.Artist;
            Title = GlobalData.MediaSource.Title;

            if (playedTrack != GlobalData.MediaSourcePath)
            {
                BackgroundGridVisible = GlobalData.MediaSource.Image != null;

                if (GlobalData.MediaSource.Image != null && GlobalData.MediaSource.Image.Length > 0)
                {
                    TrackBlur = ImageProcessing.Blur(ImageProcessing.FromArray(GlobalData.MediaSource.Image));
                    TrackImage = ImageProcessing.FromArray(GlobalData.MediaSource.Image);
                }
                else
                {
                    TrackImage = ImageSource.FromFile("EmptyTrack.png");
                }

                playedTrack = GlobalData.MediaSourcePath;
            }
            if (isPlayImage && GlobalData.MediaPlayer.IsPlaying)
            {
                MiddleButton = ImageSource.FromFile("PauseIcon.png");
                isPlayImage = false;
            }

            if (!isPlayImage && !GlobalData.MediaPlayer.IsPlaying)
            {
                MiddleButton = ImageSource.FromFile("PlayIcon.png");
                isPlayImage = true;
            }
            if (GlobalData.MediaPlayer.IsPlaying)
            {
                AudioSliderMax = GlobalData.MediaPlayer.Duration;
                AudioSliderValue = GlobalData.MediaPlayer.CurrentPosition;

            }

            if (GlobalData.PlayerMode != playerMode)
            {
                if (GlobalData.PlayerMode == PlayerMode.All)
                   ModeButton = ImageSource.FromFile("RepeatIcon.png");
                else if (GlobalData.PlayerMode == PlayerMode.One)
                    ModeButton = ImageSource.FromFile("RepeatOneIcon.png");
                else
                    ModeButton = ImageSource.FromFile("RandomIcon.png");

                playerMode = GlobalData.PlayerMode;
            }

            if (isMenuImage && GlobalData.MediaSource.Type == Newtone.Core.Media.MediaSource.SourceType.Web)
            {
                MenuButton = ImageSource.FromFile("DownloadIcon.png");
                isMenuImage = false;
            }

            if (!isMenuImage && GlobalData.MediaSource.Type == Newtone.Core.Media.MediaSource.SourceType.Local)
            {
                MenuButton = ImageSource.FromFile("MenuIcon.png");
                isMenuImage = true;
            }
            return !stopTimer;
        }

        #endregion
    }
}