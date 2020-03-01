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
using NSEC.Music_Player.Languages;

namespace NSEC.Music_Player.Models
{
    public class PlaylistListModel
    {
        public string Name { get; set; }
        public int TrackCount { get; set; }
        public string TrackElem
        {
            get
            {
                return $"{Localization.TrackCountPlaylist}: {TrackCount}";
            }
        }
    }
}