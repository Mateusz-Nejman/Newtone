using NSEC.Music_Player.Loaders;
using NSEC.Music_Player.Logic;
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
    public partial class BottomTabPage : ContentPage
    {
        private string OldPage { get; set; }
        private IViewPage Page1 { get; set; }
        private IViewPage Page2 { get; set; }
        private IViewPage Page3 { get; set; }
        public BottomTabPage()
        {
            Page1 = new HomePage();
            Page2 = new SearchPage();
            Page3 = new LibraryPage();
            InitializeComponent();
            tabBar.TabButtonClicked += TabBar_TabButtonClicked;
            Appearing += BottomTabPage_Appearing;
            Disappearing += BottomTabPage_Disappearing;

            TabBar_TabButtonClicked(tabBar.FirstButton, null);
        }

        private void BottomTabPage_Disappearing(object sender, EventArgs e)
        {

        }

        private void BottomTabPage_Appearing(object sender, EventArgs e)
        {
            Page1 = new HomePage();
            Page2 = new SearchPage();
            Page3 = new LibraryPage();
            if (!MainActivity.Loaded)
            {

                MainActivity.Loaded = true;
                Global.LoadTags();
                GlobalLoader.Load();
                Global.LoadConfig();
                CacheString.Save();
            }

            

        }

        private void TabBar_TabButtonClicked(object sender, EventArgs e)
        {
            IconView view = (IconView)sender;

            if (OldPage == "1")
            {
                Page1?.InvokeD(view);
            }
            else if (OldPage == "2")
            {
                Page2?.InvokeD(view);
            }
            else if (OldPage == "3")
            {
                Page3?.InvokeD(view);
            }

            while (Navigation.NavigationStack.Count > 1)
            {
                Task.Run(async () => { await Navigation.PopAsync(); }).Wait();
            }

            if (view.Tag == "1")
            {
                content.Content = (View)Page1;
                Page1?.InvokeA(view);
                Page1?.SetTitleView(titleView);
            }
            else if (view.Tag == "2")
            {
                content.Content = (View)Page2;
                Page2?.InvokeA(view);
                Page2?.SetTitleView(titleView);
            }
            else if (view.Tag == "3")
            {
                content.Content = (View)Page3;
                Page3?.InvokeA(view);
                Page3?.SetTitleView(titleView);
            }
        }
    }
}