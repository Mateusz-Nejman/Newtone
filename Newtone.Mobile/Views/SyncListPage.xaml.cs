using Newtone.Core.Logic;
using Newtone.Mobile.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SyncListPage : ContentView, ITimerContent
    {
        #region Properties
        private SyncListViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public SyncListPage()
        {
            InitializeComponent();
            ViewModel = BindingContext as SyncListViewModel;
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