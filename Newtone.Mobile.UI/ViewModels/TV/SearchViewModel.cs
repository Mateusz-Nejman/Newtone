using Nejman.Xamarin.FocusLibrary;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Mobile.UI.Models;
using Newtone.Mobile.UI.Views.TV.ViewCells;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.ViewModels.TV
{
    public class SearchViewModel : PropertyChangedBase
    {
        #region Fields
        private string searchText;
        private ObservableCollection<NListViewItem> suggestionItems;
        #endregion
        #region Properties
        public bool SearchTextVisible { get; private set; }

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();

                SearchTextVisible = searchText.Length > 0;
                OnPropertyChanged(() => SearchTextVisible);
            }
        }

        public ObservableCollection<NListViewItem> SuggestionItems
        {
            get => suggestionItems;
            set
            {
                suggestionItems = value;
                OnPropertyChanged();
            }
        }

        public Func<NListViewItem, View> ItemTemplate => item => new SuggestionViewCell(item);
        #endregion
        #region Constructors
        public SearchViewModel()
        {
            SuggestionItems = new ObservableCollection<NListViewItem>();
        }
        #endregion
        #region Public Methods
        public void RefreshSuggestion()
        {
            string searchedText = SearchText ?? "";
            var newList = SearchProcessing.GenerateSearchSuggestions().FindAll(
                item => searchedText.ToLowerInvariant().Contains(item.ToLowerInvariant()) || item.ToLowerInvariant().Contains(searchedText.ToLowerInvariant()));

            SuggestionItems.Clear();
            foreach (var item in newList)
            {
                SuggestionItems.Add(new SuggestionModel() { Text = item });
            }
        }
        #endregion
    }
}
