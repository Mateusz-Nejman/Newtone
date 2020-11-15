using Newtone.Core.Logic;
using Newtone.Mobile.UI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV
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
            //Not implemented
        }

        public void Disappearing()
        {
            //Not implemented
        }
        #endregion
        #region Public Methods
        public void Tick()
        {
            ViewModel?.Tick();

        }
        #endregion
    }
}