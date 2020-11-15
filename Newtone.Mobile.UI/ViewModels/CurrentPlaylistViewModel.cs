using System;
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
    public class CurrentPlaylistViewModel : PropertyChangedBase
    {
        #region Fields
        private bool isRefreshing;
        #endregion
        #region Properties
        public ObservableCollection<TrackModel> TrackItems { get; set; }
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
                        TrackItems = new ObservableCollection<TrackModel>();
                        foreach (var track in GlobalData.Current.CurrentPlaylist)
                        {
                            TrackItems.Add(new TrackModel(track, "", false, true));
                        }
                        IsRefreshing = false;
                    });
                return refresh;
            }
        }

        private ICommand itemSelected;
        public ICommand ItemSelected
        {
            get
            {
                if (itemSelected == null)
                    itemSelected = new ActionCommand(parameter =>
                    {
                        int index = (int)parameter;
                        if (index >= 0 && index < TrackItems.Count)
                        {
                            GlobalData.Current.MediaPlayer.LoadPlaylist(TrackItems.Select(item => item.FilePath).ToList(), index, true, true);
                        }
                    });
                return itemSelected;
            }
        }
        #endregion
        #region Constructors
        public CurrentPlaylistViewModel()
        {
            TrackItems = new ObservableCollection<TrackModel>();
            foreach (var track in GlobalData.Current.CurrentPlaylist)
            {
                TrackItems.Add(new TrackModel(track, "", false, true));
            }
        }
        #endregion
        #region Public Methods
        public void TrackListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ItemSelected.Execute(e.SelectedItemIndex);
            if(!Global.TV)
            {
                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }

        public void Tick()
        {
            foreach (var model in TrackItems.ToList())
                model.CheckChanges();

            if(GlobalData.Current.CurrentPlaylistNeedRefresh)
            {
                TrackItems.Clear();

                foreach(var track in GlobalData.Current.CurrentPlaylist.ToList())
                {
                    TrackItems.Add(new TrackModel(track, "", false, true));
                }
                GlobalData.Current.CurrentPlaylistNeedRefresh = false;
            }
        }
        #endregion
    }
}
