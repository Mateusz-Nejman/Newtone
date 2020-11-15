using Nejman.Xamarin.FocusLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultViewCell : ContentView
    {
        public SearchResultViewCell(NListViewItem context)
        {
            InitializeComponent();
            BindingContext = context;
        }
    }
}