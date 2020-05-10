using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
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
    public partial class DownloadPage : ContentView, ITimerContent
    {
        private ObservableCollection<DownloadModel> Items { get; set; }
        public DownloadPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<DownloadModel>();
            downloadListView.ItemsSource = Items;
        }

        public void Tick()
        {
            if (Items.Count != DownloadProcessing.GetDownloads().Count)
            {
                Items.Clear();
                foreach (var item in DownloadProcessing.GetModels())
                    Items.Add(item);
            }

            for (int a = 0; a < Items.Count; a++)
            {
                Items[a].Progress = DownloadProcessing.GetDownloads()[Items[a].Id].Progress;
                //ConsoleDebug.WriteLine(Items[a].Progress);
            }
        }
    }
}