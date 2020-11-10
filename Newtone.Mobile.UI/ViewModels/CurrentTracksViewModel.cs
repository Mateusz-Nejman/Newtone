using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
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
        }
        #endregion
        #region Public Methods

        public void Tick()
        {
            if (TrackItems.Count == 0)
            {
                _ = NormalPage.NavigationInstance.PopModalAsync();
                return;
            }

            if(GlobalData.Current.PlaylistsNeedRefresh)
            {
                TrackItems.Clear();

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
                GlobalData.Current.MediaPlayer.LoadPlaylist(TrackItems.Select(item => item.FilePath).ToList(), index, true, true);
                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }
        #endregion
    }
}
