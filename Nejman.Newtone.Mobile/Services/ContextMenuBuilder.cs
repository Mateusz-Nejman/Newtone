using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Data;
using Nejman.Newtone.Core.Implementations;
using Nejman.Newtone.Core.Localization;
using Nejman.Newtone.Mobile.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.Services
{
    public static class ContextMenuBuilder
    {
        #region Properties
        private static string CurrentModelInfo { get; set; }
        #endregion
        #region Public Methods
        public static void BuildForTrack(View sender, string modelInfo)
        {
            CurrentModelInfo = modelInfo;

            string[] elems = CurrentModelInfo.Split(new[] { CoreGlobal.SEPARATOR }, StringSplitOptions.None);
            string filePath = elems[0];
            string playlistName = elems[1];

            List<string> menuItems = new List<string>() { Localization.TrackMenuEdit, Localization.TrackMenuPlaylist, Localization.TrackMenuQueue, Localization.TrackMenuDelete };

           ContextMenuBuilderImplementation.Current.BuildForTrack(sender, modelInfo, filePath, playlistName, menuItems, TrackAction);
        }

        public static void BuildForPlaylist(View sender, string playlistName)
        {
            List<string> elements = new List<string>() { Localization.PlaylistPlay, Localization.TrackMenuPlaylist, Localization.TrackMenuQueue, Localization.ChangeName, Localization.TrackMenuDelete };

            ContextMenuBuilderImplementation.Current.BuildForPlaylist(sender, playlistName, elements, PlaylistAction);
        }

        public static void BuildForArtist(View sender, string artistName)
        {
            List<string> elements = new List<string>() { Localization.PlaylistPlay, Localization.TrackMenuPlaylist, Localization.TrackMenuQueue };

            ContextMenuBuilderImplementation.Current.BuildForArtist(sender, artistName, elements, ArtistAction);
        }

        public static void BuildForSearchResult(View sender, string modelInfo)
        {
            List<string> elements = new List<string>() { Localization.Download };

            ContextMenuBuilderImplementation.Current.BuildForSearchResult(sender, modelInfo, elements, SearchResultAction);
        }
        #endregion
        #region Private Methods
        private static async Task TrackAction(string filePath, string item, string playlistName)
        {
            if (filePath.Length == 11)
            {
                SnackbarImplementation.Current.Show(Localization.SnackFileExists);
                return;
            }

            if (item == Localization.TrackMenuEdit)
            {
                await TracksAction.Edit(filePath);
            }
            else if (item == Localization.TrackMenuPlaylist)
            {
                await PlaylistsAction.Add(filePath);
            }
            else if (item == Localization.TrackMenuDelete)
            {
                if(playlistName != "")
                {
                    await PlaylistsAction.Remove(playlistName, filePath);
                }
                else
                {
                    await TracksAction.Remove(filePath);
                }
            }
            else if (item == Localization.TrackMenuQueue)
            {
                QueueAction.Add(filePath);
                SnackbarImplementation.Current.Show(Localization.SnackQueue);
            }
        }
        private static async Task PlaylistAction(View sender, string playlistName, string item)
        {
            if (item == Localization.PlaylistPlay)
            {
                var playlist = PlaylistsAction.GetPlaylist(playlistName);

                if(playlist.Count > 0)
                {
                    await CoreGlobal.MediaPlayer.LoadPlaylist(playlist);
                }
            }
            else if (item == Localization.TrackMenuPlaylist)
            {
                var playlist = PlaylistsAction.GetPlaylist(playlistName);
                await PlaylistsAction.Add(playlist.Select(source => source.Path).ToList());
            }
            if (item == Localization.ChangeName)
            {
                await PlaylistsAction.ChangeName(playlistName);
            }
            else if (item == Localization.TrackMenuDelete)
            {
                await PlaylistsAction.Remove(playlistName);
            }
            else if (item == Localization.TrackMenuQueue)
            {
                var playlist = PlaylistsAction.GetPlaylist(playlistName);
                QueueAction.Add(playlist.Select(source => source.Path).ToList());
                SnackbarImplementation.Current.Show(Localization.SnackQueue);
            }
        }
        private static async Task ArtistAction(View sender, string artistName, string item)
        {
            if (item == Localization.PlaylistPlay)
            {
                var artist = ArtistsAction.GetArtist(artistName);

                if (artist.Count > 0)
                {
                    await CoreGlobal.MediaPlayer.LoadPlaylist(artist);
                }
            }
            else if (item == Localization.TrackMenuPlaylist)
            {
                var artist = ArtistsAction.GetArtist(artistName);
                await PlaylistsAction.Add(artist.Select(source => source.Path).ToList());
            }
            else if (item == Localization.TrackMenuQueue)
            {
                var artist = ArtistsAction.GetArtist(artistName);
                QueueAction.Add(artist.Select(source => source.Path).ToList());
                SnackbarImplementation.Current.Show(Localization.SnackQueue);
            }
        }
#pragma warning disable CS1998 // Metoda asynchroniczna nie zawiera operatorów „await” i zostanie uruchomiona synchronicznie
        private static async Task SearchResultAction(View sender, string tag, string item)
#pragma warning restore CS1998 // Metoda asynchroniczna nie zawiera operatorów „await” i zostanie uruchomiona synchronicznie
        {
            if (item == Localization.Download)
            {
                await DownloadAction.Add(tag);
            }
        }
        #endregion
    }
}
