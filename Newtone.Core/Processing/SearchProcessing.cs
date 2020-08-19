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
        public static void SearchOffline(string text, ObservableBridge<SearchResultModel> model)
        {
            GlobalData.Current.Audios.Values.ForEach(item =>
            {
                string artist = item.Artist;
                string title = item.Title;

                if (CyrylicToUnicode.IsCyrylic(artist))
                    artist = CyrylicToUnicode.Convert(artist);

                if (CyrylicToUnicode.IsCyrylic(title))
                    title = CyrylicToUnicode.Convert(title);

                double artistSimiliarity = CalculateSimilarity(text.ToLowerInvariant(), artist.ToLowerInvariant());
                double titleSimiliarity = CalculateSimilarity(text, title);

                if(artistSimiliarity >= 0.8 || titleSimiliarity >= 0.8 || artist.ToLowerInvariant().Contains(text.ToLowerInvariant()) || title.ToLowerInvariant().Contains(text.ToLowerInvariant()))
                {
                    model.Add(new SearchResultModel()
                    {
                        Author = item.Artist,
                        Duration = item.Duration,
                        Id = item.FilePath,
                        Image = item.Image,
                        Title = item.Title,
                    });
                }
            });
        }
        public async static Task Search(string text, ObservableBridge<SearchResultModel> model)
        {
            if (GlobalData.Current.History.FindIndex(model => model.Text == text) == -1)
            {
                GlobalData.Current.History.Add(new HistoryModel() { Text = text });
                GlobalData.Current.HistoryNeedRefresh = true;
            }

            GlobalData.Current.SaveConfig();
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
        public static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }
        #endregion
        #region Private Methods
        private static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
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
