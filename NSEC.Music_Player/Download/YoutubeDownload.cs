﻿using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Loaders;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Processing;
using NSEC.Music_Player.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using YoutubeExplode;
using YoutubeExplode.Models;
using YoutubeExplode.Models.MediaStreams;
using MediaSource = NSEC.Music_Player.Media.MediaSource;

namespace NSEC.Music_Player.Download
{
    public class YoutubeDownload : IDownload
    {
        public async Task AddToDownload(string id, string url, object additional = null)
        {
            YoutubeClient client = new YoutubeClient();
            string playlistId = "";
            Dictionary<QueryEnum, string> urlType = CheckLink(url);
            string playlistName = "";
            Playlist playlist = null;

            if (urlType.ContainsKey(QueryEnum.Playlist))
            {
                if (urlType.ContainsKey(QueryEnum.Video))
                {
                    bool answer = await MainPage.Instance.DisplayAlert(Localization.Question, Localization.PlaylistOrTrack, Localization.Track, Localization.Playlist);
                    if (answer)
                    {
                        playlistId = "";
                    }
                    else
                    {
                        playlistId = urlType[QueryEnum.Playlist];

                        bool toPlaylist = await MainPage.Instance.DisplayAlert(Localization.Question, Localization.PlaylistDownload, Localization.Yes, Localization.No);

                        if(toPlaylist)
                        {
                            playlist = await client.GetPlaylistAsync(playlistId);
                            string newPlaylistName = await MainPage.Instance.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel, Localization.Playlist, -1, null, playlist.Title);

                            playlistName = string.IsNullOrWhiteSpace(newPlaylistName) ? "" : newPlaylistName;
                        }
                    }
                }
            }

            if(playlistId == "")
            {
                string title;
                string _url;
                if (additional == null)
                {
                    Video video = await client.GetVideoAsync(urlType[QueryEnum.Video]);
                    title = video.Title;
                    _url = video.GetUrl();
                }
                else
                {
                    string[] elems = (string[])additional;
                    title = elems[0];
                    _url = elems[1];
                }



                DownloadProcessing.AddToDownloadTask(urlType[QueryEnum.Video], title, true, _url,playlistName);
            }
            else
            {
                if(playlist == null)
                    playlist = await client.GetPlaylistAsync(playlistId);

                foreach(Video video in playlist.Videos)
                {
                    DownloadProcessing.AddToDownloadTask(video.Id, video.Title, true, video.GetUrl(),playlistName);
                }
            }
        }

        public async Task<string> Download(string id, string url)
        {
            YoutubeClient client = new YoutubeClient();
            Video video = await client.GetVideoAsync(id);
            MediaStreamInfoSet streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);
            AudioStreamInfo streamInfo = null;

            foreach(AudioStreamInfo audio in streamInfoSet.Audio)
            {
                if(audio.AudioEncoding == AudioEncoding.Aac)
                {
                    streamInfo = audio;
                    break;
                }
            }

            Progress<double> progress = new Progress<double>(progressValue =>
            {
                DownloadProcessing.SetProgress(id, progressValue);
            });

            string fileName = video.Title.Replace('/', '_');

            await client.DownloadMediaStreamAsync(streamInfo, Global.MusicPath + "/" + fileName + ".m4a", progress);

            MainPage.Instance.Dispatcher.BeginInvokeOnMainThread(async () =>
            {
                string[] splitted = video.Title.Split(new string[] { " - ", " – ", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries);
                string artist = splitted.Length == 1 ? video.Author : splitted[0];
                string title = splitted[splitted.Length == 1 ? 0 : 1];

                byte[] picture = null;
                try
                {
                    using WebClient wc = new WebClient();
                    picture = wc.DownloadData(video.Thumbnails.MediumResUrl);
                }
                catch
                {

                }

                if (Global.AudioTags.ContainsKey(Global.MusicPath + "/" + fileName + ".m4a"))
                {
                    string f = Global.MusicPath + "/" + video.Title + ".m4a";
                    Global.AudioTags[f].Author = artist;
                    Global.AudioTags[f].Title = title;
                    Global.AudioTags[f].ImageSource = picture;
                }
                else
                {
                    Global.AudioTags.Add(Global.MusicPath + "/" + fileName + ".m4a", new MediaSourceTag() { Author = artist, Title = title, ImageSource = picture });
                }

                MediaSource container = MediaProcessing.GetSource(Global.MusicPath + "/" + fileName + ".m4a");
                GlobalLoader.AddTrack(container);
                Global.SaveConfig();
                Global.SaveTags();
                CacheString.Save();
                SnackbarBuilder.Show(Localization.Ready);

            });
            return Global.MusicPath + "/" + fileName + ".m4a";

        }

        public async Task Search(string text, ObservableCollection<SearchResultModel> model)
        {
            var validators = CheckLink(text);

            YoutubeClient client = new YoutubeClient();
            if (validators.ContainsKey(QueryEnum.Video))
            {
                var video = await client.GetVideoAsync(validators[QueryEnum.Video]);
                model.Add(new SearchResultModel() { 
                    Author = video.Author, 
                    Duration = video.Duration.TotalSeconds, 
                    Title = video.Title, 
                    Youtube = true, 
                    ThumbUrl = video.Thumbnails.MediumResUrl, 
                    Id = video.Id, 
                    MixId = video.GetVideoMixPlaylistId(),
                    VideoData = $"{video.Title}{Global.SEPARATOR}{video.GetUrl()}" 
                });
            }
            else if (validators.ContainsKey(QueryEnum.Search) || validators.ContainsKey(QueryEnum.None))
            {
                var videos = await client.SearchVideosAsync(validators[validators.ContainsKey(QueryEnum.None) ? QueryEnum.None : QueryEnum.Search], 1);

                foreach (var video in videos)
                {
                    model.Add(new SearchResultModel() { Author = video.Author, Duration = video.Duration.TotalSeconds, Title = video.Title, Youtube = true, ThumbUrl = video.Thumbnails.MediumResUrl, Id = video.Id, VideoData = $"{video.Title}{Global.SEPARATOR}{video.GetUrl()}", MixId = video.GetVideoMixPlaylistId() });
                }
            }
            else if (validators.ContainsKey(QueryEnum.Playlist))
            {
                var playlist = await client.GetPlaylistAsync(validators[QueryEnum.Playlist]);
                foreach (var video in playlist.Videos)
                {
                    model.Add(new SearchResultModel() { Author = video.Author, Duration = video.Duration.TotalSeconds, Title = video.Title, Youtube = true, ThumbUrl = video.Thumbnails.MediumResUrl, Id = video.Id, VideoData = $"{video.Title}{Global.SEPARATOR}{video.GetUrl()}&list={validators[QueryEnum.Playlist]}" });
                }
            }
        }

        private Dictionary<QueryEnum, string> CheckLink(string link)
        {
            Dictionary<QueryEnum, string> returnDict = new Dictionary<QueryEnum, string>();

            if (link != null)
            {
                string searchValue = "";

                bool videoValid = YoutubeClient.TryParseVideoId(link, out string videoId);
                bool channelValid = YoutubeClient.TryParseChannelId(link, out string channelId);
                bool playlistValid = YoutubeClient.TryParsePlaylistId(link, out string playlistId);

                bool searchValid = link.IndexOf("search_query=") > 0;
                if (searchValid)
                {
                    searchValue = HttpUtility.UrlDecode(link.Substring(link.IndexOf("search_query=") + 13));
                }

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

        public enum QueryEnum
        {
            None,
            Video,
            Channel,
            Playlist,
            Search
        }
    }
}