using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.FirstStart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstStartSearch : ContentView
    {
        private FirstStartPage Page { get; set; }
        public FirstStartSearch(FirstStartPage page)
        {
            InitializeComponent();
            Page = page;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Instance.MainPage = new NormalPage();
            Task.Run(async () => {
                await PopToRootAsync();
            }).Wait();
        }

        private async Task PopToRootAsync()
        {
            while (App.Instance.MainPage.Navigation.ModalStack.Count > 0)
            {
                await App.Instance.MainPage.Navigation.PopModalAsync(false);
            }
        }
    }
}