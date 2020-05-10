using Newtone.Core;
using Newtone.Core.Models;
using Newtone.Core.Processing;
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
        public SearchResultDataTemplate()
        {
            InitializeComponent();
        }

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
                    AlertWindow answer = new AlertWindow("Pytanie", "Pobrać utwór czy całą playlistę?", "Utwór", "Playlista")
                    {
                        Owner = MainWindow.Instance
                    };
                    answer.Left = MainWindow.Instance.CalculateSubWindowPosition(answer.Width, answer.Height)[0];
                    answer.Top = MainWindow.Instance.CalculateSubWindowPosition(answer.Width, answer.Height)[1];

                    if (answer.ShowDialog() == true)
                    {
                        playlistId = "";
                    }
                    else
                    {
                        playlistId = urlType[SearchProcessing.QueryEnum.Playlist];
                        AlertWindow alert = new AlertWindow("Pytanie", "Czy chcesz pobrać playlistę?")
                        {
                            Owner = MainWindow.Instance
                        };
                        alert.Left = MainWindow.Instance.CalculateSubWindowPosition(alert.Width, alert.Height)[0];
                        alert.Top = MainWindow.Instance.CalculateSubWindowPosition(alert.Width, alert.Height)[1];
                        bool toPlaylist = alert.ShowDialog() == true;

                        if(toPlaylist)
                        {
                            var playlist = await client.Playlists.GetAsync(urlType[SearchProcessing.QueryEnum.Playlist]);
                            PromptWindow prompt = new PromptWindow("Nazwa playlisty", playlist.Title)
                            {
                                Owner = MainWindow.Instance
                            };
                            prompt.Left = MainWindow.Instance.CalculateSubWindowPosition(prompt.Width, prompt.Height)[0];
                            prompt.Top = MainWindow.Instance.CalculateSubWindowPosition(prompt.Width, prompt.Height)[1];
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
            }
        }
    }
}
