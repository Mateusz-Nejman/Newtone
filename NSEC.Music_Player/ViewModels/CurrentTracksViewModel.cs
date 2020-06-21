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
using Newtone.Core.Media;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using Xamarin.Forms;

namespace NSEC.Music_Player.ViewModels
{
    public class CurrentTracksViewModel
    {
        #region Properties
        public ObservableCollection<TrackModel> TrackItems { get; private set; }
        #endregion
        #region Constructors
        public CurrentTracksViewModel(List<string> tracks, string playlistName)
        {
            List<TrackModel> beforeSort = new List<TrackModel>();
            foreach (string track in tracks)
            {
                if (GlobalData.Audios.ContainsKey(track))
                {
                    beforeSort.Add(new TrackModel(GlobalData.Audios[track], playlistName).CheckChanges());
                }
            }
            TrackItems = new ObservableCollection<TrackModel>(playlistName == "" ? beforeSort.OrderBy(item => item.TrackString).ToList() : beforeSort);
        }
        #endregion
        #region Public Methods

        public void Tick()
        {
            foreach (var model in TrackItems.ToList())
            {

                if (GlobalData.Audios.ContainsKey(model.FilePath))
                {
                    var source = GlobalData.Audios[model.FilePath];
                    if (model.Artist != source.Artist || model.Title != source.Title)
                    {
                        int index = TrackItems.IndexOf(model);
                        TrackItems[index].Title = source.Title;
                        TrackItems[index].Artist = source.Artist;
                    }
                    model.CheckChanges();
                }
                else
                {
                    TrackItems.Remove(model);
                }
            }
        }

        public void TrackListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                var model = TrackItems[index];

                GlobalData.MediaSource = GlobalData.Audios[model.FilePath];
                GlobalData.CurrentPlaylist.Clear();
                GlobalData.PlaylistPosition = index;
                foreach (var item in TrackItems)
                {
                    GlobalData.CurrentPlaylist.Add(GlobalData.Audios[item.FilePath]);
                }
                GlobalData.MediaPlayer.Load(model.FilePath);
                MediaPlayerHelper.Play();
                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }
        #endregion
    }
}