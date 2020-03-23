using NSEC.Music_Player.Models;
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
    public partial class PlaylistGridItem : ContentView
    {
        public PlaylistGridItem(PlaylistListModel model)
        {
            InitializeComponent();
            playlistLabel.Text = model.Name;
            tracksLabel.Text = model.TrackElem;

            foreach (string filePath in Global.Playlists[model.Name])
            {
                Media.MediaSource source = Global.Audios[filePath];
                if (source.Picture != null)
                {
                    image.Source = ImageSource.FromStream(() => new MemoryStream(source.Picture));
                    break;
                }
            }

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            darker.GestureRecognizers.Add(tap);
            playlistLabel.GestureRecognizers.Add(tap);
            tracksLabel.GestureRecognizers.Add(tap);
            image.GestureRecognizers.Add(tap);
        }

        private async void Tap_Tapped(object sender, EventArgs e)
        {
            await MainPage.NavigationInstance.PushAsync(new TrackListPage(Global.Playlists[playlistLabel.Text]));
        }
    }
}