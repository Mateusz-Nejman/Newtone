﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Mobile.UI.ViewModels;
using Newtone.Core.Logic;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Newtone.Mobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullScreenPage : ContentPage, INavigationContainer
    {
        #region Properties
        private FullScreenViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public FullScreenPage()
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);
            var safeAreaInset = On<iOS>().SafeAreaInsets();
            Padding = safeAreaInset;
            ViewModel = BindingContext as FullScreenViewModel;
            Appearing += PageAppearing;
            Disappearing += PageDisappearing;
            audioSlider.ValueNewChanged += AudioSlider_ValueNewChanged;
            trackBlur.On<iOS>().UseBlurEffect(BlurEffectStyle.Light);
        }
        #endregion
        #region Private Methods
        private void AudioSlider_ValueNewChanged(object sender, Custom.AudioSliderControl.ValueChangedArgs e)
        {
            ViewModel?.AudioSlider_ValueNewChanged(e);
        }

        private void PageDisappearing(object sender, EventArgs e)
        {
            ViewModel?.Disappearing();
        }

        private void PageAppearing(object sender, EventArgs e)
        {
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