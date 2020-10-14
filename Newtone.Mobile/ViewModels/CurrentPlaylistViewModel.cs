﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Mobile.Media;
using Xamarin.Forms;
using TrackModel = Newtone.Mobile.Models.TrackModel;

namespace Newtone.Mobile.ViewModels
{
    public class CurrentPlaylistViewModel:PropertyChangedBase
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
                            TrackItems.Add(new TrackModel(track, "", false));
                        }
                        IsRefreshing = false;
                    });
                return refresh;
            }
        }
        #endregion
        #region Constructors
        public CurrentPlaylistViewModel()
        {
            TrackItems = new ObservableCollection<TrackModel>();
            foreach (var track in GlobalData.Current.CurrentPlaylist)
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

                GlobalData.Current.MediaSource = GlobalData.Current.CurrentPlaylist[index];
                GlobalData.Current.PlaylistPosition = index;
                GlobalData.Current.QueuePosition = index;
                GlobalData.Current.MediaPlayer.Load(model.FilePath);
                MediaPlayerHelper.Play();
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