using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using Newtone.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SearchResultPage.xaml
    /// </summary>
    public partial class SearchResultPage : UserControl
    {
        private readonly ObservableCollection<SearchResultModel> Items;
        private readonly ObservableBridge<Newtone.Core.Models.SearchResultModel> RawItems;
        public SearchResultPage(string searchedText)
        {
            InitializeComponent();
            searchListView.ItemsSource = Items = new ObservableCollection<SearchResultModel>();
            RawItems = new ObservableBridge<Core.Models.SearchResultModel>
            {
                Action = item => Dispatcher.Invoke(() => Items.Add(new SearchResultModel(item)))
            };

            Task.Run(async() =>
            {
                //ConsoleDebug.WriteLine("Start task");
                //Items.Clear();
                //RawItems.Clear();
                //ConsoleDebug.WriteLine("await");
                await SearchProcessing.Search(searchedText, RawItems);
                //ConsoleDebug.WriteLine("Searched");

                for(int a = 0; a < Items.Count; a++)
                {
                    using WebClient webClient = new WebClient();

                    byte[] data = webClient.DownloadData(Items[a].ThumbUrl);
                    //ConsoleDebug.WriteLine("Thumb for " + Items[a].Title + " " + (data == null || data.Length == 0 ? "null" : ""));
                    Items[a].Image = data;
                }

                Dispatcher.Invoke(() => searchListView.Items.Refresh());
            });
        }

        private void SearchListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            /*int index = searchListView.SelectedIndex;

            if (index >= 0 && index < Items.Count)
            {
                SearchResultModel model = Items[index];

                string[] elems = model.VideoData.Split(GlobalData.SEPARATOR);
                var validators = SearchProcessing.CheckLink(elems[1]);

                if(validators.ContainsKey(SearchProcessing.QueryEnum.Playlist))
                {
                    GlobalData.CurrentPlaylist.Clear();
                    GlobalData.PlaylistPosition = index;

                    foreach (var item in Items)
                    {
                        GlobalData.CurrentPlaylist.Add(item);
                    }

                    
                }
                else
                {
                    YoutubeClient client = new YoutubeClient();

                    GlobalData.CurrentPlaylist.Clear();
                    GlobalData.PlaylistPosition = 0;
                    foreach(var video in await client.Playlists.GetVideosAsync(model.MixId).BufferAsync(40))
                    {
                        GlobalData.CurrentPlaylist.Add((Core.Models.SearchResultModel)video);
                    }
                }
                MediaSource source = GlobalData.CurrentPlaylist[GlobalData.PlaylistPosition];

                GlobalData.MediaPlayer.Stop();
                GlobalData.MediaPlayer.Reset();
                GlobalData.MediaPlayer.Load(source.FilePath);
                GlobalData.MediaPlayer.Play();
            }
            searchListView.SelectedItem = null;*/
        }
    }
}
