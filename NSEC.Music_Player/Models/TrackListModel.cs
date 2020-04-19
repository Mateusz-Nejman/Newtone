using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace NSEC.Music_Player.Models
{
    public class TrackListModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Tag { get; set; }
        public ImageSource Image { get; set; }
        public bool IsPlaylist { get; set; }
    }
}