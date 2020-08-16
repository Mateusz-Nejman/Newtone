using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Languages;
using Newtone.Mobile.Views;
using Newtone.Mobile.Views.Custom;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Newtone.Core.Processing;
using Newtone.Mobile.Media;
using Newtone.Mobile.Views.ViewCells;
using Newtone.Mobile.ViewModels.ViewCells;
using Newtone.Core.Logic;
using System.Linq;

namespace Newtone.Mobile.Logic
{
    public static class ContextMenuBuilder
    {
        #region Properties
        private static string CurrentModelInfo { get; set; }
        #endregion
        #region Public Methods
        public static void BuildForTrack(Xamarin.Forms.View sender, string modelInfo)
        {
            CurrentModelInfo = modelInfo;

            string[] elems = CurrentModelInfo.Split(GlobalData.SEPARATOR, System.StringSplitOptions.None);
            string filePath = elems[0];
            string playlistName = elems[1];

            List<string> menuItems = new List<string>() { Localization.TrackMenuEdit, Localization.TrackMenuPlaylist, Localization.SyncAdd };
            if (!string.IsNullOrEmpty(playlistName))
                menuItems.Add(Localization.SyncAddPlaylist);

            menuItems.Add(Localization.TrackMenuDelete);

            PopupMenu menu = new PopupMenu(MainActivity.Instance, (View)sender, menuItems.ToArray());
            menu.OnSelect += async(item) =>
            {
                Page page = NormalPage.Instance;
                string[] elems = CurrentModelInfo.Split(GlobalData.SEPARATOR, System.StringSplitOptions.None);
                string filePath = elems[0];
                string playlistName = elems[1];

                var track = GlobalData.Audios[filePath];

                if (track == null)
                    SnackbarBuilder.Show(Localization.SnackFileExists);

                if (item == Localization.TrackMenuEdit)
                {
                    string title;
                    string artist;

                    if (GlobalData.AudioTags.ContainsKey(filePath))
                    {
                        artist = GlobalData.AudioTags[filePath].Author;
                        title = GlobalData.AudioTags[filePath].Title;
                    }
                    else
                    {
                        artist = GlobalData.Audios[filePath].Artist;
                        title = GlobalData.Audios[filePath].Title;
                    }

                    string userArtist = await page.DisplayPromptAsync(Localization.Artist, artist, "OK", Localization.Cancel, artist, -1, null, artist);
                    string userTitle = await page.DisplayPromptAsync(Localization.Title, title, "OK", Localization.Cancel, title, -1, null, title);

                    if (userArtist != null && userTitle != null)
                    {
                        if (!GlobalData.AudioTags.ContainsKey(filePath))
                        {
                            GlobalData.AudioTags.Add(filePath, new Newtone.Core.Media.MediaSourceTag() { Author = userArtist, Title = userTitle });
                        }

                        GlobalData.AudioTags[filePath].Author = userArtist;
                        GlobalData.AudioTags[filePath].Title = userTitle;
                        var newSource = GlobalData.Audios[filePath].Clone();
                        newSource.Title = userTitle;
                        newSource.Artist = userArtist;
                        GlobalLoader.ChangeTrack(GlobalData.Audios[filePath], newSource);
                        GlobalData.SaveTags();
                        SnackbarBuilder.Show(Localization.Ready);
                    }

                }
                else if (item == Localization.TrackMenuPlaylist)
                {
                    List<string> positions = new List<string>()
                {
                    Localization.NewPlaylist
                };

                    foreach (string playlist in GlobalData.Playlists.Keys)
                        positions.Add(playlist);

                    string answer = await page.DisplayActionSheet(Localization.ChoosePlaylist, Localization.Cancel, null, positions.ToArray());

                    if (answer == Localization.NewPlaylist)
                    {
                        string playlist = await page.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel, Localization.Playlist, -1, null, Localization.NewPlaylist);

                        if (!string.IsNullOrEmpty(playlist))
                        {
                            if (GlobalData.Playlists.ContainsKey(playlist))
                                GlobalData.Playlists[playlist].Add(track.FilePath);
                            else
                                GlobalData.Playlists.Add(playlist, new List<string>() { track.FilePath });

                            GlobalData.SaveConfig();

                            SnackbarBuilder.Show(Localization.SnackPlaylist);
                        }
                    }
                    else if (GlobalData.Playlists.ContainsKey(answer))
                    {
                        if (!GlobalData.Playlists[answer].Contains(filePath))
                            GlobalData.Playlists[answer].Add(filePath);

                        GlobalData.SaveConfig();
                    }

                }
                else if (item == Localization.TrackMenuDelete)
                {
                    bool answer = await page.DisplayAlert(Localization.Question, Localization.QuestionDelete + " " + track.Title + (playlistName != "" ? " " + Localization.QuestionDeleteFromPlaylist + "?" : "?"), Localization.Yes, Localization.No);

                    if (answer)
                    {
                        if (playlistName == "")
                        {
                            if (File.Exists(filePath))
                                File.Delete(filePath);

                            if (GlobalData.Artists[track.Artist].Contains(track.FilePath))
                                GlobalData.Artists[track.Artist].Remove(track.FilePath);

                            if (GlobalData.Artists[track.Artist].Count == 0)
                                GlobalData.Artists.Remove(track.Artist);

                            foreach (var playlist in GlobalData.Playlists.Keys)
                            {
                                if (GlobalData.Playlists[playlist].Contains(filePath))
                                    GlobalData.Playlists[playlist].Remove(filePath);
                            }
                        }
                        else
                        {
                            if (GlobalData.Playlists[playlistName].Contains(filePath))
                                GlobalData.Playlists[playlistName].Remove(filePath);
                        }

                        GlobalData.SaveConfig();
                        SnackbarBuilder.Show(Localization.Ready);
                    }
                }
                else if (item == Localization.SyncAdd)
                {
                    SyncProcessing.AddFile(filePath);
                    SnackbarBuilder.Show(Localization.Ready);
                }
                else if (item == Localization.SyncAddPlaylist)
                {
                    SyncProcessing.AddFiles(GlobalData.Playlists[playlistName]);
                    SnackbarBuilder.Show(Localization.Ready);
                }
            };
            menu.Show();
        }

        public static void BuildForSyncList(View sender, string modelInfo)
        {
            CurrentModelInfo = modelInfo;
            
            PopupMenu menu = new PopupMenu(MainActivity.Instance, sender, Localization.TrackMenuDelete, Localization.Clear);
            menu.OnSelect += item =>
            {
                string[] elems = CurrentModelInfo.Split(GlobalData.SEPARATOR, System.StringSplitOptions.None);
                string filePath = elems[0];

                if (item == Localization.TrackMenuDelete)
                    SyncProcessing.Audios.Remove(filePath);
                else if (item == Localization.Clear)
                    SyncProcessing.Audios.Clear();
            };
            menu.Show();
        }

        public static void BuildForPlaylist(View sender, string playlistName)
        {
            PopupMenu menu = new PopupMenu(MainActivity.Instance, sender, Localization.PlaylistPlay, Localization.TrackMenuPlaylist, Localization.SyncAdd, Localization.ChangeName, Localization.TrackMenuDelete);
            menu.OnSelect += async(item) =>
            {
                if(item == Localization.PlaylistPlay)
                {
                    if (GlobalData.Playlists[playlistName].Count > 0)
                    {
                        GlobalData.CurrentPlaylist.Clear();

                        foreach (var track in GlobalData.Playlists[playlistName])
                        {
                            GlobalData.CurrentPlaylist.Add(GlobalData.Audios[track]);
                        }

                        GlobalData.PlaylistPosition = 0;
                        GlobalData.MediaPlayer.Load(GlobalData.CurrentPlaylist[0].FilePath);
                        GlobalData.MediaSource = GlobalData.CurrentPlaylist[0];
                        MediaPlayerHelper.Play();
                    }
                }
                else if(item == Localization.TrackMenuPlaylist)
                {
                    Page page = NormalPage.Instance;
                    List<string> positions = new List<string>()
                {
                    Localization.NewPlaylist
                };

                    foreach (string playlist in GlobalData.Playlists.Keys)
                        positions.Add(playlist);

                    string answer = await page.DisplayActionSheet(Localization.ChoosePlaylist, Localization.Cancel, null, positions.ToArray());

                    if (answer == Localization.NewPlaylist)
                    {
                        string playlist = await page.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel, Localization.Playlist, -1, null, Localization.NewPlaylist);

                        if (!string.IsNullOrEmpty(playlist))
                        {
                            foreach(var playlistItem in GlobalData.Playlists[playlistName])
                            {
                                if (GlobalData.Playlists.ContainsKey(playlist))
                                    GlobalData.Playlists[playlist].Add(playlistItem);
                                else
                                    GlobalData.Playlists.Add(playlist, new List<string>() { playlistItem });
                            }

                            GlobalData.SaveConfig();

                            SnackbarBuilder.Show(Localization.SnackPlaylist);
                        }
                    }
                    else if (GlobalData.Playlists.ContainsKey(answer))
                    {
                        foreach (var playlistItem in GlobalData.Playlists[playlistName])
                        {
                            if (!GlobalData.Playlists[answer].Contains(playlistItem))
                                GlobalData.Playlists[answer].Add(playlistItem);
                        }
                        

                        GlobalData.SaveConfig();
                    }

                    (sender as PlaylistGridItem).Page.Init();
                }
                else if(item == Localization.SyncAdd)
                {
                    SyncProcessing.AddFiles(GlobalData.Playlists[playlistName]);
                    SnackbarBuilder.Show(Localization.Ready);

                    (sender as PlaylistGridItem).Page.Init();
                }
                if(item == Localization.ChangeName)
                {
                    string answer = await NormalPage.Instance.DisplayPromptAsync(Localization.ChangeName, Localization.NewPlaylistHint, "OK", Localization.Cancel, Localization.NewPlaylistHint, -1, null, playlistName);
                    if(!string.IsNullOrEmpty(answer))
                    {
                        if (GlobalData.Playlists.ContainsKey(answer))
                            SnackbarBuilder.Show(Localization.PlaylistExists);
                        else
                        {
                            GlobalData.Playlists.Add(answer, new List<string>(GlobalData.Playlists[playlistName]));
                            GlobalData.Playlists.Remove(playlistName);

                            if(GlobalData.WebToLocalPlaylists.ContainsValue(playlistName))
                            {
                                var key = GlobalData.WebToLocalPlaylists.Where(keyPair =>
                                {
                                    return keyPair.Value == playlistName;
                                }).First().Key;

                                if (GlobalData.WebToLocalPlaylists.ContainsKey(key))
                                    GlobalData.WebToLocalPlaylists[key] = answer;

                            }
                            GlobalData.SaveConfig();
                            (sender as PlaylistGridItem).Page.Init();
                            SnackbarBuilder.Show(Localization.Ready);
                        }
                    }
                }
                else if(item == Localization.TrackMenuDelete)
                {
                    bool answer = await NormalPage.Instance.DisplayAlert(Localization.Question, Localization.QuestionDeletePlaylist+" "+playlistName+"?", Localization.Yes, Localization.No);

                    if (answer)
                    {
                        GlobalData.Playlists.Remove(playlistName);

                        if (GlobalData.WebToLocalPlaylists.ContainsValue(playlistName))
                        {
                            var key = GlobalData.WebToLocalPlaylists.Where(keyPair =>
                            {
                                return keyPair.Value == playlistName;
                            }).First().Key;

                            if (GlobalData.WebToLocalPlaylists.ContainsKey(key))
                                GlobalData.WebToLocalPlaylists.Remove(key);

                        }

                        GlobalData.SaveConfig();
                        SnackbarBuilder.Show(Localization.Ready);

                        (sender as PlaylistGridItem).Page.Init();
                    }
                }
            };
            menu.Show();
        }

        public static void BuildForArtist(View sender, string artistName)
        {
            PopupMenu menu = new PopupMenu(MainActivity.Instance, sender, Localization.PlaylistPlay, Localization.TrackMenuPlaylist, Localization.SyncAdd);
            menu.OnSelect += async(item) =>
            {
                if (item == Localization.PlaylistPlay)
                {
                    if (GlobalData.Artists[artistName].Count > 0)
                    {
                        GlobalData.CurrentPlaylist.Clear();

                        foreach (var track in GlobalData.Artists[artistName])
                        {
                            GlobalData.CurrentPlaylist.Add(GlobalData.Audios[track]);
                        }

                        GlobalData.PlaylistPosition = 0;
                        GlobalData.MediaPlayer.Load(GlobalData.CurrentPlaylist[0].FilePath);
                        GlobalData.MediaSource = GlobalData.CurrentPlaylist[0];
                        MediaPlayerHelper.Play();
                    }
                }
                else if(item == Localization.TrackMenuPlaylist)
                {
                    Page page = NormalPage.Instance;
                    List<string> positions = new List<string>()
                {
                    Localization.NewPlaylist
                };

                    foreach (string playlist in GlobalData.Playlists.Keys)
                        positions.Add(playlist);

                    string answer = await page.DisplayActionSheet(Localization.ChoosePlaylist, Localization.Cancel, null, positions.ToArray());

                    if (answer == Localization.NewPlaylist)
                    {
                        string playlist = await page.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel, Localization.Playlist, -1, null, Localization.NewPlaylist);

                        if (!string.IsNullOrEmpty(playlist))
                        {
                            foreach (var playlistItem in GlobalData.Artists[artistName])
                            {
                                if (GlobalData.Playlists.ContainsKey(playlist))
                                    GlobalData.Playlists[playlist].Add(playlistItem);
                                else
                                    GlobalData.Playlists.Add(playlist, new List<string>() { playlistItem });
                            }

                            GlobalData.SaveConfig();

                            SnackbarBuilder.Show(Localization.SnackPlaylist);
                        }
                    }
                    else if (GlobalData.Playlists.ContainsKey(answer))
                    {
                        foreach (var playlistItem in GlobalData.Artists[artistName])
                        {
                            if (!GlobalData.Playlists[answer].Contains(playlistItem))
                                GlobalData.Playlists[answer].Add(playlistItem);
                        }


                        GlobalData.SaveConfig();
                    }

                    (sender as ArtistGridItem).Page.Init();
                }
                else if (item == Localization.SyncAdd)
                {
                    SyncProcessing.AddFiles(GlobalData.Artists[artistName]);
                    SnackbarBuilder.Show(Localization.Ready);
                }
            };
            menu.Show();
        }
        #endregion
    }
}