using Newtone.Core;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using Newtone.Core.Languages;
using Newtone.Mobile.Logic;
using Newtone.Mobile.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;
using System.Net;
using Newtone.Mobile.ViewModels;
using Newtone.Core.Logic;

namespace Newtone.Mobile.Views
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
            ViewModel = BindingContext as FullScreenViewModel;
            Appearing += PageAppearing;
            Disappearing += PageDisappearing;
            audioSlider.ValueNewChanged += AudioSlider_ValueNewChanged;
        }
        #endregion
        #region Private Methods
        private void AudioSlider_ValueNewChanged(object sender, Custom.AudioSliderControl.ValueChangedArgs e)
        {
            ViewModel?.AudioSlider_ValueNewChanged(sender, e);
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