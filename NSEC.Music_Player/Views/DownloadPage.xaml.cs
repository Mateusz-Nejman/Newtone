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

            foreach (string url in Global.Downloads.Keys)
            {
                Items.Add(new DownloadModel() { Name = Global.Downloads[url].Name, Url = url, Progress = Global.Downloads[url].Progress });
            }

            Device.StartTimer(TimeSpan.FromSeconds(0.5), Refresh);
        }

        private bool Refresh()
        {
            Items.Clear();
            foreach (string url in Global.Downloads.Keys)
            {
                Items.Add(new DownloadModel() { Name = Global.Downloads[url].Name, Url = url, Progress = Global.Downloads[url].Progress });
            }

            return true;
        }


    }
}