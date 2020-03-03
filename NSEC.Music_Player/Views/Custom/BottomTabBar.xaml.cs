using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomTabBar : ContentView
    {
        public event EventHandler TabButtonClicked;
        public IconView FirstButton
        {
            get
            {
                return button1;
            }
        }
        public BottomTabBar()
        {
            InitializeComponent();

            TapGestureRecognizer tap1 = new TapGestureRecognizer();
            tap1.Tapped += Grid1_Tapped;

            TapGestureRecognizer tap2 = new TapGestureRecognizer();
            tap2.Tapped += Grid2_Tapped;

            TapGestureRecognizer tap3 = new TapGestureRecognizer();
            tap3.Tapped += Grid3_Tapped;

            grid1.GestureRecognizers.Add(tap1);
            grid2.GestureRecognizers.Add(tap2);
            grid3.GestureRecognizers.Add(tap3);

            TapGestureRecognizer_Tapped(button1, null);
        }

        private void Grid1_Tapped(object sender, EventArgs e)
        {
            TapGestureRecognizer_Tapped(button1, e);
        }

        private void Grid2_Tapped(object sender, EventArgs e)
        {
            TapGestureRecognizer_Tapped(button2, e);
        }

        private void Grid3_Tapped(object sender, EventArgs e)
        {
            TapGestureRecognizer_Tapped(button3, e);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            IconView view = (IconView)sender;

            button1.Foreground = view.Tag == "1" ? Colors.BottomBarSelected : Colors.BottomBarUnselected;
            button2.Foreground = view.Tag == "2" ? Colors.BottomBarSelected : Colors.BottomBarUnselected;
            button3.Foreground = view.Tag == "3" ? Colors.BottomBarSelected : Colors.BottomBarUnselected;

            TabButtonClicked?.Invoke(view, null);
        }
    }
}