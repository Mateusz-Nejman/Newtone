using Newtone.Desktop.ViewModels;
using System.Windows;

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
