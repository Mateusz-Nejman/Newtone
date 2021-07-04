using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Data;
using Nejman.Newtone.Core.Localization;
using Nejman.Newtone.Mobile.Models;
using Nejman.Newtone.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.ViewModels
{
    public class PlaylistsListViewModel : PropertyChangedBase
    {
        #region Fields
        private bool isRefreshing;
        private IDisposable refreshListener;
        private string title;
        #endregion
        #region Properties
        public ObservableCollection<PlaylistModel> Items { get; set; }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
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
        #region Constructors
        public PlaylistsListViewModel()
        {
            Items = new ObservableCollection<PlaylistModel>();
            Title = Localization.Playlists;
        }
        #endregion
        #region Public Methods

        public void PlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                var playlist = Items[index];
                ShellHelpers.GoTo($"{nameof(TracksListPage)}?{nameof(TracksListViewModel.PlaylistName)}={playlist.Name}");
                (sender as ListView).SelectedItem = null;
            }
        }

        public void Appearing()
        {
            refreshListener = CoreGlobal.PlaylistsRefresh.Subscribe(refresh =>
            {
                if (refresh == "")
                {
                    Refresh();
                }
            });
            Refresh();
        }

        public void Disappearing()
        {
            refreshListener?.Dispose();
            refreshListener = null;
        }
        #endregion
        #region Private Methods
        private void Refresh()
        {
            if (IsRefreshing)
            {
                return;
            }

            IsRefreshing = true;
            Items.Clear();

            var playlists = PlaylistsAction.GetPlaylists();

            foreach (var playlist in playlists)
            {
                Items.Add(new PlaylistModel(playlist.Name, playlist.Image));
            }

            IsRefreshing = false;
        }
        #endregion
    }
}
