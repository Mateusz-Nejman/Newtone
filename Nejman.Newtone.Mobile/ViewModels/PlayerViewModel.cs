using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Mobile.Implementations;
using Nejman.Newtone.Mobile.Services;
using Nejman.Newtone.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.ViewModels
{
    public class PlayerViewModel : PropertyChangedBase
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
        private bool backgroundGridVisible;
        private double audioSliderMax;
        private double audioSliderValue;

        private bool isPlayImage = true;
        private string playedTrack = "";
        private PlaybackMode playerMode = PlaybackMode.All;
        private IDisposable loopSubscription;
        private bool isLoadingVisible = true;
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

        public double AudioSliderMax
        {
            get => audioSliderMax;
            set
            {
                if (audioSliderMax != value)
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
                if (audioSliderValue != value)
                {
                    audioSliderValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsLoadingVisible
        {
            get => isLoadingVisible;
            set
            {
                if(isLoadingVisible != value)
                {
                    isLoadingVisible = value;
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
                        int oldMode = (int)CoreGlobal.PlaybackMode;
                        int newMode = oldMode + 1;
                        if (newMode == 3)
                            newMode = 0;

                        CoreGlobal.PlaybackMode = (PlaybackMode)newMode;
                        CoreGlobal.SaveData();
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
                    previousTrack = new ActionCommand(async(parameter) =>
                    {
                        await CoreGlobal.MediaPlayer.Prev();
                        if (!isPlayImage)
                            CoreGlobal.MediaPlayer.Play();
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
                        if (CoreGlobal.CurrentSource != null)
                        {
                            if (CoreGlobal.MediaPlayer.IsPlaying)
                                CoreGlobal.MediaPlayer.Pause();
                            else
                                CoreGlobal.MediaPlayer.Play();
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
                    nextTrack = new ActionCommand(async(parameter) =>
                    {
                        await CoreGlobal.MediaPlayer.Next();
                        if (!isPlayImage)
                            CoreGlobal.MediaPlayer.Play();
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
                        ContextMenuBuilder.BuildForTrack((Xamarin.Forms.View)parameter, CoreGlobal.CurrentSource.Path + CoreGlobal.SEPARATOR);
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
                    expandList = new ActionCommand(parameter =>
                    {
                        ShellHelpers.GoTo($"{nameof(TracksListPage)}?{nameof(TracksListViewModel.CurrentPlaylist)}=true");
                    });
                return expandList;
            }
        }

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (backCommand == null)
                    backCommand = new ActionCommand(parameter =>
                    {
                        ShellHelpers.GoTo("..");
                    });

                return backCommand;
            }
        }
        #endregion
        #region Constructors
        public PlayerViewModel()
        {
            MiddleButton = ImageSource.FromFile("PlayIcon.png");
            ModeButton = ImageSource.FromFile("RepeatIcon.png");
        }
        #endregion
        #region Public Methods

        public void Appearing()
        {
            var src = System.Reactive.Linq.Observable.Interval(TimeSpan.FromMilliseconds(250));
            loopSubscription = src.Subscribe(time => Tick());
        }

        public void Disappearing()
        {
            loopSubscription?.Dispose();
            loopSubscription = null;
        }

        public void AudioSlider_ValueNewChanged(AudioSliderControl.ValueChangedArgs e)
        {
            if (CoreGlobal.MediaPlayer.IsPlaying)
            {
                CoreGlobal.MediaPlayer.Seek(e.Value);
            }
        }
        #endregion
        #region Private Methods

        private void Tick()
        {
            IsLoadingVisible = CoreGlobal.MediaPlayer.IsLoading;
            if(CoreGlobal.CurrentSource == null)
            {
                return;
            }
            TrackCurrentPosition = TimeSpan.FromSeconds(CoreGlobal.MediaPlayer.CurrentPosition).ToString("mm':'ss");
            TrackDuration = CoreGlobal.CurrentSource.Duration.ToString("mm':'ss");
            Artist = CoreGlobal.CurrentSource.Artist;
            Title = CoreGlobal.CurrentSource.Title;

            if (playedTrack != CoreGlobal.CurrentSource.Path)
            {
                BackgroundGridVisible = CoreGlobal.CurrentSource.Image != null && CoreGlobal.CurrentSource.Image.Length > 0;

                if (BackgroundGridVisible)
                {
                    TrackBlur = ImageProcessingImplementation.Current.Blur(CoreGlobal.CurrentSource.Image);
                    TrackImage = ImageProcessingImplementation.FromArray(CoreGlobal.CurrentSource.Image);
                }
                else
                {
                    TrackImage = ImageSource.FromFile("EmptyTrack.png");
                }

                playedTrack = CoreGlobal.CurrentSource.Path;
            }
            if (isPlayImage && CoreGlobal.MediaPlayer.IsPlaying)
            {
                MiddleButton = ImageSource.FromFile("PauseIcon.png");
                isPlayImage = false;
            }

            if (!isPlayImage && !CoreGlobal.MediaPlayer.IsPlaying)
            {
                MiddleButton = ImageSource.FromFile("PlayIcon.png");
                isPlayImage = true;
            }
            if (CoreGlobal.MediaPlayer.IsPlaying)
            {
                AudioSliderMax = CoreGlobal.CurrentSource.Duration.TotalSeconds;
                AudioSliderValue = CoreGlobal.MediaPlayer.CurrentPosition;
            }

            if (CoreGlobal.PlaybackMode != playerMode)
            {
                if (CoreGlobal.PlaybackMode == PlaybackMode.All)
                    ModeButton = ImageSource.FromFile("RepeatIcon.png");
                else if (CoreGlobal.PlaybackMode == PlaybackMode.Single)
                    ModeButton = ImageSource.FromFile("RepeatOneIcon.png");
                else
                    ModeButton = ImageSource.FromFile("RandomIcon.png");

                playerMode = CoreGlobal.PlaybackMode;
            }
        }

        #endregion
    }
}
