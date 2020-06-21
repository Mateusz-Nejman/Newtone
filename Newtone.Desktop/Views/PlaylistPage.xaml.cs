using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Desktop.Logic;
using Newtone.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PlaylistPage.xaml
    /// </summary>
    public partial class PlaylistPage : UserControl, ITimerContent
    {
        #region Properties
        private PlaylistViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public PlaylistPage()
        {
            InitializeComponent();
            ViewModel = DataContext as PlaylistViewModel;
        }
        #endregion
        #region Private Methods
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel?.ListView_SelectionChanged(listView, e);
        }
        private void TrackListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.TrackListView_PreviewMouseLeftButtonUp(listView, trackListView);
        }

        private void TrackListView_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.TrackListView_PreviewMouseRightButtonUp(listView, trackListView);
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick(listView, trackListView);
        }
        #endregion
    }
}
