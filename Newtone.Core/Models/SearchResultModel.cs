﻿using Newtone.Core.Logic;
using System;
using System.Net;
using YoutubeExplode.Common;
using YoutubeExplode.Videos;

namespace Newtone.Core.Models
{
    public class SearchResultModel:PropertyChangedBase
    {
        #region Fields
        private string title;
        private string author;
        private string id;
        private string mixId;
        private byte[] image;
        private TimeSpan duration;
        private string thumbUrl;
        private string videoData;
        #endregion
        #region Properties
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public string Author
        {
            get => author;
            set
            {
                author = value;
                OnPropertyChanged();
            }
        }
        public string Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string MixId
        {
            get => mixId;
            set
            {
                mixId = value;
                OnPropertyChanged();
            }
        }
        public byte[] Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        public TimeSpan Duration
        {
            get => duration;
            set
            {
                duration = value;
                OnPropertyChanged();
                OnPropertyChanged(() => DurationString);
            }
        }
        public string ThumbUrl
        {
            get => thumbUrl;
            set
            {
                thumbUrl = value;
                OnPropertyChanged();
            }
        }
        public string VideoData
        {
            get => videoData;
            set
            {
                videoData = value;
                OnPropertyChanged();
            }
        }
        public string DurationString
        {
            get
            {
                return Duration.ToString("mm':'ss");
            }
        }
        public bool IsOffline
        {
            get
            {
                return id.Length > 11;
            }
        }
        #endregion

        #region Operators
        public static implicit operator SearchResultModel(Video video)
        {
            var ret = new SearchResultModel()
            {
                Author = video.Author.Title,
                Duration = video.Duration ?? TimeSpan.Zero,
                Id = video.Id,
                ThumbUrl = video.Thumbnails.GetWithHighestResolution().Url,
                Title = video.Title,
                VideoData = string.Concat(video.Title,GlobalData.SEPARATOR,video.Url)
            };

            using WebClient client = new WebClient();
            ret.Image = client.DownloadData(video.Thumbnails.GetWithHighestResolution().Url);
            return ret;
        }
        #endregion
    }
}
