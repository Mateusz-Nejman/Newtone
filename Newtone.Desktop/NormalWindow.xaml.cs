using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Newtone.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy NormalWindow.xaml
    /// </summary>
    public partial class NormalWindow : UserControl
    {
        private readonly Button[] topPanelButtons;
        private Timer Timer { get; set; }
        private int CurrentTopPanelButtonIndex = 0;
        public NormalWindow()
        {
            InitializeComponent();

            topPanelButtons = new Button[] { topPanelTracksButton, topPanelArtistsButton, topPanelPlaylistsButton, topPanelSearchButton };
            TopPanelButton_Click(CurrentTopPanelButtonIndex);
            windowContainer.Children.Clear();
            windowContainer.Children.Add(new TrackPage());
            Timer = new Timer
            {
                Interval = 500
            };
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() => {
                badgeButton.BadgeCount = DownloadProcessing.BadgeCount;
                if (windowContainer.Children.Count > 0 && windowContainer.Children[0] is ITimerContent)
                {
                    ((ITimerContent)windowContainer.Children[0]).Tick();
                }
            });

        }

        private void TopPanelButton_Click(int index)
        {
            for (int a = 0; a < topPanelButtons.Length; a++)
            {
                topPanelButtons[a].Style = FindResource("TopPanelButton") as Style;
            }
            if (index >= 0)
                topPanelButtons[index].Style = FindResource("TopPanelButtonSelected") as Style;
            CurrentTopPanelButtonIndex = index;
        }

        private void TopPanelTracksButton_Click(object sender, RoutedEventArgs e)
        {

            if (CurrentTopPanelButtonIndex != 0)
            {
                //ConsoleDebug.WriteLine("Tracks");
                windowContainer.Children.Clear();
                windowContainer.Children.Add(new TrackPage());
            }
            TopPanelButton_Click(0);
        }

        private void TopPanelArtistsButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTopPanelButtonIndex != 1)
            {
                windowContainer.Children.Clear();
                windowContainer.Children.Add(new ArtistPage());
            }

            TopPanelButton_Click(1);
        }

        private void TopPanelPlaylistsButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTopPanelButtonIndex != 2)
            {
                windowContainer.Children.Clear();
                windowContainer.Children.Add(new PlaylistPage());
            }

            TopPanelButton_Click(2);
        }

        private void TopPanelSearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(searchBox.Text))
            {
                if (CurrentTopPanelButtonIndex != 3)
                {
                    //ConsoleDebug.WriteLine("Settings");
                    windowContainer.Children.Clear();
                    windowContainer.Children.Add(new SearchResultPage(searchBox.Text));
                }
                TopPanelButton_Click(3);
            }

        }

        private void TopPanelSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            TopPanelButton_Click(4);
        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(searchBox.Text))
            {
                windowContainer.Children.Clear();
                windowContainer.Children.Add(new SearchResultPage(searchBox.Text));
                TopPanelButton_Click(3);
            }
        }

        private void BadgeButton_Click(object sender, RoutedEventArgs e)
        {
            TopPanelButton_Click(-1);
            windowContainer.Children.Clear();
            windowContainer.Children.Add(new DownloadPage());
        }
    }
}
