using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Mobile.UI.ViewModels;

namespace Newtone.Mobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentView
    {
        #region Properties
        private SettingsViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public SettingsPage()
        {
            InitializeComponent();

            ViewModel = BindingContext as SettingsViewModel;
        }
        #endregion
        #region Private Methods
        private async void SettingsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await ViewModel?.Item_Selected(sender, e);
        }
        #endregion
    }
}