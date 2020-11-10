using Newtone.Core.Logic;
using Newtone.Mobile.UI.ViewModels.Custom;
using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPanel : ContentView, ITimerContent
    {
        #region Properties
        private PlayerPanelViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public PlayerPanel()
        {
            InitializeComponent();
            ViewModel = BindingContext as PlayerPanelViewModel;
            backgroundImage.On<iOS>().UseBlurEffect(BlurEffectStyle.Light);
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick();
        }

        public void Appearing()
        {
            throw new NotImplementedException();
        }

        public void Disappearing()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}