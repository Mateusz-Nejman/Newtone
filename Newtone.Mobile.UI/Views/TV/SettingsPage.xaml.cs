using Nejman.Xamarin.FocusLibrary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views.TV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentView, INFocusContent
    {
        #region Properties
        public INFocusElement TopElement { get; set; }
        public INFocusElement BottomElement { get; set; }
        #endregion
        #region Constructors
        public SettingsPage()
        {
            InitializeComponent();
            TopElement = wwwButton;
            BottomElement = settingsList;
        }
        #endregion
    }
}