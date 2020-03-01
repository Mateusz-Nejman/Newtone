﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NSEC.Music_Player.Media
{
    public class MediaOutput
    {
        public byte[] Data { get; set; }
        public MediaOutputType OutputType { get; set; }

        public MediaOutput(byte[] data, MediaOutputType outputType)
        {
            Data = data;
            OutputType = outputType;
        }
    }
}