using Newtone.Core.Logic;
using Newtone.Desktop.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy TrackPage.xaml
    /// </summary>
    public partial class TrackPage : UserControl, ITimerContent
    {
        #region Properties
        private TrackViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public TrackPage()
        {
            InitializeComponent();

            ViewModel = DataContext as TrackViewModel;
        }
        #endregion
        #region Private Methods
        private void TrackListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.SelectedItemLeft.Execute(trackListView);
        }

        private void TrackListView_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.SelectedItemRight.Execute(trackListView);
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick(trackListView);
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
