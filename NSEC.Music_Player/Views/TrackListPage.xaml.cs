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
        public TrackListPage(List<string> tracks)
        {
            InitializeComponent();
            trackList.ItemsSource = Items = new ObservableCollection<TrackListModel>();
            foreach(string filepath in tracks)
            {
                MediaSource source = Global.Audios[filepath];

                Items.Add(new TrackListModel() { Title = source.Title, Author = source.Artist, Tag = source.FilePath, Image = source.Picture == null ? Global.EmptyTrack : ImageSource.FromStream(() => new MemoryStream(source.Picture)) });
            }
        }

        private void TrackList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                List<MediaSource> playlist = new List<MediaSource>();

                foreach(TrackListModel model in Items)
                {
                    playlist.Add(Global.Audios[model.Tag]);
                }
                Navigation.PushAsync(new PlayerPage(Global.Audios[Items[e.SelectedItemIndex].Tag], playlist, e.SelectedItemIndex));
                trackList.SelectedItem = null;
            }
        }
    }
}