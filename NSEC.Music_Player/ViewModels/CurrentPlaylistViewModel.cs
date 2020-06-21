using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core;
using Newtone.Core.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using Xamarin.Forms;

namespace NSEC.Music_Player.ViewModels
{
    public class CurrentPlaylistViewModel
    {
        #region Properties
        public ObservableCollection<TrackModel> TrackItems { get; set; }
        #endregion
        #region Constructors
        public CurrentPlaylistViewModel()
        {
            TrackItems = new ObservableCollection<TrackModel>();
            foreach (var track in GlobalData.CurrentPlaylist)
            {
                TrackItems.Add(new TrackModel(track, "", false));
            }
        }
        #endregion
        #region Public Methods
        public void TrackListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                var model = TrackItems[index];

                GlobalData.MediaSource = GlobalData.CurrentPlaylist[index];
                GlobalData.PlaylistPosition = index;
                GlobalData.MediaPlayer.Load(model.FilePath);
                MediaPlayerHelper.Play();
                ConsoleDebug.WriteLine(sender is Xamarin.Forms.ListView);
                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }

        public void Tick()
        {
            foreach (var model in TrackItems.ToList())
                model.CheckChanges();
        }
        #endregion
    }
}