using Newtone.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.FirstStart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstStartThemes : ContentView
    {
        private FirstStartPage Page { get; set; }
        public FirstStartThemes(FirstStartPage page)
        {
            InitializeComponent();
            Page = page;

            TapGestureRecognizer defTap = new TapGestureRecognizer();
            defTap.Tapped += DefTap_Tapped;

            TapGestureRecognizer ligTap = new TapGestureRecognizer();
            ligTap.Tapped += LigTap_Tapped;

            TapGestureRecognizer darTap = new TapGestureRecognizer();
            darTap.Tapped += DarTap_Tapped;


            defaultThemeImage.GestureRecognizers.Add(defTap);
            lightThemeImage.GestureRecognizers.Add(ligTap);
            darkThemeImage.GestureRecognizers.Add(darTap);
        }

        private void DarTap_Tapped(object sender, EventArgs e)
        {
            SetTheme("Dark");
        }

        private void LigTap_Tapped(object sender, EventArgs e)
        {
            SetTheme("Light");
        }

        private void DefTap_Tapped(object sender, EventArgs e)
        {
            SetTheme("Default");
        }

        private void SetTheme(string theme)
        {
            GlobalData.SaveFirstStart(theme);
            Colors.SetBase(theme);
            Page.SetPage(new FirstStartSearch(Page));
        }
    }
}