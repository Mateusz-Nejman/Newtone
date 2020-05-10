using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy DownloadPage.xaml
    /// </summary>
    public partial class DownloadPage : UserControl, ITimerContent
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
            if(Items.Count != DownloadProcessing.GetDownloads().Count)
            {
                Items.Clear();
                foreach (var item in DownloadProcessing.GetModels())
                    Items.Add(item);
            }

            for(int a = 0; a < Items.Count; a++)
            {
                Items[a].Progress = DownloadProcessing.GetDownloads()[Items[a].Id].Progress;
                //ConsoleDebug.WriteLine(Items[a].Progress);
            }

            downloadListView.Items.Refresh();
        }
    }
}
