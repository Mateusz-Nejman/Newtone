using Nejman.Newtone.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nejman.Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
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
        #region Protected Methods
        protected override void OnAppearing()
        {
            base.OnAppearing();
            playerPanel.Appearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            playerPanel.Disappearing();
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