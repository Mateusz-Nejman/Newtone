using Newtone.Core.Logic;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Mobile.UI.ViewModels.TV;
using System.Reactive.Linq;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Mobile.UI.ViewModels.TV.Custom;

namespace Newtone.Mobile.UI.Views.TV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : ContentPage, INavigationContainer
    {
        #region Fields
        private IDisposable loopSubscription;
        #endregion
        #region Properties
        private ModalViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public ModalPage(ContentView content, string title, bool topPanelVisible = true, bool playerPanelVisible = true)
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);
            var safeAreaInset = On<iOS>().SafeAreaInsets();
            page.Padding = safeAreaInset;
            BindingContext = ViewModel = new ModalViewModel(container, title, topPanelVisible);
            
            container.Children.Add(content);

            Appearing += PageAppearing;
            Disappearing += PageDisappearing;
            
            playerPanel.IsVisible = playerPanelVisible;
            ViewModel.OnPropertyChanged(() => ViewModel.DownloadButtonVisible);
            PageAppearing(null, EventArgs.Empty);
        }
        #endregion
        #region Private Methods
        private void PageDisappearing(object sender, EventArgs e)
        {
            ViewModel?.Disappearing();
            loopSubscription?.Dispose();
            loopSubscription = null;
        }

        private void PageAppearing(object sender, EventArgs e)
        {
            Console.WriteLine("ModalPage Appearing start");
            var src = System.Reactive.Linq.Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(200)).Timestamp();
            loopSubscription = src.Subscribe(time => Tick());
            ViewModel?.Appearing();
            FocusContext.UnfocusAll();

            if(container.Children[0] is DownloadPage)
            {
                backButton.IsNFocused = true;
            }
            else
            {
                backButton.IsVisible = false;
                if (container.Children[0] is INFocusContent focusContent)
                {
                    focusContent.TopElement.NextFocusUp = null;
                    focusContent.BottomElement.NextFocusDown = playerPanel.ImageButton;
                    (playerPanel.BindingContext as PlayerPanelViewModel).NextFocusUp = focusContent.BottomElement;
                    (playerPanel.BindingContext as PlayerPanelViewModel).NextFocusUp1 = focusContent.BottomElement;
                    focusContent.TopElement.IsNFocused = true;
                }
            }
            Console.WriteLine("ModalPage Appearing end");
        }

        private void Tick()
        {
            if (playerPanel != null)
            {
                playerPanel?.Tick();
            }

            ViewModel?.Tick();
        }

        public void Block()
        {
            blocker.IsVisible = true;
        }

        public void Unblock()
        {
            blocker.IsVisible = false;
        }

        public bool IsBlocked()
        {
            return blocker.IsVisible;
        }

        public Type GetContentType()
        {
            return container.Children.Count == 0 ? null : container.Children[0].GetType();
        }
        #endregion
    }
}