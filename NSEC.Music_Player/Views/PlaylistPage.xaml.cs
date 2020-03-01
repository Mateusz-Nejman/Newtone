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
    public partial class PlaylistPage : ContentPage
    {
        private ObservableCollection<PlaylistListModel> Items { get; set; }
        public PlaylistPage()
        {
            InitializeComponent();
            playlistList.ItemsSource = Items = new ObservableCollection<PlaylistListModel>();

            foreach(string playlistName in Global.Playlists.Keys)
            {
                Items.Add(new PlaylistListModel() { Name = playlistName, TrackCount = Global.Playlists[playlistName].Count });
            }
        }

        private void PlaylistList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                string playlist = Items[e.SelectedItemIndex].Name;
                Navigation.PushAsync(new TrackListPage(Global.Playlists[playlist]));
                playlistList.SelectedItem = null;
            }
        }
    }
}