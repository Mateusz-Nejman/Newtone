using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using Newtone.Desktop.Models;
using Newtone.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YoutubeExplode;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SearchResultPage.xaml
    /// </summary>
    public partial class SearchResultPage : UserControl
    {
        #region Properties
        private SearchResultViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public SearchResultPage(string searchedText)
        {
            InitializeComponent();
            DataContext = ViewModel = new SearchResultViewModel(searchedText, this);
        }
        #endregion
        #region Private Methods
        private void SearchListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.ListSelectedItem.Execute(searchListView);
        }
        #endregion
    }
}
