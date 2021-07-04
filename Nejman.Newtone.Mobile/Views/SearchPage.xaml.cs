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
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (BindingContext as SearchViewModel)?.Item_Selected(sender, e);
        }

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
    }
}