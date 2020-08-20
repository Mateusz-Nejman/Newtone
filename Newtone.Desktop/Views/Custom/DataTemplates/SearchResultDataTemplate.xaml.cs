using Newtone.Core;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Desktop.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YoutubeExplode;

namespace Newtone.Desktop.Views.Custom.DataTemplates
{
    /// <summary>
    /// Logika interakcji dla klasy SearchResultDataTemplate.xaml
    /// </summary>
    public partial class SearchResultDataTemplate : UserControl
    {
        #region Constructors
        public SearchResultDataTemplate()
        {
            InitializeComponent();
        }
        #endregion
        #region Private Methods
        private async void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            TagButton button = (TagButton)sender;
            string[] elems = button.Value.Split(GlobalData.SEPARATOR);
            YoutubeClient client = new YoutubeClient();
            string playlistId = "";
            string playlistName = "";
            var urlType = SearchProcessing.CheckLink(elems[1]);

            if(urlType.ContainsKey(SearchProcessing.QueryEnum.Playlist))
            {
                if(urlType.ContainsKey(SearchProcessing.QueryEnum.Video))
                {
                    AlertWindow answer = new AlertWindow(Newtone.Core.Languages.Localization.Question, Core.Languages.Localization.PlaylistOrTrack, Core.Languages.Localization.Track, Core.Languages.Localization.Playlist);
                    answer.CenterToMainWindow();

                    if (answer.ShowDialog() == true)
                    {
                        playlistId = "";
                    }
                    else
                    {
                        playlistId = urlType[SearchProcessing.QueryEnum.Playlist];
                        AlertWindow alert = new AlertWindow(Core.Languages.Localization.Question, Core.Languages.Localization.PlaylistDownload, Newtone.Core.Languages.Localization.Yes, Newtone.Core.Languages.Localization.No);
                        alert.CenterToMainWindow();
                        bool toPlaylist = alert.ShowDialog() == true;

                        if(toPlaylist)
                        {
                            var playlist = await client.Playlists.GetAsync(urlType[SearchProcessing.QueryEnum.Playlist]);
                            PromptWindow prompt = new PromptWindow(Core.Languages.Localization.NewPlaylist, playlist.Title);
                            prompt.CenterToMainWindow();
                            prompt.ShowDialog();
                            string newPlaylistName = prompt.Value;
                            playlistName = string.IsNullOrWhiteSpace(newPlaylistName) ? "" : newPlaylistName;
                        }
                    }
                }
            }

            if(playlistId == "")
            {
                DownloadProcessing.Add("", elems[0], elems[1], "");
            }
            else
            {
                foreach(var video in await client.Playlists.GetVideosAsync(playlistId))
                {
                    DownloadProcessing.Add(video.Id, video.Title, video.Url, playlistName);
                }
                //DownloadProcessing.ForceStartDownloadingTask();
            }
        }
        #endregion
    }
}
