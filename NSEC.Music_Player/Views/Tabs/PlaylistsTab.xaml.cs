﻿using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Services;
using NSEC.Music_Player.ViewModels.Tabs;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xam.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistsTab : ContentPage, IAsyncEndListener
    {

        PlaylistsTabModel model;

        public event EventHandler AsyncEnded;
        private string PlaylistName { get; set; }

        public PlaylistsTab()
        {
            InitializeComponent();
            this.Appearing += PlaylistsTab_Appearing;

            BindingContext = model = new PlaylistsTabModel();
            Global.asyncEndController.Add("playliststab", this);

            /*if (model.DataStore.Count() == 0)
            {
                File.AppendAllText(App.debugPath + "/authorsTab.txt", "Artist count " + Global.Audios.Count + "\n");
                foreach (string artist in Global.Audios.Keys)
                {
                    var item = new Artist() { Id = artist, Text = artist, Description = "Utworów: " + Global.Audios[artist].Count };
                    model.Items.Add(item);
                    Task.Run(() => model.DataStore.AddItemAsync(item));
                    //MenuItems.Add();
                    File.AppendAllText(App.debugPath + "/authorsTab.txt", "Add artist " + artist + "\n");
                }

                
            }*/

            AsyncEnded += PlaylistsTab_AsyncEnded;
            Task.Run(() => PlaylistsTab_AsyncEnded(this, null));

        }

        private async void PlaylistsTab_Appearing(object sender, EventArgs e)
        {
            playerPanel.Refresh();
            await Helpers.ReloadPlaylists(this, model);
        }

        private async void PlaylistsTab_AsyncEnded(object sender, EventArgs e)
        {
            //File.AppendAllText(App.debugPath + "/debugAutorsTab.txt", "Count = " + Global.Audios.Count + "\n");
            await Helpers.LoadPlaylistsOnce(this, model);
            this.model.LoadItemsCommand.Execute(this);
        }

        private async void OnPlaylistSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Track item = PlaylistsListView.SelectedItem as Track;
            //Console.WriteLine("OnAuthorSelected: " + (item == null));
            if (item == null)
                return;

            for (int a = 0; a < model.Items.Count; a++)
            {
                model.Items[a].Selected(e.SelectedItemIndex == a);
            }

            await Navigation.PushAsync(new PlaylistPage(item.Text));

            if (e.SelectedItemIndex >= 0)
                model.Items[e.SelectedItemIndex].Selected(false);
            PlaylistsListView.SelectedItem = null;
        }

        public void AsyncEnd()
        {
            AsyncEnded.Invoke(this, new EventArgs());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<string> menuItems = new ObservableCollection<string>();
            CustomButton button = (CustomButton)sender;
            Console.WriteLine("BUTTON TAG: " + button.Tag);
            PlaylistName = button.Tag;

            menuItems.Add("Odtwórz");
            menuItems.Add("Usuń");

            PopupMenu menu = new PopupMenu();
            menu.ItemsSource = menuItems;
            menu.OnItemSelected += Menu_OnItemSelected;

            menu.ShowPopup((View)sender);
        }

        private async void Menu_OnItemSelected(string item)
        {
            if(item == "Odtwórz")
            {
                if(Global.Playlists[PlaylistName].Count > 0)
                {
                    if (Global.AudioPlayer != null)
                        Global.AudioPlayer.Stop();
                    var stream = FileProcessing.GetStreamFromFile(Global.Playlists[PlaylistName][0].Container.FilePath);
                    Global.AudioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    Global.AudioPlayer.Load(stream);
                    Global.AudioPlayer.PlaybackEnded += Global.AudioPlayer_PlaybackEnded;
                    Global.AudioPlayerTrack = Global.Playlists[PlaylistName][0].Id;
                    Global.CurrentTrack = Global.Playlists[PlaylistName][0].Container;
                    Global.CurrentPlaylist = Global.Playlists[PlaylistName];
                    Global.CurrentPlaylistPosition = 0;
                    Global.AudioPlayer.Play();
                }
                
            }
            else if(item == "Usuń")
            {
                bool answer = await DisplayAlert("Pytanko", "Usunąć playlistę "+PlaylistName+"?", "Tak", "Nie");

                if(answer)
                {
                    Global.Playlists.Remove(PlaylistName);
                    await Helpers.ReloadPlaylists(this, model);
                    Global.SaveConfig();
                }
            }
        }
    }
}