using Newtone.Mobile.Views.FirstStart;
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
    public partial class FirstStartPage : ContentPage
    {
        #region Properties
        public static FirstStartPage Instance { get; private set; }
        #endregion
        #region Constructors
        public FirstStartPage()
        {
            InitializeComponent();
            Instance = this;
            SetPage(new FirstStartSearch());
        }
        #endregion
        #region Public Methods
        public void SetPage(ContentView view)
        {
            mainGrid.Children.Clear();
            mainGrid.Children.Add(view, 0, 0);
        }
        #endregion
    }
}