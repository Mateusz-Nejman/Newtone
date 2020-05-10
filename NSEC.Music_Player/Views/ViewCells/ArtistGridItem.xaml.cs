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
    public partial class ArtistGridItem : ContentView
    {
        private string ArtistName { get; set; }
        public ArtistGridItem(string artistName)
        {
            InitializeComponent();
            ArtistName = artistName;
            artistLabel.Text = artistName;
            tracksLabel.Text = Localization.TrackCount+": "+GlobalData.Artists[artistName].Count;

            foreach (string filePath in GlobalData.Artists[artistName])
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
            if(GlobalData.Artists[ArtistName].Count > 0)
            {
                GlobalData.CurrentPlaylist.Clear();

                foreach (var item in GlobalData.Artists[ArtistName])
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
            await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new CurrentTracksPage(GlobalData.Artists[ArtistName], ""),ArtistName));
            //await MainPage.NavigationInstance.PushAsync(new TrackListPage(Global.Artists[ArtistName], ""));
        }
    }
}