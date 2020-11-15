using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Mobile.UI.ViewModels.TV;
using Newtone.Mobile.UI.Logic;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Mobile.UI.ViewModels.TV.Custom;

namespace Newtone.Mobile.UI.Views.TV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NormalPage : ContentPage
    {
        #region Properties
        private NormalViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public NormalPage()
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);
            var safeAreaInset = On<iOS>().SafeAreaInsets();
            page.Padding = safeAreaInset;
            BindingContext = ViewModel = new NormalViewModel(container, playerPanel, searchButton, playerButton);
            Global.NavigationInstance = new NavigationWrapper(this.Navigation);
            Global.Page = this;
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
            FocusContext.UnfocusAll();
            artistButton.IsNFocused = true;
            (this.playerPanel.BindingContext as PlayerPanelViewModel).NextFocusUp = playerButton;
            (this.playerPanel.BindingContext as PlayerPanelViewModel).NextFocusUp1 = playlistButton;

            playerButton.NextFocusDown = this.playerPanel.ImageButton;
            trackButton.NextFocusDown = this.playerPanel.ImageButton;
            artistButton.NextFocusDown = this.playerPanel.PlayButton;
            playlistButton.NextFocusDown = this.playerPanel.PlayButton;
        }

        private async void Entry_Completed(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ViewModel?.EntryText))
            {
                await Global.NavigationInstance.PushModalAsync(new ModalPage(new Views.SearchResultPage(ViewModel?.EntryText), ViewModel?.EntryText));
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