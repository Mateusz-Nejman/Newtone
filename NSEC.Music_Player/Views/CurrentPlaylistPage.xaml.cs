using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentPlaylistPage : ContentPage
    {
        private ObservableCollection<TrackListModel> Items { get; set; }
        private PlayerPage PlayerPage { get; set; }
        public CurrentPlaylistPage(ImageSource currentBackground, PlayerPage playerPage)
        {
            InitializeComponent();
            PlayerPage = playerPage;
            trackImage.Source = currentBackground;
            trackList.ItemsSource = Items = new ObservableCollection<TrackListModel>();

            new Task(() =>
            {
                foreach (Media.MediaSource source in Global.CurrentPlaylist)
                {
                    Items.Add(source);
                }
            }).Start();
            
        }

        private void TrackList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            PlayerPage.ChangeTrack(e.SelectedItemIndex);
            Navigation.PopModalAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}