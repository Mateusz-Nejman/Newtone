﻿using System;
using System.Reactive.Linq;
using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Mobile.UI.Logic;
using Newtone.Mobile.UI.Processing;
using Newtone.Mobile.UI.Views;
using Newtone.Mobile.UI.Views.Custom;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.ViewModels
{
    public class FullScreenViewModel : PropertyChangedBase
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

        private readonly bool stopTimer = false;
        private bool isPlayImage = true;
        private string playedTrack = "";
        private PlayerMode playerMode = PlayerMode.All;
        private IDisposable loopSubscription;
        private bool isLoadingVisible;
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
                isLoadingVisible = value;
                OnPropertyChanged();
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
                        int oldMode = (int)GlobalData.Current.PlayerMode;
                        int newMode = oldMode + 1;
                        if (newMode == 3)
                            newMode = 0;

                        GlobalData.Current.PlayerMode = (PlayerMode)newMode;
                        GlobalData.Current.SaveConfig();
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
                        GlobalData.Current.MediaPlayer.Prev();
                        if (!isPlayImage)
                            GlobalData.Current.MediaPlayer.Play();
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

        private ICommand menuButtonCommand;
        public ICommand MenuButtonCommand
        {
            get
            {
                if (menuButtonCommand == null)
                    menuButtonCommand = new ActionCommand(parameter =>
                    {
                        ContextMenuBuilder.BuildForTrack((Xamarin.Forms.View)parameter, GlobalData.Current.MediaSource.FilePath + GlobalData.SEPARATOR);
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
                    expandList = new ActionCommand(async (parameter) =>
                    {
                        await Global.NavigationInstance.PushModalAsync(new ModalPage(new CurrentPlaylistPage(), "", true, false));
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
                    backCommand = new ActionCommand(async (parameter) =>
                    {
                        await Global.NavigationInstance.PopModalAsync();
                    });

                return backCommand;
            }
        }
        #endregion
        #region Constructors
        public FullScreenViewModel()
        {
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

        public void AudioSlider_ValueNewChanged(AudioSliderControl.ValueChangedArgs e)
        {
            if (GlobalData.Current.MediaPlayer.IsPlaying)
            {
                GlobalData.Current.MediaPlayer.Seek(e.Value);
            }
        }
        #endregion
        #region Private Methods

        private bool Tick()
        {
            TrackCurrentPosition = TimeSpan.FromSeconds(GlobalData.Current.MediaPlayer.CurrentPosition).ToString("mm':'ss");
            TrackDuration = GlobalData.Current.MediaSource.Duration.ToString("mm':'ss");
            Artist = GlobalData.Current.MediaSource.Artist;
            Title = GlobalData.Current.MediaSource.Title;
            IsLoadingVisible = GlobalData.Current.MediaPlayer.IsLoading;

            if (playedTrack != GlobalData.Current.MediaSourcePath)
            {
                BackgroundGridVisible = GlobalData.Current.MediaSource.Image != null;

                if (GlobalData.Current.MediaSource.Image != null && GlobalData.Current.MediaSource.Image.Length > 0)
                {
                    TrackBlur = ImageProcessing.Blur(ImageProcessing.FromArray(GlobalData.Current.MediaSource.Image));
                    TrackImage = ImageProcessing.FromArray(GlobalData.Current.MediaSource.Image);
                }
                else
                {
                    TrackImage = ImageSource.FromFile("EmptyTrack.png");
                }

                playedTrack = GlobalData.Current.MediaSourcePath;
            }
            if (isPlayImage && GlobalData.Current.MediaPlayer.IsPlaying)
            {
                MiddleButton = ImageSource.FromFile("PauseIcon.png");
                isPlayImage = false;
            }

            if (!isPlayImage && !GlobalData.Current.MediaPlayer.IsPlaying)
            {
                MiddleButton = ImageSource.FromFile("PlayIcon.png");
                isPlayImage = true;
            }
            if (GlobalData.Current.MediaPlayer.IsPlaying)
            {
                AudioSliderMax = GlobalData.Current.MediaSource.Duration.TotalSeconds;
                AudioSliderValue = GlobalData.Current.MediaPlayer.CurrentPosition;
            }

            if (GlobalData.Current.PlayerMode != playerMode)
            {
                if (GlobalData.Current.PlayerMode == PlayerMode.All)
                    ModeButton = ImageSource.FromFile("RepeatIcon.png");
                else if (GlobalData.Current.PlayerMode == PlayerMode.One)
                    ModeButton = ImageSource.FromFile("RepeatOneIcon.png");
                else
                    ModeButton = ImageSource.FromFile("RandomIcon.png");

                playerMode = GlobalData.Current.PlayerMode;
            }
            return !stopTimer;
        }

        #endregion
    }
}
