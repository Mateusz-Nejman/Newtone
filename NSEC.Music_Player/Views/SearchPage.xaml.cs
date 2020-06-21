using Newtone.Core;
using Newtone.Core.Models;
using Newtone.Core.Languages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NSEC.Music_Player.ViewModels;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentView
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
        private void SearchEntry_Completed(object sender, EventArgs e)
        {
            ViewModel?.SearchEntry_Completed(sender, e);
        }

        private void HistoryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel?.Item_Selected(sender, e);
        }
        #endregion
    }
}