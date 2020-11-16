using Newtone.Desktop.Views;

namespace Newtone.Desktop.Logic
{
    public static class SnackbarBuilder
    {
        #region Public Methods
        public static void Show(string text)
        {
            MainWindow.Instance.SnackbarShow(text);
        }
        #endregion
    }
}
