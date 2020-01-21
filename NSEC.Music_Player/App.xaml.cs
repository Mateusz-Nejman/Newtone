﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NSEC.Music_Player.Services;
using NSEC.Music_Player.Views;
using Android.Content;
using Android.Support.V4.App;
using Android;
using System.Threading.Tasks;

namespace NSEC.Music_Player
{
    public partial class App : Application
    {
        public static App Instance { get; set; }
        public static bool IsInLobby = false;
        public App(string[] directories)
        {
            InitializeComponent();
            Instance = this;
            Global.Directories = directories;
            Global.MediaPlayer = new Media.CustomMediaPlayer();
            DependencyService.Register<DefaultDataStore>();
            if (ActivityCompat.CheckSelfPermission(Global.Context, Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted)
            {
                MainPage = new MainPage(new LobbyPage());
                Global.LoadConfig();
                
            }
            else
            {
                MainPage = new MainPage(new PermissionPage());
            }
            
            
        }

        public void OnCreate()
        {
            
            OnStart();
        }

        protected override void OnStart()
        {
            if (ActivityCompat.CheckSelfPermission(Global.Context, Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted)
            {
                //base.OnStart();
                Console.WriteLine("App OnStart()");
                Task.Run(async () => { await Helpers.LoadGlobalsOnce(); }).Wait();
                
            }
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
