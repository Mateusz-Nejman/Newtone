using Newtone.Desktop.ViewModels;
using System.Windows;

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
