﻿using Newtone.Desktop.Logic;
using Newtone.Desktop.ViewModels;
using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy NormalWindow.xaml
    /// </summary>
    public partial class NormalWindow : UserControl, IWindowContent
    {
        #region Properties
        private NormalViewModel ViewModel { get; set; }
        private Timer Timer { get; set; }
        #endregion
        #region Constructors
        public NormalWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = new NormalViewModel(new Button[] { topPanelTracksButton, topPanelArtistsButton, topPanelPlaylistsButton, topPanelSearchButton, topPanelSettingsButton }, this);
            Timer = new Timer
            {
                Interval = 200
            };
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
            //newtoneIcon.Source = ImageProcessing.FromArray(Properties.Resources.NewtoneIcon);
        }
        #endregion
        #region Private Methods
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke(() => {
                    ViewModel.SearchString = searchBox.Text;
                    ViewModel?.Tick(this, downloadButton);
                });
            }
            catch
            {
                //Ignore
            }
        }
        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && !string.IsNullOrEmpty(ViewModel.SearchString))
                {
                    TopPanelButton_Click(3, new SearchResultPage(ViewModel.SearchString));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void IconButton_Click(object sender, RoutedEventArgs e)
        {
            var menu = ContextMenuBuilder.BuildForIcon();
            menu.IsOpen = true;
        }

        #endregion
        #region Public Methods
        public void ChangeMaximizeIcon(ImageSource newSource)
        {
            ViewModel.MaximizeIcon = newSource;
        }
        public void SetContainer(UIElement element)
        {
            windowContainer.Children.Clear();
            windowContainer.Children.Add(element);
        }
        public void TopPanelButton_Click(int index, UIElement element)
        {
            SetContainer(element);
            ViewModel?.SelectTopPanelButton(index, this);
        }
        #endregion
    }
}
