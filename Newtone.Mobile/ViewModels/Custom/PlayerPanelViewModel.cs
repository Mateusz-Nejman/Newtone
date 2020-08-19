using System;
using System.Collections.Generic;
using System.Linq;
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
using Newtone.Core.Models;
using Newtone.Mobile.Media;
using Newtone.Mobile.Processing;
using Newtone.Mobile.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.ViewModels.Custom
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
                        if (GlobalData.Current.MediaSource != null)
                        {
                            if (GlobalData.Current.MediaPlayer.IsPlaying)
                                GlobalData.Current.MediaPlayer.Pause();
                            else
                                GlobalData.Current.MediaPlayer.Play();
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
                    gotoPlayerCommand = new ActionCommand(async (parameter) =>
                    {
                        if (GlobalData.Current.MediaSource != null)
                        {
                            await NormalPage.NavigationInstance.PushModalAsync(new FullScreenPage());
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
            if (GlobalData.Current.MediaSource != null)
            {
                Artist = GlobalData.Current.MediaSource.Artist;
                Title = GlobalData.Current.MediaSource.Title;
            }
            if (playedTrack != GlobalData.Current.MediaSourcePath)
            {

                if (GlobalData.Current.MediaSource.Image != null && GlobalData.Current.MediaSource.Image.Length > 0)
                {
                    TrackImage = ImageProcessing.FromArray(GlobalData.Current.MediaSource.Image);
                    TrackBlur = ImageProcessing.Blur(GlobalData.Current.MediaSource.Image);
                    BackgroundGridVisible = true;
                }
                else
                {
                    TrackImage = ImageSource.FromFile("EmptyTrack.png");
                    BackgroundGridVisible = false;
                }

                playedTrack = GlobalData.Current.MediaSourcePath;
            }
            if (isPlayImage && GlobalData.Current.MediaPlayer.IsPlaying)
            {
                PlayButton = ImageSource.FromFile("PauseIcon.png");
                isPlayImage = false;
            }

            if (!isPlayImage && !GlobalData.Current.MediaPlayer.IsPlaying)
            {
                PlayButton = ImageSource.FromFile("PlayIcon.png");
                isPlayImage = true;
            }
        }
        #endregion
    }
}