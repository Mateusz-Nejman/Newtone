using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PermissionMainPage : NavigationPage
    {
        public static PermissionMainPage Instance { get; set; }
        public PermissionMainPage(Page page)
        {
            InitializeComponent();
            Instance = this;
            this.Appearing += MainPage_Appearing;

            Navigation.PushAsync(page);
            //containers = new List<MP3Processing.Container>(AsyncHelper.RunSync<MP3Processing.Container[]>(() => FileProcessing.ListFiles(App.Directories)));

        }

        private void MainPage_Appearing(object sender, EventArgs e)
        {
            base.OnAppearing();
        }
    }
}