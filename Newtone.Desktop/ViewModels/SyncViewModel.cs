using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Xps.Serialization;

namespace Newtone.Desktop.ViewModels
{
    public class SyncViewModel:PropertyChangedBase
    {
        #region Fields
        private string deviceCode;
        private bool deviceCodeIsEnabled;
        private bool connectButtonIsEnabled;
        private bool sendButtonIsEnabled;
        private bool receiveButttonIsEnabled;
        private string progressText;
        private string fileText;
        private string sendProgressText;
        private Visibility receiveGridVisibility;
        private Visibility syncViewVisibility;
        private Visibility sendGridVisibility;
        private ObservableCollection<Models.TrackModel> items;
        #endregion
        #region Properties
        public string DeviceCode
        {
            get => deviceCode;
            set
            {
                deviceCode = value;
                OnPropertyChanged();
            }
        }
        public bool DeviceCodeIsEnabled
        {
            get => deviceCodeIsEnabled;
            set
            {
                deviceCodeIsEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool ConnectButtonIsEnabled
        {
            get => connectButtonIsEnabled;
            set
            {
                connectButtonIsEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool SendButtonIsEnabled
        {
            get => sendButtonIsEnabled;
            set
            {
                sendButtonIsEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool ReceiveButtonIsEnabled
        {
            get => receiveButttonIsEnabled;
            set
            {
                receiveButttonIsEnabled = value;
                OnPropertyChanged();
            }
        }
        public string ProgressText
        {
            get => progressText;
            set
            {
                progressText = value;
                OnPropertyChanged();
            }
        }
        public string FileText
        {
            get => fileText;
            set
            {
                fileText = value;
                OnPropertyChanged();
            }
        }
        public string SendProgressText
        {
            get => sendProgressText;
            set
            {
                sendProgressText = value;
                OnPropertyChanged();
            }
        }
        public Visibility SendGridVisibility
        {
            get => sendGridVisibility;
            set
            {
                sendGridVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility SyncViewVisbility
        {
            get => syncViewVisibility;
            set
            {
                syncViewVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility ReceiveGridVisibility
        {
            get => receiveGridVisibility;
            set
            {
                receiveGridVisibility = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Models.TrackModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand connect;
        public ICommand Connect
        {
            get
            {
                if (connect == null)
                    connect = new ActionCommand(parameter =>
                    {
                        if (!string.IsNullOrEmpty(DeviceCode))
                        {
                            SyncProcessing.Connect(DeviceCode);
                        }
                    });
                return connect;
            }
        }
        private ICommand receive;
        public ICommand Receive
        {
            get
            {
                if (receive == null)
                    receive = new ActionCommand(parameter =>
                    {
                        SyncProcessing.Receive();
                    });
                return receive;
            }
        }
        private ICommand send;
        public ICommand Send
        {
            get
            {
                if (send == null)
                    send = new ActionCommand(parameter =>
                    {
                        SyncProcessing.Send();
                    });
                return send;
            }
        }
        #endregion
        #region Constructors
        public SyncViewModel()
        {
            Items = new ObservableCollection<Models.TrackModel>();
            SyncProcessing.ListenReceiver();
        }
        #endregion
        #region Public Methods
        public void Tick(ListView listView)
        {
            DeviceCodeIsEnabled = SyncProcessing.CurrentConnection == null || !SyncProcessing.CurrentConnection.Connected;
            ConnectButtonIsEnabled = SyncProcessing.CurrentConnection == null || !SyncProcessing.CurrentConnection.Connected;
            SendButtonIsEnabled = SyncProcessing.Audios.Count > 0 && !SyncProcessing.Started;
            ReceiveButtonIsEnabled = !SyncProcessing.Started;

            if (SyncProcessing.State == 0)
                ProgressText = SyncProcessing.Progress == 0 ? "" : $"{Math.Round(SyncProcessing.Progress, 2)}MB / {Math.Round(SyncProcessing.Size, 2)}MB";
            else if (SyncProcessing.State == 1)
            {
                ProgressText = $"{SyncProcessing.CurrentFileReceived} / {SyncProcessing.FilesReceived}";
                FileText = SyncProcessing.CurrentFileName;
            }
            else if (SyncProcessing.State == 2)
            {
                ProgressText = Core.Languages.Localization.Ready;
                FileText = "";
            }

            ReceiveGridVisibility = SyncProcessing.SocketMode == 1 ? Visibility.Visible : Visibility.Hidden;
            SyncViewVisbility = SyncProcessing.SocketMode == 0 ? Visibility.Visible : Visibility.Hidden;
            SendGridVisibility = SyncProcessing.SocketMode == 2 ? Visibility.Visible : Visibility.Hidden;

            if (SyncProcessing.SocketMode == 2)
                SendProgressText = $"{Math.Round(SyncProcessing.Progress, 2)}% ";

            if (Items.Count != SyncProcessing.Audios.Count)
            {
                Items.Clear();
                foreach (var item in SyncProcessing.Audios)
                    Items.Add(new Models.TrackModel(GlobalData.Audios[item]));

                listView.Items.Refresh();
            }

            foreach (var item in Items)
                item.CheckChanges();
        }
        #endregion
    }
}
