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
using Newtone.Mobile.Logic;
using Newtone.Mobile.Media;
using Newtone.Mobile.Processing;
using Newtone.Mobile.Views;
using Xamarin.Forms;
using Android.Support.V4.App;
using System.Reactive.Linq;

namespace Newtone.Mobile
{
    [Activity(Label = "Newtone", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode = LaunchMode.SingleTask, AlwaysRetainTaskState = true)]
    [IntentFilter(new[] { Intent.ActionView}, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic }, DataSchemes = new[] { "file","content"}, DataMimeType = "audio/*")]
    [IntentFilter(new[] { MediaStore.IntentActionMediaPlayFromSearch }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic })]
    [IntentFilter(new[] { MediaStore.IntentActionMediaSearch }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic })]
    [IntentFilter(new[] { Intent.ActionGetContent} ,Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic }, DataMimeType = "audio/*")]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        #region Fields
        public static bool Loaded = false;
        private bool backPressed = false;
        private IDisposable stateRefresher;
        #endregion
        #region Properties
        public static MainActivity Instance { get; set; }
        #endregion
        #region Protected Methods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ConsoleDebug.WriteLine("MainActivity OnCreate()");
            Instance = this;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            Forms.Init(this, savedInstanceState);
            InitializeGlobalVariables();

            LoadApplication(new App());
            ConsoleDebug.WriteLine("MainActivity Service MediaPlayerService");
            this.ApplicationContext.StartServiceCompat<MediaPlayerService>();
        }
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            ConsoleDebug.WriteLine("MainActivity OnNewIntent()");
            ProcessNewIntent(intent);
            if(!Global.WakeLock?.IsHeld == true)
                Global.WakeLock?.Acquire();
        }
        protected override void OnStart()
        {
            base.OnStart();
            ConsoleDebug.WriteLine("MainActivity OnStart()");
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
            ConsoleDebug.WriteLine("MainActivity OnStop()");
            MediaControllerCompat.GetMediaController(this)?.UnregisterCallback(Global.ControllerCallback);
            try
            {
                Global.MediaBrowser?.Disconnect();
            }
            catch
            {

            }

        }

        private bool test()
        {
            return false;
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
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

                if (!GlobalData.Current.IncludedPaths.Contains(newPath))
                {
                    GlobalData.Current.IncludedPaths.Add(newPath);
                    Task.Run(async () => {
                        var files = await FileProcessing.Scan(newPath, new List<string>());
                        files.ForEach(GlobalLoader.AddTrack);
                        CacheLoader.SaveCache();
                    });
                    GlobalData.Current.SaveConfig();
                    SnackbarBuilder.Show(Localization.Ready);
                }

            }
        }
        #endregion
        #region Private Methods
        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            LogException(e.Exception);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogException(e.ExceptionObject as Exception);
        }

        private void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            LogException(e.Exception);
        }
        private void LogException(Exception e)
        {
            StreamWriter streamWriter = new StreamWriter(GlobalData.Current.MusicPath + "/log.txt", true);
            streamWriter.WriteLine("ERROR " + DateTime.Now.ToString());
            streamWriter.WriteLine("Exception: " + e.Message);
            streamWriter.WriteLine("StackTrace: " + e.StackTrace);
            streamWriter.WriteLine("Source: " + e.Source);
            streamWriter.WriteLine("ERROR END");
            streamWriter.Close();

            try
            {
                GlobalData.Current.Messenger.Show(MessageGenerator.EMessageType.Error, e.ToString());
            }
            catch { }
        }
        private void InitializeGlobalVariables()
        {
            Global.ConnectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            Global.NotificationManager = (NotificationManager)GetSystemService(NotificationService);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel("newtone", "Newtone", NotificationImportance.Max);
                notificationChannel.SetSound(null, null);
                notificationChannel.SetVibrationPattern(new long[0]);
                notificationChannel.SetShowBadge(true);
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

            GlobalData.Current.Initialize();
            GlobalData.Current.MediaPlayer = new CrossPlayer(new MobileMediaPlayer());
            GlobalData.Current.Messenger = new MessageGenerator(new CoreMessenger());
            GlobalData.Current.MusicPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/NSEC/Music_Player";
            ConsoleDebug.SetLogfile(GlobalData.Current.MusicPath + "/consoleDebug.txt");
            GlobalData.Current.IncludedPaths = new List<string>()
            {
                GlobalData.Current.MusicPath,
                Android.OS.Environment.ExternalStorageDirectory.AbsolutePath
            };
        }

        private void ProcessNewIntent(Intent intent)
        {
            if(intent.Extras != null)
            {
                if(!string.IsNullOrWhiteSpace(intent.Extras.GetString("query","")))
                {
                    MediaSessionCallback.ProcessSearch(intent.Extras.GetString("query", ""));
                }
            }
            
            Android.Net.Uri uri = intent.Data;
            if (uri != null)
            {
                
                GlobalData.Current.AudioFromIntent = true;
                string filepath = HexToString(FilterUriString(uri.Path.Replace("/external_files", Android.OS.Environment.ExternalStorageDirectory.AbsolutePath)));

                if (File.Exists(filepath))
                {
                    Newtone.Core.Media.MediaSource source = MediaProcessing.GetSource(filepath);

                    if (GlobalData.Current.MediaPlayer != null)
                        GlobalData.Current.MediaPlayer.Stop();

                    GlobalData.Current.MediaSource = source;
                    GlobalData.Current.PlaylistPosition = 0;
                    GlobalData.Current.CurrentPlaylist = new List<Newtone.Core.Media.MediaSource>() { source };
                    GlobalData.Current.MediaPlayer.Load(filepath);
                    GlobalData.Current.MediaPlayer.Play();
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
        public override void OnBackPressed()
        {
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
                NormalPage.NavigationInstance.Pop();
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

