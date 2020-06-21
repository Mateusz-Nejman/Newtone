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
    /// Logika interakcji dla klasy InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow(string title, string message, string confirm)
        {
            InitializeComponent();
            DataContext = new InfoViewModel(this, title, message, confirm);
        }
    }
}
