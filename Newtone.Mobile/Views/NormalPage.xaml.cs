using Newtone.Core.Logic;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Mobile.ViewModels;
using Newtone.Mobile.Logic;

namespace Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NormalPage : ContentPage, INavigationContainer
    {
        #region Properties
        private NormalViewModel ViewModel { get; set; }
        public static NormalPage Instance { get; set; }
        public static NavigationWrapper NavigationInstance
        {
            get
            {
                return new NavigationWrapper(Instance.Navigation);
            }
        }
        #endregion
        #region Constructors
        public NormalPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new NormalViewModel(container, playerPanel, searchEntry);
            Instance = this;
            Appearing += PageAppearing;
            Disappearing += PageDisappearing;
        }
        #endregion
        #region Public Methods
        public void Block()
        {
            blocker.IsVisible = true;
        }

        public void Unblock()
        {
            blocker.IsVisible = false;
        }
        public bool IsBlocked()
        {
            return blocker.IsVisible;
        }
        #endregion
        #region Private Methods
        private void PageDisappearing(object sender, EventArgs e)
        {
            ViewModel?.Disappearing();
        }

        private void PageAppearing(object sender, EventArgs e)
        {
            ViewModel?.Appearing();
        }

        private async void Entry_Completed(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ViewModel?.EntryText))
            {
                await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(ViewModel?.EntryText), ViewModel?.EntryText));
            }
        }
        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            ViewModel.SearchSuggestionsVisible = true;
            ViewModel?.RefreshSuggestion();
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            ViewModel.SearchSuggestionsVisible = false;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel?.RefreshSuggestion();
        }

        private void SuggestionList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel?.SuggestionItem_Selected(sender, e);
        }
        #endregion
    }
}