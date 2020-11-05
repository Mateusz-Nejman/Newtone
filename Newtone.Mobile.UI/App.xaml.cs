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
                MainPage = new NormalPage();
            }
            else
            {
                MainPage = new LanguageSelectPage("permissions");
            }
        }
        #endregion
    }
}
