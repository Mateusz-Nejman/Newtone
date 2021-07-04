using Nejman.Newtone.Core.Implementations;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Local = Nejman.Newtone.Core.Localization.Localization;

namespace Nejman.Newtone.Core.Data
{
    public static class ArtistsAction
    {
        public static void Add(string artistName, MediaSource track)
        {
            Add(artistName, track.Path);
        }
        public static void Add(string artistName, string track)
        {
            Artists.Add(artistName, track);
        }

        public static List<ArtistModel> GetArtists()
        {
            List<ArtistModel> models = new List<ArtistModel>();

            foreach (var name in CoreGlobal.Artists.Keys)
            {
                var artist = CoreGlobal.Artists[name];

                if (artist.Count > 0)
                {
                    var withImage = artist.FirstOrDefault(trackPath =>
                    {
                        if (!CoreGlobal.Audios.ContainsKey(trackPath))
                        {
                            return false;
                        }

                        var track = CoreGlobal.Audios[trackPath];

                        return track.Image != null && track.Image.Length > 0;
                    });

                    var image = (withImage != null && CoreGlobal.Audios.ContainsKey(withImage)) ? CoreGlobal.Audios[withImage].Image : new byte[0];

                    models.Add(new ArtistModel(name, image));
                }
            }

            return models;
        }

        public static List<MediaSource> GetArtist(string artistName)
        {
            List<MediaSource> models = new List<MediaSource>();

            if (CoreGlobal.Artists.ContainsKey(artistName))
            {
                foreach (var trackPath in CoreGlobal.Artists[artistName])
                {
                    var track = TracksAction.Get(trackPath);

                    if(track != null)
                    {
                        models.Add(track);
                    }
                }
            }

            return models;
        }

        public static List<MediaSource> GetArtistInvariant(string invariantArtistName)
        {
            string artistName = null;

            foreach(var key in CoreGlobal.Artists.Keys)
            {
                if(key.ToLowerInvariant().Contains(invariantArtistName.ToLowerInvariant()))
                {
                    artistName = key;
                    break;
                }
            }

            if(artistName == null)
            {
                return new List<MediaSource>();
            }

            return GetArtist(artistName);
        }

        public static List<ArtistModel> GetArtistsSorted()
        {
            List<ArtistModel> beforeSort = new List<ArtistModel>();

            foreach (var name in CoreGlobal.Artists.Keys)
            {
                var artist = CoreGlobal.Artists[name];

                if (artist.Count > 0)
                {
                    var withImage = artist.FirstOrDefault(trackPath =>
                    {
                        if (!CoreGlobal.Audios.ContainsKey(trackPath))
                        {
                            return false;
                        }

                        var track = CoreGlobal.Audios[trackPath];

                        return track.Image != null && track.Image.Length > 0;
                    });

                    var image = (withImage != null && CoreGlobal.Audios.ContainsKey(withImage)) ? CoreGlobal.Audios[withImage].Image : new byte[0];

                    beforeSort.Add(new ArtistModel(name, image));
                }
            }

            return beforeSort.OrderBy(item => item.Name).ToList();
        }
    }
}
