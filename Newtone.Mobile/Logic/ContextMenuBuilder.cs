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
                var track = GlobalData.Current.Audios[filePath];

                if (track == null)
                    SnackbarBuilder.Show(Localization.SnackFileExists);

                if (item == Localization.TrackMenuEdit)
                {
                    string title;
                    string artist;

                    if (GlobalData.Current.AudioTags.ContainsKey(filePath))
                    {
                        artist = GlobalData.Current.AudioTags[filePath].Author;
                        title = GlobalData.Current.AudioTags[filePath].Title;
                    }
                    else
                    {
                        artist = GlobalData.Current.Audios[filePath].Artist;
                        title = GlobalData.Current.Audios[filePath].Title;
                    }

                    string userArtist = await page.DisplayPromptAsync(Localization.Artist, artist, "OK", Localization.Cancel, artist, -1, null, artist);
                    string userTitle = await page.DisplayPromptAsync(Localization.Title, title, "OK", Localization.Cancel, title, -1, null, title);

                    if (userArtist != null && userTitle != null)
                    {
                        if (!GlobalData.Current.AudioTags.ContainsKey(filePath))
                        {
                            GlobalData.Current.AudioTags.Add(filePath, new Newtone.Core.Media.MediaSourceTag() { Author = userArtist, Title = userTitle });
                        }

                        GlobalData.Current.AudioTags[filePath].Author = userArtist;
                        GlobalData.Current.AudioTags[filePath].Title = userTitle;
                        var newSource = GlobalData.Current.Audios[filePath].Clone();
                        newSource.Title = userTitle;
                        newSource.Artist = userArtist;
                        GlobalLoader.ChangeTrack(GlobalData.Current.Audios[filePath], newSource);
                        GlobalData.Current.SaveTags();
                        SnackbarBuilder.Show(Localization.Ready);
                        GlobalData.Current.TracksNeedRefresh = true;
                    }

                }
                else if (item == Localization.TrackMenuPlaylist)
                {
                    List<string> positions = new List<string>()
                {
                    Localization.NewPlaylist
                };

                    foreach (string playlist in GlobalData.Current.Playlists.Keys)
                        positions.Add(playlist);

                    string answer = await page.DisplayActionSheet(Localization.ChoosePlaylist, Localization.Cancel, null, positions.ToArray());

                    if (answer == Localization.NewPlaylist)
                    {
                        string playlist = await page.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel, Localization.Playlist, -1, null, Localization.NewPlaylist);

                        if (!string.IsNullOrEmpty(playlist))
                        {
                            if (GlobalData.Current.Playlists.ContainsKey(playlist))
                                GlobalData.Current.Playlists[playlist].Add(track.FilePath);
                            else
                                GlobalData.Current.Playlists.Add(playlist, new List<string>() { track.FilePath });

                            GlobalData.Current.PlaylistsNeedRefresh = true;
                            GlobalData.Current.SaveConfig();

                            SnackbarBuilder.Show(Localization.SnackPlaylist);
                        }
                    }
                    else if (GlobalData.Current.Playlists.ContainsKey(answer))
                    {
                        if (!GlobalData.Current.Playlists[answer].Contains(filePath))
                            GlobalData.Current.Playlists[answer].Add(filePath);

                        GlobalData.Current.SaveConfig();
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

                            if (GlobalData.Current.Artists[track.Artist].Contains(track.FilePath))
                                GlobalData.Current.Artists[track.Artist].Remove(track.FilePath);

                            if (GlobalData.Current.Artists[track.Artist].Count == 0)
                            {
                                GlobalData.Current.Artists.Remove(track.Artist);
                                GlobalData.Current.ArtistsNeedRefresh = true;
                            }

                            GlobalData.Current.Audios.Remove(filePath);
                            GlobalData.Current.TracksNeedRefresh = true;

                            foreach (var playlist in GlobalData.Current.Playlists.Keys)
                            {
                                if (GlobalData.Current.Playlists[playlist].Contains(filePath))
                                {
                                    GlobalData.Current.Playlists[playlist].Remove(filePath);
                                    GlobalData.Current.PlaylistsNeedRefresh = true;
                                }
                            }
                        }
                        else
                        {
                            if (GlobalData.Current.Playlists[playlistName].Contains(filePath))
                            {
                                GlobalData.Current.Playlists[playlistName].Remove(filePath);
                                GlobalData.Current.PlaylistsNeedRefresh = true;
                            }
                        }

                        GlobalData.Current.SaveConfig();
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
                    SyncProcessing.AddFiles(GlobalData.Current.Playlists[playlistName]);
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
                    if (GlobalData.Current.Playlists[playlistName].Count > 0)
                    {
                        GlobalData.Current.CurrentPlaylist.Clear();

                        foreach (var track in GlobalData.Current.Playlists[playlistName])
                        {
                            GlobalData.Current.CurrentPlaylist.Add(GlobalData.Current.Audios[track]);
                        }

                        GlobalData.Current.PlaylistPosition = 0;
                        GlobalData.Current.MediaPlayer.Load(GlobalData.Current.CurrentPlaylist[0].FilePath);
                        GlobalData.Current.MediaSource = GlobalData.Current.CurrentPlaylist[0];
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

                    foreach (string playlist in GlobalData.Current.Playlists.Keys)
                        positions.Add(playlist);

                    string answer = await page.DisplayActionSheet(Localization.ChoosePlaylist, Localization.Cancel, null, positions.ToArray());

                    if (answer == Localization.NewPlaylist)
                    {
                        string playlist = await page.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel, Localization.Playlist, -1, null, Localization.NewPlaylist);

                        if (!string.IsNullOrEmpty(playlist))
                        {
                            foreach(var playlistItem in GlobalData.Current.Playlists[playlistName])
                            {
                                if (GlobalData.Current.Playlists.ContainsKey(playlist))
                                    GlobalData.Current.Playlists[playlist].Add(playlistItem);
                                else
                                    GlobalData.Current.Playlists.Add(playlist, new List<string>() { playlistItem });
                            }

                            GlobalData.Current.SaveConfig();

                            SnackbarBuilder.Show(Localization.SnackPlaylist);
                        }
                    }
                    else if (GlobalData.Current.Playlists.ContainsKey(answer))
                    {
                        foreach (var playlistItem in GlobalData.Current.Playlists[playlistName])
                        {
                            if (!GlobalData.Current.Playlists[answer].Contains(playlistItem))
                                GlobalData.Current.Playlists[answer].Add(playlistItem);
                        }
                        

                        GlobalData.Current.SaveConfig();
                    }

                    (sender as PlaylistGridItem).Page.Init();
                }
                else if(item == Localization.SyncAdd)
                {
                    SyncProcessing.AddFiles(GlobalData.Current.Playlists[playlistName]);
                    SnackbarBuilder.Show(Localization.Ready);

                    (sender as PlaylistGridItem).Page.Init();
                }
                if(item == Localization.ChangeName)
                {
                    string answer = await NormalPage.Instance.DisplayPromptAsync(Localization.ChangeName, Localization.NewPlaylistHint, "OK", Localization.Cancel, Localization.NewPlaylistHint, -1, null, playlistName);
                    if(!string.IsNullOrEmpty(answer))
                    {
                        if (GlobalData.Current.Playlists.ContainsKey(answer))
                            SnackbarBuilder.Show(Localization.PlaylistExists);
                        else
                        {
                            GlobalData.Current.Playlists.Add(answer, new List<string>(GlobalData.Current.Playlists[playlistName]));
                            GlobalData.Current.Playlists.Remove(playlistName);

                            if(GlobalData.Current.WebToLocalPlaylists.ContainsValue(playlistName))
                            {
                                var key = GlobalData.Current.WebToLocalPlaylists.Where(keyPair =>
                                {
                                    return keyPair.Value == playlistName;
                                }).First().Key;

                                if (GlobalData.Current.WebToLocalPlaylists.ContainsKey(key))
                                    GlobalData.Current.WebToLocalPlaylists[key] = answer;

                            }
                            GlobalData.Current.SaveConfig();
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
                        GlobalData.Current.Playlists.Remove(playlistName);

                        if (GlobalData.Current.WebToLocalPlaylists.ContainsValue(playlistName))
                        {
                            var key = GlobalData.Current.WebToLocalPlaylists.Where(keyPair =>
                            {
                                return keyPair.Value == playlistName;
                            }).First().Key;

                            if (GlobalData.Current.WebToLocalPlaylists.ContainsKey(key))
                                GlobalData.Current.WebToLocalPlaylists.Remove(key);

                        }

                        GlobalData.Current.SaveConfig();
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
                    if (GlobalData.Current.Artists[artistName].Count > 0)
                    {
                        GlobalData.Current.CurrentPlaylist.Clear();

                        foreach (var track in GlobalData.Current.Artists[artistName])
                        {
                            GlobalData.Current.CurrentPlaylist.Add(GlobalData.Current.Audios[track]);
                        }

                        GlobalData.Current.PlaylistPosition = 0;
                        GlobalData.Current.MediaPlayer.Load(GlobalData.Current.CurrentPlaylist[0].FilePath);
                        GlobalData.Current.MediaSource = GlobalData.Current.CurrentPlaylist[0];
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

                    foreach (string playlist in GlobalData.Current.Playlists.Keys)
                        positions.Add(playlist);

                    string answer = await page.DisplayActionSheet(Localization.ChoosePlaylist, Localization.Cancel, null, positions.ToArray());

                    if (answer == Localization.NewPlaylist)
                    {
                        string playlist = await page.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel, Localization.Playlist, -1, null, Localization.NewPlaylist);

                        if (!string.IsNullOrEmpty(playlist))
                        {
                            foreach (var playlistItem in GlobalData.Current.Artists[artistName])
                            {
                                if (GlobalData.Current.Playlists.ContainsKey(playlist))
                                    GlobalData.Current.Playlists[playlist].Add(playlistItem);
                                else
                                    GlobalData.Current.Playlists.Add(playlist, new List<string>() { playlistItem });
                            }

                            GlobalData.Current.SaveConfig();

                            SnackbarBuilder.Show(Localization.SnackPlaylist);
                        }
                    }
                    else if (GlobalData.Current.Playlists.ContainsKey(answer))
                    {
                        foreach (var playlistItem in GlobalData.Current.Artists[artistName])
                        {
                            if (!GlobalData.Current.Playlists[answer].Contains(playlistItem))
                                GlobalData.Current.Playlists[answer].Add(playlistItem);
                        }


                        GlobalData.Current.SaveConfig();
                    }

                    (sender as ArtistGridItem).Page.Init();
                }
                else if (item == Localization.SyncAdd)
                {
                    SyncProcessing.AddFiles(GlobalData.Current.Artists[artistName]);
                    SnackbarBuilder.Show(Localization.Ready);
                }
            };
            menu.Show();
        }
        #endregion
    }
}