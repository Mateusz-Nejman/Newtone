using System.Windows.Input;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Mobile.UI.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.ViewModels.TV
{
    public class ModalViewModel : PropertyChangedBase
    {
        #region Fields
        private string modalTitle;
        private string badge;
        private bool badgeVisible;
        private bool topPanelVisible;

        private INFocusElement focusElementUp;
        private INFocusElement focusElementDown;
        private INFocusElement focusElementFromUp;
        private INFocusElement focusElementFromDown;
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

        public bool BackButtonVisible => Device.RuntimePlatform == Device.iOS;

        public Grid Container { get; private set; }
        public bool DownloadButtonVisible => false;

        public INFocusElement FocusElementUp
        {
            get => focusElementUp;
            set
            {
                focusElementUp = value;
                OnPropertyChanged();
            }
        }

        public INFocusElement FocusElementDown
        {
            get => focusElementDown;
            set
            {
                focusElementDown = value;
                OnPropertyChanged();
            }
        }

        public INFocusElement FocusElementFromUp
        {
            get => focusElementFromUp;
            set
            {
                focusElementFromUp = value;
                OnPropertyChanged();
            }
        }

        public INFocusElement FocusElementFromDown
        {
            get => focusElementFromDown;
            set
            {
                focusElementFromDown = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private ICommand toFullScreen;
        public ICommand ToFullScreen
        {
            get
            {
                if (toFullScreen == null)
                    toFullScreen = new ActionCommand(async (parameter) =>
                    {
                        if (GlobalData.Current.MediaSource != null)
                        {
                            await Global.NavigationInstance.PushModalAsync(new FullScreenPage());
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
                        await Global.NavigationInstance.PushModalAsync(new ModalPage(new DownloadPage(), Localization.TitleDownloads));
                    });

                return toDownloadPage;
            }
        }

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (backCommand == null)
                    backCommand = new ActionCommand(async (parameter) =>
                    {
                        await Global.NavigationInstance.PopModalAsync();
                    });

                return backCommand;
            }
        }
        #endregion
        #region Constructors
        public ModalViewModel(Grid container, string title, bool topPanelVisible = true)
        {
            ModalTitle = title;
            TopPanelVisible = topPanelVisible;
            Container = container;
        }
        #endregion
        #region Public Methods

        public void Appearing()
        {
            //Not implemented
        }

        public void Disappearing()
        {
            //Not implemented
        }

        public void Tick()
        {
            Badge = DownloadProcessing.BadgeCount.ToString();
            BadgeVisible = DownloadProcessing.BadgeCount > 0;

            if (Container.Children.Count > 0 && Container.Children[0] is ITimerContent content)
                content.Tick();
        }
        #endregion
    }
}
