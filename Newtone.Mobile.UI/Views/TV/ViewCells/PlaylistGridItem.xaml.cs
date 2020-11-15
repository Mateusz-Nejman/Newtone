using Nejman.Xamarin.FocusLibrary;
using Newtone.Mobile.UI.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistGridItem : ContentView
    {
        #region Constructors
        public PlaylistGridItem(NListViewItem context)
        {
            InitializeComponent();
            (context as PlaylistModel).View = this;
            BindingContext = context;
        }
        #endregion
    }
}