using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Models
{
    public class SettingsModel
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
