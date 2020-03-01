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
    public class HistoryModel
    {
        public string Text { get; set; }
        public bool Youtube { get; set; }
        public ImageSource Picture
        {
            get
            {
                return Youtube ? ImageSource.FromFile("YoutubeIcon.png") : ImageSource.FromFile("SoundcloudIcon.png");
            }
        }

        public override string ToString()
        {
            string boolString = Youtube ? "yt" : "sc";
            return $"{boolString}{Global.SEPARATOR}{Text}";
        }

        public static HistoryModel FromString(string text)
        {
            string[] elems = text.Split(Global.SEPARATOR);
            return new HistoryModel()
            {
                Text = elems[1],
                Youtube = elems[0] == "yt"
            };
        }
    }
}