using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

using NSEC.Music_Player.Models;
using NSEC.Music_Player.Logic;

namespace NSEC.Music_Player.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public static MainPage Instance { get; set; }
        public static List<MP3Processing.Container> containers = new List<MP3Processing.Container>();
        readonly Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            Instance = this;

            this.Appearing += MainPage_Appearing;

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Library, (NavigationPage)Detail);

            //containers = new List<MP3Processing.Container>(AsyncHelper.RunSync<MP3Processing.Container[]>(() => FileProcessing.ListFiles(App.Directories)));

        }

        private void MainPage_Appearing(object sender, EventArgs e)
        {
            base.OnAppearing();
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Library:
                        MenuPages.Add(id, new NavigationPage(new LibraryPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Youtube:
                        MenuPages.Add(id, new NavigationPage(new YoutubePage()));
                        break;
                    default:
                        MenuPages.Add(id, new NavigationPage(new LibraryPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}