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
    public partial class ArtistGridItem : ContentView
    {
        private string ArtistName { get; set; }
        public ArtistGridItem(ArtistListModel model)
        {
            InitializeComponent();
            ArtistName = model.Name;
            artistLabel.Text = model.Name;
            tracksLabel.Text = model.TrackElem;

            foreach(string filePath in Global.Artists[model.Name])
            {
                Media.MediaSource source = Global.Audios[filePath];
                if (source.Picture != null)
                {
                    image.Source = ImageSource.FromStream(() => new MemoryStream(source.Picture));
                    break;
                }
            }
        }

        private async void LongPressed(object sender, EventArgs e)
        {
            if (!PlayerPage.Showed)
            {
                List<string> artistTracks = new List<string>(Global.Artists[ArtistName]);
                List<Media.MediaSource> playlist = new List<Media.MediaSource>();

                foreach (string track in artistTracks)
                {
                    if (Global.Audios.ContainsKey(track))
                        playlist.Add(Global.Audios[track]);
                }

                if (playlist.Count > 0)
                    await Navigation.PushModalAsync(new PlayerPage(playlist[0], playlist, 0));
            }
        }

        private async void Pressed(object sender, EventArgs e)
        {
            await MainPage.NavigationInstance.PushAsync(new TrackListPage(Global.Artists[ArtistName], ""));
        }
    }
}