using System;
using System.Collections.Generic;
using System.Text;

namespace Nejman.Newtone.Core.Models
{
    public class TrackModel
    {
        public string Artist { get; }
        public string Title { get; }
        public string Path { get; }
        internal TrackModel(string artist, string title, string path)
        {
            Artist = artist;
            Title = title;
            Path = path;
        }
    }
}
