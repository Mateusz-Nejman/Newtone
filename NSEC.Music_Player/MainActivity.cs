using System;
using System.Collections.Generic;
using System.IO;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using NSEC.Music_Player.Media;
using Xam.Plugin.WebView.Droid;
using static Android.Support.V4.Media.App.NotificationCompat;

namespace NSEC.Music_Player
{
    [Activity(Label = "NSEC Music_Player", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.Navigation | ConfigChanges.UiMode, MultiProcess = false, LaunchMode = LaunchMode.SingleTop)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public AudioManager AudioManager { get; set; }
        public static global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity Instance { get; set; }
        public static NotificationManager NotificationManager { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Instance = this;
            var customReceiver = new MediaPlayerReceiver();
            var intentFilter = new IntentFilter();
            intentFilter.AddAction("prev");
            intentFilter.AddAction("next");
            intentFilter.AddAction("play");
            intentFilter.AddAction("pause");
            this.RegisterReceiver(customReceiver,intentFilter);
            AudioManager = (AudioManager)GetSystemService("audio");
            App.Context = this.ApplicationContext;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            NotificationChannel notificationChannel = new NotificationChannel("nsec music_player notification", "NSEC Music Player", NotificationImportance.Max);
            NotificationManager = (NotificationManager)GetSystemService(NotificationService);
            NotificationManager.CreateNotificationChannel(notificationChannel);


            FormsWebViewRenderer.Initialize();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            //global::Xamarin.Forms.Forms.SetTitleBarVisibility(this, Xamarin.Forms.AndroidTitleBarVisibility.);
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

        protected override void OnNewIntent(Intent intent)
        {
            string action = intent.GetStringExtra("action");
            Console.WriteLine("MainActivity Intent " + intent.GetStringExtra("action"));
            if (action == "prev")
                Global.MediaPlayer.Prev();
        }

        public static void SetNotification(string title, string desc, bool play)
        {
            PendingIntent prevIntentP = PendingIntent.GetBroadcast(Instance, 1, new Intent("prev"), PendingIntentFlags.CancelCurrent);
            PendingIntent playIntentP = PendingIntent.GetBroadcast(Instance, 0, new Intent("play"), PendingIntentFlags.Immutable);
            PendingIntent pauseIntentP = PendingIntent.GetBroadcast(Instance, 0, new Intent("pause"), PendingIntentFlags.Immutable);
            PendingIntent nextIntentP = PendingIntent.GetBroadcast(Instance, 0, new Intent("next"), PendingIntentFlags.Immutable);

            NotificationCompat.Action actionPrev = new NotificationCompat.Action(Resource.Drawable.prevN, "Prev", prevIntentP);
            NotificationCompat.Action actionPlay = new NotificationCompat.Action(!play ? Resource.Drawable.playN : Resource.Drawable.pauseN, "Play", !play ? playIntentP : pauseIntentP);
            NotificationCompat.Action actionNext = new NotificationCompat.Action(Resource.Drawable.nextN, "Next", nextIntentP);


            NotificationCompat.Builder builder = new NotificationCompat.Builder(Instance, "nsec music_player notification").
                SetContentTitle(title).
                SetContentText(desc).
                SetSmallIcon(Resource.Drawable.playN).
                AddAction(actionPrev).
                AddAction(actionPlay).
                AddAction(actionNext).
                SetContentIntent(prevIntentP).
                SetStyle(new MediaStyle()).
                SetLargeIcon(BitmapFactory.DecodeResource(Instance.Resources, Resource.Drawable.playN)).
                SetVisibility(NotificationCompat.VisibilityPublic).SetOngoing(true);
            Notification notification = builder.Build();

            //Instance.StartService(prevIntent);
            NotificationManager.Notify(0, notification);
        }
    }
}

