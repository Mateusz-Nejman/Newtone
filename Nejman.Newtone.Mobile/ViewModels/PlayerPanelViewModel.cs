using Nejman.Newtone.Core;
using Nejman.Newtone.Mobile.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.ViewModels
{
    public class PlayerPanelViewModel : PropertyChangedBase
    {
        #region Fields
        private bool backgroundGridVisible;
        private string title;
        private string artist;
        private ImageSource trackBlur;
        private ImageSource trackImage;
        private ImageSource playButton;
        private bool isPlayImage = true;
        private string playedTrack = "";
        private bool isPanelVisible;
        #endregion

        #region Properties
        public bool BackgroundGridVisible
        {
            get => backgroundGridVisible;
            set
            {
                backgroundGridVisible = value;
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

        public ImageSource PlayButton
        {
            get => playButton;
            set
            {
                playButton = value;
                OnPropertyChanged();
            }
        }

        public bool IsPanelVisible
        {
            get => isPanelVisible;
            set
            {
                isPanelVisible = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private ICommand playPauseCommand;
        public ICommand PlayPause
        {
            get
            {
                if (playPauseCommand == null)
                    playPauseCommand = new ActionCommand(parameter =>
                    {
                        if (CoreGlobal.CurrentSource != null)
                        {
                            if (CoreGlobal.MediaPlayer.IsPlaying)
                                CoreGlobal.MediaPlayer.Pause();
                            else
                                CoreGlobal.MediaPlayer.Play();
                        }
                    });

                return playPauseCommand;
            }
        }

        private ICommand gotoPlayerCommand;
        public ICommand GotoPlayer
        {
            get
            {
                if (gotoPlayerCommand == null)
                    gotoPlayerCommand = new ActionCommand(parameter =>
                    {
                        if (CoreGlobal.CurrentSource != null)
                        {
                            ShellHelpers.GoTo("PlayerPage");
                        }
                    });
                return gotoPlayerCommand;
            }
        }
        #endregion
        #region Constructors
        public PlayerPanelViewModel()
        {
            PlayButton = ImageSource.FromFile("PlayIcon.png");
            TrackImage = ImageSource.FromFile("EmptyTrack.png");
        }
        #endregion
        #region Public Methods

        public void Tick()
        {
            IsPanelVisible = CoreGlobal.CurrentSource != null;

            if(!IsPanelVisible)
            {
                return;
            }

            if (CoreGlobal.CurrentSource != null)
            {
                Artist = CoreGlobal.CurrentSource.Artist;
                Title = CoreGlobal.CurrentSource.Title;
            }
            if (playedTrack != CoreGlobal.CurrentSource.Path)
            {

                if (CoreGlobal.CurrentSource.Image != null && CoreGlobal.CurrentSource.Image.Length > 0)
                {
                    TrackImage = ImageProcessingImplementation.FromArray(CoreGlobal.CurrentSource.Image);
                    TrackBlur = ImageProcessingImplementation.Current.Blur(CoreGlobal.CurrentSource.Image);
                    BackgroundGridVisible = true;
                }
                else
                {
                    TrackImage = ImageSource.FromFile("EmptyTrack.png");
                    BackgroundGridVisible = false;
                }

                playedTrack = CoreGlobal.CurrentSource.Path;
            }
            if (isPlayImage && CoreGlobal.MediaPlayer.IsPlaying)
            {
                PlayButton = ImageSource.FromFile("PauseIcon.png");
                isPlayImage = false;
            }

            if (!isPlayImage && !CoreGlobal.MediaPlayer.IsPlaying)
            {
                PlayButton = ImageSource.FromFile("PlayIcon.png");
                isPlayImage = true;
            }
        }
        #endregion
    }
}
