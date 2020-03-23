using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Loaders;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Views.Custom;
using Xamarin.Forms;
using MediaSource = NSEC.Music_Player.Media.MediaSource;

namespace NSEC.Music_Player.Processing
{
    public class TrackProcessing
    {
        private static string CurrentTag { get; set; }
        private static ObservableCollection<MediaSource> Items { get; set; }
        private static Page View { get; set; }
        private static bool Playlist { get; set; }
        private static string PlaylistName { get; set; }

        public static void Process(object sender, ObservableCollection<MediaSource> items, Page view)
        {
            Process(sender, items, view, false, "");
        }

        public static MediaSource GetTrack(string filepath)
        {
            return Global.Audios[filepath];
        }
        public static void Process(object sender, ObservableCollection<MediaSource> items, Page view, bool playlist, string playlistName)
        {
            if(sender is CustomButton)
            {
                CustomButton button = (CustomButton)sender;

                CurrentTag = button.Tag;
            }
            else
            {
                IconView button = (IconView)sender;
                CurrentTag = button.Tag;
            }
            
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
            MediaSource track = Global.Audios[CurrentTag];

            if (track == null)
                SnackbarBuilder.Show(Localization.SnackFileExists);
            else
            {
                if (item == Localization.TrackMenuDelete)
                {
                    bool answer = await View.DisplayAlert(Localization.Question, Localization.QuestionDelete + " " + track.Title + (Playlist ? " " + Localization.QuestionDeleteFromPlaylist + "?" : "?"), Localization.Yes, Localization.No);
                    if (answer)
                    {
                        if (!Playlist)
                        {
                            File.Delete(track.FilePath);

                            if (Global.Artists[track.Artist].Contains(track.FilePath))
                                Global.Artists[track.Artist].Remove(track.FilePath);

                            if (Global.Artists[track.Artist].Count == 0)
                                Global.Artists.Remove(track.Artist);
                        }

                        if (Global.Playlists.ContainsKey(PlaylistName))
                        {
                            ObservableCollection<string> observableTracks = new ObservableCollection<string>(Global.Playlists[PlaylistName]);
                            GlobalLoader.RemoveTrack(track.FilePath, Playlist, observableTracks);

                            if (Playlist)
                                Global.Playlists[PlaylistName] = observableTracks.ToList();


                            foreach (MediaSource tr in Items)
                            {
                                if (tr.FilePath == track.FilePath)
                                {
                                    Items.Remove(tr);
                                    break;
                                }
                            }
                        }

                        if (Global.Audios.ContainsKey(track.FilePath))
                            Global.Audios.Remove(track.FilePath);


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

                    if (answer == Localization.NewPlaylist)
                    {
                        string playlistName = await View.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel, Localization.Playlist,-1,null,Localization.NewPlaylist);

                        if (!string.IsNullOrEmpty(playlistName))
                        {
                            if (Global.Playlists.ContainsKey(playlistName))
                                Global.Playlists[playlistName].Add(track.FilePath);
                            else
                                Global.Playlists.Add(playlistName, new List<string>() { track.FilePath });

                            Global.SaveConfig();

                            SnackbarBuilder.Show(Localization.SnackPlaylist);
                        }
                    }
                    else if (Global.Playlists.ContainsKey(answer))
                    {
                        bool contains = false;

                        foreach (string filepath in Global.Playlists[answer])
                        {
                            MediaSource playlistTrack = Global.Audios[filepath];
                            if (playlistTrack.FilePath == track.FilePath)
                            {
                                contains = true;
                                break;
                            }
                        }
                        if (!contains)
                            Global.Playlists[answer].Add(track.FilePath);
                        Global.SaveConfig();

                        SnackbarBuilder.Show(Localization.SnackPlaylist);
                    }
                }
                else if (item == Localization.TrackMenuQueue)
                {
                    if (Global.CurrentQueue.Count == 0)
                        Global.QueuePosition = -1;
                    if (!Global.CurrentQueue.Contains(track))
                        Global.CurrentQueue.Add(track);

                    SnackbarBuilder.Show(Localization.SnackQueue);
                }
                else if (item == Localization.TrackMenuEdit)
                {
                    string title;
                    //Zmiany będą widoczne po ponownym uruchomieniu aplikacji

                    string artist;
                    if (Global.AudioTags.ContainsKey(track.FilePath))
                    {
                        artist = Global.AudioTags[track.FilePath].Author;
                        title = Global.AudioTags[track.FilePath].Title;
                    }
                    else
                    {
                        artist = Global.Audios[track.FilePath].Artist;
                        title = Global.Audios[track.FilePath].Title;
                        FileInfo fileInfo = new FileInfo(track.FilePath);
                    }



                    string userArtist = await View.DisplayPromptAsync(Localization.Artist, artist, "OK", Localization.Cancel, artist,-1,null,artist);
                    string userTitle = await View.DisplayPromptAsync(Localization.Title, title, "OK", Localization.Cancel, title,-1,null,title);

                    if (userArtist != null && userTitle != null)
                    {
                        userArtist = userArtist == "" ? artist : userArtist;
                        userTitle = userTitle == "" ? title : userTitle;

                        if (Global.AudioTags.ContainsKey(track.FilePath))
                        {
                            Global.AudioTags[track.FilePath].Author = userArtist;
                            Global.AudioTags[track.FilePath].Title = userTitle;
                        }
                        else
                        {
                            Global.AudioTags.Add(track.FilePath, new Media.MediaSourceTag() { Author = userArtist, Title = userTitle });
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