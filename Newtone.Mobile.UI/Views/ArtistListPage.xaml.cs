using Newtone.Core.Logic;
using Newtone.Mobile.UI.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistListPage : ContentView, ITimerContent
    {
        #region Properties
        private ArtistListViewModel ViewModel { get; set; }
        #endregion
        public ArtistListPage()
        {
            InitializeComponent();

            ViewModel = BindingContext as ArtistListViewModel;
        }

        #region Public Methods
        public void Tick()
        {
            Device.BeginInvokeOnMainThread(() =>
           {
               ViewModel?.Tick();
           });
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
        #region Private Methods
        private void ArtistListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel?.Artist_Selected(sender, e);
        }
        #endregion
    }
}