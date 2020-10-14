using Newtone.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.Views
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

        private void SearchListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            ViewModel?.SearchListView_ItemAppearing(e.ItemIndex);
        }
        #endregion
    }
}