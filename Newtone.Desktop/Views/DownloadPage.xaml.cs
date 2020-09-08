using Newtone.Core.Logic;
using Newtone.Desktop.ViewModels;
using System;
using System.Windows.Controls;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy DownloadPage.xaml
    /// </summary>
    public partial class DownloadPage : UserControl, ITimerContent
    {
        #region Properties
        private DownloadViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public DownloadPage()
        {
            InitializeComponent();
            ViewModel = DataContext as DownloadViewModel;
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick(downloadListView);
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
