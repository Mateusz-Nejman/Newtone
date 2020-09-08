using Newtone.Desktop.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

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
