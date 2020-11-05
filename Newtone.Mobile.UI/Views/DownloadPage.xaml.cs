using Newtone.Core.Logic;
using Newtone.Mobile.UI.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DownloadPage : ContentView, ITimerContent
    {
        #region Properties
        private DownloadViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public DownloadPage()
        {
            InitializeComponent();
            ViewModel = BindingContext as DownloadViewModel;
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