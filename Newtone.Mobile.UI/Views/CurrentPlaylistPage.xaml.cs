using Newtone.Core.Logic;
using Newtone.Mobile.UI.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CurrentPlaylistPage : ContentView, ITimerContent
    {
        #region Fields
        private readonly CurrentPlaylistViewModel ViewModel;
        #endregion
        #region Constructors
        public CurrentPlaylistPage()
        {
            InitializeComponent();
            ViewModel = BindingContext as CurrentPlaylistViewModel;
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
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick();

        }
        #endregion
        #region Private Methods
        private void TrackListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel?.TrackListView_ItemSelected(sender, e);
        }
        #endregion
    }
}