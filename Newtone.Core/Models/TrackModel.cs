using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Newtone.Core.Models
{
    public class TrackModel
    {
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }

        public string Artist { get; set; }
    }
}
