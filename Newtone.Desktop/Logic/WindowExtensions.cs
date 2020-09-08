using Newtone.Desktop.Views;
using System.Windows;

namespace Newtone.Desktop.Logic
{
    public static class WindowExtensions
    {
        public static void CenterToMainWindow(this Window window)
        {
            window.Owner = MainWindow.Instance;
            window.Left = MainWindow.Instance.CalculateSubWindowPosition(window.Width, window.Height)[0];
            window.Top = MainWindow.Instance.CalculateSubWindowPosition(window.Width, window.Height)[1];
        }
    }
}
