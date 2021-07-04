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
    public partial class TracksListPage : ContentPage
    {
        private readonly TracksListViewModel viewModel;
        public TracksListPage()
        {
            InitializeComponent();
            viewModel = BindingContext as TracksListViewModel;
            viewModel.Handler = this;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await viewModel?.Track_Selected(sender, e);
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