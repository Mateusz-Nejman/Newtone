using Nejman.Newtone.Core.IO;
using Nejman.Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nejman.Newtone.Core.Data
{
    internal static class Playlists
    {
        public static void CreateIfNotExists(string playlistName)
        {
            if(!CoreGlobal.Playlists.ContainsKey(playlistName))
            {
                CoreGlobal.Playlists.Add(playlistName, new List<string>());
            }
        }

        public static void Add(string playlistName, MediaSource track)
        {
            Add(playlistName, track.Path);
        }

        public static void Add(string playlistName, string track)
        {
            CreateIfNotExists(playlistName);

            if (CoreGlobal.Playlists[playlistName].Contains(track))
            {
                return;
            }

            CoreGlobal.Playlists[playlistName].Add(track);
            CoreGlobal.PlaylistsRefresh.OnNext(playlistName);
        }

        public static void Remove(string playlistName)
        {
            if(!CoreGlobal.Playlists.ContainsKey(playlistName))
            {
                return;
            }

            CoreGlobal.Playlists.Remove(playlistName);
            CoreGlobal.Playlists.Remove("");
            CoreGlobal.PlaylistsRefresh.OnNext(playlistName);
            DataFile.Save();
        }

        public static void Remove(string playlistName, MediaSource track)
        {
            Remove(playlistName, track.Path);
        }

        public static void Remove(string playlistName, string track)
        {
            if (!CoreGlobal.Playlists.ContainsKey(playlistName))
            {
                return;
            }

            if (!CoreGlobal.Playlists[playlistName].Contains(track))
            {
                return;
            }

            CoreGlobal.Playlists[playlistName].Remove(track);
            CoreGlobal.PlaylistsRefresh.OnNext(playlistName);
            DataFile.Save();
        }

        public static void ChangeName(string oldName, string newName)
        {
            if(!CoreGlobal.Playlists.ContainsKey(oldName))
            {
                return;
            }

            if(CoreGlobal.Playlists.ContainsKey(newName))
            {
                return;
            }

            var playlist = CoreGlobal.Playlists[oldName];
            CoreGlobal.Playlists.Add(newName, playlist);
            CoreGlobal.Playlists.Remove(oldName);
            CoreGlobal.PlaylistsRefresh.OnNext(newName);
            CoreGlobal.PlaylistsRefresh.OnNext(oldName);
            CoreGlobal.PlaylistsRefresh.OnNext("");
            DataFile.Save();
        }
    }
}
