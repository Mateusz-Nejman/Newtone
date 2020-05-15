using Newtone.Core;
using Newtone.Core.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguageSelectPage : ContentPage
    {
        private string NextPage { get; set; }
        public LanguageSelectPage( string nextPage)
        {
            InitializeComponent();
            NextPage = nextPage;
        }

        private void ChangeLanguage(string lang)
        {
            GlobalData.CurrentLanguage = lang;
            Localization.RefreshLanguage();
            if (NextPage == "permissions")
                App.Instance.MainPage = new PermissionPage();
            else if (NextPage == "firststart")
                App.Instance.MainPage = new FirstStartPage();
        }

        private void PolandFlag_Clicked(object sender, EventArgs e)
        {
            ChangeLanguage("pl");
        }

        private void EnglandFlag_Clicked(object sender, EventArgs e)
        {
            ChangeLanguage("us");
        }

        private void RussiaFlag_Clicked(object sender, EventArgs e)
        {
            ChangeLanguage("ru");
        }


    }
}