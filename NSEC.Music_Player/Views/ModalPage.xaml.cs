using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Core.Languages;
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
    public partial class ModalPage : ContentPage
    {
        private bool StopTimer { get; set; }
        private bool isPlayImage = true;
        private string playedTrack = "";
        public ModalPage(ContentView content, string title, bool topPanelVisible = true)
        {
            InitializeComponent();

            Appearing += PageAppearing;
            Disappearing += PageDisappearing;

            container.Children.Add(content);
            titleLabel.Text = title;
            topPanel.IsVisible = topPanelVisible;
        }

        private void PageDisappearing(object sender, EventArgs e)
        {
            StopTimer = true;
        }

        private void PageAppearing(object sender, EventArgs e)
        {
            Device.StartTimer(TimeSpan.FromSeconds(0.5), TimerTick);
            StopTimer = false;
        }

        private bool TimerTick()
        {
            badgeCount.Text = DownloadProcessing.BadgeCount.ToString();
            badgeBubble.IsVisible = DownloadProcessing.BadgeCount > 0;
            if(GlobalData.MediaSource != null)
            {
                artistLabel.Text = GlobalData.MediaSource.Artist;
                trackLabel.Text = GlobalData.MediaSource.Title;
            }
            if (playedTrack != GlobalData.MediaSourcePath)
            {
                artistLabel.Text = GlobalData.MediaSource.Artist;
                trackLabel.Text = GlobalData.MediaSource.Title;

                if (GlobalData.MediaSource.Image != null && GlobalData.MediaSource.Image.Length > 0)
                {
                    trackImage.Source = ImageProcessing.FromArray(GlobalData.MediaSource.Image);
                    backgroundImage.Source = ImageProcessing.Blur(GlobalData.MediaSource.Image);
                    backgroundGrid.IsVisible = true;
                }
                else
                {
                    trackImage.Source = ImageSource.FromFile("EmptyTrack.png");
                    backgroundGrid.IsVisible = false;
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

            if (container.Children.Count > 0 && container.Children[0] is ITimerContent)
                ((ITimerContent)container.Children[0]).Tick();

            return !StopTimer;
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
            //Global.MediaBrowser.GetTransportControls().Play();
        }

        private void TrackImage_Clicked(object sender, EventArgs e)
        {
            if (GlobalData.MediaSource != null)
            {
                Navigation.PushModalAsync(new FullScreenPage());
            }
        }

        private void DownloadButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ModalPage(new DownloadPage(), Localization.TitleDownloads, false));
        }
    }
}