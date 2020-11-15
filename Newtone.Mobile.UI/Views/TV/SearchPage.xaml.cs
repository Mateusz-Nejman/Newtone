using Nejman.Xamarin.FocusLibrary;
using Newtone.Mobile.UI.ViewModels.TV;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentView, INFocusContent
    {
        public INFocusElement TopElement { get; set; }
        public INFocusElement BottomElement { get; set; }
        private SearchViewModel ViewModel { get; set; }
        public SearchPage()
        {
            InitializeComponent();
            TopElement = screenKeyboard;
            BottomElement = screenKeyboard;
            ViewModel = BindingContext as SearchViewModel;
            ScreenKeyboard_OnKeyboardClicked("");
        }

        private async void ScreenKeyboard_OnKeyboardClicked(string clickedButton)
        {
            if(clickedButton == NScreenKeyboard.EnterButton)
            {
                if (!string.IsNullOrEmpty(ViewModel.SearchText))
                {
                    await Global.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(ViewModel.SearchText), ViewModel.SearchText));
                }
            }
            else if(clickedButton == NScreenKeyboard.RemoveButton)
            {
                if (ViewModel.SearchText.Length > 0)
                {
                    ViewModel.SearchText = ViewModel.SearchText[0..^1];
                    ViewModel.RefreshSuggestion();
                }
            }
            else
            {
                ViewModel.SearchText += clickedButton.ToLowerInvariant();
                ViewModel.RefreshSuggestion();
            }
        }
    }
}