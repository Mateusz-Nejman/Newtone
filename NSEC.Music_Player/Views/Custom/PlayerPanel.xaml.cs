using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Custom
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

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Label_Tapped;

            artistLabel.GestureRecognizers.Add(tapGestureRecognizer);
            titleLabel.GestureRecognizers.Add(tapGestureRecognizer);

            Device.StartTimer(TimeSpan.FromSeconds(0.5), UpdatePanel);
        }

        private async void Label_Tapped(object sender, EventArgs e)
        {
            if(Global.PlaylistType == Media.MediaSource.SourceType.Local)
                await Navigation.PushAsync(new PlayerPage(Global.CurrentPlaylist[Global.PlaylistPosition], Global.CurrentPlaylist, Global.PlaylistPosition));
            else
            {
                await Navigation.PushAsync(new StreamPlayerPage(Global.MediaSource, Global.CurrentPlaylist,Global.PlaylistPosition));
            }
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            if (Global.MediaPlayer.IsPlaying)
                Global.MediaPlayer.Pause();
            else
                Global.MediaPlayer.Play();

            bool start = Global.MediaPlayer.IsPlaying;
            playButton.ImageSource = start ? ImageSource.FromFile("PauseIcon.png") : ImageSource.FromFile("PlayIcon.png");
            Global.LastPlayerClick = start;
        }

        public void Refresh()
        {
            if (Global.MediaSource != null)
            {
                titleLabel.Text = Global.MediaSource.Title;
                artistLabel.Text = Global.MediaSource.Artist;
                bool start = Global.MediaPlayer.IsPlaying;
                playButton.ImageSource = start ? ImageSource.FromFile("PauseIcon.png") : ImageSource.FromFile("PlayIcon.png");
                if (Global.MediaSource.FilePath != oldTrack)
                {
                    oldTrack = Global.MediaSource.FilePath;
                    image.Source = Global.MediaSource.Picture != null ? ImageSource.FromStream(() => new MemoryStream(Global.MediaSource.Picture)) : ImageSource.FromFile("EmptyTrack.png");
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