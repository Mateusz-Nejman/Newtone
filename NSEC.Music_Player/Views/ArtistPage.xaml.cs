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
    public partial class ArtistPage : ContentPage
    {
        public ObservableCollection<Track> MenuItems { get; set; }
        public ArtistPage(string artist)
        {
            InitializeComponent();
            Title = artist;

            Appearing += TracksTab_Appearing;
            MenuItems = new ObservableCollection<Track>();

            List<Track> tracksBeforeSort = new List<Track>();
            foreach (string filepath in Global.Authors[artist])
            {
                MediaProcessing.MediaTag container = Global.Audios[filepath];
                tracksBeforeSort.Add(new Track() { Id = container.Artist + container.Title, Text = container.Title, Description = container.Artist, Container = container });
                //MenuItems.Add(new Track() { Id = container.Author + container.Title, Text = container.Title, Description = container.Author, Container = container });
            }

            List<Track> tracksAfterSort = tracksBeforeSort.OrderBy(o => o.Text).ToList();

            foreach (Track track in tracksAfterSort)
            {
                MenuItems.Add(track);
            }
            ArtistTrackListView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                Track item = e.SelectedItem as Track;

                await Navigation.PushAsync(new PlayerPage(item, MenuItems.ToList(), e.SelectedItemIndex));
            };

            ArtistTrackListView.BindingContext = this;


        }

        private void TracksTab_Appearing(object sender, EventArgs e)
        {
            base.OnAppearing();
            playerPanel.Refresh();
            ArtistTrackListView.SelectedItem = null;
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
            TrackProcessing.Process(sender, MenuItems, this);
        }
    }
}