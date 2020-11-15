using Nejman.Xamarin.FocusLibrary;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TracksPage : ContentView, ITimerContent, INFocusContent
    {
        #region Fields
        private bool tick = false;
        #endregion
        #region Properties
        private TrackViewModel ViewModel { get; set; }
        public INFocusElement TopElement { get; set; }
        public INFocusElement BottomElement { get; set; }
        #endregion
        #region Constructors
        public TracksPage()
        {
            InitializeComponent();
            ViewModel = BindingContext as TrackViewModel;
            TopElement = trackList;
            BottomElement = trackList;
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            if(!tick)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    tick = true;
                    ViewModel?.Tick();
                    tick = false;
                });
            }
        }
        public void Appearing()
        {
            //Not implemented
        }

        public void Disappearing()
        {
            //Not implemented
        }
        #endregion
    }
}