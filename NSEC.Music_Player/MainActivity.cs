using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using Newtone.Core.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Processing;
using NSEC.Music_Player.Views;
using Xamarin.Forms;

namespace NSEC.Music_Player
{
    [Activity(Label = "Newtone", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode = LaunchMode.SingleTop, ScreenOrientation = ScreenOrientation.Portrait)]
    [IntentFilter(new[] { Intent.ActionView}, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic }, DataSchemes = new[] { "file","content"}, DataMimeType = "audio/*")]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        #region Fields
        public static bool Loaded = false;
        private bool backPressed = false;
        #endregion
        #region Properties
        public static MainActivity Instance { get; set; }
        #endregion
        #region Protected Methods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Instance = this;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            InitializeGlobalVariables();

            ConsoleDebug.WriteLine(SyncProcessing.Code);

            LoadApplication(new App());

            Intent serviceIntent = new Intent(this, typeof(MediaPlayerService));
            StartService(serviceIntent);
        }
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            //ConsoleDebug.WriteLine("MainActivity Intent " + intent.Data.ToString());
            ConsoleDebug.WriteLine("MainActivity ProcessNewIntent OnNewIntent");
            ProcessNewIntent(intent);
        }

        protected override void OnResume()
        {
            ConsoleDebug.WriteLine("MainActivity OnResume");
            base.OnResume();
        }
        protected override void OnStart()
        {
            base.OnStart();
            try
            {
                Global.MediaBrowser.Connect();
            }
            catch
            {

            }
        }

        protected override void OnStop()
        {
            base.OnStop();
            ConsoleDebug.WriteLine("MainActivity OnStop");
            //if (GlobalData.MediaPlayer != null && !GlobalData.MediaPlayer.IsPlaying && DownloadProcessing.GetDownloads().Count == 0)
            //    Process.KillProcess(Process.MyPid());
            MediaControllerCompat.GetMediaController(this)?.UnregisterCallback(Global.ControllerCallback);
            try
            {
                Global.MediaBrowser.Disconnect();
            }
            catch
            {

            }

        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            ConsoleDebug.WriteLine("Result");
            if (requestCode == 9999 && data != null)
            {
                string[] elems = data.Data.Path.Split(':');

                string rootPath = "";
                string volume = elems[0].Replace("/tree/", "");

                if (volume == "primary")
                    rootPath = Android.OS.Environment.ExternalStorageDirectory + "/";

                foreach (var item in GetExternalMediaDirs())
                {
                    string path = item.AbsolutePath.Substring(0, item.AbsolutePath.IndexOf("Android"));

                    if (path.Contains(volume))
                        rootPath = path;
                }

                string newPath = rootPath + elems[1];

                if (!GlobalData.IncludedPaths.Contains(newPath))
                {
                    GlobalData.IncludedPaths.Add(newPath);
                    Task.Run(async () => {
                        var files = await FileProcessing.Scan(newPath, new List<string>());

                        foreach (var file in files)
                        {
                            GlobalLoader.AddTrack(file);
                        }
                    });
                    GlobalData.SaveConfig();
                    SnackbarBuilder.Show(Localization.Ready);
                }

            }
        }
        #endregion
        #region Private Methods
        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(GlobalData.MusicPath + "/log.txt", true);
            streamWriter.WriteLine("ERROR " + DateTime.Now.ToString());
            streamWriter.WriteLine("Exception: " + e.Exception.Message);
            streamWriter.WriteLine("StackTrace: " + e.Exception.StackTrace);
            streamWriter.WriteLine("Source: " + e.Exception.Source);
            streamWriter.WriteLine("ERROR END");
            streamWriter.Close();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
           
            StreamWriter streamWriter = new StreamWriter(GlobalData.MusicPath + "/log.txt", true);
            streamWriter.WriteLine("ERROR " + DateTime.Now.ToString());
            streamWriter.WriteLine("Exception: " + ((Exception)e.ExceptionObject).Message);
            streamWriter.WriteLine("StackTrace: " + ((Exception)e.ExceptionObject).StackTrace);
            streamWriter.WriteLine("Source: " + ((Exception)e.ExceptionObject).Source);
            streamWriter.WriteLine("ERROR END");
            streamWriter.Close();
        }

        private void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(GlobalData.MusicPath + "/log.txt", true);
            streamWriter.WriteLine("ERROR " + DateTime.Now.ToString());
            streamWriter.WriteLine("Exception: " + e.Exception.Message);
            streamWriter.WriteLine("StackTrace: " + e.Exception.StackTrace);
            streamWriter.WriteLine("Source: " + e.Exception.Source);
            streamWriter.WriteLine("ERROR END");
            streamWriter.Close();
        }
        private void InitializeGlobalVariables()
        {

            //Global.PowerManager = (PowerManager)GetSystemService(PowerService);
            Global.ConnectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            Global.NotificationManager = (NotificationManager)GetSystemService(NotificationService);
            //Global.WakeLock = Global.PowerManager.NewWakeLock(WakeLockFlags.Partial, "NSEC WakeLock");
            //Global.WakeLock.Acquire();
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel("newtone", "Newtone", NotificationImportance.Max);
                notificationChannel.SetSound(null, null);
                notificationChannel.SetVibrationPattern(new long[0]);
                Global.NotificationManager.CreateNotificationChannel(notificationChannel);
                Global.NotificationManager.CreateNotificationChannel(notificationChannel);
                AudioFocusRequestClass afrc = new AudioFocusRequestClass.Builder(AudioFocus.GainTransient).SetOnAudioFocusChangeListener(new AudioFocusListener()).Build();
                ((AudioManager)GetSystemService(AudioService)).RequestAudioFocus(afrc);
            }
            else
            {
#pragma warning disable CS0618 // Typ lub składowa jest przestarzała
                ((AudioManager)GetSystemService(AudioService)).RequestAudioFocus(new AudioFocusListener(), Android.Media.Stream.Music, AudioFocus.GainTransient);
#pragma warning restore CS0618 // Typ lub składowa jest przestarzała
            }

            Global.PowerManager = (PowerManager)GetSystemService(PowerService);
            Global.WakeLock = Global.PowerManager.NewWakeLock(WakeLockFlags.Partial, "Newtone WakeLock");
            Global.WakeLock.Acquire();

            Global.MetadataBuilder = new MediaMetadataCompat.Builder();
            Global.StateBuilder = new PlaybackStateCompat.Builder();
            Global.StateBuilder.SetActions(PlaybackStateCompat.ActionPlay | PlaybackStateCompat.ActionPlayPause | PlaybackStateCompat.ActionSkipToNext | PlaybackStateCompat.ActionSkipToPrevious | PlaybackStateCompat.ActionPause);
            Global.ControllerCallback = new MediaControllerCallback();
            Global.ConnectionCallback = new MediaBrowserConnectionCallback();
            Global.AudioFocusListener = new AudioFocusListener();
            Global.MediaBrowser = new MediaBrowserCompat(this, new ComponentName(this, Java.Lang.Class.FromType(typeof(MediaPlayerService)).Name), Global.ConnectionCallback, null);

            GlobalData.Artists = new Dictionary<string, List<string>>();
            GlobalData.Audios = new Dictionary<string, Newtone.Core.Media.MediaSource>();
            GlobalData.AudioTags = new Dictionary<string, MediaSourceTag>();
            GlobalData.DownloadedIds = new List<string>();
            GlobalData.CurrentPlaylist = new List<Newtone.Core.Media.MediaSource>();
            GlobalData.CurrentQueue = new List<Newtone.Core.Media.MediaSource>();
            GlobalData.DataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            GlobalData.MusicPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/NSEC/Music_Player";

            //ConsoleDebug.WriteLine(GlobalData.DataPath);
            //ConsoleDebug.WriteLine(GlobalData.MusicPath);

            //Directory.CreateDirectory(GlobalData.DataPath);
            //Directory.CreateDirectory(GlobalData.MusicPath);

            GlobalData.History = new List<Newtone.Core.Models.HistoryModel>();
            GlobalData.LastTracks = new Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST];
            GlobalData.MostTracks = new Newtone.Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST];

            GlobalData.PlayerMode = PlayerMode.All;
            GlobalData.Playlists = new Dictionary<string, List<string>>();
            GlobalData.PlaylistType = Newtone.Core.Media.MediaSource.SourceType.Local;
            GlobalData.MediaPlayer = new CrossPlayer(new MobileMediaPlayer());

            GlobalData.ExcludedPaths = new List<string>();
            GlobalData.IncludedPaths = new List<string>()
            {
                GlobalData.MusicPath,
                Android.OS.Environment.ExternalStorageDirectory.AbsolutePath
            };
        }

        private void ProcessNewIntent(Intent intent)
        {
            Android.Net.Uri uri = intent.Data;

            if (uri != null)
            {
                GlobalData.AudioFromIntent = true;
                string filepath = HexToString(FilterUriString(uri.Path.Replace("/external_files", Android.OS.Environment.ExternalStorageDirectory.AbsolutePath)));

                if (File.Exists(filepath))
                {
                    Newtone.Core.Media.MediaSource source = MediaProcessing.GetSource(filepath);

                    if (GlobalData.MediaPlayer != null)
                        GlobalData.MediaPlayer.Stop();

                    GlobalData.MediaSource = source;
                    GlobalData.PlaylistPosition = 0;
                    GlobalData.CurrentPlaylist = new List<Newtone.Core.Media.MediaSource>() { source };
                    GlobalData.MediaPlayer.Load(filepath);
                    GlobalData.MediaPlayer.Play();
                }
                else
                {
                    SnackbarBuilder.Show(Localization.SnackFileExists);
                }
            }
        }
        private string FilterUriString(string uriString)
        {

            if (uriString.IndexOf("file:///") > -1)
            {
                return new System.Uri(uriString.Substring(uriString.IndexOf("file:///"))).LocalPath;
            }
            return uriString;
        }

        private string HexToString(string partlyHexString)
        {
            while (partlyHexString.IndexOf('%') > -1)
            {
                int index = partlyHexString.IndexOf('%');
                if (index <= partlyHexString.Length - 3)
                {

                    string hexString = partlyHexString.Substring(index + 1);
                    hexString = "%" + FindHex(hexString);

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
            for (int a = 0; a < str.Length; a++)
            {
                if (validChars.Contains(str[a]))
                    retString += str[a];
                else
                    return retString;
            }
            return retString;
        }
        #endregion
        #region Public Methods
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            ConsoleDebug.WriteLine("OnBackPressed " + NormalPage.NavigationInstance.NavigationStack.Count + " "+ NormalPage.NavigationInstance.ModalStack.Count);
            if (NormalPage.NavigationInstance.NavigationStack.Count == 0 && NormalPage.NavigationInstance.ModalStack.Count == 0)
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
        public void ForceRestart()
        {
            OnStop();
            OnRestart();
        }
        

        public static bool IsInternet()
        {
            bool haveConnectedWifi = false;
            bool haveConnectedMobile = false;

            NetworkInfo[] netInfo = Global.ConnectivityManager.GetAllNetworkInfo();

            foreach(NetworkInfo info in netInfo)
            {
                if(info.TypeName.Contains("WIFI",StringComparison.OrdinalIgnoreCase))
                {
                    if (info.IsConnected)
                        haveConnectedWifi = true;
                }

                if(info.TypeName.Contains("MOBILE",StringComparison.OrdinalIgnoreCase))
                {
                    if (info.IsConnected)
                        haveConnectedMobile = true;
                }
            }

            return haveConnectedWifi || haveConnectedMobile;
        }
        #endregion
    }
}

