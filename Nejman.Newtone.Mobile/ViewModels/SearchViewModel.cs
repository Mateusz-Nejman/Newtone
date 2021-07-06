using Nejman.Newtone.Core;
using Nejman.Newtone.Core.External;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Mobile.Implementations;
using Nejman.Newtone.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.ViewModels
{
    [QueryProperty(nameof(SearchQuery), nameof(SearchQuery))]
    [QueryProperty(nameof(SearchQueryBase), nameof(SearchQueryBase))]
    public class SearchViewModel : PropertyChangedBase
    {
        #region Fields
        private ObservableCollection<SearchModel> items;
        private readonly ObservableBridge<MediaSource> rawItems;
        private bool spinnerVisible = false;
        private string searchQuery;
        private string searchText;
        #endregion

        #region Properties
        public ObservableCollection<SearchModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public bool SpinnerVisible
        {
            get => spinnerVisible;
            set
            {
                spinnerVisible = value;
                OnPropertyChanged();
            }
        }

        public string SearchQuery
        {
            get => searchQuery;
            set
            {
                searchQuery = value;
                Task.Run(async () => await Search());
            }
        }

        public string SearchQueryBase
        {
            get => HttpUtility.UrlEncode(searchQuery);
            set
            {
                searchQuery = HttpUtility.UrlDecode(value);
                Task.Run(async () => await Search());
            }
        }

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Constructors
        public SearchViewModel()
        {
            Items = new ObservableCollection<SearchModel>();

            rawItems = new ObservableBridge<MediaSource>
            {
                Action = model =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Items.Add(new SearchModel(model));
                    });
                }
            };
        }
        #endregion
        #region Public Methods
        public async Task Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                ShellHelpers.GoTo("PlayerPage");
                await CoreGlobal.MediaPlayer.LoadPlaylist(Items.Select(source => new MediaSource(source.ID, source.Artist, source.Title, source.Duration, source.ImageBytes, source.ID, source.ImageUrl)).ToList(), index);

                (sender as ListView).SelectedItem = null;
            }
        }
        #endregion
        #region Private Methods
        private async Task Search()
        {
            SpinnerVisible = true;
            
            if(ApplicationImplementation.Current.HasInternet())
            {
                Items.Clear();
                await YoutubeExplodeIntegration.Search(SearchQuery, rawItems);
            }

            for (int a = 0; a < Items.Count; a++)
            {
                Items[a].DownloadImage();
            }

            SpinnerVisible = false;
        }
        #endregion
    }
}
