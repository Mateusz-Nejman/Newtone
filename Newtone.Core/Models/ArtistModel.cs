using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Models
{
    public class ArtistModel
    {
        public string Name { get; set; }
        public int TrackCount { get; set; }
        public string TrackElem
        {
            get
            {
                return $"{Name} ({TrackCount})";
            }
        }
    }
}
