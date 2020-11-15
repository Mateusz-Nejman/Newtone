using Nejman.Xamarin.FocusLibrary;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentTracksPage : ContentView, ITimerContent, INFocusContent
    {
        #region Properties
        private CurrentTracksViewModel ViewModel { get; set; }
        public INFocusElement TopElement { get; set; }
        public INFocusElement BottomElement { get; set; }
        #endregion
        #region Constructors
        public CurrentTracksPage(List<string> tracks, string playlistName)
        {
            InitializeComponent();
            TopElement = currentList;
            BottomElement = currentList;
            BindingContext = ViewModel = new CurrentTracksViewModel(tracks, playlistName);
            currentList.Rerender();

        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick();

        }

        public void Appearing()
        {
            //Not implemented
        }

        public void Disappearing()
        {
            //Not implemented
        }

        public void FocusLeft()
        {
            throw new NotImplementedException();
        }

        public void FocusRight()
        {
            throw new NotImplementedException();
        }

        public void FocusUp()
        {
            throw new NotImplementedException();
        }

        public void FocusDown()
        {
            throw new NotImplementedException();
        }

        public void FocusAction()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}