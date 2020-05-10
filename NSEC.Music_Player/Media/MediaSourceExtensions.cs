using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media;
using Android.Views;
using Android.Widget;
using Newtone.Core.Media;

namespace NSEC.Music_Player.Media
{
    public static class MediaSourceExtensions
    {
        public static MediaMetadataCompat ToMetadata(this MediaSource source)
        {
            Global.MetadataBuilder.PutString(MediaMetadataCompat.MetadataKeyTitle, source.Title);
            Global.MetadataBuilder.PutString(MediaMetadataCompat.MetadataKeyArtist, source.Artist);
            Global.MetadataBuilder.PutLong(MediaMetadataCompat.MetadataKeyDuration, (long)source.Duration.TotalMilliseconds);
            return Global.MetadataBuilder.Build();
        }
    }
}