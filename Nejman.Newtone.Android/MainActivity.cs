using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Nejman.Newtone.Droid.Implementations;
using Nejman.Newtone.Core;
using Android.Content;
using Android.Speech;
using System.Threading.Tasks;
using Nejman.Newtone.Core.IO;
using Nejman.Newtone.Core.Localization;
using Nejman.Newtone.Mobile;
using Android.Net;
using Android.Media;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Nejman.Newtone.Droid.Media;
using Android.Provider;
using System.IO;
using Nejman.Newtone.Core.Implementations;
using Nejman.Newtone.Core.Media;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Nejman.Newtone.Droid
{
    [Activity(Label = "Newtone", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.Navigation, LaunchMode = LaunchMode.SingleTask, AlwaysRetainTaskState = true)]
    [IntentFilter(new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic }, DataSchemes = new[] { "file", "content" }, DataMimeType = "audio/*")]
    [IntentFilter(new[] { MediaStore.IntentActionMediaPlayFromSearch }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic })]
    [IntentFilter(new[] { MediaStore.IntentActionMediaSearch }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic })]
    [IntentFilter(new[] { Intent.ActionGetContent }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic }, DataMimeType = "audio/*")]
    [IntentFilter(new[] { Intent.ActionMain }, Categories = new[] { Intent.CategoryLeanbackLauncher })]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private bool backPressed = false;
        internal static MainActivity Handler { get; private set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Handler = this;
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            InitializeGlobalVariables();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(new Implementations.MediaPlayerImplementation(), new Implementations.NotificationImplementation(), new Implementations.SnackbarImplementation(), new ImageProcessingImplementation(), new ContextMenuBuilderImplementation(), new ApplicationImplementation(), new SpeechImplementation()));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            if (Shell.Current.Navigation.ModalStack.Count == 0 && Shell.Current.Navigation.NavigationStack.Count == 1)
            {
                if (backPressed)
                    base.OnBackPressed();
                else
                {
                    Core.Implementations.SnackbarImplementation.Current.Show(Localization.BackPressed);
                    backPressed = true;
                    Task.Run(async() => {
                        await Task.Delay(2000);
                        backPressed = false;
                    });
                }

            }
            else
            {
                base.OnBackPressed();
            }

        }

        protected override void OnStart()
        {
            base.OnStart();
            try
            {
                DroidGlobal.MediaBrowser.Connect();
            }
            catch
            {
                //Ignore
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            if (intent.Extras != null && !string.IsNullOrWhiteSpace(intent.Extras.GetString("query", "")))
            {
                Task.Run(async () => await Mobile.Implementations.SpeechImplementation.Process(intent.Extras.GetString("query", "")));
            }

            Android.Net.Uri uri = intent.Data;
            if (uri != null)
            {
                string filepath = HexToString(FilterUriString(uri.Path.Replace("/external_files", Android.OS.Environment.ExternalStorageDirectory.AbsolutePath)));

                if (File.Exists(filepath))
                {
                    MediaSource source = AudiosLoader.GetSource(filepath);

                    if (CoreGlobal.MediaPlayer != null)
                        CoreGlobal.MediaPlayer.Pause();

                    Task.Run(async () => await CoreGlobal.MediaPlayer.LoadPlaylist(new List<MediaSource>() { source }, 0));
                }
                else
                {
                    Core.Implementations.SnackbarImplementation.Current.Show(Localization.SnackFileExists);
                }
            }

            if (!DroidGlobal.WakeLock?.IsHeld == true)
            {
                DroidGlobal.WakeLock?.Acquire();
            }
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

                string newPath = rootPath + elems[elems.Length-1];

                if (!CoreGlobal.IncludedPaths.Contains(newPath))
                {
                    CoreGlobal.IncludedPaths.Add(newPath);
                    Task.Run(async () => {
                        await AudiosLoader.ScanAsync(newPath);
                    });
                    CoreGlobal.SaveData();
                    Newtone.Core.Implementations.SnackbarImplementation.Current.Show(Localization.Ready);
                }

            }
            else if (requestCode == 100 && resultCode == Result.Ok && data != null) //Speech
            {
                var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);

                if (matches.Count > 0)
                {
                    Task.Run(async () => await Mobile.Implementations.SpeechImplementation.Process(matches[0]));
                }
            }
        }

        private void InitializeGlobalVariables()
        {
            CoreGlobal.MusicPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/NSEC/Music_Player";
            CoreGlobal.DataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            CoreGlobal.IncludedPaths.Add(CoreGlobal.MusicPath);
            CoreGlobal.IncludedPathsToSkip = 1;
            Global.TV = ((UiModeManager)GetSystemService(UiModeService)).CurrentModeType == Android.Content.Res.UiMode.TypeTelevision;
            CoreGlobal.MediaFormat = Global.TV ? Core.Media.MediaFormat.ogg : Core.Media.MediaFormat.m4a;

            DroidGlobal.AssetManager = this.Assets;

            DroidGlobal.ConnectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            DroidGlobal.NotificationManager = (NotificationManager)GetSystemService(NotificationService);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel("newtone", "Newtone", NotificationImportance.Max);
                notificationChannel.SetSound(null, null);
                notificationChannel.SetVibrationPattern(new long[0]);
                notificationChannel.SetShowBadge(true);
                DroidGlobal.NotificationManager.CreateNotificationChannel(notificationChannel);
                DroidGlobal.NotificationManager.CreateNotificationChannel(notificationChannel);
                AudioFocusRequestClass afrc = new AudioFocusRequestClass.Builder(AudioFocus.GainTransient).SetOnAudioFocusChangeListener(new AudioFocusListener()).Build();
                ((AudioManager)GetSystemService(AudioService)).RequestAudioFocus(afrc);
            }
            else
            {
#pragma warning disable CS0618 // Typ lub składowa jest przestarzała
                ((AudioManager)GetSystemService(AudioService)).RequestAudioFocus(new AudioFocusListener(), Android.Media.Stream.Music, AudioFocus.GainTransient);
#pragma warning restore CS0618 // Typ lub składowa jest przestarzała
            }

            DroidGlobal.PowerManager = (PowerManager)GetSystemService(PowerService);
            DroidGlobal.WakeLock = DroidGlobal.PowerManager.NewWakeLock(WakeLockFlags.Partial, "Newtone WakeLock");
            DroidGlobal.WakeLock.Acquire();

            DroidGlobal.MetadataBuilder = new MediaMetadataCompat.Builder();
            DroidGlobal.StateBuilder = new PlaybackStateCompat.Builder();
            DroidGlobal.StateBuilder.SetActions(PlaybackStateCompat.ActionPlay | PlaybackStateCompat.ActionPlayPause | PlaybackStateCompat.ActionPlayFromSearch | PlaybackStateCompat.ActionPlayFromUri
                | PlaybackStateCompat.ActionPrepare | PlaybackStateCompat.ActionPrepareFromSearch | PlaybackStateCompat.ActionPrepareFromUri | PlaybackStateCompat.ActionPlayFromMediaId | PlaybackStateCompat.ActionPause);
            DroidGlobal.ControllerCallback = new MediaControllerCallback();
            DroidGlobal.ConnectionCallback = new MediaBrowserConnectionCallback();
            DroidGlobal.AudioFocusListener = new AudioFocusListener();
            DroidGlobal.MediaBrowser = new MediaBrowserCompat(this, new ComponentName(this, Java.Lang.Class.FromType(typeof(MediaPlayerService)).Name), DroidGlobal.ConnectionCallback, null);
        }

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
            try
            {
                Directory.CreateDirectory(CoreGlobal.MusicPath + "/Debug");
                StreamWriter streamWriter = new StreamWriter(CoreGlobal.MusicPath + "/Debug/log.txt", true);
                streamWriter.WriteLine("ERROR " + DateTime.Now.ToString());
                streamWriter.WriteLine("Exception: " + e.Message);
                streamWriter.WriteLine("StackTrace: " + e.StackTrace);
                streamWriter.WriteLine("Source: " + e.Source);
                streamWriter.WriteLine("ERROR END");
                streamWriter.Close();
                MessageImplementation.Current?.Show(e.ToString());
            }
            catch
            {
                //Ignore
            }
        }

        private string FilterUriString(string uriString)
        {

            if (uriString.IndexOf("file:///") > -1)
            {
                return new System.Uri(uriString[uriString.IndexOf("file:///")..]).LocalPath;
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

                    string hexString = partlyHexString[(index + 1)..];
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
    }
}