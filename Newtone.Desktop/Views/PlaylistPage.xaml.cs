using Newtone.Core.Logic;
using Newtone.Desktop.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Input;

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

        public void Appearing()
        {
            throw new NotImplementedException();
        }

        public void Disappearing()
        {
            throw new NotImplementedException();
        }
        #endregion

        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.ListView_SelectionChanged(listView);
        }

        private void ListView_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.PlaylistListView_PreviewMouseRightButtonUp(listView);
        }
    }
}
