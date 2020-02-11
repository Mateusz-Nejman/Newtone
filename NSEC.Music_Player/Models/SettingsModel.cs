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
    class SettingsModel
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public bool CheckboxVisible { get; set; }
        public bool CheckboxValue { get; set; }

    }
}