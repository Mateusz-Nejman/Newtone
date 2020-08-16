using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Mobile.Logic;
using Newtone.Mobile.Views;

namespace Newtone.Mobile.ViewModels
{
    public class SyncViewModel:PropertyChangedBase
    {
        #region Fields
        private string deviceCode;
        private string fileText;
        private string progressText;
        private string deviceCodeEntry;

        private bool deviceCodeEntryEnabled;
        private bool connectButtonEnabled;
        private bool receiveButtonEnabled;
        private bool sendButtonEnabled;
        private bool disconnectButtonEnabled;
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

        public string FileText
        {
            get => fileText;
            set
            {
                fileText = value;
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

        public string DeviceCodeEntry
        {
            get => deviceCodeEntry;
            set
            {
                deviceCodeEntry = value;
                OnPropertyChanged();
            }
        }

        public bool DeviceCodeEntryEnabled
        {
            get => deviceCodeEntryEnabled;
            set
            {
                deviceCodeEntryEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool ConnectButtonEnabled
        {
            get => connectButtonEnabled;
            set
            {
                connectButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool ReceiveButtonEnabled
        {
            get => receiveButtonEnabled;
            set
            {
                receiveButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool SendButtonEnabled
        {
            get => sendButtonEnabled;
            set
            {
                sendButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool DisconnectButtonIsVisible
        {
            get => disconnectButtonEnabled;
            set
            {
                disconnectButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        private ICommand showFiles;
        public ICommand ShowFiles
        {
            get
            {
                if (showFiles == null)
                    showFiles = new ActionCommand(async(parameter) =>
                    {
                        await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new SyncListPage(), ""));
                    });
                return showFiles;
            }
        }
        private ICommand connect;
        public ICommand Connect
        {
            get
            {
                if (connect == null)
                    connect = new ActionCommand(parameter =>
                    {
                        if (!string.IsNullOrEmpty(DeviceCodeEntry) && SyncProcessing.Verify(DeviceCodeEntry))
                        {
                            SyncProcessing.Connect(DeviceCodeEntry);
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
        private ICommand disconnect;
        public ICommand Disconnect
        {
            get
            {
                if (disconnect == null)
                    disconnect = new ActionCommand(parameter =>
                    {
                        SyncProcessing.Disconnect();
                    });

                return disconnect;
            }
        }
        #endregion
        #region Constructors
        public SyncViewModel()
        {
            DeviceCode = SyncProcessing.Code;
            SyncProcessing.ListenReceiver();
            SyncProcessing.ReceivingAction = () =>
            {
                NormalPage.Instance.Dispatcher.BeginInvokeOnMainThread(async () =>
                {
                    if (await NormalPage.Instance.DisplayAlert(Localization.Question, Localization.PlaylistDownload, Localization.Yes, Localization.No))
                    {
                        List<string> positions = new List<string>()
                        {
                            Localization.NewPlaylist
                        };

                        foreach (string playlist in GlobalData.Playlists.Keys)
                            positions.Add(playlist);

                        string answer = await NormalPage.Instance.DisplayActionSheet(Localization.ChoosePlaylist, Localization.Cancel, null, positions.ToArray());

                        if (answer == Localization.NewPlaylist)
                        {
                            string playlist = await NormalPage.Instance.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel, Localization.Playlist, -1, null, Localization.NewPlaylist);

                            if (!string.IsNullOrEmpty(playlist))
                            {
                                if (!GlobalData.Playlists.ContainsKey(playlist))
                                {
                                    GlobalData.Playlists.Add(playlist, new List<string>());
                                }
                                foreach (string file in SyncProcessing.ReceivedTracks)
                                    if (!GlobalData.Playlists[playlist].Contains(file))
                                        GlobalData.Playlists[playlist].Add(file);

                                GlobalData.SaveConfig();

                                SnackbarBuilder.Show(Localization.SnackPlaylist);
                            }
                        }
                        else if (GlobalData.Playlists.ContainsKey(answer))
                        {
                            foreach (string file in SyncProcessing.ReceivedTracks)
                                if (!GlobalData.Playlists[answer].Contains(file))
                                    GlobalData.Playlists[answer].Add(file);

                            GlobalData.SaveConfig();
                        }
                        SyncProcessing.ReceivedTracks.Clear();
                    }
                });
            };
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            DeviceCodeEntryEnabled = SyncProcessing.ChceckEnabled(false, 0, false);
            ConnectButtonEnabled = SyncProcessing.ChceckEnabled(false, 0, false);
            ReceiveButtonEnabled = SyncProcessing.ChceckEnabled(false, 0, true);
            SendButtonEnabled = SyncProcessing.ChceckEnabled(false, 0, true) && SyncProcessing.Audios.Count > 0;
            DisconnectButtonIsVisible = SyncProcessing.CurrentConnection != null;
            FileText = SyncProcessing.CurrentFileName;

            if (SyncProcessing.State == 0)
                ProgressText = SyncProcessing.Progress == 0 ? "" : $"{Math.Round(SyncProcessing.Progress, 2)}MB / {Math.Round(SyncProcessing.Size, 2)}MB";
            else if (SyncProcessing.State == 1)
            {
                ProgressText = $"{SyncProcessing.CurrentFileReceived} / {SyncProcessing.FilesReceived}";
            }
            else if (SyncProcessing.State == 2)
                ProgressText = Localization.Unpacked;
        }
        #endregion
    }
}