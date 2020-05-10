using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Processing;
using NSEC.Music_Player.Views.Images;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NormalPage : ContentPage
    {
        private bool StopTimer { get; set; }
        public static NormalPage Instance { get; set; }
        public static INavigation NavigationInstance
        {
            get
            {
                return Instance.Navigation;
            }
        }

        private bool isPlayImage = true;
        private string playedTrack = "";

        private int CurrentButtonIndex = -1;
        public NormalPage()
        {
            InitializeComponent();
            if(!MainActivity.Loaded)
            {
                GlobalData.LoadTags();
                Task.Run(async () => await GlobalLoader.Load()).Wait();
                GlobalData.LoadConfig();
                MainActivity.Loaded = true;
            }
            Directory.CreateDirectory(GlobalData.MusicPath);
            Instance = this;
            ConsoleDebug.WriteLine("normal");
            Appearing += PageAppearing;
            Disappearing += PageDisappearing;

            TracksButton_Clicked(null, null);
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

        private void PlayerButton_Clicked(object sender, EventArgs e)
        {
            if(GlobalData.MediaSource != null)
            {
                Navigation.PushModalAsync(new FullScreenPage());
            }
        }

        private bool TimerTick()
        {
            badgeCount.Text = DownloadProcessing.BadgeCount.ToString();
            badgeBubble.IsVisible = DownloadProcessing.BadgeCount > 0;
            if (GlobalData.MediaSource != null)
            {
                artistLabel.Text = GlobalData.MediaSource.Artist;
                trackLabel.Text = GlobalData.MediaSource.Title;
            }
            if (playedTrack != GlobalData.MediaSourcePath)
            {

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

        private void Toggle(int buttonIndex = 0)
        {
            tracksButton.IsToggled = buttonIndex == 0;
            artistsButton.IsToggled = buttonIndex == 1;
            playlistsButton.IsToggled = buttonIndex == 2;
            searchButton.IsToggled = buttonIndex == 3;
            settingsButton.IsToggled = buttonIndex == 4;
            CurrentButtonIndex = buttonIndex;
        }

        private void TracksButton_Clicked(object sender, EventArgs e)
        {
            if (CurrentButtonIndex != 0)
            {
                SetContainer(new TracksPage(), Localization.Tracks);
                Toggle(0);
            }
            
        }

        private void ArtistsButton_Clicked(object sender, EventArgs e)
        {
            if (CurrentButtonIndex != 1)
            {
                SetContainer(new ArtistPage(), Localization.Artists);
                Toggle(1);
            }
        }

        private void PlaylistsButton_Clicked(object sender, EventArgs e)
        {
            if (CurrentButtonIndex != 2)
            {
                SetContainer(new PlaylistPage(), Localization.Playlists);
                Toggle(2);
            }
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            if (CurrentButtonIndex != 3)
            {
                SetContainer(new SearchPage(), Localization.Search);
                Toggle(3);
            }
        }

        private void SettingsButton_Clicked(object sender, EventArgs e)
        {
            if (CurrentButtonIndex != 4)
            {
                SetContainer(new SettingsPage(), Localization.Settings);
                Toggle(4);
            }

        }

        public void SetContainer(ContentView content, string title)
        {
            container.Children.Clear();
            container.Children.Add(content);
            titleLabel.Text = title;
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            if(GlobalData.MediaSource != null)
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
            Navigation.PushModalAsync(new ModalPage(new DownloadPage(), Localization.TitleDownloads,false));
        }
    }
}