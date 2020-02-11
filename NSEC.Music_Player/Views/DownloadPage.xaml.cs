using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DownloadPage : ContentPage
    {
        public ObservableCollection<DownloadModel> Items;
        public DownloadPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<DownloadModel>();
            TrackListView.ItemsSource = Items;

            foreach (string id in DownloadProcessing.GetDownloads().Keys)
            {
                DownloadModel model = DownloadProcessing.GetDownloads()[id];
                Items.Add(new DownloadModel() { Name = model.Name, Url = model.Url, Progress = model.Progress });
            }

            Device.StartTimer(TimeSpan.FromSeconds(0.5), Refresh);
        }

        private bool Refresh()
        {
            Items.Clear();
            foreach (string id in DownloadProcessing.GetDownloads().Keys)
            {
                DownloadModel model = DownloadProcessing.GetDownloads()[id];
                Items.Add(new DownloadModel() { Name = model.Name, Url = model.Url, Progress = model.Progress });
            }

            return true;
        } 
    }
}