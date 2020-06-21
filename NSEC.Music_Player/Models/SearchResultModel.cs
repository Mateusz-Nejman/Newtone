using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using NSEC.Music_Player.Processing;
using NSEC.Music_Player.Views;
using Xamarin.Forms;
using YoutubeExplode;

namespace NSEC.Music_Player.Models
{
    public class SearchResultModel : Newtone.Core.Models.SearchResultModel
    {
        #region Fields
        private ImageSource thumb;
        #endregion

        #region Properties
        public ImageSource Thumb
        {
            get
            {
                if (thumb == null && Image != null)
                {
                    thumb = ImageProcessing.FromArray(Image);
                    OnPropertyChanged();
                }
                return thumb;
            }
            set
            {
                if (thumb != value)
                {
                    thumb = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region Commands
        private ICommand downloadClicked;
        public ICommand DownloadClicked
        {
            get
            {
                if (downloadClicked == null)
                    downloadClicked = new ActionCommand(async (parameter) =>
                    {
                        string tag = parameter as string;
                        ConsoleDebug.WriteLine("downloadClicked");

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
            set => downloadClicked = value;
        }
        #endregion
        #region Constructors
        public SearchResultModel(Newtone.Core.Models.SearchResultModel model)
        {
            this.Author = model.Author;
            this.Duration = model.Duration;
            this.Id = model.Id;
            this.Image = model.Image;
            this.MixId = model.MixId;
            this.ThumbUrl = model.ThumbUrl;
            this.Title = model.Title;
            this.VideoData = model.VideoData;
        }
        #endregion
        #region Public Methods
        public void CheckChanges()
        {
            var thumb = Thumb;
            thumb.GetType(); //WTF
        }
        #endregion
    }
}