using Newtone.Core.Logic;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using YoutubeExplode.Videos;

namespace Newtone.Core.Models
{
    public class SearchResultModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Id { get; set; }
        public string MixId { get; set; }
        public byte[] Image { get; set; }
        public TimeSpan Duration { get; set; }
        public string ThumbUrl { get; set; }
        public string VideoData { get; set; }
        public string DurationString
        {
            get
            {
                return Duration.ToString("mm':'ss");
            }
        }

        public static implicit operator SearchResultModel(Video video)
        {
            var ret = new SearchResultModel()
            {
                Author = video.Author,
                Duration = video.Duration,
                Id = video.Id,
                MixId = video.GetVideoMixPlaylistId(),
                ThumbUrl = video.Thumbnails.MediumResUrl,
                Title = video.Title,
                VideoData = $"{video.Title}{GlobalData.SEPARATOR}{video.Url}"
            };

            using WebClient client = new WebClient();
            ret.Image = client.DownloadData(video.Thumbnails.MediumResUrl);
            return ret;
        }
    }
}
