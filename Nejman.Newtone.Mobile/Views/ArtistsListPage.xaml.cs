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
    public partial class ArtistsListPage : ContentPage
    {
        private readonly ArtistsListViewModel viewModel;
        public ArtistsListPage()
        {
            InitializeComponent();
            viewModel = BindingContext as ArtistsListViewModel;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            viewModel?.ArtistSelected(sender, e);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel?.Appearing();
            playerPanel.Appearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel?.Disappearing();
            playerPanel.Disappearing();
        }
    }
}