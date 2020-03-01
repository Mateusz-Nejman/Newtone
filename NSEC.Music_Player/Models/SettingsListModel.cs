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

namespace NSEC.Music_Player.Models
{
    class SettingsListModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public bool HasCheckbox { get; set; }
        public string EnabledString
        {
            get
            {
                return Enabled ? "on" : "off";
            }
        }
    }
}