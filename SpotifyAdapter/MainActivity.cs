using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System.Threading.Tasks;
using System;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Android.Provider;
using Android.Content.PM;
using Java.Lang;
using Exception = System.Exception;

namespace SpotifyAdapter
{
    [Activity(Label = "Spotify Adapter for Newtone", Theme = "@style/AppTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode = LaunchMode.SingleTask, AlwaysRetainTaskState = true)]
    [IntentFilter(new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic }, DataSchemes = new[] { "file", "content" }, DataMimeType = "audio/*")]
    [IntentFilter(new[] { MediaStore.IntentActionMediaPlayFromSearch }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic })]
    [IntentFilter(new[] { MediaStore.IntentActionMediaSearch }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic })]
    [IntentFilter(new[] { Intent.ActionGetContent }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable, Intent.CategoryAppMusic }, DataMimeType = "audio/*")]
    public class MainActivity : AppCompatActivity
    {
        public static MediaBrowserCompat MediaBrowser { get; set; }
        public static MediaControllerCallback ControllerCallback { get; set; }
        public static MediaBrowserConnectionCallback ConnectionCallback { get; set; }
        public static MediaSessionCompat MediaSession { get; set; }
        public static MainActivity Instance { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Instance = this;
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            ControllerCallback = new MediaControllerCallback();
            ConnectionCallback = new MediaBrowserConnectionCallback();
            MediaBrowser = new MediaBrowserCompat(this, new ComponentName(this, Java.Lang.Class.FromType(typeof(MediaPlayerService)).Name), ConnectionCallback, null);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnNewIntent(Intent intent)
        {
            Console.WriteLine("OnNewIntent Adapter");
            if(intent.Extras != null)
            {
                if(!string.IsNullOrWhiteSpace(intent.Extras.GetString("query","")))
                {
                    var newIntent = Application.Context.PackageManager.GetLaunchIntentForPackage("com.nejman.nsec.music_player");
                    newIntent.PutExtra("query", intent.Extras.GetString("query", ""));
                    newIntent.AddCategory("android.intent.category.LAUNCHER");

                    if (IsAvailable(newIntent))
                    {
                        newIntent.AddFlags(ActivityFlags.NewTask);
                        Console.WriteLine("newIntent " + newIntent.Extras.GetString("query", ""));
                        Application.Context.StartActivity(newIntent);
                        Thread.Sleep(1000);
                        Application.Context.StartActivity(newIntent);
                        Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                    }
                }
            }
        }

        private bool IsAvailable(Intent intent)
        {
            return intent != null && Application.Context.PackageManager.QueryIntentActivities(intent, 0).Count != 0;
        }


        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine("ERROR " + DateTime.Now.ToString());
            Console.WriteLine("Exception: " + e.Exception.Message);
            Console.WriteLine("StackTrace: " + e.Exception.StackTrace);
            Console.WriteLine("Source: " + e.Exception.Source);
            Console.WriteLine("ERROR END");
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("ERROR " + DateTime.Now.ToString());
            Console.WriteLine("Exception: " + ((Exception)e.ExceptionObject).Message);
            Console.WriteLine("StackTrace: " + ((Exception)e.ExceptionObject).StackTrace);
            Console.WriteLine("Source: " + ((Exception)e.ExceptionObject).Source);
            Console.WriteLine("ERROR END");
        }

        private void AndroidEnvironment_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            Console.WriteLine("ERROR " + DateTime.Now.ToString());
            Console.WriteLine("Exception: " + e.Exception.Message);
            Console.WriteLine("StackTrace: " + e.Exception.StackTrace);
            Console.WriteLine("Source: " + e.Exception.Source);
            Console.WriteLine("ERROR END");
        }
    }
}