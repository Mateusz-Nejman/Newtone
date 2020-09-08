using Newtone.Desktop.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        #region Properties
        private SettingsViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public SettingsPage()
        {
            InitializeComponent();
            ViewModel = DataContext as SettingsViewModel;
        }
        #endregion
        #region Private Methods
        private void SearchListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.SelectedItem.Execute(settingsListView);
        }
        #endregion
    }
}
