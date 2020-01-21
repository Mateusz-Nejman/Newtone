﻿using NSEC.Music_Player.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NSEC.Music_Player.ViewModels.Tabs
{
    public class ArtistsTabModel : BaseViewModel
    {
        public ObservableCollection<Track> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public ArtistsTabModel()
        {
            Title = "Wykonawcy";

            Items = new ObservableCollection<Track>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add((Track)item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}