using Nejman.Xamarin.FocusLibrary;
using Newtone.Mobile.UI.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultPage : ContentView, INFocusContent
    {
        #region Properties
        private SearchResultViewModel ViewModel { get; set; }
        public INFocusElement TopElement { get; set; }
        public INFocusElement BottomElement { get; set; }
        #endregion
        #region Constructors
        public SearchResultPage(string searchedText)
        {
            InitializeComponent();
            TopElement = searchResultList;
            BottomElement = searchResultList;
            BindingContext = ViewModel = new SearchResultViewModel(searchedText);
        }
        #endregion
    }
}