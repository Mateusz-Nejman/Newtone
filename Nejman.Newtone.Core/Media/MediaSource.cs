using System;
using System.Collections.Generic;
using System.Text;

namespace Nejman.Newtone.Core.Media
{
    public class MediaSource
    {
        public string Artist { get; private set; }
        public string Title { get; private set; }
        public TimeSpan Duration { get; private set; }
        public byte[] Image { get; private set; }
        public string Path { get; private set; }
        public string ID { get; private set; }
        public string ImageUrl { get; private set; }
        public bool IsLocal
        {
            get
            {
                return !Path.StartsWith("https://") && Path.Length > 11;
            }
        }

        public MediaSource(string path = null, string artist = null, string title = null, TimeSpan duration = default, byte[] image = null, string id = null, string imageUrl = null)
        {
            Artist = artist;
            Title = title;
            Duration = duration;
            Image = image;
            Path = path;
            ID = id;
            ImageUrl = imageUrl;
        }
    }
}
