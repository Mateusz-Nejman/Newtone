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
    public class TrackViewModel
    {
        #region Properties
        public ObservableCollection<TrackModel> Items { get; set; }
        #endregion
        #region Constructors
        public TrackViewModel()
        {
            List<TrackModel> beforeSort = new List<TrackModel>();
            foreach (var track in GlobalData.Audios.Values)
            {
                beforeSort.Add(new TrackModel(track).CheckChanges());
            }
            Items = new ObservableCollection<TrackModel>(beforeSort.OrderBy(item => item.TrackString));
        }
        #endregion
        #region Public Methods

        public void Tick()
        {
            foreach (var model in Items.ToList())
            {

                if (GlobalData.Audios.ContainsKey(model.FilePath))
                {
                    var source = GlobalData.Audios[model.FilePath];
                    if (model.Artist != source.Artist || model.Title != source.Title)
                    {
                        int index = Items.IndexOf(model);
                        Items[index].Title = source.Title;
                        Items[index].Artist = source.Artist;
                    }
                    model.CheckChanges();
                }
                else
                {
                    Items.Remove(model);
                }
            }

        }

        public void Track_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                var model = Items[index];

                GlobalData.MediaSource = GlobalData.Audios[model.FilePath];
                GlobalData.CurrentPlaylist.Clear();
                GlobalData.PlaylistPosition = index;
                foreach (var item in Items)
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