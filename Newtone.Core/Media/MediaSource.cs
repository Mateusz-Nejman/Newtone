using Newtone.Core.Logic;
using Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using YoutubeExplode.Videos;

namespace Newtone.Core.Media
{
    public class MediaSource
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string Artist { get; set; }
        public TimeSpan Duration { get; set; }
        public byte[] Image { get; set; }
        public SourceType Type { get; set; }

        public enum SourceType
        {
            Local,
            Web
        }

        public MediaSource Clone()
        {
            return new MediaSource()
            {
                Title = this.Title,
                Artist = this.Artist,
                Duration = this.Duration,
                FilePath = this.FilePath,
                Image = this.Image,
                Type = this.Type
            };
        }

        public static explicit operator MediaSource(Video video)
        {
            using WebClient client = new WebClient();
            byte[] picture = client.DownloadData(video.Thumbnails.MediumResUrl);
            return new MediaSource()
            {
                Artist = video.Author,
                Duration = video.Duration,
                FilePath = video.Id,
                Title = video.Title,
                Type = SourceType.Web,
                Image = picture
            };
        }

        public static implicit operator TrackModel(MediaSource source)
        {
            return new TrackModel()
            {
                Duration = source.Duration.ToString("mm':'ss"),
                FilePath = source.FilePath,
                Title = source.Title,
                Artist = source.Artist
            };
        }

        public static implicit operator MediaSource(SearchResultModel model)
        {
            return new MediaSource()
            {
                Artist = model.Author,
                Duration = model.Duration,
                FilePath = model.Id,
                Image = model.Image,
                Title = model.Title,
                Type = SourceType.Web
            };
        }


    }
}
