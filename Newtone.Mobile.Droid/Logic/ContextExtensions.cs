using Android.App;
using Android.Content;
using Android.OS;

namespace Newtone.Mobile.Droid.Logic
{
    public static class ContextExtensions
    {
        public static void StartForegroundServiceCompat<T>(this Context context, Bundle args = null) where T : Service
        {
            try
            {
                var intent = new Intent(context, typeof(T));
                if (args != null)
                {
                    intent.PutExtras(args);
                }

                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    context.StartForegroundService(intent);
                }
                else
                {
                    context.StartService(intent);
                }
            }
            catch
            {
                //ignore
            }
        }

        public static void StartServiceCompat<T>(this Context context, Bundle args = null) where T : Service
        {
            try
            {
                var intent = new Intent(context, typeof(T));
                if (args != null)
                {
                    intent.PutExtras(args);
                }

                context.StartService(intent);
            }
            catch
            {
                //ignore
            }
        }
    }
}