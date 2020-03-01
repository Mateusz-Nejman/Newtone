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
using Xamarin.Forms;

namespace NSEC.Music_Player.Media
{
    public class MediaSource
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string Artist { get; set; }
        public double Duration { get; set; }
        public byte[] Picture { get; set; }
        public ImageSource ImageSource { get; set; }
        public SourceType Type { get; set; }

        public enum SourceType
        {
            Local,
            Web
        }
    }
}