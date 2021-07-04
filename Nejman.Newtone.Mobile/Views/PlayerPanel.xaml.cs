using Nejman.Newtone.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Nejman.Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPanel : ContentView
    {
        #region Properties
        private PlayerPanelViewModel ViewModel { get; set; }
        private IDisposable timer;
        #endregion
        #region Constructors
        public PlayerPanel()
        {
            InitializeComponent();
            ViewModel = BindingContext as PlayerPanelViewModel;
            backgroundImage.On<iOS>().UseBlurEffect(BlurEffectStyle.Light);
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick();
        }

        public void Appearing()
        {
            timer = Observable.Interval(TimeSpan.FromMilliseconds(250)).Subscribe(time => Tick());
        }

        public void Disappearing()
        {
            timer?.Dispose();
            timer = null;
        }
        #endregion
    }
}