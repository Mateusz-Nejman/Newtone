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
    public partial class MainPage : NavigationPage
    {
        #region Properties
        public static MainPage Instance { get; set; }
        public static INavigation NavigationInstance
        {
            get
            {
                return Instance.Navigation;
            }
        }
        #endregion
        #region Constructors
        public MainPage()
        {
            InitializeComponent();
            Instance = this;
        }
        #endregion
    }
}