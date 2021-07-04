using Nejman.Newtone.Core.Implementations;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Local = Nejman.Newtone.Core.Localization.Localization;

namespace Nejman.Newtone.Core.Data
{
    public static class TracksAction
    {
        public async static Task Remove(MediaSource track)
        {
            await Remove(track.Path);
        }
        public async static Task Remove(string track)
        {
            var selected = await MessageImplementation.Current.Show(Local.QuestionDelete + "?", Local.QuestionDelete + " " + track + "?", Local.Yes, Local.No);

            if(selected == Local.No || selected == null)
            {
                return;
            }

            Tracks.Remove(track);
        }

        public async static Task Edit(string track)
        {
            if(!CoreGlobal.Audios.ContainsKey(track))
            {
                return;
            }

            await Edit(CoreGlobal.Audios[track]);
        }

        public async static Task Edit(MediaSource track)
        {
            var artist = await MessageImplementation.Current.ShowPrompt(Local.Artist, track.Artist, Local.Save, Local.Cancel, track.Artist, track.Artist);

            if(artist == Local.Cancel || artist == null)
            {
                return;
            }

            var title = await MessageImplementation.Current.ShowPrompt(Local.Title, track.Title, Local.Save, Local.Cancel, track.Title, track.Title);

            if(title == Local.Cancel || title == null)
            {
                return;
            }

            Tracks.Edit(track, artist, title);
        }

        public static List<TrackModel> GetSorted()
        {
            List<TrackModel> beforeSort = new List<TrackModel>();
            foreach(var source in CoreGlobal.Audios.Values.ToList())
            {
                beforeSort.Add(new TrackModel(source.Artist, source.Title, source.Path));
            }

            return beforeSort.OrderBy(item => item.Artist + " - " + item.Title).ToList();
        }

        public static MediaSource Get(string path)
        {
            if(!CoreGlobal.Audios.ContainsKey(path) || !File.Exists(path))
            {
                return null;
            }
            return CoreGlobal.Audios[path];
        }

        public static MediaSource GetInvariant(string invariant)
        {
            foreach(var source in CoreGlobal.Audios.Values)
            {
                string toCheck = source.Artist + " - " + source.Title;

                if(toCheck.ToLowerInvariant().Contains(invariant.ToLowerInvariant()))
                {
                    return source;
                }
            }

            return null;
        }
    }
}
