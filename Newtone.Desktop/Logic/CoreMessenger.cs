using Newtone.Core.Logic;
using Newtone.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Desktop.Logic
{
    public class CoreMessenger : ICoreMessage
    {
        public void ShowError(string message)
        {
            ShowSnackbar(message);
        }

        public void ShowMessage(string message)
        {
            ShowSnackbar(message);
        }

        public void ShowSnackbar(string message)
        {
            MainWindow.Instance.SnackbarShow(message);
        }
    }
}
