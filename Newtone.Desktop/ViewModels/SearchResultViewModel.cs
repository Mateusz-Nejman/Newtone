using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using YoutubeExplode;

namespace Newtone.Desktop.ViewModels
{
    public class SearchResultViewModel:PropertyChangedBase
    {
        #region Fields
        private ObservableCollection<Newtone.Desktop.Models.SearchResultModel> items;
        private ObservableBridge<Newtone.Core.Models.SearchResultModel> rawItems;
        #endregion
        #region Properties
        public ObservableCollection<Newtone.Desktop.Models.SearchResultModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }
        public ObservableBridge<Newtone.Core.Models.SearchResultModel> RawItems
        {
            get => rawItems;
            set
            {
                rawItems = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand listSelectedItem;
        public ICommand ListSelectedItem
        {
            get
            {
                if (listSelectedItem == null)
                    listSelectedItem = new ActionCommand(parameter =>
                    {
                        var searchListView = parameter as ListView;
                        int index = searchListView.SelectedIndex;

                        if (index >= 0 && index < Items.Count)
                        {
                            var item = Items[index];
                            GlobalData.Current.CurrentPlaylist.Clear();
                            GlobalData.Current.PlaylistType = item.IsOffline ? Core.Media.MediaSource.SourceType.Local : Core.Media.MediaSource.SourceType.Web;

                            if (string.IsNullOrEmpty(item.MixId))
                            {
                                GlobalData.Current.PlaylistPosition = index;

                                foreach (var _item in Items)
                                {
                                    GlobalData.Current.CurrentPlaylist.Add(new Newtone.Core.Media.MediaSource()
                                    {
                                        Artist = _item.Author,
                                        Duration = _item.Duration,
                                        FilePath = _item.Id,
                                        Image = _item.Image,
                                        Title = _item.Title,
                                        Type = _item.IsOffline ? Core.Media.MediaSource.SourceType.Local : Core.Media.MediaSource.SourceType.Web
                                    });
                                }

                                GlobalData.Current.MediaSource = GlobalData.Current.CurrentPlaylist[index];
                            }
                            else
                            {
                                GlobalData.Current.PlaylistPosition = 0;

                                GlobalData.Current.CurrentPlaylist.Add(new Newtone.Core.Media.MediaSource()
                                {
                                    Artist = item.Author,
                                    Duration = item.Duration,
                                    FilePath = item.Id,
                                    Image = item.Image,
                                    Title = item.Title,
                                    Type = Newtone.Core.Media.MediaSource.SourceType.Web
                                });

                                GlobalData.Current.MediaSource = GlobalData.Current.CurrentPlaylist[0];
                            }

                            //await NormalPage.NavigationInstance.PushModalAsync(new FullScreenPage());


                            new Task(() =>
                            {
                                //MobileMediaPlayer.EntityClicked = true;
                                GlobalData.Current.MediaPlayer.Load(GlobalData.Current.MediaSource.FilePath);
                                GlobalData.Current.MediaPlayer.Play();
                                //MediaPlayerHelper.Play();

                                if (!string.IsNullOrEmpty(item.MixId))
                                {
                                    new Task(async () =>
                                    {
                                        YoutubeClient youtubeClient = new YoutubeClient();
                                        var playlist = await youtubeClient.Playlists.GetVideosAsync(item.MixId).BufferAsync(20);

                                        using WebClient client = new WebClient();
                                        foreach (var _item in playlist)
                                        {
                                            byte[] data = client.DownloadData(_item.Thumbnails.MediumResUrl);
                                            GlobalData.Current.CurrentPlaylist.Add(new Newtone.Core.Media.MediaSource()
                                            {
                                                Artist = _item.Author,
                                                Duration = _item.Duration,
                                                FilePath = _item.Id,
                                                Image = data,
                                                Title = _item.Title,
                                                Type = Newtone.Core.Media.MediaSource.SourceType.Web
                                            });
                                        }
                                    }).Start();
                                }
                            }).Start();


                            searchListView.SelectedItem = null;
                        }
                    });
                return listSelectedItem;
            }
        }
        #endregion
        #region Constructors
        public SearchResultViewModel(string searchedText, SearchResultPage page)
        {
            Items = new ObservableCollection<Models.SearchResultModel>();
            RawItems = new ObservableBridge<Core.Models.SearchResultModel>
            {
                Action = item => MainWindow.MainDispatcher.Invoke(() => Items.Add(new Models.SearchResultModel(item)))
            };

            Task.Run(async () =>
            {
                //ConsoleDebug.WriteLine("Start task");
                //Items.Clear();
                //RawItems.Clear();
                //ConsoleDebug.WriteLine("await");
                SearchProcessing.SearchOffline(searchedText, RawItems);
                await SearchProcessing.Search(searchedText, RawItems);
                //ConsoleDebug.WriteLine("Searched");

                for (int a = 0; a < Items.Count; a++)
                {
                    using WebClient webClient = new WebClient();

                    if (!string.IsNullOrEmpty(Items[a].ThumbUrl))
                    {
                        byte[] data = webClient.DownloadData(Items[a].ThumbUrl);
                        //ConsoleDebug.WriteLine("Thumb for " + Items[a].Title + " " + (data == null || data.Length == 0 ? "null" : ""));
                        Items[a].Image = data;
                    }
                    else
                    {
                        Items[a].OnPropertyChanged("Thumb");
                    }
                }

                MainWindow.MainDispatcher.Invoke(() => page.searchListView.Items.Refresh());
            });
        }
        #endregion
    }
}
