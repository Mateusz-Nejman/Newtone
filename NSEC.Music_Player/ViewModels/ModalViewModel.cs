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
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Processing;
using NSEC.Music_Player.Views;
using NSEC.Music_Player.Views.Custom;
using Xamarin.Forms;

namespace NSEC.Music_Player.ViewModels
{
    public class ModalViewModel:PropertyChangedBase
    {
        #region Fields
        private string modalTitle;
        private string badge;
        private bool badgeVisible;
        private bool topPanelVisible;
        private bool stopTimer = false;
        private PlayerPanel playerPanel;
        #endregion

        #region Properties
        public string ModalTitle
        {
            get => modalTitle;
            set
            {
                modalTitle = value;
                OnPropertyChanged();
            }
        }

        public string Badge
        {
            get => badge;
            set
            {
                badge = value;
                OnPropertyChanged();
            }
        }
        public bool BadgeVisible
        {
            get => badgeVisible;
            set
            {
                badgeVisible = value;
                OnPropertyChanged();
            }
        }

        public bool TopPanelVisible
        {
            get => topPanelVisible;
            set
            {
                topPanelVisible = value;
                OnPropertyChanged();
            }
        }

        public PlayerPanel PlayerPanel
        {
            get => playerPanel;
            set
            {
                playerPanel = value;
                OnPropertyChanged();
            }
        }

        public Grid Container { get; private set; }
        #endregion

        #region Commands
        private ICommand toFullScreen;
        public ICommand ToFullScreen
        {
            get
            {
                if (toFullScreen == null)
                    toFullScreen = new ActionCommand(async(parameter) =>
                    {
                        if (GlobalData.MediaSource != null)
                        {
                            await NormalPage.NavigationInstance.PushModalAsync(new FullScreenPage());
                        }
                    });

                return toFullScreen;
            }
        }

        private ICommand toDownloadPage;
        public ICommand ToDownloadPage
        {
            get
            {
                if (toDownloadPage == null)
                    toDownloadPage = new ActionCommand(async (parameter) =>
                    {
                        await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new DownloadPage(), Localization.TitleDownloads, false));
                    });

                return toDownloadPage;
            }
        }
        #endregion
        #region Constructors
        public ModalViewModel(Grid container, string title, bool topPanelVisible = true, PlayerPanel panel = null)
        {
            ModalTitle = title;
            TopPanelVisible = topPanelVisible;
            PlayerPanel = panel;
            Container = container;
        }
        #endregion
        #region Public Methods

        public void Appearing()
        {
            Device.StartTimer(TimeSpan.FromSeconds(0.2), TimerTick);
            stopTimer = false;
        }

        public void Disappearing()
        {
            stopTimer = true;
        }
        #endregion

        #region Private Methods
        private bool TimerTick()
        {
            Badge = DownloadProcessing.BadgeCount.ToString();
            BadgeVisible = DownloadProcessing.BadgeCount > 0;

            PlayerPanel?.Tick();

            if (Container.Children.Count > 0 && Container.Children[0] is ITimerContent)
                ((ITimerContent)Container.Children[0]).Tick();
            return !stopTimer;
        }
        #endregion
    }
}