using Android.App;
using Android.Support.Design.Widget;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Xam.Plugin;
using Xamarin.Forms;

namespace NSEC.Music_Player.Logic
{
    public class TrackProcessing
    {
        private static string CurrentTag { get; set; }
        private static ObservableCollection<Track> Items { get; set; }
        private static Page View { get; set; }
        private static bool Playlist { get; set; }
        private static string PlaylistName { get; set; }
        public static void Process(object sender,ObservableCollection<Track> items, Page view)
        {
            Process(sender, items, view, false,"");
        }

        public static void Process(object sender,ObservableCollection<Track> items,Page view, bool playlist, string playlistName)
        {
            ObservableCollection<string> menuItems = new ObservableCollection<string>();
            CustomButton button = (CustomButton)sender;
            Console.WriteLine("BUTTON TAG: " + button.Tag);

            menuItems.Add("Dodaj do kolejki");
            menuItems.Add("Dodaj do playlisty");
            menuItems.Add("Usuń");

            CurrentTag = button.Tag;
            Items = items;
            View = view;
            Playlist = playlist;
            PlaylistName = playlistName;
            PopupMenu menu = new PopupMenu();
            menu.ItemsSource = menuItems;
            menu.OnItemSelected += Menu_OnItemSelected;

            menu.ShowPopup((View)sender);
        }

        private static async void Menu_OnItemSelected(string item)
        {
            Console.WriteLine(CurrentTag);
            Console.WriteLine(item);
            Track track = Helpers.FindTrackByTag(Items, CurrentTag);
            if (item == "Usuń")
            {
                bool answer = await View.DisplayAlert("Pytanko", "Usunąć plik " + track.Text + (Playlist ? " z playlisty?" : "?"), "Tak", "Nie");
                if (answer)
                {
                    if(!Playlist)
                    {
                        File.Delete(track.Container.FilePath);
                        
                    }

                    ObservableCollection<Track> observableTracks = new ObservableCollection<Track>(Global.Playlists[PlaylistName]);
                    Helpers.RemoveTrack(track.Container.FilePath, Playlist,observableTracks);

                    if (Playlist)
                        Global.Playlists[PlaylistName] = observableTracks.ToList();


                    foreach (Track tr in Items)
                    {
                        if (tr.Container.FilePath == track.Container.FilePath)
                        {
                            Items.Remove(tr);
                            break;
                        }
                    }

                    Global.SaveConfig();
                    var view = ((Activity)Forms.Context).FindViewById(Android.Resource.Id.Content);
                    var snack = Snackbar.Make(view, "Usunięto", Snackbar.LengthLong);
                    snack.Show();
                }
            }
            else if (item == "Dodaj do playlisty")
            {
                List<string> positions = new List<string>();
                positions.Add("Nowa playlista");
                foreach (string playlist in Global.Playlists.Keys)
                    positions.Add(playlist);

                string answer = await View.DisplayActionSheet("Wybierz playlistę", "Anuluj", null, positions.ToArray());
                Console.WriteLine("ANSWER " + answer);

                if (answer == "Nowa playlista")
                {
                    string playlistName = await View.DisplayPromptAsync("Nowa playlista", "Wprowadź nazwę playlisty", "Dodaj", "Anuluj", "Playlista");

                    if (!string.IsNullOrEmpty(playlistName))
                    {
                        if (Global.Playlists.ContainsKey(playlistName))
                            Global.Playlists[playlistName].Add(track);
                        else
                            Global.Playlists.Add(playlistName, new List<Track>() { track });

                        Global.SaveConfig();

                        var view = ((Activity)Forms.Context).FindViewById(Android.Resource.Id.Content);
                        var snack = Snackbar.Make(view, "Dodano do nowej playlisty", Snackbar.LengthLong);
                        snack.Show();
                    }
                }
                else if (Global.Playlists.ContainsKey(answer))
                {
                    bool contains = false;

                    foreach (Track playlistTrack in Global.Playlists[answer])
                    {
                        if (playlistTrack.Container.FilePath == track.Container.FilePath)
                        {
                            contains = true;
                            break;
                        }
                    }
                    if (!contains)
                        Global.Playlists[answer].Add(track);
                    Global.SaveConfig();

                    var view = ((Activity)Forms.Context).FindViewById(Android.Resource.Id.Content);
                    var snack = Snackbar.Make(view, "Dodano do playlisty", Snackbar.LengthLong);
                    snack.Show();
                }
            }
            else if(item == "Dodaj do kolejki")
            {
                if (!Global.CurrentQueue.Contains(track))
                    Global.CurrentQueue.Add(track);

                var view = ((Activity)Forms.Context).FindViewById(Android.Resource.Id.Content);
                var snack = Snackbar.Make(view, "Dodano do kolejki", Snackbar.LengthLong);
                snack.Show();
            }
        }
    }
}