using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Content;
using Android.Support.V4.App;
using Android;
using System.Threading.Tasks;
using System.IO;
using NSEC.Music_Player.Views;

namespace NSEC.Music_Player
{
    public partial class App : Application
    {
        public static App Instance { get; set; }
        public App()
        {
            InitializeComponent();
            Instance = this;
            if (ActivityCompat.CheckSelfPermission(Global.Context, Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted && File.Exists(Global.DataPath + "/newtone.nsec2"))
                MainPage = new MainPage();
            else
            {
                MainPage = new PermissionPage();
            }
        }

        public void OnCreate()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


    }
}
