using Newtone.Core;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullScreenPage : ContentPage
    {
        private bool StopTimer { get; set; }
        private bool isMenuImage = true;
        private bool isPlayImage = true;
        private string playedTrack = "";
        private PlayerMode playerMode = PlayerMode.All;
        public FullScreenPage()
        {
            InitializeComponent();
            Appearing += PageAppearing;
            Disappearing += PageDisappearing;
            audioSlider.ValueNewChanged += AudioSlider_ValueNewChanged;
        }

        private void AudioSlider_ValueNewChanged(object sender, Custom.AudioSliderControl.ValueChangedArgs e)
        {
            if (GlobalData.MediaPlayer.IsPlaying)
            {
                GlobalData.MediaPlayer.Seek(e.Value);
            }
        }

        private void PageDisappearing(object sender, EventArgs e)
        {
            StopTimer = true;
        }

        private void PageAppearing(object sender, EventArgs e)
        {
            TimerTick();
            Device.StartTimer(TimeSpan.FromSeconds(0.5), TimerTick);
            StopTimer = false;
        }

        private bool TimerTick()
        {
            timeCurrent.Text = TimeSpan.FromSeconds(GlobalData.MediaPlayer.CurrentPosition).ToString("mm':'ss");
            timeMax.Text = GlobalData.MediaSource.Duration.ToString("mm':'ss");
            artistLabel.Text = GlobalData.MediaSource.Artist;
            titleLabel.Text = GlobalData.MediaSource.Title;
            if (playedTrack != GlobalData.MediaSourcePath)
            {
                backgroundGrid.IsVisible = GlobalData.MediaSource.Image != null;

                if (GlobalData.MediaSource.Image != null && GlobalData.MediaSource.Image.Length > 0)
                {
                    backgroundImage.Source = ImageProcessing.Blur(ImageProcessing.FromArray(GlobalData.MediaSource.Image));
                    trackImage.Source = ImageProcessing.FromArray(GlobalData.MediaSource.Image);
                }
                else
                {
                    trackImage.Source = ImageSource.FromFile("EmptyTrack.png");
                }

                playedTrack = GlobalData.MediaSourcePath;
            }
            if (isPlayImage && GlobalData.MediaPlayer.IsPlaying)
            {
                playButton.Source = ImageSource.FromFile("PauseIcon.png");
                isPlayImage = false;
            }

            if (!isPlayImage && !GlobalData.MediaPlayer.IsPlaying)
            {
                playButton.Source = ImageSource.FromFile("PlayIcon.png");
                isPlayImage = true;
            }
            if (GlobalData.MediaPlayer.IsPlaying)
            {
                audioSlider.Max = GlobalData.MediaPlayer.Duration;
                audioSlider.SetValue(GlobalData.MediaPlayer.CurrentPosition);
                
            }

            if (GlobalData.PlayerMode != playerMode)
            {
                if (GlobalData.PlayerMode == PlayerMode.All)
                    modeButton.Source = ImageSource.FromFile("RepeatIcon.png");
                else if (GlobalData.PlayerMode == PlayerMode.One)
                    modeButton.Source = ImageSource.FromFile("RepeatOneIcon.png");
                else
                    modeButton.Source = ImageSource.FromFile("RandomIcon.png");

                playerMode = GlobalData.PlayerMode;
            }

            if(isMenuImage && GlobalData.MediaSource.Type == Newtone.Core.Media.MediaSource.SourceType.Web)
            {
                actionButton.Source = ImageSource.FromFile("DownloadIcon.png");
                isMenuImage = false;
            }

            if (!isMenuImage && GlobalData.MediaSource.Type == Newtone.Core.Media.MediaSource.SourceType.Local)
            {
                actionButton.Source = ImageSource.FromFile("MenuIcon.png");
                isMenuImage = true;
            }

            return !StopTimer;
        }

        private void ExpandButton_Clicked(object sender, EventArgs e)
        {
            NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new CurrentPlaylistPage(), ""));
        }

        private void PrevButton_Clicked(object sender, EventArgs e)
        {
            GlobalData.MediaPlayer.Prev();
            if (!isPlayImage)
                GlobalData.MediaPlayer.Play();
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            if (GlobalData.MediaSource != null)
            {
                if (GlobalData.MediaPlayer.IsPlaying)
                    GlobalData.MediaPlayer.Pause();
                else
                    GlobalData.MediaPlayer.Play();
            }
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            GlobalData.MediaPlayer.Next();
            if (!isPlayImage)
                GlobalData.MediaPlayer.Play();
        }

        private void ModeButton_Clicked(object sender, EventArgs e)
        {
            int oldMode = (int)GlobalData.PlayerMode;
            int newMode = oldMode + 1;
            if (newMode == 3)
                newMode = 0;

            GlobalData.PlayerMode = (PlayerMode)newMode;
            GlobalData.SaveConfig();
        }

        private void ActionButton_Clicked(object sender, EventArgs e)
        {
            if(GlobalData.MediaSource.Type == Newtone.Core.Media.MediaSource.SourceType.Local)
            {
                ContextMenuBuilder.BuildForTrack((View)sender, GlobalData.MediaSource.FilePath+GlobalData.SEPARATOR);
            }
            else
            {
                DownloadProcessing.Add(GlobalData.MediaSource.FilePath, GlobalData.MediaSource.Title, "", "");
            }
        }
    }
}