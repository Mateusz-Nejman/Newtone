using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace NSEC.Music_Player.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<Models.MenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<Models.MenuItem>
            {
                new Models.MenuItem {Id = MenuItemType.Library, Title="Biblioteka" },
                new Models.MenuItem{Id = MenuItemType.Youtube, Title="Pobieranie z youtube"},
                new Models.MenuItem {Id = MenuItemType.About, Title="O Apce" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((Models.MenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            for (int a = 0; a < menuItems.Count; a++)
            {
                menuItems[a].Selected(e.SelectedItemIndex == a);
            }
        }
    }
}