using Com.Xamarin.Formsviewgroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutTab : ContentPage
    {
        public AboutTab()
        {
            InitializeComponent();

            versionLabel.Text = Global.Context.PackageManager.GetPackageInfo(Global.Context.PackageName, 0).VersionName;
        }

        [Obsolete]
        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://mateusz-nejman.pl/"));
        }
    }
}