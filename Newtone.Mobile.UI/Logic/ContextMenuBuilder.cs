using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Languages;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Newtone.Core.Processing;
using System.Linq;
using Newtone.Mobile.UI.Views;
using System.Threading.Tasks;
using Newtone.Mobile.UI.Views.ViewCells;
using YoutubeExplode;
using Newtone.Core.Logic;
using System.Net;

namespace Newtone.Mobile.UI.Logic
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

            List<string> menuItems = new List<string>() { filePath.Length == 11 ? Localization.Download : Localization.TrackMenuEdit, Localization.TrackMenuPlaylist, Localization.TrackMenuQueue };
            if (!string.IsNullOrEmpty(playlistName))
                menuItems.Add(Localization.SyncAddPlaylist);

            menuItems.Add(Localization.TrackMenuDelete);

            Global.ContextMenuBuilder.BuildForTrack(sender, modelInfo, filePath, playlistName, menuItems, TrackAction);
        }

        public static void BuildForPlaylist(View sender, string playlistName)
        {
            List<string> elements = new List<string>() { Localization.PlaylistPlay, Localization.TrackMenuPlaylist, Localization.TrackMenuQueue, Localization.ChangeName, Localization.TrackMenuDelete };

            Global.ContextMenuBuilder.BuildForPlaylist(sender, playlistName, elements, PlaylistAction);
        }

        public static void BuildForArtist(View sender, string artistName)
        {
            List<string> elements = new List<string>() { Localization.PlaylistPlay, Localization.TrackMenuPlaylist, Localization.TrackMenuQueue };

            Global.ContextMenuBuilder.BuildForArtist(sender, artistName, elements, ArtistAction);
        }

        public static void BuildForSearchResult(View sender, string modelInfo)
        {
            List<string> elements = new List<string>() { Localization.Download, Localization.TrackMenuPlaylist };

            Global.ContextMenuBuilder.BuildForSearchResult(sender, modelInfo, elements, SearchResultAction);
        }
        #endregion
        #region Private Methods
        private static async Task TrackAction(string filePath, string item, string playlistName)
        {
            Page page = Global.Page;

            if(filePath.Length == 11 && !GlobalData.Current.SavedTracks.ContainsKey(filePath))
            {
                YoutubeClient client = new YoutubeClient();
                var video = await client.Videos.GetAsync(filePath);

                var mediaSource = new Core.Media.MediaSource()
                {
                    Artist = video.Author,
                    Duration = video.Duration,
                    FilePath = video.Id,
                    Title = video.Title,
                    Type = Core.Media.MediaSource.SourceType.Web
                };

                try
                {
                    using WebClient webClient = new WebClient();
                    byte[] thumbData = webClient.DownloadData(video.Thumbnails.MediumResUrl);
                    mediaSource.Image = thumbData;
                }
                catch
                {
                    //Ignore
                }

                GlobalData.Current.SavedTracks.Add(filePath, mediaSource);
                GlobalData.Current.SaveSavedTracks();
            }
            var track = filePath.Length == 11 ? GlobalData.Current.SavedTracks[filePath] : GlobalData.Current.Audios[filePath];

            if (track == null)
            {
                Global.Application.ShowSnackbar(Localization.SnackFileExists);
                return;
            }

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
                    Global.Application.ShowSnackbar(Localization.Ready);
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

                        Global.Application.ShowSnackbar(Localization.SnackPlaylist);
                    }
                }
                else if (GlobalData.Current.Playlists.ContainsKey(answer))
                {
                    if (!GlobalData.Current.Playlists[answer].Contains(filePath))
                        GlobalData.Current.Playlists[answer].Add(filePath);

                    GlobalData.Current.SaveConfig();
                    Global.Application.ShowSnackbar(Localization.SnackPlaylist);
                }

                GlobalData.Current.PlaylistsNeedRefresh = true;

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

                        if(filePath.Length == 11)
                        {
                            GlobalLoader.RemoveSavedTrack(filePath);
                        }

                        if (GlobalData.Current.Artists[track.Artist].Contains(track.FilePath))
                            GlobalData.Current.Artists[track.Artist].Remove(track.FilePath);

                        if (GlobalData.Current.Artists[track.Artist].Count == 0)
                        {
                            GlobalData.Current.Artists.Remove(track.Artist);
                            GlobalData.Current.ArtistsNeedRefresh = true;
                        }

                        GlobalData.Current.Audios.Remove(filePath);

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
                    Global.Application.ShowSnackbar(Localization.Ready);
                }
            }
            else if (item == Localization.TrackMenuQueue)
            {
                if (GlobalData.Current.CurrentPlaylist.Count > 0)
                {
                    if (GlobalData.Current.QueuePosition < GlobalData.Current.PlaylistPosition || GlobalData.Current.QueuePosition > GlobalData.Current.CurrentPlaylist.Count)
                    {
                        GlobalData.Current.QueuePosition = GlobalData.Current.PlaylistPosition;
                    }

                    GlobalData.Current.CurrentPlaylist.Insert(GlobalData.Current.QueuePosition + 1, filePath.Length == 11 ? GlobalData.Current.SavedTracks[filePath] : GlobalData.Current.Audios[filePath]);
                    GlobalData.Current.QueuePosition++;
                    Global.Application.ShowSnackbar(Localization.SnackQueue);
                }
            }
            else if(item == Localization.Download)
            {
                DownloadProcessing.Add(filePath, track.Title, "", "");
                Global.Application.ShowSnackbar(Localization.Ready);
            }
        }
        private static async Task PlaylistAction(View sender, string playlistName, string item)
        {
            if (item == Localization.PlaylistPlay)
            {
                if (GlobalData.Current.Playlists[playlistName].Count > 0)
                {
                    GlobalData.Current.MediaPlayer.LoadPlaylist(GlobalData.Current.Playlists[playlistName], 0, true, true);
                }
            }
            else if (item == Localization.TrackMenuPlaylist)
            {
                Page page = UI.Global.Page;
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
                        foreach (var playlistItem in GlobalData.Current.Playlists[playlistName])
                        {
                            if (GlobalData.Current.Playlists.ContainsKey(playlist))
                                GlobalData.Current.Playlists[playlist].Add(playlistItem);
                            else
                                GlobalData.Current.Playlists.Add(playlist, new List<string>() { playlistItem });
                        }

                        GlobalData.Current.SaveConfig();

                        Global.Application.ShowSnackbar(Localization.SnackPlaylist);
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
                    Global.Application.ShowSnackbar(Localization.SnackPlaylist);
                }

                GlobalData.Current.PlaylistsNeedRefresh = true;
                if(!Global.TV)
                {
                    (sender as PlaylistGridItem).Page.Init();
                }
            }
            if (item == Localization.ChangeName)
            {
                string answer = await Global.Page.DisplayPromptAsync(Localization.ChangeName, Localization.NewPlaylistHint, "OK", Localization.Cancel, Localization.NewPlaylistHint, -1, null, playlistName);
                if (!string.IsNullOrEmpty(answer))
                {
                    if (GlobalData.Current.Playlists.ContainsKey(answer))
                        Global.Application.ShowSnackbar(Localization.PlaylistExists);
                    else
                    {
                        GlobalData.Current.Playlists.Add(answer, new List<string>(GlobalData.Current.Playlists[playlistName]));
                        GlobalData.Current.Playlists.Remove(playlistName);

                        if (GlobalData.Current.WebToLocalPlaylists.ContainsValue(playlistName))
                        {
                            var key = GlobalData.Current.WebToLocalPlaylists.First(keyPair => keyPair.Value == playlistName).Key;

                            if (GlobalData.Current.WebToLocalPlaylists.ContainsKey(key))
                                GlobalData.Current.WebToLocalPlaylists[key] = answer;

                        }
                        GlobalData.Current.SaveConfig();
                        GlobalData.Current.PlaylistsNeedRefresh = true;
                        if (!Global.TV)
                        {
                            (sender as PlaylistGridItem).Page.Init();
                        }
                        Global.Application.ShowSnackbar(Localization.Ready);
                    }
                }
            }
            else if (item == Localization.TrackMenuDelete)
            {
                bool answer = await Global.Page.DisplayAlert(Localization.Question, Localization.QuestionDeletePlaylist + " " + playlistName + "?", Localization.Yes, Localization.No);

                if (answer)
                {
                    GlobalData.Current.Playlists.Remove(playlistName);

                    if (GlobalData.Current.WebToLocalPlaylists.ContainsValue(playlistName))
                    {
                        var key = GlobalData.Current.WebToLocalPlaylists.First(keyPair => keyPair.Value == playlistName).Key;

                        if (GlobalData.Current.WebToLocalPlaylists.ContainsKey(key))
                            GlobalData.Current.WebToLocalPlaylists.Remove(key);

                    }

                    GlobalData.Current.SaveConfig();
                    Global.Application.ShowSnackbar(Localization.Ready);
                    GlobalData.Current.PlaylistsNeedRefresh = true;
                    if(!Global.TV)
                    {
                        (sender as PlaylistGridItem).Page.Init();
                    }
                }
            }
            else if (item == Localization.TrackMenuQueue)
            {
                if (GlobalData.Current.CurrentPlaylist.Count > 0)
                {
                    foreach (var playlistTrack in GlobalData.Current.Playlists[playlistName])
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
                    Global.Application.ShowSnackbar(Localization.SnackQueue);
                }
            }
        }
        private static async Task ArtistAction(View sender, string artistName, string item)
        {
            if (item == Localization.PlaylistPlay)
            {
                if (GlobalData.Current.Artists[artistName].Count > 0)
                {
                    GlobalData.Current.MediaPlayer.LoadPlaylist(GlobalData.Current.Artists[artistName], 0, true, true);
                }
            }
            else if (item == Localization.TrackMenuPlaylist)
            {
                Page page = Global.Page;
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

                        Global.Application.ShowSnackbar(Localization.SnackPlaylist);
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

                if(!Global.TV)
                {
                    (sender as ArtistGridItem).Page.Init();
                }
            }
            else if (item == Localization.TrackMenuQueue)
            {
                if (GlobalData.Current.CurrentPlaylist.Count > 0)
                {
                    foreach (var artistTrack in GlobalData.Current.Artists[artistName])
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
                }
            }
        }
        private static async Task SearchResultAction(View sender, string tag, string item)
        {
            Page page = Global.Page;

            if (item == Localization.Download)
            {
                string[] elems = tag.Split(GlobalData.SEPARATOR);
                YoutubeClient client = new YoutubeClient();
                string playlistId = "";
                string playlistName = "";
                var urlType = SearchProcessing.CheckLink(elems[1]);

                if (urlType.ContainsKey(SearchProcessing.Query.Playlist))
                {
                    if (urlType.ContainsKey(SearchProcessing.Query.Video))
                    {
                        if (await Global.Page.DisplayAlert(Localization.Question, Localization.PlaylistOrTrack, Localization.Track, Localization.Playlist))
                        {
                            playlistId = "";
                        }
                        else
                        {
                            playlistId = urlType[SearchProcessing.Query.Playlist];

                            if (await Global.Page.DisplayAlert(Localization.Question, Localization.PlaylistDownload, Localization.Yes, Localization.No))
                            {
                                var playlist = await client.Playlists.GetAsync(urlType[SearchProcessing.Query.Playlist]);
                                string newPlaylistName = await Global.Page.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, "OK", Localization.Cancel, Localization.NewPlaylist, -1, null, playlist.Title);
                                playlistName = string.IsNullOrWhiteSpace(newPlaylistName) ? "" : newPlaylistName;
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
            else if (item == Localization.TrackMenuPlaylist)
            {
                string[] elems = tag.Split(GlobalData.SEPARATOR);
                ConsoleDebug.WriteLine("Tag: " + tag);
                YoutubeClient client = new YoutubeClient();
                var urlType = SearchProcessing.CheckLink(elems[1]);

                if (urlType.ContainsKey(SearchProcessing.Query.Video))
                {
                    List<string> positions = new List<string>()
                    {
                        Localization.NewPlaylist
                    };

                    foreach (string playlist in GlobalData.Current.Playlists.Keys)
                        positions.Add(playlist);

                    string answer = await page.DisplayActionSheet(Localization.ChoosePlaylist, Localization.Cancel, null, positions.ToArray());

                    if(!GlobalData.Current.SavedTracks.ContainsKey(urlType[SearchProcessing.Query.Video]))
                    {
                        var video = await client.Videos.GetAsync(urlType[SearchProcessing.Query.Video]);

                        var mediaSource = new Core.Media.MediaSource()
                        {
                            Artist = video.Author,
                            Duration = video.Duration,
                            FilePath = video.Id,
                            Title = video.Title,
                            Type = Core.Media.MediaSource.SourceType.Web
                        };

                        try
                        {
                            using WebClient webClient = new WebClient();
                            byte[] thumbData = webClient.DownloadData(video.Thumbnails.MediumResUrl);
                            mediaSource.Image = thumbData;
                        }
                        catch
                        {
                            //Ignore
                        }

                        GlobalData.Current.SavedTracks.Add(urlType[SearchProcessing.Query.Video], mediaSource);
                        GlobalData.Current.SaveSavedTracks();
                    }

                    if (answer == Localization.NewPlaylist)
                    {
                        string playlist = await page.DisplayPromptAsync(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel, Localization.Playlist, -1, null, Localization.NewPlaylist);

                        if (!string.IsNullOrEmpty(playlist))
                        {
                            if (GlobalData.Current.Playlists.ContainsKey(playlist))
                                GlobalData.Current.Playlists[playlist].Add(urlType[SearchProcessing.Query.Video]);
                            else
                                GlobalData.Current.Playlists.Add(playlist, new List<string>() { urlType[SearchProcessing.Query.Video] });

                            GlobalData.Current.PlaylistsNeedRefresh = true;
                            GlobalData.Current.SaveConfig();

                            Global.Application.ShowSnackbar(Localization.SnackPlaylist);
                        }
                    }
                    else if (GlobalData.Current.Playlists.ContainsKey(answer))
                    {
                        if (!GlobalData.Current.Playlists[answer].Contains(urlType[SearchProcessing.Query.Video]))
                            GlobalData.Current.Playlists[answer].Add(urlType[SearchProcessing.Query.Video]);

                        GlobalData.Current.PlaylistsNeedRefresh = true;
                        GlobalData.Current.SaveConfig();
                        Global.Application.ShowSnackbar(Localization.SnackPlaylist);
                    }
                }
            }
        }
        #endregion
    }
}
