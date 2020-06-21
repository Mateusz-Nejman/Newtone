using Microsoft.Win32;
using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Desktop.Logic;
using Newtone.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
