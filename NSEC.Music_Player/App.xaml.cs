using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NSEC.Music_Player.Services;
using NSEC.Music_Player.Views;
using Android.Content;
using Android.Support.V4.App;
using Android;
using System.Threading.Tasks;
using System.IO;

namespace NSEC.Music_Player
{
    public partial class App : Application
    {
        public static App Instance { get; set; }
        public App(string[] directories)
        {
            InitializeComponent();
            Instance = this;
            Global.Directories = directories;
            Global.MediaPlayer = new Media.CustomMediaPlayer();
            DependencyService.Register<DefaultDataStore>();
            if (ActivityCompat.CheckSelfPermission(Global.Context, Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted && File.Exists(Global.DataPath+"/data.nsec2"))
            {
                MainPage = new MainPage(new LobbyPage());
                
            }
            else
            {
                MainPage = new PermissionMainPage(new PermissionPage());
                
            }
            
            
        }

        public void OnCreate()
        {
            
        }

        protected override void OnSleep()
        {
            Console.WriteLine("App OnSleep()");
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            Console.WriteLine("App OnResume()");
            // Handle when your app resumes
        }

        
    }
}
