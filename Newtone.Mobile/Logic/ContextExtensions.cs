using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Newtone.Mobile.Logic
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

                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
                {
                    context.StartForegroundService(intent);
                }
                else
                {
                    context.StartService(intent);
                }
            }
            catch { }
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
            { }
        }
    }
}