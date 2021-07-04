using Newtone.Core.Logic;
using Newtone.Mobile.UI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TracksPage : ContentView, ITimerContent
    {
        #region Properties
        private TrackViewModel ViewModel { get; set; }
        #endregion
        #region Constructors
        public TracksPage()
        {
            InitializeComponent();

            ViewModel = BindingContext as TrackViewModel;
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ViewModel?.Tick();
            });
        }
        #endregion
        #region Private Methods
        private void TrackListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel?.Track_Selected(sender, e);
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