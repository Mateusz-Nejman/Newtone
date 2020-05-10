﻿using Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Logic
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
            return $"{Media?.FilePath}{GlobalData.SEPARATOR}{Count}:";
        }

        public static TrackCounter FromString(string fromString)
        {
            fromString = fromString.Replace(":", "");

            string[] elems = fromString.Split(GlobalData.SEPARATOR);
            return GlobalData.Audios.ContainsKey(elems[0]) ? new TrackCounter(GlobalData.Audios[elems[0]], int.Parse(elems[1])) : null;
        }
    }
}
