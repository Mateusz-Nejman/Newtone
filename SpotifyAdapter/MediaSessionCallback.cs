using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media.Session;
using Android.Views;
using Android.Widget;

namespace SpotifyAdapter
{
    public class MediaSessionCallback : MediaSessionCompat.Callback
    {
        #region Public Methods
        public override void OnPlayFromSearch(string query, Bundle extras)
        {
            Console.WriteLine("query " + query);
        }
        #endregion
    }
}