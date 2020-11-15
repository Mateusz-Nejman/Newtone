using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Xamarin.Forms;
using TrackModel = Newtone.Mobile.UI.Models.TrackModel;

namespace Newtone.Mobile.UI.ViewModels
{
    public class TrackViewModel : PropertyChangedBase
    {
        #region Fields
        private bool isRefreshing;
        #endregion
        #region Properties
        public ObservableCollection<TrackModel> Items { get; set; }
        public ObservableCollection<NListViewItem> ListItems { get; set; }
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
        public Func<NListViewItem, View> ItemTemplate
        {
            get => item => new Views.TV.ViewCells.TrackViewCell(item);
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
                        IsRefreshing = true;
                        List<TrackModel> beforeSort = new List<TrackModel>();
                        foreach (var track in GlobalData.Current.Audios.Values)
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
            foreach (var track in GlobalData.Current.Audios.Values.ToList())
            {
                beforeSort.Add(new TrackModel(track).CheckChanges());
            }
            Items = new ObservableCollection<TrackModel>(beforeSort.OrderBy(item => item.TrackString));
            ListItems = new ObservableCollection<NListViewItem>();

            foreach(var item in Items)
            {
                ListItems.Add(item);
            }
        }
        #endregion
        #region Public Methods

        public void Tick()
        {
            if (Items.Count != GlobalData.Current.Audios.Count)
            {
                Items.Clear();
                ListItems.Clear();
                List<TrackModel> beforeSort = new List<TrackModel>();
                foreach (var track in GlobalData.Current.Audios.Values.ToList())
                {
                    beforeSort.Add(new TrackModel(track).CheckChanges());
                }
                foreach (var item in beforeSort.OrderBy(item => item.TrackString))
                {
                    Items.Add(item);
                    ListItems.Add(Items[^1]);
                }
            }
            foreach (var model in Items.ToList())
            {
                if (GlobalData.Current.Audios.ContainsKey(model.FilePath))
                {
                    var source = GlobalData.Current.Audios[model.FilePath];
                    int index = Items.IndexOf(model);
                    if (model.Artist != source.Artist || model.Title != source.Title)
                    {
                        Items[index].Title = source.Title;
                        Items[index].Artist = source.Artist;
                    }
                    model.CheckChanges();
                    ListItems[index] = model;
                }
                else
                {
                    Items.Remove(model);
                    ListItems.Remove(model);
                }
            }

        }

        public void Track_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                GlobalData.Current.MediaPlayer.LoadPlaylist(Items.Select(item => item.FilePath).ToList(), index, true, true);
                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }

        #endregion
    }
}
