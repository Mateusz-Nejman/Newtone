using System;
using System.Collections.Generic;
using System.IO;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Xam.Plugin.WebView.Droid;

namespace NSEC.Music_Player
{
    [Activity(Label = "NSEC.Music_Player", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.Navigation | ConfigChanges.UiMode, MultiProcess = false, LaunchMode = LaunchMode.SingleInstance)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            App.Context = this.ApplicationContext;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            FormsWebViewRenderer.Initialize();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 0);

            string[] paths = new string[] { Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath,
                Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).AbsolutePath,
                Android.OS.Environment.ExternalStorageDirectory.AbsolutePath,
                Android.OS.Environment.ExternalStorageDirectory.AbsolutePath+"/Videoder",
                Android.OS.Environment.ExternalStorageDirectory.AbsolutePath+"/NSEC/Music_Player"
            };

            Global.DataPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/NSEC/Music_Player";

            List<string> folders = new List<string>();

            foreach (string path in paths)
            {
                if (Directory.Exists(path))
                    folders.Add(path);
            }

            Console.WriteLine("MainActivity OnCreate()");
            LoadApplication(new App(folders.ToArray()));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

