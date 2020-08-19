using Newtone.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Newtone.Mobile.Views.FirstStart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstStartThemes : ContentView
    {
        #region Constructors
        public FirstStartThemes()
        {
            InitializeComponent();

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
        #endregion
        #region Private Methods
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
            GlobalData.Current.SaveFirstStart(theme);
            Colors.SetBase(theme);
            FirstStartPage.Instance.SetPage(new FirstStartSearch());
        }
        #endregion
    }
}