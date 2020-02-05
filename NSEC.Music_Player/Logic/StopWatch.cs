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

namespace NSEC
{
    public static class StopWatch
    {
        private static System.Diagnostics.Stopwatch stopwatch;

        public static void Start()
        {
            if (stopwatch == null)
                stopwatch = new System.Diagnostics.Stopwatch();
            else if(stopwatch.IsRunning)
                stopwatch.Stop();

            stopwatch.Start();
        }

        public static void Stop(string title)
        {
            if(stopwatch != null && stopwatch.IsRunning)
            {
                stopwatch.Stop();

                Console.WriteLine("StopWatch " + title + " " + stopwatch.ElapsedMilliseconds);
            }
        }
    }
}