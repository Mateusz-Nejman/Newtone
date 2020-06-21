using Newtone.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PromptWindow.xaml
    /// </summary>
    public partial class PromptWindow : Window
    {
        #region Properties
        private PromptViewModel ViewModel { get; set; }
        public string Value
        {
            get => ViewModel?.Value;
        }
        #endregion
        #region Constructors
        public PromptWindow(string title, string defaultValue, string confirmText = "Tak", string cancelText = "Nie")
        {
            InitializeComponent();
            DataContext = ViewModel = new PromptViewModel(title, confirmText, cancelText, defaultValue);
        }
        #endregion
    }
}
