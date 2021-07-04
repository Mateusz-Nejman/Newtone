using Nejman.Newtone.Core.IO;
using Nejman.Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nejman.Newtone.Core.Data
{
    public static class Tracks
    {
        public static void Add(MediaSource source)
        {
            if (!CoreGlobal.Audios.ContainsKey(source.Path) && source.IsLocal && File.Exists(source.Path))
            {
                CoreGlobal.Audios.Add(source.Path, source);

                Artists.Add(source.Artist, source);
                CoreGlobal.TracksRefresh.OnNext(true);
            }
        }

        public static void Remove(string track)
        {
            if(!CoreGlobal.Audios.ContainsKey(track))
            {
                return;
            }

            Remove(CoreGlobal.Audios[track]);
        }

        public static void Remove(MediaSource source)
        {
            if(!CoreGlobal.Audios.ContainsKey(source.Path) || !File.Exists(source.Path))
            {
                return;
            }

            CoreGlobal.Audios.Remove(source.Path);
            Artists.Remove(source.Artist, source);
            CoreGlobal.TracksRefresh.OnNext(true);

            File.Delete(source.Path);
            DataFile.Save();
        }

        public static void Edit(MediaSource source, string artist, string title)
        {
            if(!CoreGlobal.Audios.ContainsKey(source.Path))
            {
                return;
            }

            var oldArtist = source.Artist;

            CoreGlobal.Audios[source.Path] = new MediaSource(source.Path, artist, title, source.Duration, source.Image, source.ID);

            if(oldArtist != artist)
            {
                Artists.Remove(oldArtist, source);
                Artists.Add(artist, source);
            }

            if (!CoreGlobal.AudioTags.ContainsKey(source.Path))
            {
                CoreGlobal.AudioTags.Add(source.Path, new Newtone.Core.Media.MediaSourceTag() { Author = artist, Title = title });
            }

            CoreGlobal.AudioTags[source.Path].Author = artist;
            CoreGlobal.AudioTags[source.Path].Title = title;

            CoreGlobal.TracksRefresh.OnNext(true);
            CoreGlobal.ArtistsRefresh.OnNext(oldArtist);
            CoreGlobal.ArtistsRefresh.OnNext(artist);
            DataFile.SaveTags();
        }
    }
}
