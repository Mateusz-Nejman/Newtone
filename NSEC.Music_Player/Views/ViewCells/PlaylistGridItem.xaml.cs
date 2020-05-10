using Newtone.Core;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistGridItem : ContentView
    {
        private string PlaylistName { get; set; }
        public PlaylistGridItem(string playlistName)
        {
            InitializeComponent();
            PlaylistName = playlistName;
            playlistLabel.Text = playlistName;
            tracksLabel.Text = Localization.TrackCount + ": " + GlobalData.Playlists[playlistName].Count;

            foreach (string filePath in GlobalData.Playlists[playlistName])
            {
                var source = GlobalData.Audios[filePath];
                if (source.Image != null)
                {
                    image.Source = ImageProcessing.FromArray(source.Image);
                    break;
                }
            }
        }

        private void LongPressed(object sender, EventArgs e)
        {
            if (GlobalData.Playlists[PlaylistName].Count > 0)
            {
                GlobalData.CurrentPlaylist.Clear();

                foreach (var item in GlobalData.Playlists[PlaylistName])
                {
                    GlobalData.CurrentPlaylist.Add(GlobalData.Audios[item]);
                }

                GlobalData.PlaylistPosition = 0;
                GlobalData.MediaPlayer.Load(GlobalData.CurrentPlaylist[0].FilePath);
                GlobalData.MediaSource = GlobalData.CurrentPlaylist[0];
                GlobalData.MediaPlayer.Play();
            }
        }

        private async void Pressed(object sender, EventArgs e)
        {
            await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new CurrentTracksPage(GlobalData.Playlists[PlaylistName], PlaylistName), PlaylistName));
            //await MainPage.NavigationInstance.PushAsync(new TrackListPage(Global.Artists[ArtistName], ""));
        }
    }
}