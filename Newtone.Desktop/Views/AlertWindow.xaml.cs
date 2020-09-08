using Newtone.Desktop.ViewModels;
using System.Windows;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PromptWindow.xaml
    /// </summary>
    public partial class AlertWindow : Window
    {
        #region Constructors
        public AlertWindow(string title, string message, string confirm, string cancel)
        {
            InitializeComponent();
            DataContext = new AlertViewModel(this, title, message, confirm,cancel);
        }
        #endregion
    }
}
