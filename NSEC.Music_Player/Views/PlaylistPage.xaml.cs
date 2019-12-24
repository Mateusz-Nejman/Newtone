using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistPage : ContentPage
    {
        public ObservableCollection<Track> MenuItems { get; set; }
        public PlaylistPage(string playlist)
        {
            InitializeComponent();
            Title = playlist;

            this.Appearing += TracksTab_Appearing;
            MenuItems = new ObservableCollection<Track>();

            List<Track> playlistTracks = Global.Playlists[playlist];

            foreach (Track track in playlistTracks)
            {
                MenuItems.Add(track);
            }
            PlaylistTrackListView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                Track item = e.SelectedItem as Track;

                await Navigation.PushAsync(new PlayerPage(item, MenuItems.ToList(), e.SelectedItemIndex));
            };

            PlaylistTrackListView.BindingContext = this;


        }

        private void TracksTab_Appearing(object sender, EventArgs e)
        {
            base.OnAppearing();
            playerPanel.Refresh();
            PlaylistTrackListView.SelectedItem = null;
            //labelTest.Text += "a ";
        }
        void OnTrackSelected(object sender, SelectedItemChangedEventArgs args)
        {


            for (int a = 0; a < MenuItems.Count; a++)
            {
                MenuItems[a].Selected(args.SelectedItemIndex == a);
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            TrackProcessing.Process(sender, MenuItems, this, true, Title);
        }
    }
}