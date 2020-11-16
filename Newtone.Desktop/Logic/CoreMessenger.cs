using Newtone.Core.Logic;
using Newtone.Desktop.Views;
using System;
using Windows.UI.Notifications;

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

            if((Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 0) || Environment.OSVersion.Version.Major >= 10)
            {
                var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);
                var stringElements = toastXml.GetElementsByTagName("text");
                stringElements[0].AppendChild(toastXml.CreateTextNode("Newtone"));
                stringElements[1].AppendChild(toastXml.CreateTextNode(message));
                var toast = new ToastNotification(toastXml);
                ToastNotificationManager.CreateToastNotifier("Newtone Toast Notification").Show(toast);
            }
        }
    }
}
