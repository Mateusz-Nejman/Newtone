﻿using System;
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

namespace NSEC.Music_Player.Models
{
    public class DownloadModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public double Progress { get; set; }
        public bool Download { get; set; }
        public string ProgressString
        {
            get
            {
                return string.Format("{0:0.00}", Progress * 100.0) + "%";
            }
        }
    }
}