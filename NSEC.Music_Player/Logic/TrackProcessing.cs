using Android.App;
using Android.Support.Design.Widget;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.CustomViews;
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

        public static void Process(object sender, ObservableCollection<Track> items, Page view)
        {
            Process(sender, items, view, false, "");
        }

        public static Track GetTrack(string filepath)
        {
            MediaProcessing.MediaTag container = Global.Audios[filepath];
            return new Track()
            {
                Container = container,
                Id = container.FilePath
            };
        }
        public static void Process(object sender, ObservableCollection<Track> items, Page view, bool playlist, string playlistName)
        {
            CustomButton button = (CustomButton)sender;
            Console.WriteLine("BUTTON TAG: " + button.Tag);

            CurrentTag = button.Tag;
            Items = items;
            View = view;
            Playlist = playlist;
            PlaylistName = playlistName;
            PopupMenu menu = new PopupMenu(Global.Context, (View)sender, Localization.TrackMenuQueue, Localization.TrackMenuPlaylist, Localization.TrackMenuDelete, Localization.TrackMenuEdit);
            menu.OnSelect += Menu_OnItemSelected;

            menu.Show();
        }

        private static async void Menu_OnItemSelected(string item)
        {
            Console.WriteLine("TrackProcessing item " + item);
            Console.WriteLine(CurrentTag);
            Console.WriteLine(item);
            Track track = Helpers.FindTrackByTag(Items, CurrentTag);

            if (track == null)
                SnackbarBuilder.Show(Localization.SnackFileExists);
            else
            {
                if (item == Localization.TrackMenuDelete)
                {
                    bool answer = await View.DisplayAlert(Localization.Question, Localization.QuestionDelete + " " + track.Text + (Playlist ? " " + Localization.QuestionDeleteFromPlaylist + "?" : "?"), Localization.Yes, Localization.No);
                    if (answer)
                    {
                        if (!Playlist)
                        {
                            File.Delete(track.Container.FilePath);

                            if (Global.Artists[track.Container.Artist].Contains(track.Container.FilePath))
                                Global.Artists[track.Container.Artist].Remove(track.Container.FilePath);

                            if (Global.Artists[track.Container.Artist].Count == 0)
                                Global.Artists.Remove(track.Container.Artist);
                        }

                        if (Global.Playlists.ContainsKey(PlaylistName))
                        {
                            ObservableCollection<Track> observableTracks = new ObservableCollection<Track>(Global.Playlists[PlaylistName]);
                            Helpers.RemoveTrack(track.Container.FilePath, Playlist, observableTracks);

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
                        }

                        if (Global.Audios.ContainsKey(track.Container.FilePath))
                            Global.Audios.Remove(track.Container.FilePath);


                        Global.SaveConfig();
                        SnackbarBuilder.Show(Localization.SnackDelete);
                    }
                }
                else if (item == Localization.TrackMenuPlaylist)
                {
                    List<string> positions = new List<string>
                {
                    Localization.NewPlaylist
                };
                    foreach (string playlist in Global.Playlists.Keys)
                        positions.Add(playlist);

                    string answer = await View.DisplayActionSheet(Localization.ChoosePlaylist, Localization.Cancel, null, positions.ToArray());
                    Console.WriteLine("ANSWER " + answer);

                    if (answer == Localization.NewPlaylist)
                    {
                        string playlistName = await View.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel, Localization.Playlist);

                        if (!string.IsNullOrEmpty(playlistName))
                        {
                            if (Global.Playlists.ContainsKey(playlistName))
                                Global.Playlists[playlistName].Add(track);
                            else
                                Global.Playlists.Add(playlistName, new List<Track>() { track });

                            Global.SaveConfig();

                            SnackbarBuilder.Show(Localization.SnackPlaylist);
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

                        SnackbarBuilder.Show(Localization.SnackPlaylist);
                    }
                }
                else if (item == Localization.TrackMenuQueue)
                {
                    if (Global.CurrentQueue.Count == 0)
                        Global.CurrentQueuePosition = -1;
                    if (!Global.CurrentQueue.Contains(track))
                        Global.CurrentQueue.Add(track);

                    SnackbarBuilder.Show(Localization.SnackQueue);
                }
                else if (item == Localization.TrackMenuEdit)
                {
                    string title;
                    //Zmiany będą widoczne po ponownym uruchomieniu aplikacji

                    string artist;
                    if (Global.AudioTags.ContainsKey(track.Container.FilePath))
                    {
                        artist = Global.AudioTags[track.Container.FilePath].Artist;
                        title = Global.AudioTags[track.Container.FilePath].Title;
                    }
                    else
                    {
                        artist = Global.Audios[track.Container.FilePath].Artist;
                        title = Global.Audios[track.Container.FilePath].Title;
                        FileInfo fileInfo = new FileInfo(track.Container.FilePath);
                    }



                    string userArtist = await View.DisplayPromptAsync(Localization.Artist, artist, "OK", Localization.Cancel, artist);
                    string userTitle = await View.DisplayPromptAsync(Localization.Title, title, "OK", Localization.Cancel, title);

                    if (userArtist != null && userTitle != null)
                    {
                        userArtist = userArtist == "" ? artist : userArtist;
                        userTitle = userTitle == "" ? title : userTitle;

                        if (Global.AudioTags.ContainsKey(track.Container.FilePath))
                        {
                            Global.AudioTags[track.Container.FilePath].Artist = userArtist;
                            Global.AudioTags[track.Container.FilePath].Title = userTitle;
                        }
                        else
                        {
                            Global.AudioTags.Add(track.Container.FilePath, new MediaProcessing.MediaTag() { Artist = userArtist, Title = userTitle });
                        }

                        Global.SaveTags();

                        SnackbarBuilder.Show(Localization.SettingsChanges);
                    }
                }
            }

            if (View is IInvokePage)
                ((IInvokePage)View).PageInvoke();

        }
    }
}