using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Mobile.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.ViewModels
{
    public class SearchViewModel : PropertyChangedBase
    {
        #region Fields
        private ObservableCollection<HistoryModel> items;
        private string searchText;
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
                        GlobalData.History.Clear();
                        GlobalData.SaveConfig();
                    });
                return clearCommand;
            }
        }

        #endregion
        #region Constructors
        public SearchViewModel()
        {
            Items = new ObservableCollection<HistoryModel>();
            foreach (var item in GlobalData.History.Reverse<HistoryModel>())
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
                if (MainActivity.IsInternet())
                    await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(SearchText), SearchText));
                else
                    await NormalPage.Instance.DisplayAlert(Localization.Warning, Localization.NoConnection, Localization.Cancel);
            }
        }

        public async void Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                if (MainActivity.IsInternet())
                    await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(Items[index].Text), Items[index].Text));
                else
                    await NormalPage.Instance.DisplayAlert(Localization.Warning, Localization.NoConnection, Localization.Cancel);

                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }
        #endregion
    }
}