using Nejman.Newtone.Core.Media;
using System;

namespace Nejman.Newtone.Core.Models
{
    public class ArtistItemModel
    {
        public string Artist { get; }
        public string Title { get; }
        public TimeSpan Duration { get; }
        public string Path { get; }
        public byte[] Image { get; }

        internal ArtistItemModel(MediaSource source)
        {
            Artist = source.Artist;
            Title = source.Title;
            Duration = source.Duration;
            Path = source.Path;
            Image = source.Image;
        }
    }
}
