using Newtone.Core.Logic;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Mobile.UI.ViewModels;
using System.Reactive.Linq;
using Newtone.Core;

namespace Newtone.Mobile.UI.Views
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
            BindingContext = ViewModel = new ModalViewModel(container, title, topPanelVisible);
            container.Children.Add(content);

            Appearing += PageAppearing;
            Disappearing += PageDisappearing;

            playerPanel.IsVisible = playerPanelVisible;
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
            var src = System.Reactive.Linq.Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(200)).Timestamp();
            loopSubscription = src.Subscribe(time => Tick());
            ViewModel?.Appearing();
        }

        private void Tick()
        {
            if (playerPanel != null)
            {
                playerPanel.IsVisible = GlobalData.Current.MediaSource != null;
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