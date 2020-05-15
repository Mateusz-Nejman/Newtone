using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Models;
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
    /// Logika interakcji dla klasy SyncPage.xaml
    /// </summary>
    public partial class SyncPage : UserControl, ITimerContent
    {
        private ObservableCollection<TrackModel> Items { get; set; }
        public SyncPage()
        {
            InitializeComponent();
            syncListView.ItemsSource = Items = new ObservableCollection<TrackModel>();
            SyncProcessing.ListenReceiver();
        }

        public void Tick()
        {
            deviceCode.IsEnabled = SyncProcessing.CurrentConnection == null || !SyncProcessing.CurrentConnection.Connected;
            connectButton.IsEnabled = SyncProcessing.CurrentConnection == null || !SyncProcessing.CurrentConnection.Connected;
            sendButton.IsEnabled = SyncProcessing.Audios.Count > 0 && !SyncProcessing.Started;
            receiveButton.IsEnabled = !SyncProcessing.Started;
            
            if (SyncProcessing.State == 0)
                progressText.Text = SyncProcessing.Progress == 0 ? "" : $"{Math.Round(SyncProcessing.Progress, 2)}MB / {Math.Round(SyncProcessing.Size, 2)}MB";
            else if (SyncProcessing.State == 1)
            {
                progressText.Text = $"{SyncProcessing.CurrentFileReceived} / {SyncProcessing.FilesReceived}";
                fileText.Text = SyncProcessing.CurrentFileName;
            }
            else if (SyncProcessing.State == 2)
            {
                progressText.Text = Core.Languages.Localization.Ready;
                fileText.Text = "";
            }

            receiveGrid.Visibility = SyncProcessing.SocketMode == 1 ? Visibility.Visible : Visibility.Hidden;
            syncListView.Visibility = SyncProcessing.SocketMode == 0 ? Visibility.Visible : Visibility.Hidden;
            sendGrid.Visibility = SyncProcessing.SocketMode == 2 ? Visibility.Visible : Visibility.Hidden;

            if (SyncProcessing.SocketMode == 2)
                sendProgressText.Text = $"{Math.Round(SyncProcessing.Progress, 2)}% ";

            if (Items.Count != SyncProcessing.Audios.Count)
            {
                Items.Clear();
                foreach (var item in SyncProcessing.Audios)
                    Items.Add(new TrackModel(GlobalData.Audios[item]));

                syncListView.Items.Refresh();
            }

            foreach (var item in Items)
                item.CheckChanges();
        }

        private void SyncListView_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            int index = syncListView.SelectedIndex;

            if(index >= 0 && index < Items.Count)
            {
                var menu = ContextMenuBuilder.BuildForSync(Items[index].FilePath);
                menu.PlacementTarget = (UIElement)sender;
                menu.IsOpen = true;
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(deviceCode.Text))
            {
                SyncProcessing.Connect(deviceCode.Text);
            }
        }

        private void ReceiveButton_Click(object sender, RoutedEventArgs e)
        {
            SyncProcessing.Receive();
            
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SyncProcessing.Send();
        }
    }
}
