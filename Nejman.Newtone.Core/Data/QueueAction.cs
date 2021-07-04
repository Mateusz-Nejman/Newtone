using Nejman.Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nejman.Newtone.Core.Data
{
    public static class QueueAction
    {
        public static void Add(MediaSource track)
        {
            if (CoreGlobal.CurrentPlaylist.Count > 0 && CoreGlobal.Audios.ContainsKey(track.Path))
            {
                if (CoreGlobal.QueuePosition < CoreGlobal.CurrentPlaylistPosition || CoreGlobal.QueuePosition > CoreGlobal.CurrentPlaylist.Count)
                {
                    CoreGlobal.QueuePosition = CoreGlobal.CurrentPlaylistPosition;
                }

                CoreGlobal.CurrentPlaylist.Insert(CoreGlobal.QueuePosition + 1, CoreGlobal.Audios[track.Path]);
                CoreGlobal.QueuePosition++;
            }
        }

        public static void Add(string track)
        {
            Add(CoreGlobal.Audios[track]);
        }

        public static void Add(IList<string> tracks)
        {
            foreach(var track in tracks)
            {
                Add(track);
            }
        }

        public static void Add(IList<MediaSource> tracks)
        {
            foreach (var track in tracks)
            {
                Add(track);
            }
        }
    }
}
