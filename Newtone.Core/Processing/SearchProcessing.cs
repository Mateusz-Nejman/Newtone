using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Newtone.Core.Processing
{
    public class SearchProcessing
    {
        #region Public Methods
        public async static Task Search(string text, ObservableBridge<SearchResultModel> model)
        {
            if (GlobalData.History.FindIndex(model => model.Text == text) == -1)
                GlobalData.History.Add(new HistoryModel() { Text = text });

            GlobalData.SaveConfig();
            ConsoleDebug.WriteLine("Start search");
            YoutubeClient client = new YoutubeClient();
            ConsoleDebug.WriteLine("init");
            var validators = CheckLink(text);
            ConsoleDebug.WriteLine(validators.Count);

            foreach(var val in validators.Keys)
            {
                ConsoleDebug.WriteLine(val);
            }

            if(validators.ContainsKey(QueryEnum.Video))
            {
                ConsoleDebug.WriteLine("Video");
                var video = await client.Videos.GetAsync(validators[QueryEnum.Video]);

                model.Add(new SearchResultModel()
                {
                    Author = video.Author,
                    Duration = video.Duration,
                    Title = video.Title,
                    ThumbUrl = video.Thumbnails.MediumResUrl,
                    Id = video.Id,
                    MixId = video.GetVideoMixPlaylistId(),
                    VideoData = $"{video.Title}{GlobalData.SEPARATOR}{video.Url}"
                });
            }
            else if(validators.ContainsKey(QueryEnum.Search) || validators.ContainsKey(QueryEnum.None))
            {
                ConsoleDebug.WriteLine("Search None");
                var videos = await client.Search.GetVideosAsync(validators[validators.ContainsKey(QueryEnum.None) ? QueryEnum.None : QueryEnum.Search]).BufferAsync(20);
                ConsoleDebug.WriteLine("Search " + videos.Count);
                foreach(var video in videos)
                {
                    ConsoleDebug.WriteLine("Search " + video.Title);
                    model.Add(new SearchResultModel()
                    {
                        Author = video.Author,
                        Duration = video.Duration,
                        Id = video.Id,
                        MixId = video.GetVideoMixPlaylistId(),
                        ThumbUrl = video.Thumbnails.MediumResUrl,
                        Title = video.Title,
                        VideoData = $"{video.Title}{GlobalData.SEPARATOR}{video.Url}"
                    });
                }
            }
            else if (validators.ContainsKey(QueryEnum.Playlist))
            {
                ConsoleDebug.WriteLine("Playlist");
                var playlist = await client.Playlists.GetVideosAsync(validators[QueryEnum.Playlist]);
                foreach (var video in playlist)
                {
                    ConsoleDebug.WriteLine("Video " + video.Id);
                    model.Add(new SearchResultModel() { Author = video.Author, Duration = video.Duration, Title = video.Title, ThumbUrl = video.Thumbnails.MediumResUrl, Id = video.Id, VideoData = $"{video.Title}{GlobalData.SEPARATOR}{video.Url}&list={validators[QueryEnum.Playlist]}" });
                }
            }
        }

        public static Dictionary<QueryEnum, string> CheckLink(string link)
        {
            Dictionary<QueryEnum, string> returnDict = new Dictionary<QueryEnum, string>();

            if(link != null)
            {
                string searchValue = "";

                bool videoValid = YoutubeExplodeExtensions.TryParseVideoId(link, out string videoId);
                bool channelValid = YoutubeExplodeExtensions.TryParseChannelId(link, out string channelId);
                bool playlistValid = YoutubeExplodeExtensions.TryParsePlaylistId(link, out string playlistId);

                bool searchValid = link.IndexOf("search_query=") > 0;

                if(searchValid)
                    searchValue = HttpUtility.UrlDecode(link.Substring(link.IndexOf("search_query=") + 13));

                if (videoValid)
                    returnDict.Add(QueryEnum.Video, videoId);
                if (channelValid)
                    returnDict.Add(QueryEnum.Channel, channelId);
                if (playlistValid)
                    returnDict.Add(QueryEnum.Playlist, playlistId);
                if (searchValid)
                    returnDict.Add(QueryEnum.Search, searchValue);
            }

            if (returnDict.Count == 0)
                returnDict.Add(QueryEnum.None, link);

            return returnDict;
        }
        #endregion
        #region Enums
        public enum QueryEnum
        {
            None,
            Video,
            Channel,
            Playlist,
            Search
        }
        #endregion
    }
}
