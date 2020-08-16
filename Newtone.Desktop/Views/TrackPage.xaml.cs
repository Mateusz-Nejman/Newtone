using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Models;
using Newtone.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
