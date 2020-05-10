using Newtone.Core;
using Newtone.Core.Loaders;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Views;
using NSEC.Music_Player.Views.Custom;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace NSEC.Music_Player.Logic
{
    public static class ContextMenuBuilder
    {
        private static string CurrentModelInfo { get; set; }
        private static View View { get; set; }
        public static void BuildForTrack(Xamarin.Forms.View sender, string modelInfo)
        {
            CurrentModelInfo = modelInfo;
            View = sender;

            PopupMenu menu = new PopupMenu(MainActivity.Instance, (View)sender, Localization.TrackMenuEdit, Localization.TrackMenuPlaylist, Localization.TrackMenuDelete);
            menu.OnSelect += Menu_OnSelect;
            menu.Show();
        }

        private static async void Menu_OnSelect(string item)
        {
            Page page = NormalPage.Instance;
            string[] elems = CurrentModelInfo.Split(GlobalData.SEPARATOR, System.StringSplitOptions.None);
            string filePath = elems[0];
            string playlistName = elems[1];

            var track = GlobalData.Audios[filePath];

            if (track == null)
                SnackbarBuilder.Show(Localization.SnackFileExists);

            if(item == Localization.TrackMenuEdit)
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

                if(userArtist != null && userTitle != null)
                {
                    if(!GlobalData.AudioTags.ContainsKey(filePath))
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
            else if(item == Localization.TrackMenuPlaylist)
            {
                List<string> positions = new List<string>()
                {
                    Localization.NewPlaylist
                };

                foreach (string playlist in GlobalData.Playlists.Keys)
                    positions.Add(playlist);

                string answer = await page.DisplayActionSheet(Localization.ChoosePlaylist, Localization.Cancel, null, positions.ToArray());

                if(answer == Localization.NewPlaylist)
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
                else if(GlobalData.Playlists.ContainsKey(answer))
                {
                    if (!GlobalData.Playlists[answer].Contains(filePath))
                        GlobalData.Playlists[answer].Add(filePath);

                    GlobalData.SaveConfig();
                }

            }
            else if(item == Localization.TrackMenuDelete)
            {
                bool answer = await page.DisplayAlert(Localization.Question, Localization.QuestionDelete + " " + track.Title + (playlistName != "" ? " " + Localization.QuestionDeleteFromPlaylist + "?" : "?"), Localization.Yes, Localization.No);

                if(answer)
                {
                    if(playlistName == "")
                    {
                        if (File.Exists(filePath))
                            File.Delete(filePath);

                        if (GlobalData.Artists[track.Artist].Contains(track.FilePath))
                            GlobalData.Artists[track.Artist].Remove(track.FilePath);

                        if (GlobalData.Artists[track.Artist].Count == 0)
                            GlobalData.Artists.Remove(track.Artist);

                        foreach(var playlist in GlobalData.Playlists.Keys)
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
        }
    }
}