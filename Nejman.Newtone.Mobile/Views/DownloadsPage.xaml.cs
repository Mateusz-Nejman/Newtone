using Nejman.Newtone.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Nejman.Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DownloadsPage : ContentPage
    {
        #region Fields
        private IDisposable timer;
        #endregion
        #region Properties
        private DownloadsViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public DownloadsPage()
        {
            InitializeComponent();
            ViewModel = BindingContext as DownloadsViewModel;
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            timer = Observable.Interval(TimeSpan.FromMilliseconds(250)).Subscribe(x => Tick());
            playerPanel.Appearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            timer?.Dispose();
            timer = null;
            playerPanel.Disappearing();
        }
        #endregion
    }
}