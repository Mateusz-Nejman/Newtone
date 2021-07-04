using Nejman.Newtone.Core.IO;
using Nejman.Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nejman.Newtone.Core.Data
{
    internal static class Artists
    {
        public static void CreateIfNotExists(string artist)
        {
            if(CoreGlobal.Artists.ContainsKey(artist))
            {
                return;
            }

            CoreGlobal.Artists.Add(artist, new List<string>());
            CoreGlobal.ArtistsRefresh.OnNext("");
        }
        public static void Add(string artist, MediaSource track)
        {
            Add(artist, track.Path);
        }

        public static void Add(string artist, string track)
        {
            CreateIfNotExists(artist);

            if(CoreGlobal.Artists[artist].Contains(track))
            {
                return;
            }

            CoreGlobal.Artists[artist].Add(track);
            CoreGlobal.ArtistsRefresh.OnNext(artist);
            CoreGlobal.ArtistsRefresh.OnNext("");
        }
        public static void Remove(string artist, MediaSource track)
        {
            Remove(artist, track.Path);
        }
        public static void Remove(string artist, string track)
        {
            if(!CoreGlobal.Artists.ContainsKey(artist))
            {
                return;
            }

            if(!CoreGlobal.Artists[artist].Contains(track))
            {
                return;
            }

            CoreGlobal.Artists[artist].Remove(track);

            if(CoreGlobal.Artists[artist].Count == 0)
            {
                Remove(artist);
            }
            else
            {
                CoreGlobal.ArtistsRefresh.OnNext(artist);
                CoreGlobal.ArtistsRefresh.OnNext("");
            }
        }

        private static void Remove(string artist)
        {
            if (!CoreGlobal.Artists.ContainsKey(artist))
            {
                return;
            }

            CoreGlobal.Artists.Remove(artist);
            CoreGlobal.ArtistsRefresh.OnNext(artist);
            CoreGlobal.ArtistsRefresh.OnNext("");
            DataFile.Save();
        }
    }
}
