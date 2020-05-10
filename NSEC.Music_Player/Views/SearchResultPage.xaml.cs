using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultPage : ContentView
    {
        private ObservableCollection<SearchResultModel> Items { get; set; }
        private ObservableBridge<Newtone.Core.Models.SearchResultModel> RawItems { get; set; }
        public SearchResultPage(string searchedText)
        {
            InitializeComponent();

            searchListView.ItemsSource = Items = new ObservableCollection<SearchResultModel>();
            RawItems = new ObservableBridge<Newtone.Core.Models.SearchResultModel>
            {
                Action = model => Items.Add(new SearchResultModel(model))
            };

            Task.Run(async () =>
            {
                //ConsoleDebug.WriteLine("Start task");
                //Items.Clear();
                //RawItems.Clear();
                //ConsoleDebug.WriteLine("await");
                await SearchProcessing.Search(searchedText, RawItems);
                //ConsoleDebug.WriteLine("Searched");

                for (int a = 0; a < Items.Count; a++)
                {
                    using WebClient webClient = new WebClient();

                    byte[] data = webClient.DownloadData(Items[a].ThumbUrl);
                    //ConsoleDebug.WriteLine("Thumb for " + Items[a].Title + " " + (data == null || data.Length == 0 ? "null" : ""));
                    Items[a].Image = data;
                    Items[a].CheckChanges();
                }
            });
        }

        private void SearchListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if(index >= 0 && index < Items.Count)
            {
                var item = Items[index];

                if(string.IsNullOrEmpty(item.MixId))
                {
                    GlobalData.PlaylistPosition = index;
                    GlobalData.CurrentPlaylist.Clear();
                    GlobalData.PlaylistType = Newtone.Core.Media.MediaSource.SourceType.Web;
                    foreach(var _item in Items)
                    {
                        GlobalData.CurrentPlaylist.Add(new Newtone.Core.Media.MediaSource()
                        {
                            Artist = _item.Author,
                            Duration = _item.Duration,
                            FilePath = _item.Id,
                            Image = _item.Image,
                            Title = _item.Title,
                            Type = Newtone.Core.Media.MediaSource.SourceType.Web
                        });
                    }

                    GlobalData.MediaSource = GlobalData.CurrentPlaylist[index];
                    GlobalData.MediaPlayer.SetPlayerController(new WebPlayerController());
                    GlobalData.MediaPlayer.Load(GlobalData.MediaSource.FilePath);
                    MediaPlayerHelper.Play();
                }
                else
                {
                    GlobalData.PlaylistPosition = 0;
                    GlobalData.CurrentPlaylist.Clear();
                    GlobalData.PlaylistType = Newtone.Core.Media.MediaSource.SourceType.Web;

                    GlobalData.CurrentPlaylist.Add(new Newtone.Core.Media.MediaSource()
                    {
                        Artist = item.Author,
                        Duration = item.Duration,
                        FilePath = item.Id,
                        Image = item.Image,
                        Title = item.Title,
                        Type = Newtone.Core.Media.MediaSource.SourceType.Web
                    });


                    GlobalData.MediaSource = GlobalData.CurrentPlaylist[0];
                    GlobalData.MediaPlayer.SetPlayerController(new WebPlayerController());
                    GlobalData.MediaPlayer.Load(GlobalData.MediaSource.FilePath);
                    MediaPlayerHelper.Play();

                    Task.Run(async () =>
                    {
                        YoutubeClient youtubeClient = new YoutubeClient();
                        var playlist = await youtubeClient.Playlists.GetVideosAsync(item.MixId).BufferAsync(20);

                        using WebClient client = new WebClient();
                        foreach (var _item in playlist)
                        {
                            byte[] data = client.DownloadData(_item.Thumbnails.MediumResUrl);
                            GlobalData.CurrentPlaylist.Add(new Newtone.Core.Media.MediaSource()
                            {
                                Artist = _item.Author,
                                Duration = _item.Duration,
                                FilePath = _item.Id,
                                Image = data,
                                Title = _item.Title,
                                Type = Newtone.Core.Media.MediaSource.SourceType.Web
                            });
                        }
                    });
                }
                searchListView.SelectedItem = null;
            }
        }
    }
}