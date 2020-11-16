using Newtone.Core.Logic;
using Newtone.Desktop.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ArtistPage.xaml
    /// </summary>
    public partial class ArtistPage : UserControl, ITimerContent
    {
        #region Properties
        private ArtistViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public ArtistPage()
        {
            InitializeComponent();

            ViewModel = DataContext as ArtistViewModel;
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
        private void ListView_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.ArtistListView_PreviewMouseRightButtonUp(listView);
        }

        private void ListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.ListView_SelectionChanged(listView);
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
    }
}
