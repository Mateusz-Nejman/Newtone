using Newtone.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Desktop.Logic
{
    public class SnackbarBuilder
    {
        #region Public Methods
        public static void Show(string text)
        {
            MainWindow.Instance.SnackbarShow(text);
        }
        #endregion
    }
}
