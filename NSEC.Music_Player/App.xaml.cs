﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Content;
using Android.Support.V4.App;
using Android;
using System.Threading.Tasks;
using System.IO;
using NSEC.Music_Player.Views;
using Newtone.Core;

namespace NSEC.Music_Player
{
    public partial class App : Application
    {
        public static App Instance { get; set; }
        public App()
        {
            InitializeComponent();
            Instance = this;
            if (ActivityCompat.CheckSelfPermission(MainActivity.Instance, Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted && File.Exists(GlobalData.DataPath + "/newtone.nsec2"))
            {
                string theme = GlobalData.LoadFirstStart();
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
