using Newtone.Mobile.ViewModels.ViewCells;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.Views.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistGridItem : ContentView
    {
        #region Properties
        public ArtistPage Page { get; private set; }
        #endregion
        #region Constructors
        public ArtistGridItem(ArtistPage page, string artistName)
        {
            InitializeComponent();
            Page = page;
            BindingContext = new ArtistGridItemViewModel(artistName, this);
        }
        #endregion
    }
}