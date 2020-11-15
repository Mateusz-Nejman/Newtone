using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Mobile.UI.Views;
using Xamarin.Forms;
using TrackModel = Newtone.Mobile.UI.Models.TrackModel;

namespace Newtone.Mobile.UI.ViewModels
{
    public class CurrentTracksViewModel : PropertyChangedBase
    {
        #region Fields
        private bool isRefreshing;
        private readonly List<string> tracks;
        private readonly string playlistName;
        #endregion
        #region Properties
        public ObservableCollection<TrackModel> TrackItems { get; private set; }
        public ObservableCollection<NListViewItem> ListItems { get; private set; }
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
                        foreach (string track in tracks)
                        {
                            if (GlobalData.Current.Audios.ContainsKey(track))
                            {
                                beforeSort.Add(new TrackModel(GlobalData.Current.Audios[track], playlistName).CheckChanges());
                            }
                        }
                        TrackItems = new ObservableCollection<TrackModel>(playlistName == "" ? beforeSort.OrderBy(item => item.TrackString).ToList() : beforeSort);
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
        public CurrentTracksViewModel(List<string> tracks, string playlistName)
        {
            this.tracks = tracks;
            this.playlistName = playlistName;
            List<TrackModel> beforeSort = new List<TrackModel>();
            foreach (string track in tracks)
            {
                if (GlobalData.Current.Audios.ContainsKey(track))
                {
                    beforeSort.Add(new TrackModel(GlobalData.Current.Audios[track], playlistName).CheckChanges());
                }
                else if(GlobalData.Current.SavedTracks.ContainsKey(track))
                {
                    beforeSort.Add(new TrackModel(GlobalData.Current.SavedTracks[track], playlistName).CheckChanges());
                }
            }
            TrackItems = new ObservableCollection<TrackModel>(playlistName == "" ? beforeSort.OrderBy(item => item.TrackString).ToList() : beforeSort);
            ListItems = new ObservableCollection<NListViewItem>();

            foreach(var item in TrackItems)
            {
                ListItems.Add(item);
            }
        }
        #endregion
        #region Public Methods

        public void Tick()
        {
            if (TrackItems.Count == 0)
            {
                _ = Global.NavigationInstance.PopModalAsync();
                return;
            }

            if(GlobalData.Current.PlaylistsNeedRefresh)
            {
                TrackItems.Clear();
                ListItems.Clear();

                List<TrackModel> beforeSort = new List<TrackModel>();
                foreach (string track in tracks)
                {
                    if (GlobalData.Current.Audios.ContainsKey(track))
                    {
                        beforeSort.Add(new TrackModel(GlobalData.Current.Audios[track], playlistName).CheckChanges());
                    }
                    else if (GlobalData.Current.SavedTracks.ContainsKey(track))
                    {
                        beforeSort.Add(new TrackModel(GlobalData.Current.SavedTracks[track], playlistName).CheckChanges());
                    }
                }
                var afterSort = playlistName == "" ? beforeSort.OrderBy(item => item.TrackString).ToList() : beforeSort;

                foreach(var item in afterSort)
                {
                    TrackItems.Add(item);
                    ListItems.Add(TrackItems[^1]);
                }

                GlobalData.Current.PlaylistsNeedRefresh = false;
            }

            foreach (var model in TrackItems.ToList())
            {

                if (GlobalData.Current.Audios.ContainsKey(model.FilePath))
                {
                    var source = GlobalData.Current.Audios[model.FilePath];
                    if (model.Artist != source.Artist || model.Title != source.Title)
                    {
                        int index = TrackItems.IndexOf(model);
                        TrackItems[index].Title = source.Title;
                        TrackItems[index].Artist = source.Artist;
                        ListItems[index] = model;
                    }
                    model.CheckChanges();
                }
                else if(GlobalData.Current.SavedTracks.ContainsKey(model.FilePath))
                {
                    var source = GlobalData.Current.SavedTracks[model.FilePath];
                    if (model.Artist != source.Artist || model.Title != source.Title)
                    {
                        int index = TrackItems.IndexOf(model);
                        TrackItems[index].Title = source.Title;
                        TrackItems[index].Artist = source.Artist;
                        ListItems[index] = model;
                    }
                    model.CheckChanges();
                }
                else
                {
                    TrackItems.Remove(model);
                    Device.BeginInvokeOnMainThread(() => ListItems.Remove(model));
                }
            }
        }

        public void TrackListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ItemSelected.Execute(e.SelectedItemIndex);
            if (!Global.TV)
            {
                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }
        #endregion
    }
}
