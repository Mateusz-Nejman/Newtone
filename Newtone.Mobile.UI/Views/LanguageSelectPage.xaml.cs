using Newtone.Mobile.UI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguageSelectPage : ContentPage
    {
        #region Constructors
        public LanguageSelectPage(string nextPage)
        {
            InitializeComponent();
            BindingContext = new LanguageSelectViewModel(nextPage);
        }
        #endregion
    }
}