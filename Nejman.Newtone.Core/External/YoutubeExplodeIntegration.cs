using Nejman.Newtone.Core.Exceptions;
using Nejman.Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Videos.Streams;

namespace Nejman.Newtone.Core.External
{
    public static class YoutubeExplodeIntegration
    {
        public async static Task<int> Search(string searchData, ObservableBridge<MediaSource> bridge)
        {
            int maxItems = -1;
            var validators = CheckLink(searchData);

            YoutubeClient client = new YoutubeClient();

            try
            {
                if (validators.ContainsKey(Query.Video))
                {
                    var video = await client.Videos.GetAsync(validators[Query.Video]);

                    var thumbUrl = video.Thumbnails.GetWithHighestResolution().Url;
                    byte[] thumb;

                    using (WebClient webClient = new WebClient())
                    {
                        thumb = await webClient.DownloadDataTaskAsync(thumbUrl);
                    }

                    bridge.Add(new MediaSource(video.Id.Value, video.Author.Title, video.Title, video.Duration ?? TimeSpan.Zero, thumb, video.Id.Value));
                    maxItems = 1;
                }
                else if (validators.ContainsKey(Query.Search) || validators.ContainsKey(Query.None))
                {
                    var videos = await client.Search.GetVideosAsync(validators[validators.ContainsKey(Query.None) ? Query.None : Query.Search]).CollectAsync(40);

                    foreach (var video in videos)
                    {
                        var thumbUrl = video.Thumbnails.GetWithHighestResolution().Url;
                        byte[] thumb;

                        using (WebClient webClient = new WebClient())
                        {
                            thumb = await webClient.DownloadDataTaskAsync(thumbUrl);
                        }

                        bridge.Add(new MediaSource(video.Id.Value, video.Author.Title, video.Title, video.Duration ?? TimeSpan.Zero, thumb, video.Id.Value));
                    }
                }
                else if (validators.ContainsKey(Query.Playlist))
                {
                    var playlist = await client.Playlists.GetVideosAsync(validators[Query.Playlist]).CollectAsync(100);
                    foreach (var video in playlist)
                    {
                        var thumbUrl = video.Thumbnails.GetWithHighestResolution().Url;
                        byte[] thumb;

                        using (WebClient webClient = new WebClient())
                        {
                            thumb = await webClient.DownloadDataTaskAsync(thumbUrl);
                        }

                        bridge.Add(new MediaSource(video.Id.Value, video.Author.Title, video.Title, video.Duration ?? TimeSpan.Zero, thumb, video.Id.Value));
                    }

                    maxItems = playlist.Count;
                }
            }
            catch
            {
                throw new YoutubeException("Search");
            }

            return maxItems;
        }

        public async static Task<string> GetAudioUrl(string id)
        {
            string url;
            YoutubeClient client = new YoutubeClient();
            
            try
            {
                var manifest = await client.Videos.Streams.GetManifestAsync(id);
                url = manifest.GetAudioOnlyStreams().Where(info => info.AudioCodec.Contains(CoreGlobal.MediaFormat == MediaFormat.m4a ? "mp4a" : "opus")).OrderByDescending(info => info.Bitrate.BitsPerSecond).First().Url;
            }
            catch
            {
                throw new YoutubeException("GetAudioUrl");
            }

            return url;
        }

        public async static Task DownloadFile(string id, string filePath, IProgress<double> progress)
        {
            YoutubeClient client = new YoutubeClient();
            
            try
            {
                await client.Videos.Streams.DownloadAsync(await GetAudioStream(id), filePath, progress);
            }
            catch
            {
                throw new YoutubeException("DownloadFile");
            }
        }

        public async static Task<MediaSource> GetVideo(string id)
        {
            YoutubeClient client = new YoutubeClient();

            try
            {
                var video = await client.Videos.GetAsync(id);

                return new MediaSource(await GetAudioUrl(id), video.Author.Title, video.Title, video.Duration ?? TimeSpan.Zero, null, id, video.Thumbnails.GetWithHighestResolution().Url);
            }
            catch
            {
                throw new YoutubeException("GetVideo");
            }
        }

        public async static Task<string> GetPlaylistName(string id)
        {
            YoutubeClient client = new YoutubeClient();

            try
            {
                var playlist = await client.Playlists.GetAsync(id);

                return playlist.Title;
            }
            catch
            {
                throw new YoutubeException("GetPlaylistName");
            }
        }

        internal static Dictionary<Query, string> CheckLink(string link)
        {
            Dictionary<Query, string> returnDict = new Dictionary<Query, string>();

            if (link != null)
            {
                string searchValue = "";

                bool videoValid = TryParseVideoId(link, out string videoId);
                bool playlistValid = TryParsePlaylistId(link, out string playlistId);

                bool searchValid = link.IndexOf("search_query=") >= 0;

                string trimmed = link.Trim();

                if (trimmed.ToLowerInvariant().StartsWith("video:"))
                {
                    string temp = trimmed.Substring(6);
                    if (temp.Length == 11)
                    {
                        videoId = temp;
                        videoValid = true;
                    }
                }

                if (trimmed.ToLowerInvariant().StartsWith("playlist:"))
                {
                    string temp = trimmed.Substring(9);
                    if (temp.Length == 11)
                    {
                        playlistId = temp;
                        playlistValid = true;
                    }
                }

                if (searchValid)
                    searchValue = HttpUtility.UrlDecode(link.Substring(link.IndexOf("search_query=") + 13));

                if (videoValid)
                    returnDict.Add(Query.Video, videoId);
                if (playlistValid)
                    returnDict.Add(Query.Playlist, playlistId);
                if (searchValid)
                    returnDict.Add(Query.Search, searchValue);
            }

            if (returnDict.Count == 0)
                returnDict.Add(Query.None, link);

            return returnDict;
        }

        private async static Task<IStreamInfo> GetAudioStream(string id)
        {
            YoutubeClient client = new YoutubeClient();

            try
            {
                var manifest = await client.Videos.Streams.GetManifestAsync(id);
                return manifest.GetAudioOnlyStreams().Where(info => info.AudioCodec.Contains(CoreGlobal.MediaFormat == MediaFormat.m4a ? "mp4a" : "opus")).OrderByDescending(info => info.Bitrate.BitsPerSecond).First();
            }
            catch(Exception e)
            {
                throw new YoutubeException("GetAudioStream");
            }
        }

        /// <summary>
        /// Verifies that the given string is syntactically a valid YouTube video ID.
        /// </summary>
        private static bool ValidateVideoId(string videoId)
        {
            if (string.IsNullOrWhiteSpace(videoId))
                return false;

            // Video IDs are always 11 characters
            if (videoId.Length != 11)
                return false;

            return !Regex.IsMatch(videoId, @"[^0-9a-zA-Z_\-]");
        }

        /// <summary>
        /// Tries to parse video ID from a YouTube video URL.
        /// </summary>
        private static bool TryParseVideoId(string videoUrl, out string videoId)
        {
            videoId = default;

            if (string.IsNullOrWhiteSpace(videoUrl))
                return false;

            // https://www.youtube.com/watch?v=yIVRs6YSbOM
            var regularMatch = Regex.Match(videoUrl, @"youtube\..+?/watch.*?v=(.*?)(?:&|/|$)").Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(regularMatch) && ValidateVideoId(regularMatch))
            {
                videoId = regularMatch;
                return true;
            }

            // https://youtu.be/yIVRs6YSbOM
            var shortMatch = Regex.Match(videoUrl, @"youtu\.be/(.*?)(?:\?|&|/|$)").Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(shortMatch) && ValidateVideoId(shortMatch))
            {
                videoId = shortMatch;
                return true;
            }

            // https://www.youtube.com/embed/yIVRs6YSbOM
            var embedMatch = Regex.Match(videoUrl, @"youtube\..+?/embed/(.*?)(?:\?|&|/|$)").Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(embedMatch) && ValidateVideoId(embedMatch))
            {
                videoId = embedMatch;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifies that the given string is syntactically a valid YouTube playlist ID.
        /// </summary>
        private static bool ValidatePlaylistId(string playlistId)
        {
            if (string.IsNullOrWhiteSpace(playlistId))
                return false;

            // Watch later playlist is special
            if (playlistId == "WL")
                return true;

            // Other playlist IDs should start with these two characters
            if (!playlistId.StartsWith("PL", StringComparison.Ordinal) &&
                !playlistId.StartsWith("RD", StringComparison.Ordinal) &&
                !playlistId.StartsWith("UL", StringComparison.Ordinal) &&
                !playlistId.StartsWith("UU", StringComparison.Ordinal) &&
                !playlistId.StartsWith("PU", StringComparison.Ordinal) &&
                !playlistId.StartsWith("OL", StringComparison.Ordinal) &&
                !playlistId.StartsWith("LL", StringComparison.Ordinal) &&
                !playlistId.StartsWith("FL", StringComparison.Ordinal))
                return false;

            // Playlist IDs vary a lot in lengths, so we will just compare with the extremes
            if (playlistId.Length < 13 || playlistId.Length > 42)
                return false;

            return !Regex.IsMatch(playlistId, @"[^0-9a-zA-Z_\-]");
        }

        /// <summary>
        /// Tries to parse playlist ID from a YouTube playlist URL.
        /// </summary>
        private static bool TryParsePlaylistId(string playlistUrl, out string playlistId)
        {
            playlistId = default;

            if (string.IsNullOrWhiteSpace(playlistUrl))
                return false;

            // https://www.youtube.com/playlist?list=PLOU2XLYxmsIJGErt5rrCqaSGTMyyqNt2H
            var regularMatch = Regex.Match(playlistUrl, @"youtube\..+?/playlist.*?list=(.*?)(?:&|/|$)").Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(regularMatch) && ValidatePlaylistId(regularMatch))
            {
                playlistId = regularMatch;
                return true;
            }

            // https://www.youtube.com/watch?v=b8m9zhNAgKs&list=PL9tY0BWXOZFuFEG_GtOBZ8-8wbkH-NVAr
            var compositeMatch = Regex.Match(playlistUrl, @"youtube\..+?/watch.*?list=(.*?)(?:&|/|$)").Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(compositeMatch) && ValidatePlaylistId(compositeMatch))
            {
                playlistId = compositeMatch;
                return true;
            }

            // https://youtu.be/b8m9zhNAgKs/?list=PL9tY0BWXOZFuFEG_GtOBZ8-8wbkH-NVAr
            var shortCompositeMatch = Regex.Match(playlistUrl, @"youtu\.be/.*?/.*?list=(.*?)(?:&|/|$)").Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(shortCompositeMatch) && ValidatePlaylistId(shortCompositeMatch))
            {
                playlistId = shortCompositeMatch;
                return true;
            }

            // https://www.youtube.com/embed/b8m9zhNAgKs/?list=PL9tY0BWXOZFuFEG_GtOBZ8-8wbkH-NVAr
            var embedCompositeMatch = Regex.Match(playlistUrl, @"youtube\..+?/embed/.*?/.*?list=(.*?)(?:&|/|$)")
                .Groups[1].Value;
            if (!string.IsNullOrWhiteSpace(embedCompositeMatch) && ValidatePlaylistId(embedCompositeMatch))
            {
                playlistId = embedCompositeMatch;
                return true;
            }

            return false;
        }

        public enum Query
        {
            None,
            Video,
            Channel,
            Playlist,
            Search
        }
    }
}
