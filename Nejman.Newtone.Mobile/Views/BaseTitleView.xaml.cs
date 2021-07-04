using Nejman.Newtone.Mobile.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nejman.Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseTitleView : ContentView
    {
        private readonly TitleViewModel viewModel;
        public BaseTitleView()
        {
            InitializeComponent();
            viewModel = BindingContext as TitleViewModel;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            viewModel.Search();
        }

        private void LifecycleViewEffect_Appearing(object sender, EventArgs e)
        {
            viewModel.Appearing();
        }

        private void LifecycleViewEffect_Disappearing(object sender, EventArgs e)
        {
            viewModel.Disappearing();
        }
    }
}