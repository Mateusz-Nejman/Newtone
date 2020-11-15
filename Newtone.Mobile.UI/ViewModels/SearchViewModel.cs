using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Mobile.UI.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.ViewModels
{
    public class SearchViewModel : PropertyChangedBase
    {
        #region Fields
        private ObservableCollection<HistoryModel> items;
        private ObservableCollection<HistoryModel> suggestionItems;
        private string searchText = string.Empty;
        private bool searchSuggestionsVisible = false;
        #endregion
        #region Properties
        public ObservableCollection<HistoryModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<HistoryModel> SuggestionItems
        {
            get => suggestionItems;
            set
            {
                suggestionItems = value;
                OnPropertyChanged();
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

        public bool SearchSuggestionsVisible
        {
            get => searchSuggestionsVisible;
            set
            {
                searchSuggestionsVisible = value;
                OnPropertyChanged();
                OnPropertyChanged(() => SearchSuggestionsVisibleNegative);
            }
        }

        public bool SearchSuggestionsVisibleNegative => !SearchSuggestionsVisible;
        #endregion
        #region Commands
        private ICommand clearCommand;
        public ICommand ClearList
        {
            get
            {
                if (clearCommand == null)
                    clearCommand = new ActionCommand(parameter =>
                    {
                        Items.Clear();
                        GlobalData.Current.History.Clear();
                        GlobalData.Current.SaveConfig();
                    });
                return clearCommand;
            }
        }

        #endregion
        #region Constructors
        public SearchViewModel()
        {
            SuggestionItems = new ObservableCollection<HistoryModel>();
            Items = new ObservableCollection<HistoryModel>();
            foreach (var item in GlobalData.Current.History.Reverse<HistoryModel>())
            {
                Items.Add(item);
            }
        }
        #endregion
        #region Public Methods

        public async void SearchEntry_Completed(string searchText)
        {
            SearchText = searchText;
            if (!string.IsNullOrEmpty(SearchText))
            {
                await Global.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(SearchText), SearchText));
            }
        }

        public async void Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                if (Global.Application.HasInternet())
                    await Global.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(Items[index].Text), Items[index].Text));
                else
                    await Global.Page.DisplayAlert(Localization.Warning, Localization.NoConnection, Localization.Cancel);

                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }

        public async void SuggestionItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < SuggestionItems.Count)
            {
                if (Global.Application.HasInternet())
                    await Global.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(SuggestionItems[index].Text), SuggestionItems[index].Text));
                else
                    await Global.Page.DisplayAlert(Localization.Warning, Localization.NoConnection, Localization.Cancel);

                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }

        public void RefreshSuggestion(string text)
        {
            SearchSuggestionsVisible = true;
            var newList = SearchProcessing.GenerateSearchSuggestions().FindAll(item => item.ToLowerInvariant().Contains(text.ToLowerInvariant()) || text.ToLowerInvariant().Contains(item.ToLowerInvariant()));

            SuggestionItems.Clear();
            foreach (var item in newList)
            {
                SuggestionItems.Add(new HistoryModel() { Text = item });
            }
        }
        #endregion
    }
}
