using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;
using Android.Runtime;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.CustomViews;
using Xam.Plugin.WebView.Droid;
using Xamarin.Forms;

namespace NSEC.Music_Player
{
    [Activity(Label = "NSEC Music Player", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.Navigation | ConfigChanges.UiMode, MultiProcess = false, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Intent.ActionView}, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic }, DataSchemes = new[] { "file","content"}, DataMimeType = "audio/*")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static bool Loaded = false;
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
            if(!Loaded)
                InitializeGlobalVariables();


            FormsWebViewRenderer.Initialize();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);


            Console.WriteLine("MainActivity ProcessNewIntent OnCreate");
            ProcessNewIntent(Intent);

            LoadApplication(new App());

            backgroundIntent = new Intent(this, typeof(BackgroundService));

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            //Console.WriteLine("MainActivity Intent " + intent.Data.ToString());
            Console.WriteLine("MainActivity ProcessNewIntent OnNewIntent");
            ProcessNewIntent(Intent);
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
            if (Loaded)
            {
                Task.Run(async () => { 
                    await Helpers.ReloadTracks();
                    FileProcessing.SaveCache();
                });
                
            }
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
#pragma warning disable CS0618 // Typ lub składowa jest przestarzała
                Global.AudioManager.RequestAudioFocus(new AudioFocusListener(), Android.Media.Stream.Music, AudioFocus.GainTransient);
#pragma warning restore CS0618 // Typ lub składowa jest przestarzała
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
            Global.AudioTags = new Dictionary<string, MediaProcessing.MediaTag>();
            Global.MediaPlayer = new Media.CustomMediaPlayer();
            Global.AudioFromIntent = false;
            Global.AutoTags = false;
        }

        private void ProcessNewIntent(Intent intent)
        {
            Android.Net.Uri uri = intent.Data;

            if(uri != null)
            {
                Global.AudioFromIntent = true;
                string filepath = HexToString(FilterUriString(uri.Path.Replace("/external_files", Android.OS.Environment.ExternalStorageDirectory.AbsolutePath)));
                
                if (File.Exists(filepath))
                {

                    Track track = new Track()
                    {
                        Id = filepath,
                        Container = MediaProcessing.GetTags(filepath)
                    };

                    if (Global.MediaPlayer != null)
                        Global.MediaPlayer.Stop();

                    Global.AudioPlayerTrack = track.Id;
                    Global.CurrentTrack = track.Container;
                    Global.CurrentPlaylistPosition = 0;
                    Global.CurrentPlaylist = new List<Track>() { track };
                    Global.MediaPlayer.Load(FileProcessing.GetStreamFromFile(filepath), filepath);
                    Global.MediaPlayer.Play();
                    Global.MediaPlayer.SetNotification(track);
                }
                else
                    SnackbarBuilder.Show(Localization.SnackFileExists);
            }
        }

        private string FilterUriString(string uriString)
        {
            
            if(uriString.IndexOf("file:///") > -1)
            {
                return new System.Uri(uriString.Substring(uriString.IndexOf("file:///"))).LocalPath;
            }
            return uriString;
        }

        private string HexToString(string partlyHexString)
        {
            while(partlyHexString.IndexOf('%') > -1)
            {
                int index = partlyHexString.IndexOf('%');
                if (index <= partlyHexString.Length - 3)
                {
                   
                    string hexString = partlyHexString.Substring(index+1);
                    hexString = "%"+FindHex(hexString);

                    partlyHexString = partlyHexString.Replace(hexString, System.Text.Encoding.UTF8.GetString(Hex(hexString.Replace("%", ""))));
                }
                else
                    break;
            }

            return partlyHexString;
        }

        private byte[] Hex(string hex)
        {
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        private string FindHex(string str)
        {
            string validChars = "1234567890ABCDEF";
            string retString = "";
            for(int a = 0; a < str.Length; a++)
            {
                if (validChars.Contains(str[a]))
                    retString += str[a];
                else
                    return retString;
            }
            return retString;
        }
    }
}

