using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Desktop.Views;
using Newtone.Desktop.Views.Custom;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static Newtone.Desktop.ViewModels.MainViewModel;

namespace Newtone.Desktop.ViewModels
{
    public class NormalViewModel : PropertyChangedBase
    {
        #region Fields
        private string searchString;
        private ImageSource maximizeIcon;

        #endregion
        #region Properties
        private int CurrentTopPanelButtonIndex { get; set; } = 0;
        public string SearchString
        {
            get => searchString;
            set
            {
                searchString = value;
                OnPropertyChanged();
            }
        }
        public ImageSource MaximizeIcon
        {
            get => maximizeIcon;
            set
            {
                maximizeIcon = value;
                OnPropertyChanged();
            }
        }

        private Button[] TopPanelButtons { get; set; }
        #endregion
        #region Commands
        private ICommand gotoTracks;
        public ICommand GotoTracks
        {
            get
            {
                if (gotoTracks == null)
                    gotoTracks = new ActionCommand(parameter =>
                    {
                        var window = parameter as NormalWindow;
                        if(CurrentTopPanelButtonIndex != 0)
                        {
                            window.TopPanelButton_Click(0, new TrackPage());
                            CurrentTopPanelButtonIndex = 0;
                        }
                    });
                return gotoTracks;
            }
        }
        private ICommand gotoArtists;
        public ICommand GotoArtists
        {
            get
            {
                if (gotoArtists == null)
                    gotoArtists = new ActionCommand(parameter =>
                    {
                        var window = parameter as NormalWindow;
                        if(CurrentTopPanelButtonIndex != 1)
                        {
                            window.TopPanelButton_Click(1, new ArtistPage());
                            CurrentTopPanelButtonIndex = 1;
                        }
                    });
                return gotoArtists;
            }
        }
        private ICommand gotoPlaylists;
        public ICommand GotoPlaylists
        {
            get
            {
                if (gotoPlaylists == null)
                    gotoPlaylists = new ActionCommand(parameter =>
                    {
                        var window = parameter as NormalWindow;
                        if (CurrentTopPanelButtonIndex != 2)
                        {
                            window.TopPanelButton_Click(2, new PlaylistPage());
                            CurrentTopPanelButtonIndex = 2;
                        }
                    });
                return gotoPlaylists;
            }
        }
        private ICommand gotoSearch;
        public ICommand GotoSearch
        {
            get
            {
                if(gotoSearch == null)
                    gotoSearch = new ActionCommand(parameter =>
                    {
                        var window = parameter as NormalWindow;
                        if (CurrentTopPanelButtonIndex != 3 && !string.IsNullOrWhiteSpace(SearchString))
                        {
                            window.TopPanelButton_Click(3, new SearchResultPage(SearchString));
                            CurrentTopPanelButtonIndex = 3;
                        }
                    });
                return gotoSearch;
            }
        }
        private ICommand gotoSettings;
        public ICommand GotoSettings
        {
            get
            {
                if(gotoSettings == null)
                    gotoSettings = new ActionCommand(parameter =>
                    {
                        var window = parameter as NormalWindow;
                        if (CurrentTopPanelButtonIndex != 4)
                        {
                            window.TopPanelButton_Click(4, new SettingsPage());
                            CurrentTopPanelButtonIndex = 4;
                        }
                    });
                return gotoSettings;
            }
        }
        private ICommand gotoSync;
        public ICommand GotoSync
        {
            get
            {
                if (gotoSync == null)
                    gotoSync = new ActionCommand(parameter =>
                    {
                        var window = parameter as NormalWindow;
                        window.TopPanelButton_Click(-1, new SyncPage());
                    });
                return gotoSync;
            }
        }
        private ICommand gotoDownload;
        public ICommand GotoDownload
        {

            get
            {
                if (gotoDownload == null)
                    gotoDownload = new ActionCommand(parameter =>
                    {
                        var window = parameter as NormalWindow;
                        window.TopPanelButton_Click(-1, new DownloadPage());
                    });
                return gotoDownload;
            }
        }

        private ICommand minimizeCommand;
        public ICommand Minimize
        {
            get
            {
                if (minimizeCommand == null)
                    minimizeCommand = new ActionCommand(parameter =>
                    {
                        MainWindow.Instance.TopBarClick(TitleBarButton.Minimize);
                    });

                return minimizeCommand;
            }
        }

        private ICommand maximizeCommand;
        public ICommand Maximize
        {
            get
            {
                if (maximizeCommand == null)
                    maximizeCommand = new ActionCommand(parameter =>
                    {
                        MainWindow.Instance.TopBarClick(TitleBarButton.Maximize);
                    });
                return maximizeCommand;
            }
        }

        private ICommand closeCommand;
        public ICommand Close
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new ActionCommand(parameter =>
                    {
                        MainWindow.Instance.TopBarClick(TitleBarButton.Close);
                    });
                return closeCommand;
            }
        }
        #endregion
        #region Constructors
        public NormalViewModel(Button[] topPanelButtons, NormalWindow window)
        {
            TopPanelButtons = topPanelButtons;
            SelectTopPanelButton(CurrentTopPanelButtonIndex, window);
            window.SetContainer(new TrackPage());
        }
        #endregion
        #region Public Methods
        public void Tick(NormalWindow window, BadgeButton syncButton, BadgeButton downloadButton)
        {
            downloadButton.BadgeCount = DownloadProcessing.BadgeCount;
            syncButton.BadgeCount = SyncProcessing.Audios.Count;
            if (window.windowContainer.Children.Count > 0 && window.windowContainer.Children[0] is ITimerContent content)
            {
                content.Tick();
            }
        }
        public void SelectTopPanelButton(int index, NormalWindow window)
        {
            for (int a = 0; a < TopPanelButtons.Length; a++)
            {
                TopPanelButtons[a].Style = window.FindResource("TopPanelButton") as Style;
            }
            if (index >= 0)
                TopPanelButtons[index].Style = window.FindResource("TopPanelButtonSelected") as Style;
        }
        #endregion
    }
}
