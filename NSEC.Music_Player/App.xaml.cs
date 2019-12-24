using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NSEC.Music_Player.Services;
using NSEC.Music_Player.Views;
using Android.Content;

namespace NSEC.Music_Player
{
    public partial class App : Application
    {
        public static Context Context { get; set; }
        public App(string[] directories)
        {
            InitializeComponent();

            Global.Directories = directories;
            DependencyService.Register<DefaultDataStore>();
            MainPage = new MainPage();
        }

        protected async override void OnStart()
        {
            //base.OnStart();
            Console.WriteLine("App OnStart()");
            Global.LoadConfig();
            await Helpers.LoadGlobalsOnce();
            
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
