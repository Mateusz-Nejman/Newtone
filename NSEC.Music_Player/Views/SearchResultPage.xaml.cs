using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Processing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultPage : ContentPage
    {
        private ObservableCollection<SearchResultModel> Items { get; set; }
        private bool stopTimer = false;
        public SearchResultPage(string searchText)
        {
            InitializeComponent();
            searchResultView.ItemsSource = Items = new ObservableCollection<SearchResultModel>();
            titleView.Title = searchText;
            Disappearing += SearchResultPage_Disappearing;

            Device.StartTimer(TimeSpan.FromMilliseconds(300), Refresh);

            Task.Run(async () => 
            {
                Items.Clear();
                await DownloadProcessing.GetDownloadInterface("https://youtube.com").Search(searchText, Items);
                using WebClient webClient = new WebClient();
                for (int a = 0; a < Items.Count; a++)
                {
                    try
                    {
                        byte[] data = webClient.DownloadData(Items[a].ThumbUrl);
                        Items[a].Picture = ImageSource.FromStream(() => new MemoryStream(data));
                        Items[a].ImageData = data;
                    }
                    catch
                    {

                    }
                }
            });
        }

        private void SearchResultPage_Disappearing(object sender, EventArgs e)
        {
            stopTimer = true;
        }

        private bool Refresh()
        {
            searchLabel.IsVisible = Items.Count == 0;
            return !stopTimer;
        }
        private void SearchResultView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                SearchResultModel model = Items[e.SelectedItemIndex];

                if(model.MixId == null || model.MixId == "")
                {
                    MediaSource source = new MediaSource()
                    {
                        Artist = model.Author,
                        Duration = model.Duration,
                        ImageSource = model.Picture,
                        Picture = model.ImageData,
                        Title = model.Title,
                        Type = MediaSource.SourceType.Web,
                        FilePath = model.Id

                    };
                    Global.PlaylistType = MediaSource.SourceType.Web;
                    Console.WriteLine("Play " + model.Title);
                    Navigation.PushAsync(new StreamPlayerPage(source, Items.ToList(), e.SelectedItemIndex));
                }
                else
                {
                    Global.PlaylistType = MediaSource.SourceType.Web;
                    Console.WriteLine("Play " + model.Title);
                    Navigation.PushAsync(new StreamPlayerPage(model));
                }
               

                searchResultView.SelectedItem = null;

            }
            
        }
    }
}