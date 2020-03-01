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
using NSEC.Music_Player.Media;

namespace NSEC.Music_Player.Models
{
    public class TrackCounter
    {
        public MediaSource Media { get; set; }
        public int Count { get; set; }

        public TrackCounter()
        {
            Media = new MediaSource();
            Count = 0;
        }

        public TrackCounter(MediaSource media, int count)
        {
            Media = media;
            Count = count;
        }

        public override string ToString()
        {
            return $"{Media?.FilePath}{Global.SEPARATOR}{Count}:";
        }

        public static TrackCounter FromString(string fromString)
        {
            fromString = fromString.Replace(":", "");

            string[] elems = fromString.Split(Global.SEPARATOR);
            return Global.Audios.ContainsKey(elems[0]) ? new TrackCounter(Global.Audios[elems[0]], int.Parse(elems[1])) : null;
        }
    }
}