using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Core.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SyncPage : ContentView, ITimerContent
    {
        public SyncPage()
        {
            InitializeComponent();
            deviceCode.Text = SyncProcessing.Code;
            SyncProcessing.ListenReceiver();
        }

        public void Tick()
        {
            deviceCodeEntry.IsEnabled = SyncProcessing.ChceckEnabled(false, 0, false);
            connectButton.IsEnabled = SyncProcessing.ChceckEnabled(false, 0, false);
            receiveButton.IsEnabled = SyncProcessing.ChceckEnabled(false, 0, true);
            sendButton.IsEnabled = SyncProcessing.ChceckEnabled(false, 0, true) && SyncProcessing.Audios.Count > 0;
            fileText.Text = SyncProcessing.CurrentFileName;

            if (SyncProcessing.State == 0)
                progressText.Text = SyncProcessing.Progress == 0 ? "" : $"{Math.Round(SyncProcessing.Progress, 2)}MB / {Math.Round(SyncProcessing.Size, 2)}MB";
            else if (SyncProcessing.State == 1)
            {
                progressText.Text = $"{SyncProcessing.CurrentFileReceived} / {SyncProcessing.FilesReceived}";
            }
            else if (SyncProcessing.State == 2)
                progressText.Text = Localization.Unpacked;
        }

        private void ConnectButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(deviceCodeEntry.Text) && SyncProcessing.Verify(deviceCodeEntry.Text))
            {
                SyncProcessing.Connect(deviceCodeEntry.Text);
            }
        }

        private void ReceiveButton_Clicked(object sender, EventArgs e)
        {
            SyncProcessing.Receive();
        }

        private void SendButton_Clicked(object sender, EventArgs e)
        {
            SyncProcessing.Send();
        }

        private void ShowButton_Clicked(object sender, EventArgs e)
        {
            NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new SyncListPage(), ""));
        }
    }
}