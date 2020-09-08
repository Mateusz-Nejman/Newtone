using Xamarin.Forms;
using Android;
using System.IO;
using Newtone.Mobile.Views;
using Newtone.Core;
using AndroidX.Core.App;

namespace Newtone.Mobile
{
    public partial class App : Application
    {
        #region Properties
        public static App Instance { get; set; }
        #endregion
        #region Constructors
        public App()
        {
            InitializeComponent();
            Instance = this;
            if (ActivityCompat.CheckSelfPermission(MainActivity.Instance, Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted && File.Exists(GlobalData.Current.DataPath + "/newtone.nsec2"))
            {
                MainPage = new NormalPage();
            }
            else
            {
                MainPage = new LanguageSelectPage("permissions");
            }
        }
        #endregion
    }
}
