using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Security;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Mobile.Media;
using Newtone.Mobile.Models;
using Xamarin.Forms;
using TrackModel = Newtone.Mobile.Models.TrackModel;

namespace Newtone.Mobile.ViewModels
{
    public class TrackViewModel:PropertyChangedBase
    {
        #region Fields
        private bool isRefreshing;
        #endregion
        #region Properties
        public ObservableCollection<TrackModel> Items { get; set; }
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand refresh;
        public ICommand Refresh
        {
            get
            {
                if (refresh == null)
                    refresh = new ActionCommand(parameter =>
                    {
                        ConsoleDebug.WriteLine("[Refresh] TrackViewModel");
                        IsRefreshing = true;
                        List<TrackModel> beforeSort = new List<TrackModel>();
                        foreach (var track in GlobalData.Audios.Values)
                        {
                            beforeSort.Add(new TrackModel(track).CheckChanges());
                        }
                        Items = new ObservableCollection<TrackModel>(beforeSort.OrderBy(item => item.TrackString));
                        IsRefreshing = false;
                    });
                return refresh;
            }
        }
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