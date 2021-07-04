using Nejman.Newtone.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Nejman.Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        #region Properties
        private PlayerViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public PlayerPage()
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);
            var safeAreaInset = On<iOS>().SafeAreaInsets();
            Padding = safeAreaInset;
            ViewModel = BindingContext as PlayerViewModel;
            audioSlider.ValueNewChanged += AudioSlider_ValueNewChanged;
            trackBlur.On<iOS>().UseBlurEffect(BlurEffectStyle.Light);
        }
        #endregion
        #region Private Methods
        private void AudioSlider_ValueNewChanged(object sender, AudioSliderControl.ValueChangedArgs e)
        {
            ViewModel?.AudioSlider_ValueNewChanged(e);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel?.Disappearing();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.Appearing();
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
        #endregion
    }
}