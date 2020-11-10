using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Mobile.UI.Views;
using Xamarin.Forms;
namespace Newtone.Mobile.UI.ViewModels
{
    public class ModalViewModel : PropertyChangedBase
    {
        #region Fields
        private string modalTitle;
        private string badge;
        private bool badgeVisible;
        private bool topPanelVisible;
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
        public bool DownloadButtonVisible => !(Container.Children.Count > 0 && Container.Children[0] is DownloadPage);
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
                        await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new DownloadPage(), Localization.TitleDownloads));
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
                        await NormalPage.NavigationInstance.PopModalAsync();
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

        }

        public void Disappearing()
        {

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
