using Nejman.Xamarin.FocusLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV.ViewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsViewCell : ContentView
    {
        public SettingsViewCell(NListViewItem context)
        {
            InitializeComponent();
            BindingContext = context;
            this.LayoutChanged += SettingsViewCell_LayoutChanged;
        }

        private void SettingsViewCell_LayoutChanged(object sender, System.EventArgs e)
        {
            HorizontalOptions = LayoutOptions.StartAndExpand;
        }
    }
}