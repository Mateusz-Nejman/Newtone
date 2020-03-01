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
    public class DownloadListModel
    {
        public string Name { get; set; }
        public double Progress { get; set; }
        public bool Downloaded { get; set; }
        public string Url { get; set; }
        public string ProgressString
        {
            get
            {
                return string.Format("{0:0.00}", Progress * 100.0) + "%";
            }
        }
        public ImageSource Image { get; set; }
    }
}