using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackListPage : ContentPage
    {
        private ObservableCollection<TrackListModel> Items { get; set; }
        private bool Playlist { get; set; }
        private string PlaylistName { get; set; }
        public TrackListPage(List<string> tracks, string playlistName, bool playlist = false)
        {
            InitializeComponent();
            trackList.ItemsSource = Items = new ObservableCollection<TrackListModel>();
            PlaylistName = playlistName;
            foreach(string filepath in tracks)
            {
                Media.MediaSource source = Global.Audios[filepath];

                Items.Add(new TrackListModel() { Title = source.Title, Author = source.Artist, Tag = source.FilePath+Global.SEPARATOR+(playlist ? "true" : "false")+Global.SEPARATOR+PlaylistName, Image = source.Picture == null ? Global.EmptyTrack : ImageSource.FromStream(() => new MemoryStream(source.Picture)), IsPlaylist = Playlist });;
            }
            Playlist = playlist;
        }

        private async void TrackList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(!PlayerPage.Showed)
            {
                if (e.SelectedItem != null)
                {
                    List<Media.MediaSource> playlist = new List<Media.MediaSource>();

                    foreach (TrackListModel model in Items)
                    {
                        playlist.Add(Global.Audios[model.Tag.Split(Global.SEPARATOR)[0]]);
                    }
                    await Navigation.PushModalAsync(new PlayerPage(Global.Audios[Items[e.SelectedItemIndex].Tag.Split(Global.SEPARATOR)[0]], playlist, e.SelectedItemIndex));
                    trackList.SelectedItem = null;
                }
            }
        }
    }
}