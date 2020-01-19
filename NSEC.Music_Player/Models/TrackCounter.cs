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

namespace NSEC.Music_Player.Models
{
    public class TrackCounter
    {
        public string Track { get; set; }
        public int Count { get; set; }

        public TrackCounter()
        {
            Track = "";
            Count = 0;
        }

        public TrackCounter(string track, int count)
        {
            Track = track;
            Count = count;
        }

        public override string ToString()
        {
            return $"{Track};{Count}:";
        }
        
        public static TrackCounter FromString(string fromString)
        {
            fromString = fromString.Replace(":", "");

            string[] elems = fromString.Split(';');
            return new TrackCounter(elems[0], int.Parse(elems[1]));
        }
    }
}