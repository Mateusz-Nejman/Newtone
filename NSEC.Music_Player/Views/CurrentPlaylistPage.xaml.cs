using Newtone.Core;
using Newtone.Core.Logic;
using NSEC.Music_Player.Media;
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
    public partial class CurrentPlaylistPage : ContentView, ITimerContent
    {
        private ObservableCollection<TrackModel> TrackItems { get; set; }
        public CurrentPlaylistPage()
        {
            InitializeComponent();
            trackListView.ItemsSource = TrackItems = new ObservableCollection<TrackModel>();
            foreach (var track in GlobalData.CurrentPlaylist)
            {
                TrackItems.Add(new TrackModel(track, "", false));
            }
        }

        public void Tick()
        {
            foreach (var model in TrackItems.ToList())
            {
                model.CheckChanges();
            }

        }

        private void TrackListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                var model = TrackItems[index];

                GlobalData.MediaSource = GlobalData.CurrentPlaylist[index];
                GlobalData.PlaylistPosition = index;
                GlobalData.MediaPlayer.Load(model.FilePath);
                MediaPlayerHelper.Play();
                trackListView.SelectedItem = null;
            }
        }
    }
}