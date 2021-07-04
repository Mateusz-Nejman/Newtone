using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Data;
using Nejman.Newtone.Core.Localization;
using Nejman.Newtone.Mobile.Models;
using Nejman.Newtone.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.ViewModels
{
    public class ArtistsListViewModel : PropertyChangedBase
    {
        #region Fields
        private bool isRefreshing;
        private IDisposable refreshListener;
        private string title;
        #endregion
        #region Properties
        public ObservableCollection<ArtistModel> Items { get; set; }

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
        public ArtistsListViewModel()
        {
            Items = new ObservableCollection<ArtistModel>();
            Title = Localization.Artists;
        }
        #endregion
        #region Public Methods

        public void ArtistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                var artist = Items[index];
                ShellHelpers.GoTo($"{nameof(TracksListPage)}?{nameof(TracksListViewModel.ArtistName)}={artist.Name}");

                (sender as ListView).SelectedItem = null;
            }
        }

        public void Appearing()
        {
            refreshListener = CoreGlobal.ArtistsRefresh.Subscribe(refresh =>
            {
                if(refresh == "")
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
            if(IsRefreshing)
            {
                return;
            }

            IsRefreshing = true;
            Items.Clear();

            var artists = ArtistsAction.GetArtistsSorted();

            foreach(var artist in artists)
            {
                Items.Add(new ArtistModel(artist.Name, artist.Image));
            }

            IsRefreshing = false;
        }
        #endregion
    }
}
