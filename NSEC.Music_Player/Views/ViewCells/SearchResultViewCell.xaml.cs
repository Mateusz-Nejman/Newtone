using Newtone.Core;
using Newtone.Core.Processing;
using Newtone.Core.Languages;
using NSEC.Music_Player.Views.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;

namespace NSEC.Music_Player.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultViewCell : ViewCell
    {
        public SearchResultViewCell()
        {
            InitializeComponent();
        }

        private async void DownloadButton_Clicked(object sender, EventArgs e)
        {
            string tag = ((CustomImageButton)sender).Tag;

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
                            string newPlaylistName = await NormalPage.Instance.DisplayPromptAsync(Localization.NewPlaylist,Localization.NewPlaylistHint,"OK",Localization.Cancel,Localization.NewPlaylist,-1,null,playlist.Title);
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
        }
    }
}