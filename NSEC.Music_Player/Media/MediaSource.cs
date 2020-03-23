using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NSEC.Music_Player.Models;
using Xamarin.Forms;

namespace NSEC.Music_Player.Media
{
    public class MediaSource
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string Artist { get; set; }
        public double Duration { get; set; }
        public byte[] Picture { get; set; }
        public ImageSource ImageSource { get; set; }
        public SourceType Type { get; set; }

        public enum SourceType
        {
            Local,
            Web
        }

        public static implicit operator SearchResultModel(MediaSource source)
        {
            return new SearchResultModel()
            {
                Author = source.Artist,
                Duration = source.Duration,
                Id = source.FilePath,
                ImageData = source.Picture,
                Picture = source.ImageSource,
                Title = source.Title,
                Youtube = source.Type == SourceType.Web,
                VideoData = $"{source.Title}{Global.SEPARATOR}https://youtube.com/watch?v={source.FilePath}"
            };
        }

        public static implicit operator TrackListModel(MediaSource source)
        {
            return new TrackListModel() { Title = source.Title, Author = source.Artist, Tag = source.FilePath, Image = source.Picture == null ? Global.EmptyTrack : ImageSource.FromStream(() => new MemoryStream(source.Picture)) };
        }

        public static explicit operator MediaSource(SearchResultModel model)
        {
            return new MediaSource()
            {
                Artist = model.Author,
                Duration = model.Duration,
                FilePath = model.Id,
                ImageSource = model.Picture,
                Picture = model.ImageData,
                Title = model.Title,
                Type = SourceType.Web
            };
        }

        public static explicit operator MediaSource(YoutubeExplode.Models.Video video)
        {
            using WebClient client = new WebClient();
            byte[] picture = client.DownloadData(video.Thumbnails.MediumResUrl);
            return new MediaSource()
            {
                Artist = video.Author,
                Duration = video.Duration.TotalSeconds,
                FilePath = video.Id,
                Title = video.Title,
                Type = SourceType.Web,
                Picture = picture,
                ImageSource = ImageSource.FromStream(() => new MemoryStream(picture))
            };
        }
    }
}