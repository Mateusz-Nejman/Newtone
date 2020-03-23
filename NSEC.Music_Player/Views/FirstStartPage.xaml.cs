using NSEC.Music_Player.Views.FirstStart;
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
    public partial class FirstStartPage : ContentPage
    {
        public FirstStartPage()
        {
            InitializeComponent();
            SetPage(new FirstStartThemes(this));
        }

        public void SetPage(ContentView view)
        {
            mainGrid.Children.Clear();
            mainGrid.Children.Add(view, 0, 0);
        }
    }
}