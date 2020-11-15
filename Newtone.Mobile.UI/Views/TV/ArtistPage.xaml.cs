using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistPage : ContentView, ITimerContent, INFocusContent
    {
        #region Properties
        public INFocusElement TopElement { get; set; }
        public INFocusElement BottomElement { get; set; }
        #endregion
        #region Constructors
        public ArtistPage()
        {
            InitializeComponent();
            TopElement = artistList;
            BottomElement = artistList;
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

        public void FocusAction()
        {
            throw new System.NotImplementedException();
        }

        public void FocusDown()
        {
            throw new System.NotImplementedException();
        }

        public void FocusLeft()
        {
            throw new System.NotImplementedException();
        }

        public void FocusRight()
        {
            throw new System.NotImplementedException();
        }

        public void FocusUp()
        {
            throw new System.NotImplementedException();
        }

        public void Tick()
        {
            if (GlobalData.Current.ArtistsNeedRefresh && !(BindingContext as ArtistViewModel).IsInitializing && Global.Loaded)
            {
                Device.BeginInvokeOnMainThread((BindingContext as ArtistViewModel).Initialize);
                GlobalData.Current.ArtistsNeedRefresh = false;
            }
        }
        #endregion
    }
}