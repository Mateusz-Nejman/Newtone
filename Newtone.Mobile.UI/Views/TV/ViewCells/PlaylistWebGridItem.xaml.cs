using Nejman.Xamarin.FocusLibrary;
using Newtone.Mobile.UI.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistWebGridItem : ContentView
    {
        #region Constructors
        public PlaylistWebGridItem(NListViewItem context)
        {
            InitializeComponent();
            (context as PlaylistModel).View = this;
            BindingContext = context;
        }
        #endregion
    }
}