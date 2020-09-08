using Newtone.Core.Logic;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtone.Mobile.ViewModels;

namespace Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SyncPage : ContentView, ITimerContent
    {
        #region Constructors
        public SyncPage()
        {
            InitializeComponent();
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
            (BindingContext as SyncViewModel)?.Tick();
        }
        #endregion
    }
}