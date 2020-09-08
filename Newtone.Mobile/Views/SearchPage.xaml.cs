using Newtone.Core;
using Newtone.Core.Models;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Mobile.ViewModels;
using Newtone.Core.Logic;

namespace Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentView, ITimerContent
    {
        #region Properties
        private SearchViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public SearchPage()
        {
            InitializeComponent();
            ViewModel = BindingContext as SearchViewModel;
        }
        #endregion
        #region Private Methods
        public void SearchEntry_Completed(string text)
        {
            ViewModel?.SearchEntry_Completed(text);
        }

        private void HistoryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel?.Item_Selected(sender, e);
        }

        public void Tick()
        {
            if(GlobalData.Current.HistoryNeedRefresh)
            {
                ViewModel?.Items?.Clear();
                foreach (var item in GlobalData.Current.History.Reverse<HistoryModel>())
                {
                    ViewModel?.Items.Add(item);
                }
                GlobalData.Current.HistoryNeedRefresh = false;
            }
        }

        public void Appearing()
        {
            
        }

        public void Disappearing()
        {
            
        }
        #endregion
    }
}