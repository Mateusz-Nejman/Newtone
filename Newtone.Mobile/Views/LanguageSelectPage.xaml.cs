using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguageSelectPage : ContentPage
    {
        #region Constructors
        public LanguageSelectPage( string nextPage)
        {
            InitializeComponent();
            BindingContext = new LanguageSelectViewModel(nextPage);
        }
        #endregion
    }
}