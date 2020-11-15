using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Mobile.UI.Processing;
using Newtone.Mobile.UI.Views;
using Newtone.Mobile.UI.Views.TV.ViewCells;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.ViewModels
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
        private int maxItems;
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

        public ObservableCollection<NListViewItem> ListItems { get; private set; }
        public Func<NListViewItem, View> ItemTemplate => item => new SearchResultViewCell(item);
        #endregion
        #region Commands
        private ICommand itemAppearingCommand;
        public ICommand ItemAppearing
        {
            get
            {
                if (itemAppearingCommand == null)
                    itemAppearingCommand = new ActionCommand(parameter =>
                    {
                        int itemIndex = (int)parameter;

                        if (pageLoaded && itemIndex == Items.Count - 1 && (maxItems == -1 || Items.Count < maxItems))
                        {
                            pageLoaded = false;
                            currentPage++;

                            Task.Run(async () =>
                            {
                                SpinnerVisible = true;
                                if (Global.Application.HasInternet())
                                    maxItems = await SearchProcessing.Search(searchedText, rawItems, currentPage);

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
                    });

                return itemAppearingCommand;
            }
        }
        #endregion
        #region Constructors
        public SearchResultViewModel(string searchedText)
        {
            this.searchedText = searchedText;
            Items = new ObservableCollection<Models.SearchResultModel>();
            ListItems = new ObservableCollection<NListViewItem>();

            rawItems = new ObservableBridge<Newtone.Core.Models.SearchResultModel>
            {
                Action = model =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Items.Add(new Models.SearchResultModel(model));
                        ListItems.Add(Items[^1]);
                    });
                }
            };

            Task.Run(async () =>
            {
                Console.WriteLine("Task.Run start");
                SpinnerVisible = true;
                SearchProcessing.SearchOffline(searchedText, rawItems);

                if (Global.Application.HasInternet())
                    maxItems = await SearchProcessing.Search(searchedText, rawItems);

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
                            if (Items[a].Image == null || Items[a].Image.Length > 0)
                                Items[a].Thumb = ImageProcessing.FromArray(Items[a].Image);
                            else
                                Items[a].Thumb = ImageSource.FromFile("EmptyTrack.png");
                        }
                        Items[a].CheckChanges();

                        Device.BeginInvokeOnMainThread(() =>
                        {
                            if(a < Items.Count)
                            {
                                ListItems[a] = Items[a];
                            }
                        });
                    }

                    pageLoaded = true;
                }

                SpinnerVisible = false;
                Console.WriteLine("Task.Run end");
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
                            Type = _item.Id.Length == 11 ? Newtone.Core.Media.MediaSource.SourceType.Web : Core.Media.MediaSource.SourceType.Local
                        });
                    }

                    GlobalData.Current.MediaSource = GlobalData.Current.CurrentPlaylist[e.SelectedItemIndex];

                    GlobalData.Current.MediaPlayer.LoadPlaylist(() =>
                    {
                        List<Core.Media.MediaSource> newPlaylist = Items.Select(_item => new Core.Media.MediaSource()
                        {
                            Artist = _item.Author,
                            Duration = _item.Duration,
                            FilePath = _item.Id,
                            Image = _item.Image,
                            Title = _item.Title,
                            Type = _item.Id.Length == 11 ? Newtone.Core.Media.MediaSource.SourceType.Web : Core.Media.MediaSource.SourceType.Local
                        }).ToList();

                        return newPlaylist;
                    }, index, true, true);
                }
                else
                {
                    GlobalData.Current.MediaPlayer.LoadPlaylist(item.MixId, 0, new Newtone.Core.Media.MediaSource()
                    {
                        Artist = item.Author,
                        Duration = item.Duration,
                        FilePath = item.Id,
                        Image = item.Image,
                        Title = item.Title,
                        Type = Newtone.Core.Media.MediaSource.SourceType.Web
                    }, true, true);
                }

                await Global.NavigationInstance.PushModalAsync(new FullScreenPage());

                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }

        public void SearchListView_ItemAppearing(int itemIndex)
        {
            ItemAppearing.Execute(itemIndex);
        }
        #endregion
    }
}
