using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPanel : ContentView
    {
        private string oldTrack = "";
        public PlayerPanel()
        {
            InitializeComponent();
            IsVisible = false;
            HeightRequest = 64;
            VerticalOptions = LayoutOptions.End;
            playStopButton.Clicked += PlayStopButton_Clicked;

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Label_Tapped;

            artistLabel.GestureRecognizers.Add(tapGestureRecognizer);
            titleLabel.GestureRecognizers.Add(tapGestureRecognizer);

            Device.StartTimer(TimeSpan.FromSeconds(0.5), UpdatePanel);
        }

        private async void Label_Tapped(object sender, EventArgs e)
        {
            Console.WriteLine($"PlayerPanel " + Global.CurrentPlaylistPosition);
            await Navigation.PushAsync(new PlayerPage(Global.CurrentPlaylist[Global.CurrentPlaylistPosition], Global.CurrentPlaylist, Global.CurrentPlaylistPosition));
        }

        private void PlayStopButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("ProcessNewIntent -> "+Global.CurrentTrack.FilePath);
            if (Global.MediaPlayer.IsPlaying)
                Global.MediaPlayer.Pause();
            else
                Global.MediaPlayer.Play();

            bool start = Global.MediaPlayer.IsPlaying;
            playStopButton.ImageSource = start ? ImageSource.FromFile("pauseIcon.png") : ImageSource.FromFile("playIcon.png");
            Global.LastPlayerClick = start;
        }

        public void Refresh()
        {
            if (Global.CurrentTrack != null)
            {
                titleLabel.Text = Global.CurrentTrack.Title;
                artistLabel.Text = Global.CurrentTrack.Artist;
                bool start = Global.MediaPlayer.IsPlaying;
                playStopButton.ImageSource = start ? ImageSource.FromFile("pauseIcon.png") : ImageSource.FromFile("playIcon.png");
                if (Global.CurrentTrack.FilePath != oldTrack)
                {
                    oldTrack = Global.CurrentTrack.FilePath;
                    trackImage.Source = Global.CurrentTrack.Picture != null ? ImageSource.FromStream(() => new MemoryStream(Global.CurrentTrack.Picture)) : ImageSource.FromFile("emptyTrack.png");
                }


                IsVisible = true;
            }
            else
                IsVisible = false;

        }

        public bool UpdatePanel()
        {
            Refresh();
            return true;
        }
    }
}