using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Mobile.Media;
using Newtone.Mobile.Models;
using Newtone.Mobile.ViewModels;
using Newtone.Mobile.Views.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.Views
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