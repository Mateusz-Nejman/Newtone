using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Views.CustomViews;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xam.Plugin.WebView.Droid;
using Xamarin.Forms;
using static Android.Support.V4.Media.App.NotificationCompat;

namespace NSEC.Music_Player
{
    [Activity(Label = "NSEC Music Player", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.Navigation | ConfigChanges.UiMode, MultiProcess = false, LaunchMode = LaunchMode.SingleTop)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private List<string> folders;
        private bool backPressed = false;
        private Intent backgroundIntent;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            Console.WriteLine("MainActivity OnCreate");
            base.OnCreate(savedInstanceState);
            Global.Context = this;

            var customReceiver = new MediaPlayerReceiver();
            var intentFilter = new IntentFilter();
            intentFilter.AddAction("prev");
            intentFilter.AddAction("next");
            intentFilter.AddAction("play");
            intentFilter.AddAction("pause");
            intentFilter.AddAction("open");
            intentFilter.AddAction("close");
            RegisterReceiver(customReceiver, intentFilter);


            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            InitializeGlobalVariables();


            FormsWebViewRenderer.Initialize();
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);

            string[] paths = new string[] { Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath,
                Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).AbsolutePath,
                Android.OS.Environment.ExternalStorageDirectory.AbsolutePath,
                Android.OS.Environment.ExternalStorageDirectory.AbsolutePath+"/Videoder",
                Android.OS.Environment.ExternalStorageDirectory.AbsolutePath+"/NSEC/Music_Player"
            };

            folders = new List<string>();

            foreach (string path in paths)
            {
                if (Directory.Exists(path))
                    folders.Add(path);
            }



            LoadApplication(new App(folders.ToArray()));

            backgroundIntent = new Intent(this, typeof(BackgroundService));

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

        protected override void OnDestroy()
        {
            Console.WriteLine("MainActivity OnDestroy");
            base.OnDestroy();

        }

        protected override void OnPause()
        {
            Console.WriteLine("MainActivity OnPause");
            base.OnPause();
        }

        protected override void OnRestart()
        {
            Console.WriteLine("MainActivity OnRestart");
            base.OnRestart();
        }

        protected override void OnResume()
        {
            Console.WriteLine("MainActivity OnResume");
            StopService(backgroundIntent);
            base.OnResume();
        }

        protected override void OnStart()
        {
            Console.WriteLine("MainActivity OnStart");
            base.OnStart();
        }

        public override void OnBackPressed()
        {

            if (App.Instance.MainPage.Navigation.NavigationStack.Count == 1)
            {
                if (backPressed)
                    base.OnBackPressed();
                else
                {
                    SnackbarBuilder.Show(Localization.BackPressed);
                    backPressed = true;
                    Task.Run(() => {
                        Thread.Sleep(2000);
                        backPressed = false;
                    });
                }

            }
            else
            {
                base.OnBackPressed();
            }

        }

        protected override void OnStop()
        {
            Console.WriteLine("MainActivity OnStop");
            if (Global.MediaPlayer != null && !Global.MediaPlayer.IsPlaying)
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());

            StartService(backgroundIntent);
            base.OnStop();
        }

        public void ForceRestart()
        {
            OnStop();
            OnRestart();
        }
        private void InitializeGlobalVariables()
        {

            Global.NotificationManager = (NotificationManager)GetSystemService(NotificationService);
            Global.AudioManager = (AudioManager)GetSystemService(AudioService);
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel("nsec music_player notification", "NSEC Music Player", NotificationImportance.Default);
                notificationChannel.SetSound(null, null);
                notificationChannel.SetVibrationPattern(new long[0]);
                Global.NotificationManager.CreateNotificationChannel(notificationChannel);
                AudioFocusRequestClass afrc = new AudioFocusRequestClass.Builder(AudioFocus.GainTransient).SetOnAudioFocusChangeListener(new AudioFocusListener()).Build();
                Global.AudioManager.RequestAudioFocus(afrc);
            }
            else
            {
                Global.AudioManager.RequestAudioFocus(new AudioFocusListener(), Android.Media.Stream.Music, AudioFocus.GainTransient);
            }




            Global.PowerManager = (PowerManager)GetSystemService(PowerService);
            Global.WakeLock = Global.PowerManager.NewWakeLock(WakeLockFlags.Partial, "NSEC WakeLock");
            Global.WakeLock.Acquire();
            Global.Audios = new Dictionary<string, Logic.MediaProcessing.MediaTag>();
            Global.Artists = new Dictionary<string, List<string>>();
            Global.CurrentPlaylist = new List<Models.Track>();
            Global.CurrentPlaylistPosition = 0;
            Global.CurrentQueue = new List<Models.Track>();
            Global.CurrentQueuePosition = 0;
            Global.LastTracks = new Models.TrackCounter[0];
            Global.MostTracks = new Models.TrackCounter[0];
            Global.Playlists = new Dictionary<string, System.Collections.Generic.List<Models.Track>>();
            Global.MusicPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/NSEC/Music_Player";
            Global.DataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            Global.PlayerMode = Models.PlayerMode.All;
            Global.LastPlayerClick = true;
            Global.EmptyTrack = ImageSource.FromFile("emptyTrack.png");
            Global.Downloads = new Dictionary<string, Models.DownloadModel>();
            Global.AudioTags = new Dictionary<string, MediaProcessing.MediaTag>();
        }
    }
}

