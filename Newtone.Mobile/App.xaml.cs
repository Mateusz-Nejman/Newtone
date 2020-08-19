using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Content;
using Android.Support.V4.App;
using Android;
using System.Threading.Tasks;
using System.IO;
using Newtone.Mobile.Views;
using Newtone.Core;

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
                string theme = GlobalData.Current.LoadFirstStart();
                if(theme == null)
                {
                    MainPage = new LanguageSelectPage("firststart");
                }
                else
                {
                    Colors.SetBase(theme);
                    MainPage = new NormalPage();
                }
                
            }
            else
            {
                MainPage = new LanguageSelectPage("permissions");
            }
        }
        #endregion
    }
}
