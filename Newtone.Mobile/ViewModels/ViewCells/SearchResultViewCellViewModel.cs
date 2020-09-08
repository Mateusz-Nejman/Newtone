﻿using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Mobile.Views;
using YoutubeExplode;

namespace Newtone.Mobile.ViewModels.ViewCells
{
    public class SearchResultViewCellViewModel
    {
        #region Commands
        private ICommand downloadClicked;
        public ICommand DownloadClicked
        {
            get
            {
                if (downloadClicked == null)
                    downloadClicked = new ActionCommand(async(parameter) =>
                    {
                        string tag = parameter as string;
                        string[] elems = tag.Split(GlobalData.SEPARATOR);
                        YoutubeClient client = new YoutubeClient();
                        string playlistId = "";
                        string playlistName = "";
                        var urlType = SearchProcessing.CheckLink(elems[1]);

                        if (urlType.ContainsKey(SearchProcessing.QueryEnum.Playlist))
                        {
                            if (urlType.ContainsKey(SearchProcessing.QueryEnum.Video))
                            {
                                if (await NormalPage.Instance.DisplayAlert(Localization.Question, Localization.PlaylistOrTrack, Localization.Track, Localization.Playlist))
                                {
                                    playlistId = "";
                                }
                                else
                                {
                                    playlistId = urlType[SearchProcessing.QueryEnum.Playlist];

                                    if (await NormalPage.Instance.DisplayAlert(Localization.Question, Localization.PlaylistDownload, Localization.Yes, Localization.No))
                                    {
                                        var playlist = await client.Playlists.GetAsync(urlType[SearchProcessing.QueryEnum.Playlist]);
                                        string newPlaylistName = await NormalPage.Instance.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, "OK", Localization.Cancel, Localization.NewPlaylist, -1, null, playlist.Title);
                                        playlistName = string.IsNullOrWhiteSpace(newPlaylistName) ? "" : newPlaylistName;
                                    }
                                }
                            }
                        }

                        if (playlistId == "")
                        {
                            DownloadProcessing.Add("", elems[0], elems[1], "");
                        }
                        else
                        {
                            foreach (var video in await client.Playlists.GetVideosAsync(playlistId))
                            {
                                DownloadProcessing.Add(video.Id, video.Title, video.Url, playlistName);
                            }
                        }
                    });

                return downloadClicked;
            }
        }
        #endregion
    }
}