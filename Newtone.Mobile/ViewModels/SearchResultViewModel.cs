using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Mobile.Media;
using Newtone.Mobile.Processing;
using Newtone.Mobile.Views;
using Xamarin.Forms;
using YoutubeExplode;

namespace Newtone.Mobile.ViewModels
{
    public class SearchResultViewModel : PropertyChangedBase
    {
        #region Fields
        private ObservableCollection<Models.SearchResultModel> items;
        private readonly ObservableBridge<Newtone.Core.Models.SearchResultModel> rawItems;
        private int currentPage = 1;
        private bool pageLoaded = false;
        private readonly string searchedText;
        private bool spinnerVisible = false;
        #endregion

        #region Properties
        public ObservableCollection<Models.SearchResultModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public bool SpinnerVisible
        {
            get => spinnerVisible;
            set
            {
                spinnerVisible = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Constructors
        public SearchResultViewModel(string searchedText)
        {
            this.searchedText = searchedText;
            Items = new ObservableCollection<Models.SearchResultModel>();
            rawItems = new ObservableBridge<Newtone.Core.Models.SearchResultModel>
            {
                Action = model => Items.Add(new Models.SearchResultModel(model))
            };

            Task.Run(async () =>
            {
                SpinnerVisible = true;
                SearchProcessing.SearchOffline(searchedText, rawItems);

                if(MainActivity.IsInternet())
                    await SearchProcessing.Search(searchedText, rawItems);

                using (WebClient webClient = new WebClient())
                {
                    for (int a = 0; a < Items.Count; a++)
                    {
                        if (!string.IsNullOrEmpty(Items[a].ThumbUrl))
                        {
                            byte[] data = webClient.DownloadData(Items[a].ThumbUrl);
                            Items[a].Image = data;
                        }
                        else
                        {
                            Items[a].Thumb = ImageProcessing.FromArray(Items[a].Image);
                        }
                        Items[a].CheckChanges();
                    }

                    pageLoaded = true;
                }

                SpinnerVisible = false;
            });
        }
        #endregion
        #region Public Methods
        public async Task Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                var item = Items[index];
                GlobalData.Current.CurrentPlaylist.Clear();

                if (string.IsNullOrEmpty(item.MixId))
                {
                    GlobalData.Current.PlaylistPosition = e.SelectedItemIndex;

                    foreach (var _item in Items)
                    {
                        GlobalData.Current.CurrentPlaylist.Add(new Newtone.Core.Media.MediaSource()
                        {
                            Artist = _item.Author,
                            Duration = _item.Duration,
                            FilePath = _item.Id,
                            Image = _item.Image,
                            Title = _item.Title,
                            Type = Newtone.Core.Media.MediaSource.SourceType.Web
                        });
                    }

                    GlobalData.Current.MediaSource = GlobalData.Current.CurrentPlaylist[e.SelectedItemIndex];
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

                await NormalPage.NavigationInstance.PushModalAsync(new FullScreenPage());


                new Task(() =>
                {
                    GlobalData.Current.MediaPlayer.Load(GlobalData.Current.MediaSource.FilePath);
                    MediaPlayerHelper.Play();

                    if (!string.IsNullOrEmpty(item.MixId))
                    {
                        new Task(async () =>
                        {
                        YoutubeClient youtubeClient = new YoutubeClient();
                        var playlist = await youtubeClient.Playlists.GetVideosAsync(item.MixId).BufferAsync(20);

                            if (playlist.Count > 0)
                            {
                                using (WebClient client = new WebClient())
                                {
                                    GlobalData.Current.CurrentPlaylist.Clear();
                                    GlobalData.Current.PlaylistPosition = 0;
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
                                }
                            }
                        }).Start();
                    }
                }).Start();


                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }

        public void SearchListView_ItemAppearing(int itemIndex)
        {
            if(pageLoaded)
            {
                if(itemIndex == Items.Count - 1)
                {
                    pageLoaded = false;
                    currentPage++;

                    Task.Run(async () =>
                    {
                        SpinnerVisible = true;
                        if (MainActivity.IsInternet())
                            await SearchProcessing.Search(searchedText, rawItems, currentPage);

                        using (WebClient webClient = new WebClient())
                        {
                            for (int a = 0; a < Items.Count; a++)
                            {
                                if (!string.IsNullOrEmpty(Items[a].ThumbUrl))
                                {
                                    byte[] data = webClient.DownloadData(Items[a].ThumbUrl);
                                    Items[a].Image = data;
                                }
                                else
                                {
                                    Items[a].Thumb = ImageProcessing.FromArray(Items[a].Image);
                                }
                                Items[a].CheckChanges();
                            }

                            pageLoaded = true;
                        }

                        SpinnerVisible = false;
                    });
                }
            }
        }
        #endregion
    }
}