using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryPage : ContentView, IViewPage
    {
        public event EventHandler Appearing;
        public event EventHandler Disappearing;
        private ObservableCollection<LibraryMenuModel> MenuItems { get; set; }
        public LibraryPage()
        {
            InitializeComponent();
            menuList.ItemsSource = MenuItems = new ObservableCollection<LibraryMenuModel>();
            MenuItems.Add(new LibraryMenuModel() { Image = ImageSource.FromFile("TrackIcon.png"), Title = Localization.Tracks });
            MenuItems.Add(new LibraryMenuModel() { Image = ImageSource.FromFile("ArtistIcon.png"), Title = Localization.Artists });
            MenuItems.Add(new LibraryMenuModel() { Image = ImageSource.FromFile("PlaylistIcon.png"), Title = Localization.Playlists });
            MenuItems.Add(new LibraryMenuModel() { Image = ImageSource.FromFile("YoutubeIcon.png"), Title = "Youtube" });
            MenuItems.Add(new LibraryMenuModel() { Image = ImageSource.FromFile("SettingsIcon.png"), Title = Localization.Settings });

            versionLabel.Text = "v"+ Global.Context.PackageManager.GetPackageInfo(Global.Context.PackageName, 0).VersionName;
        }

        public void InvokeD(object sender)
        {
            Disappearing?.Invoke(sender, null);
        }

        public void InvokeA(object sender)
        {
            Appearing?.Invoke(sender, null);
        }

        public void SetTitleView(CustomTitleView titleView)
        {
            titleView.Title = Localization.Library;
            titleView.IsBackButton = false;
        }

        private void MenuList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                if(e.SelectedItemIndex == 0)
                {
                    Navigation.PushAsync(new TrackListPage(Global.Audios.Keys.ToList()));
                }
                else if(e.SelectedItemIndex == 1)
                {
                    Navigation.PushAsync(new ArtistPage());
                }
                else if(e.SelectedItemIndex == 2)
                {
                    Navigation.PushAsync(new PlaylistPage());
                }
                else if (e.SelectedItemIndex == 3)
                {
                    Navigation.PushAsync(new WebPage("https://youtube.com"));
                }
                else if(e.SelectedItemIndex == 4)
                {
                    Navigation.PushAsync(new SettingsPage());
                }

                menuList.SelectedItem = null;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://mateusz-nejman.pl/"));
        }
    }
}