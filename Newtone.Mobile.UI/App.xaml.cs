using Xamarin.Forms;
using System.IO;
using Newtone.Core;
using Newtone.Mobile.UI.Views;

namespace Newtone.Mobile.UI
{
    public partial class App : Application
    {
        #region Properties
        public static App Instance { get; set; }
        #endregion
        #region Constructors
        public App()
        {
            InitializeComponent();
            Instance = this;
            if (Global.Permissions.IsValid() && File.Exists(GlobalData.Current.DataPath + "/newtone.nsec2"))
            {
                if(Global.TV)
                {
                    MainPage = new Views.TV.NormalPage();
                }
                else
                {
                    MainPage = new NormalPage();
                }
            }
            else
            {
                if(Global.TV)
                {
                    MainPage = new Views.TV.LanguageSelectPage();
                }
                else
                {
                    MainPage = new LanguageSelectPage();
                }
            }
        }
        #endregion
    }
}
