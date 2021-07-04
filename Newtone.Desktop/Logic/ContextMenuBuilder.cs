using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Loaders;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using Newtone.Desktop.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Controls;
using YoutubeExplode;
using YoutubeExplode.Common;

namespace Newtone.Desktop.Logic
{
    public static class ContextMenuBuilder
    {
        #region Properties
        private static string FilePath { get; set; }
        private static string Playlist { get; set; }
        private static string Artist { get; set; }
        private static string Tag { get; set; }
        #endregion
        #region Public Methods
        public static ContextMenu BuildForTrack(string filePath, string playlist = "")
        {
            FilePath = filePath;
            Playlist = playlist;
            ContextMenu menu = new ContextMenu();

            MenuItem menuEdit = new MenuItem
            {
                Header = Localization.TrackMenuEdit
            };
            menuEdit.Click += MenuEdit_Click;

            MenuItem menuDownload = new MenuItem
            { 
                Header = Localization.Download
            };
            menuDownload.Click += MenuDownload_Click;

            if (filePath.Length == 11)
                menu.Items.Add(menuDownload);
            else
                menu.Items.Add(menuEdit);

            MenuItem itemNew = new MenuItem
            {
                Header = Localization.NewPlaylist
            };
            itemNew.Click += ItemNew_Click;
            MenuItem menuAdd = new MenuItem
            {
                Header = Localization.TrackMenuPlaylist
            };
            menuAdd.Items.Add(itemNew);
            foreach (var item in GlobalData.Current.Playlists.Keys)
            {
                MenuItem playlistItem = new MenuItem
                {
                    Header = item
                };
                playlistItem.Click += (sender, e) =>
                {
                    if (!GlobalData.Current.Playlists[item].Contains(FilePath))
                        GlobalData.Current.Playlists[item].Add(FilePath);

                    GlobalData.Current.SaveConfig();
                    GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar,Localization.SnackPlaylist);
                    GlobalData.Current.PlaylistsNeedRefresh = true;
                };
                menuAdd.Items.Add(playlistItem);
            }

            MenuItem menuQueue = new MenuItem
            {
                Header = Localization.TrackMenuQueue
            };
            menuQueue.Click += MenuQueue_Click;

            MenuItem menuDelete = new MenuItem
            {
                Header = Localization.TrackMenuDelete
            };
            menuDelete.Click += MenuDelete_Click;

            menu.Items.Add(menuAdd);
            menu.Items.Add(menuQueue);
            menu.Items.Add(menuDelete);

            return menu;
        }

        public static ContextMenu BuildForLanguage()
        {
            ContextMenu menu = new ContextMenu();

            MenuItem menuLangPL = new MenuItem
            {
                Header = Localization.LanguagePL
            };
            menuLangPL.Click += (sender, e) => { GlobalData.Current.CurrentLanguage = "pl"; Localization.RefreshLanguage(); SnackbarBuilder.Show(Localization.SettingsChanges); GlobalData.Current.SaveConfig(); };
            MenuItem menuLangEN = new MenuItem
            {
                Header = Localization.LanguageEN
            };
            menuLangEN.Click += (sender, e) => { GlobalData.Current.CurrentLanguage = "en"; Localization.RefreshLanguage(); SnackbarBuilder.Show(Localization.SettingsChanges); GlobalData.Current.SaveConfig(); };
            MenuItem menuLangRU = new MenuItem
            {
                Header = Localization.LanguageRU
            };
            menuLangRU.Click += (sender, e) => { GlobalData.Current.CurrentLanguage = "ru"; Localization.RefreshLanguage(); SnackbarBuilder.Show(Localization.SettingsChanges); GlobalData.Current.SaveConfig(); };


            menu.Items.Add(menuLangPL);
            menu.Items.Add(menuLangEN);
            menu.Items.Add(menuLangRU);

            return menu;
        }

        public static ContextMenu BuildForIcon()
        {
            ContextMenu menu = new ContextMenu();

            MenuItem menuInfo = new MenuItem
            {
                Header = Localization.Informations,
            };
            menuInfo.Click += (sender, e) =>
            {
                AboutWindow about = new AboutWindow();
                about.CenterToMainWindow();
                about.ShowDialog();
            };
            menu.Items.Add(menuInfo);

            return menu;
        }

        public static ContextMenu BuildForPlaylist(string playlistName)
        {
            Playlist = playlistName;

            ContextMenu menu = new ContextMenu();

            MenuItem menuPlay = new MenuItem
            {
                Header = Localization.PlaylistPlay
            };
            menuPlay.Click += MenuPlaylistPlay_Click;

            MenuItem itemNew = new MenuItem
            {
                Header = Localization.NewPlaylist
            };
            itemNew.Click += PlaylistItemNew_Click;
            MenuItem menuAdd = new MenuItem
            {
                Header = Localization.TrackMenuPlaylist
            };
            menuAdd.Items.Add(itemNew);

            foreach (var item in GlobalData.Current.Playlists.Keys)
            {
                MenuItem playlistItem = new MenuItem
                {
                    Header = item
                };
                playlistItem.Click += (sender, e) =>
                {
                    foreach (var playlistItem in GlobalData.Current.Playlists[playlistName])
                    {
                        if (!GlobalData.Current.Playlists[item].Contains(playlistItem))
                            GlobalData.Current.Playlists[item].Add(playlistItem);
                    }

                    GlobalData.Current.SaveConfig();
                    GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.SnackPlaylist);
                    GlobalData.Current.PlaylistsNeedRefresh = true;
                };
                menuAdd.Items.Add(playlistItem);
            }

            MenuItem menuQueue = new MenuItem
            {
                Header = Localization.TrackMenuQueue
            };
            menuQueue.Click += MenuPlaylistQueue_Click;

            MenuItem menuChangeName = new MenuItem
            {
                Header = Localization.ChangeName
            };
            menuChangeName.Click += MenuPlaylistChangeName_Click;

            MenuItem menuDelete = new MenuItem
            {
                Header = Localization.TrackMenuDelete
            };
            menuDelete.Click += MenuPlaylistDelete_Click;

            menu.Items.Add(menuPlay);
            menu.Items.Add(menuAdd);
            menu.Items.Add(menuQueue);
            menu.Items.Add(menuChangeName);
            menu.Items.Add(menuDelete);

            return menu;
        }

        public static ContextMenu BuildForArtist(string artistName)
        {
            Artist = artistName;

            ContextMenu menu = new ContextMenu();

            MenuItem menuPlay = new MenuItem
            {
                Header = Localization.PlaylistPlay
            };
            menuPlay.Click += MenuArtistPlay_Click;

            MenuItem itemNew = new MenuItem
            {
                Header = Localization.NewPlaylist
            };
            itemNew.Click += ArtistItemNew_Click;
            MenuItem menuAdd = new MenuItem
            {
                Header = Localization.TrackMenuPlaylist
            };
            menuAdd.Items.Add(itemNew);

            foreach (var item in GlobalData.Current.Playlists.Keys)
            {
                MenuItem playlistItem = new MenuItem
                {
                    Header = item
                };
                playlistItem.Click += (sender, e) =>
                {
                    foreach (var playlistItem in GlobalData.Current.Artists[artistName])
                    {
                        if (!GlobalData.Current.Playlists[item].Contains(playlistItem))
                            GlobalData.Current.Playlists[item].Add(playlistItem);
                    }

                    GlobalData.Current.SaveConfig();
                    GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.SnackPlaylist);
                    GlobalData.Current.ArtistsNeedRefresh = true;
                };
                menuAdd.Items.Add(playlistItem);
            }

            MenuItem menuQueue = new MenuItem
            {
                Header = Localization.TrackMenuQueue
            };
            menuQueue.Click += MenuArtistQueue_Click;

            menu.Items.Add(menuPlay);
            menu.Items.Add(menuAdd);
            menu.Items.Add(menuQueue);

            return menu;
        }

        public static ContextMenu BuildForSeachResult(string tag)
        {
            Tag = tag;
            ContextMenu menu = new ContextMenu();

            MenuItem menuDownload = new MenuItem
            {
                Header = Localization.Download
            };
            menuDownload.Click += MenuSearchResultDownload_Click;

            MenuItem itemNew = new MenuItem
            {
                Header = Localization.NewPlaylist
            };
            itemNew.Click += MenuSearchResultNewItem_Click;
            MenuItem menuAdd = new MenuItem
            {
                Header = Localization.TrackMenuPlaylist
            };
            menuAdd.Items.Add(itemNew);

            foreach (var item in GlobalData.Current.Playlists.Keys)
            {
                MenuItem playlistItem = new MenuItem
                {
                    Header = item
                };
                playlistItem.Click += async(sender, e) =>
                {
                    string[] elems = Tag.Split(GlobalData.SEPARATOR);
                    var urlType = SearchProcessing.CheckLink(elems[1]);
                    await AddSavedTrack(Tag);

                    if (!GlobalData.Current.Playlists[item].Contains(urlType[SearchProcessing.Query.Video]))
                        GlobalData.Current.Playlists[item].Add(urlType[SearchProcessing.Query.Video]);

                    GlobalData.Current.PlaylistsNeedRefresh = true;
                    GlobalData.Current.SaveConfig();
                    GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.SnackPlaylist);
                };
                menuAdd.Items.Add(playlistItem);
            }

            menu.Items.Add(menuDownload);
            menu.Items.Add(menuAdd);

            return menu;
        }
        #endregion

        #region Private Methods
        private static async Task AddSavedTrack(string tag)
        {
            string[] elems = tag.Split(GlobalData.SEPARATOR);
            YoutubeClient client = new YoutubeClient();
            var urlType = SearchProcessing.CheckLink(elems[1]);

            if (!GlobalData.Current.SavedTracks.ContainsKey(urlType[SearchProcessing.Query.Video]))
            {
                var video = await client.Videos.GetAsync(urlType[SearchProcessing.Query.Video]);

                var mediaSource = new Core.Media.MediaSource()
                {
                    Artist = video.Author.Title,
                    Duration = video.Duration ?? TimeSpan.Zero,
                    FilePath = video.Id,
                    Title = video.Title,
                    Type = Core.Media.MediaSource.SourceType.Web
                };

                try
                {
                    using WebClient webClient = new WebClient();
                    byte[] thumbData = webClient.DownloadData(video.Thumbnails.FirstOrDefault().Url);
                    mediaSource.Image = thumbData;
                }
                catch
                {
                    //Ignore
                }

                GlobalData.Current.SavedTracks.Add(urlType[SearchProcessing.Query.Video], mediaSource);
                GlobalData.Current.SaveSavedTracks();
            }
        }
        private static async Task<MediaSource> GetMediaSource()
        {
            if (FilePath.Length == 11 && !GlobalData.Current.SavedTracks.ContainsKey(FilePath))
            {
                YoutubeClient client = new YoutubeClient();
                var video = await client.Videos.GetAsync(FilePath);

                var mediaSource = new Core.Media.MediaSource()
                {
                    Artist = video.Author.Title,
                    Duration = video.Duration ?? TimeSpan.Zero,
                    FilePath = video.Id,
                    Title = video.Title,
                    Type = Core.Media.MediaSource.SourceType.Web
                };

                try
                {
                    using WebClient webClient = new WebClient();
                    byte[] thumbData = webClient.DownloadData(video.Thumbnails.FirstOrDefault().Url);
                    mediaSource.Image = thumbData;
                }
                catch
                {
                    //Ignore
                }

                GlobalData.Current.SavedTracks.Add(FilePath, mediaSource);
                GlobalData.Current.SaveSavedTracks();
            }
            var track = FilePath.Length == 11 ? GlobalData.Current.SavedTracks[FilePath] : GlobalData.Current.Audios[FilePath];

            if (track == null)
            {
                GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.SnackFileExists);
                return null;
            }

            return track;
        }

        private static void MenuEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow(FilePath);
            editWindow.CenterToMainWindow();
            editWindow.ShowDialog();
        }

        private async static void MenuDownload_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var track = await GetMediaSource();
            DownloadProcessing.Add(FilePath, track.Title, "", "");
            GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.Ready);
        }

        private async static void MenuDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(FilePath);
            AlertWindow prompt = new AlertWindow(Localization.Warning, Localization.QuestionDelete + " " + fileInfo.Name + (Playlist == "" ? "?" : " " + Localization.QuestionDeleteFromPlaylist + "?"), Localization.Yes, Localization.No);
            prompt.CenterToMainWindow();
            bool? answer = prompt.ShowDialog();

            if (answer == true)
            {
                var track = await GetMediaSource();
                if (Playlist == "")
                {
                    if (File.Exists(FilePath))
                        File.Delete(FilePath);

                    if (FilePath.Length == 11)
                    {
                        GlobalLoader.RemoveSavedTrack(FilePath);
                    }

                    if (GlobalData.Current.Artists[track.Artist].Contains(track.FilePath))
                        GlobalData.Current.Artists[track.Artist].Remove(track.FilePath);

                    if (GlobalData.Current.Artists[track.Artist].Count == 0)
                    {
                        GlobalData.Current.Artists.Remove(track.Artist);
                        GlobalData.Current.ArtistsNeedRefresh = true;
                    }

                    GlobalData.Current.Audios.Remove(FilePath);

                    foreach (var playlist in GlobalData.Current.Playlists.Keys)
                    {
                        if (GlobalData.Current.Playlists[playlist].Contains(FilePath))
                        {
                            GlobalData.Current.Playlists[playlist].Remove(FilePath);
                            GlobalData.Current.PlaylistsNeedRefresh = true;
                        }
                    }
                }
                else
                {
                    if (GlobalData.Current.Playlists[Playlist].Contains(FilePath))
                    {
                        GlobalData.Current.Playlists[Playlist].Remove(FilePath);
                        GlobalData.Current.PlaylistsNeedRefresh = true;
                    }
                }
            }

            SnackbarBuilder.Show(Localization.Ready);
            GlobalData.Current.SaveConfig();
            GlobalData.Current.SaveTags();
        }

        private static void MenuQueue_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GlobalData.Current.CurrentPlaylist.Count > 0)
            {
                if (GlobalData.Current.QueuePosition < GlobalData.Current.PlaylistPosition || GlobalData.Current.QueuePosition > GlobalData.Current.CurrentPlaylist.Count)
                {
                    GlobalData.Current.QueuePosition = GlobalData.Current.PlaylistPosition;
                }

                GlobalData.Current.CurrentPlaylist.Insert(GlobalData.Current.QueuePosition + 1, FilePath.Length == 11 ? GlobalData.Current.SavedTracks[FilePath] : GlobalData.Current.Audios[FilePath]);
                GlobalData.Current.QueuePosition++;
                GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.SnackQueue);
            }
        }

        private static async void ItemNew_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var track = await GetMediaSource();

            PromptWindow prompt = new PromptWindow(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel);
            prompt.CenterToMainWindow();
            bool? answer = prompt.ShowDialog();

            if (answer == true && !string.IsNullOrEmpty(prompt.Value))
            {
                if (!GlobalData.Current.Playlists.ContainsKey(prompt.Value))
                    GlobalData.Current.Playlists.Add(prompt.Value, new List<string>());

                GlobalData.Current.Playlists[prompt.Value].Add(track.FilePath);
            }

            GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.Ready);
            GlobalData.Current.PlaylistsNeedRefresh = true;
            GlobalData.Current.SaveConfig();
        }

        private static void PlaylistItemNew_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PromptWindow prompt = new PromptWindow(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel);
            prompt.CenterToMainWindow();
            bool? answer = prompt.ShowDialog();

            if (answer == true && !string.IsNullOrEmpty(prompt.Value))
            {
                foreach (var playlistItem in GlobalData.Current.Playlists[Playlist])
                {
                    if (GlobalData.Current.Playlists.ContainsKey(prompt.Value))
                        GlobalData.Current.Playlists[prompt.Value].Add(playlistItem);
                    else
                        GlobalData.Current.Playlists.Add(prompt.Value, new List<string>() { playlistItem });
                }

                GlobalData.Current.SaveConfig();

                GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.SnackPlaylist);
            }
            GlobalData.Current.PlaylistsNeedRefresh = true;
            GlobalData.Current.SaveConfig();
        }

        private static void MenuPlaylistDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AlertWindow alertWindow = new AlertWindow(Localization.Question, Localization.QuestionDeletePlaylist + " " + Playlist + "?", Localization.Yes, Localization.No);
            alertWindow.CenterToMainWindow();
            bool? answer = alertWindow.ShowDialog();

            if (answer == true)
            {
                GlobalData.Current.Playlists.Remove(Playlist);

                if (GlobalData.Current.WebToLocalPlaylists.ContainsValue(Playlist))
                {
                    var key = GlobalData.Current.WebToLocalPlaylists.First(keyPair => keyPair.Value == Playlist).Key;

                    if (GlobalData.Current.WebToLocalPlaylists.ContainsKey(key))
                        GlobalData.Current.WebToLocalPlaylists.Remove(key);

                }

                GlobalData.Current.SaveConfig();
                GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.Ready);
                GlobalData.Current.PlaylistsNeedRefresh = true;
            }
        }

        private static void MenuPlaylistChangeName_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PromptWindow prompt = new PromptWindow(Localization.ChangeName, Playlist, "OK", Localization.Cancel);
            prompt.CenterToMainWindow();
            bool? valid = prompt.ShowDialog();

            if (valid == true)
            {
                string answer = prompt.Value;

                if (!string.IsNullOrEmpty(answer))
                {
                    if (GlobalData.Current.Playlists.ContainsKey(answer))
                        GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.PlaylistExists);
                    else
                    {
                        GlobalData.Current.Playlists.Add(answer, new List<string>(GlobalData.Current.Playlists[Playlist]));
                        GlobalData.Current.Playlists.Remove(Playlist);

                        if (GlobalData.Current.WebToLocalPlaylists.ContainsValue(Playlist))
                        {
                            var key = GlobalData.Current.WebToLocalPlaylists.First(keyPair => keyPair.Value == Playlist).Key;

                            if (GlobalData.Current.WebToLocalPlaylists.ContainsKey(key))
                                GlobalData.Current.WebToLocalPlaylists[key] = answer;

                        }
                        GlobalData.Current.SaveConfig();
                        GlobalData.Current.PlaylistsNeedRefresh = true;
                        GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.Ready);
                    }
                }
            }
        }

        private static void MenuPlaylistQueue_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GlobalData.Current.CurrentPlaylist.Count > 0)
            {
                foreach (var playlistTrack in GlobalData.Current.Playlists[Playlist])
                {
                    if (GlobalData.Current.Audios.ContainsKey(playlistTrack))
                    {
                        if (GlobalData.Current.QueuePosition < GlobalData.Current.PlaylistPosition || GlobalData.Current.QueuePosition > GlobalData.Current.CurrentPlaylist.Count)
                        {
                            GlobalData.Current.QueuePosition = GlobalData.Current.PlaylistPosition;
                        }

                        GlobalData.Current.CurrentPlaylist.Insert(GlobalData.Current.QueuePosition + 1, GlobalData.Current.Audios[playlistTrack]);
                        GlobalData.Current.QueuePosition++;
                    }
                }
                GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.SnackQueue);
            }
        }

        private static void MenuPlaylistPlay_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GlobalData.Current.Playlists[Playlist].Count > 0)
            {
                GlobalData.Current.MediaPlayer.LoadPlaylist(GlobalData.Current.Playlists[Playlist], 0, true, true);
            }
        }

        private static void ArtistItemNew_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PromptWindow prompt = new PromptWindow(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel);
            prompt.CenterToMainWindow();
            bool? answer = prompt.ShowDialog();

            if (answer == true && !string.IsNullOrEmpty(prompt.Value))
            {
                foreach (var playlistItem in GlobalData.Current.Artists[Artist])
                {
                    if (GlobalData.Current.Playlists.ContainsKey(prompt.Value))
                        GlobalData.Current.Playlists[prompt.Value].Add(playlistItem);
                    else
                        GlobalData.Current.Playlists.Add(prompt.Value, new List<string>() { playlistItem });
                }

                GlobalData.Current.SaveConfig();

                GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.SnackPlaylist);
            }
            GlobalData.Current.PlaylistsNeedRefresh = true;
            GlobalData.Current.SaveConfig();
        }
        private static void MenuArtistQueue_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GlobalData.Current.CurrentPlaylist.Count > 0)
            {
                foreach (var artistTrack in GlobalData.Current.Artists[Artist])
                {
                    if (GlobalData.Current.Audios.ContainsKey(artistTrack))
                    {
                        if (GlobalData.Current.QueuePosition < GlobalData.Current.PlaylistPosition || GlobalData.Current.QueuePosition > GlobalData.Current.CurrentPlaylist.Count)
                        {
                            GlobalData.Current.QueuePosition = GlobalData.Current.PlaylistPosition;
                        }

                        GlobalData.Current.CurrentPlaylist.Insert(GlobalData.Current.QueuePosition + 1, GlobalData.Current.Audios[artistTrack]);
                        GlobalData.Current.QueuePosition++;
                    }
                }
                GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.SnackQueue);
            }
        }

        private static void MenuArtistPlay_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (GlobalData.Current.Artists[Artist].Count > 0)
            {
                GlobalData.Current.MediaPlayer.LoadPlaylist(GlobalData.Current.Artists[Artist], 0, true, true);
            }
        }

        private async static void MenuSearchResultNewItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string[] elems = Tag.Split(GlobalData.SEPARATOR);
            var urlType = SearchProcessing.CheckLink(elems[1]);

            await AddSavedTrack(Tag);

            PromptWindow prompt = new PromptWindow(Localization.NewPlaylist, Localization.NewPlaylist, Localization.Add, Localization.Cancel);
            prompt.CenterToMainWindow();
            bool? answer = prompt.ShowDialog();

            if (answer == true && !string.IsNullOrEmpty(prompt.Value))
            {
                if (GlobalData.Current.Playlists.ContainsKey(prompt.Value))
                    GlobalData.Current.Playlists[prompt.Value].Add(urlType[SearchProcessing.Query.Video]);
                else
                    GlobalData.Current.Playlists.Add(prompt.Value, new List<string>() { urlType[SearchProcessing.Query.Video] });

                GlobalData.Current.PlaylistsNeedRefresh = true;
                GlobalData.Current.SaveConfig();

                GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar, Localization.SnackPlaylist);
            }
        }

        private async static void MenuSearchResultDownload_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string[] elems = Tag.Split(GlobalData.SEPARATOR);
            YoutubeClient client = new YoutubeClient();
            string playlistId = "";
            string playlistName = "";
            var urlType = SearchProcessing.CheckLink(elems[1]);

            if (urlType.ContainsKey(SearchProcessing.Query.Playlist))
            {
                if (urlType.ContainsKey(SearchProcessing.Query.Video))
                {
                    AlertWindow alertPlaylistOrTrack = new AlertWindow(Localization.Question, Localization.PlaylistOrTrack, Localization.Track, Localization.Playlist);
                    alertPlaylistOrTrack.CenterToMainWindow();
                    bool? alertPOT = alertPlaylistOrTrack.ShowDialog();

                    if (alertPOT == true)
                    {
                        playlistId = "";
                    }
                    else
                    {
                        playlistId = urlType[SearchProcessing.Query.Playlist];

                        AlertWindow alertPlaylist = new AlertWindow(Localization.Question, Localization.PlaylistDownload, Localization.Yes, Localization.No);
                        alertPlaylist.CenterToMainWindow();
                        bool? alertPlaylistAnswer = alertPlaylist.ShowDialog();
                        if (alertPlaylistAnswer == true)
                        {
                            var playlist = await client.Playlists.GetAsync(urlType[SearchProcessing.Query.Playlist]);

                            PromptWindow promptPlaylist = new PromptWindow(Localization.NewPlaylist, playlistName, "OK", Localization.Cancel);
                            promptPlaylist.CenterToMainWindow();
                            bool? playlistAnswer = promptPlaylist.ShowDialog();

                            if (playlistAnswer == true)
                            {
                                string newPlaylistName = promptPlaylist.Value;
                                playlistName = string.IsNullOrWhiteSpace(newPlaylistName) ? "" : newPlaylistName;
                            }
                        }
                    }
                }
            }

            if (playlistId == "")
            {
                DownloadProcessing.Add("", elems[0], elems[1], "");
            }
            else
            {
                DownloadProcessing.AddRange(await client.Playlists.GetVideosAsync(playlistId), playlistName, playlistId);
            }
        }
        #endregion
    }
}
