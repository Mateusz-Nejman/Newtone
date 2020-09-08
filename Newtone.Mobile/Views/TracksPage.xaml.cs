using Newtone.Core.Logic;
using Newtone.Mobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.Views
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
            ViewModel?.Tick();
        }
        #endregion
        #region Private Methods
        private void TrackListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel?.Track_Selected(sender, e);
        }

        public void Appearing()
        {
        }

        public void Disappearing()
        {
        }
        #endregion
    }
}