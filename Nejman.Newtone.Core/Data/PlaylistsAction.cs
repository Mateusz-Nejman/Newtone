using Nejman.Newtone.Core.Implementations;
using Nejman.Newtone.Core.IO;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Local = Nejman.Newtone.Core.Localization.Localization;

namespace Nejman.Newtone.Core.Data
{
    public static class PlaylistsAction
    {
        public static void Add(string playlistName, List<MediaSource> tracks)
        {
            foreach(var track in tracks)
            {
                Playlists.Add(playlistName, track);
            }
            DataFile.Save();
        }

        public static void Add(string playlistName, List<string> tracks, bool save = true)
        {
            foreach (var track in tracks)
            {
                Playlists.Add(playlistName, track);
            }

            if(save)
            {
                DataFile.Save();
            }
        }

        public static async Task Add(List<MediaSource> tracks)
        {
            var selected = await SelectPlaylist();

            if (selected == null)
            {
                return;
            }

            Add(selected, tracks);
            SnackbarImplementation.Current.Show(Local.Ready);
        }

        public static async Task Add(List<string> tracks)
        {
            var selected = await SelectPlaylist();

            if (selected == null)
            {
                return;
            }

            Add(selected, tracks);
            SnackbarImplementation.Current.Show(Local.Ready);
        }
        public static void Add(string playlistName, MediaSource track)
        {
            Add(playlistName, track.Path);
        }
        public static void Add(string playlistName, string track)
        {
            Playlists.Add(playlistName, track);
        }
        public static async Task Add(MediaSource track)
        {
            await Add(track.Path);
        }

        public static async Task Add(string track)
        {
            var selected = await SelectPlaylist();

            if(selected == null)
            {
                return;
            }

            Playlists.Add(selected, track);
            SnackbarImplementation.Current.Show(Local.Ready);
        }

        public static async Task Remove(string playlistName)
        {
            if(!CoreGlobal.Playlists.ContainsKey(playlistName))
            {
                return;
            }

            var selected = await MessageImplementation.Current.Show(Local.QuestionDeletePlaylist, Local.QuestionDeletePlaylist + " " + playlistName + "?", Local.Yes, Local.No);

            if(selected == Local.No || selected == null)
            {
                return;
            }

            Playlists.Remove(playlistName);
            SnackbarImplementation.Current.Show(Local.Ready);
        }

        public static async Task Remove(string playlistName, MediaSource track)
        {
            await Remove(playlistName, track.Path);
        }

#pragma warning disable CS1998 // Metoda asynchroniczna nie zawiera operatorów „await” i zostanie uruchomiona synchronicznie
        public static async Task Remove(string playlistName, string track)
#pragma warning restore CS1998 // Metoda asynchroniczna nie zawiera operatorów „await” i zostanie uruchomiona synchronicznie
        {
            if (!CoreGlobal.Playlists.ContainsKey(playlistName))
            {
                return;
            }

            Playlists.Remove(playlistName, track);
            SnackbarImplementation.Current.Show(Local.Ready);
        }

        public static List<PlaylistModel> GetPlaylists()
        {
            List<PlaylistModel> models = new List<PlaylistModel>();

            foreach(var name in CoreGlobal.Playlists.Keys)
            {
                var playlist = CoreGlobal.Playlists[name];

                if(playlist.Count > 0)
                {
                    var withImage = playlist.FirstOrDefault(trackPath =>
                    {
                        if(!CoreGlobal.Audios.ContainsKey(trackPath))
                        {
                            return false;
                        }

                        var track = CoreGlobal.Audios[trackPath];

                        return track.Image != null && track.Image.Length > 0;
                    });

                    var image = withImage != null && CoreGlobal.Audios.ContainsKey(withImage) ? CoreGlobal.Audios[withImage].Image : new byte[0];

                    models.Add(new PlaylistModel(name, image));
                }
            }

            return models;
        }

        public static List<PlaylistItemModel> GetPlaylist(string playlistName)
        {
            List<PlaylistItemModel> models = new List<PlaylistItemModel>();

            if(CoreGlobal.Playlists.ContainsKey(playlistName))
            {
                foreach(var trackPath in CoreGlobal.Playlists[playlistName])
                {
                    var source = TracksAction.Get(trackPath);

                    if(source != null)
                    {
                        models.Add(new PlaylistItemModel(source));
                    }
                }
            }

            return models;
        }

        public static List<PlaylistItemModel> GetPlaylistInvariant(string invariantPlaylistName)
        {
            string playlistName = null;

            foreach(var key in CoreGlobal.Playlists.Keys)
            {
                if(key.ToLowerInvariant().Contains(invariantPlaylistName.ToLowerInvariant()))
                {
                    playlistName = key;
                    break;
                }
            }

            if(playlistName == null)
            {
                return new List<PlaylistItemModel>();
            }

            return GetPlaylist(playlistName);
        }

        public static List<MediaSource> GetCurrentPlaylist()
        {
            return CoreGlobal.CurrentPlaylist;
        }

        public static async Task ChangeName(string playlistName)
        {
            var newName = await MessageImplementation.Current.ShowPrompt(Local.ChangeName, playlistName, "OK", Local.Cancel, Local.NewPlaylistHint, playlistName);

            if(CoreGlobal.Playlists.ContainsKey(newName))
            {
                await MessageImplementation.Current.Show(Local.ChangeName, Local.PlaylistExists, "OK", Local.Cancel);
                return;
            }

            Playlists.ChangeName(playlistName, newName);
            SnackbarImplementation.Current.Show(Local.Ready);
        }

        internal static async Task<string> SelectPlaylist(string newPlaylistDefaultName = "")
        {
            List<string> positions = new List<string>() { Local.NewPlaylist };

            foreach (var playlist in CoreGlobal.Playlists.Keys)
            {
                positions.Add(playlist);
            }

            var selected = await MessageImplementation.Current.Show(Local.ChoosePlaylist, Local.Cancel, positions.ToArray());

            if(selected == Local.Cancel)
            {
                return null;
            }

            if(selected == Local.NewPlaylist)
            {
                var newPlaylistName = await MessageImplementation.Current.ShowPrompt(Local.NewPlaylist, Local.NewPlaylistHint, Local.Add, Local.Cancel, Local.NewPlaylist, newPlaylistDefaultName == "" ? Local.NewPlaylist : newPlaylistDefaultName);

                if(newPlaylistName == Local.Cancel || newPlaylistName == null)
                {
                    return null;
                }

                Playlists.CreateIfNotExists(newPlaylistName);
                selected = newPlaylistName;
            }

            return selected;
        }
    }
}
