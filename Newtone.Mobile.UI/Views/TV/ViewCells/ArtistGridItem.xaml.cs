using Nejman.Xamarin.FocusLibrary;
using Newtone.Mobile.UI.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistGridItem : ContentView
    {
        public ArtistGridItem(NListViewItem context)
        {
            InitializeComponent();
            (context as ArtistModel).View = this;
            BindingContext = context;
        }
    }
}