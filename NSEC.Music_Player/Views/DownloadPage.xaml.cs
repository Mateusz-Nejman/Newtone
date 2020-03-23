using NSEC.Music_Player.Models;
using NSEC.Music_Player.Processing;
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
        private ObservableCollection<DownloadListModel> Items { get; set; }
        private bool stopTimer = false;
        public DownloadPage()
        {
            InitializeComponent();
            downloadList.ItemsSource = Items = new ObservableCollection<DownloadListModel>();
            Device.StartTimer(TimeSpan.FromSeconds(0.5), Refresh);
            Disappearing += DownloadPage_Disappearing;
        }

        private void DownloadPage_Disappearing(object sender, EventArgs e)
        {
            stopTimer = true;
        }

        private bool Refresh()
        {
            downloadLabel.IsVisible = DownloadProcessing.GetDownloads().Count == 0;

            foreach (DownloadListModel model in DownloadProcessing.GetDownloads().Values.ToList())
            {
                if(Items.Contains(model))
                {
                    int index = Items.IndexOf(model);
                    Items[index].Progress = model.Progress;
                }
                else
                    Items.Add(model);
            }

            return !stopTimer;
        }
    }
}