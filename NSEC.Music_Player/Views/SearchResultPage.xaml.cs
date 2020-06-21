using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultPage : ContentView
    {
        #region Properties
        private SearchResultViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public SearchResultPage(string searchedText)
        {
            InitializeComponent();

            BindingContext = ViewModel = new SearchResultViewModel(searchedText);
        }
        #endregion
        #region Private Methods
        private async void SearchListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await ViewModel?.Item_Selected(sender, e);
        }
        #endregion
    }
}