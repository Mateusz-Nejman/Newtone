using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Models;

namespace NSEC.Music_Player.Loaders
{
    public static class ArtistLoader
    {
        public static void Load(ref ObservableCollection<ArtistListModel> model)
        {
            if(model.Count == 0)
            {
                ArtistListModel unknown = null;
                List<ArtistListModel> beforeSort = new List<ArtistListModel>();

                foreach(string artist in Global.Artists.Keys)
                {
                    if(artist == Localization.UnknownArtist)
                    {
                        unknown = new ArtistListModel()
                        {
                            Name = Localization.UnknownArtist,
                            TrackCount = Global.Artists[artist].Count
                        };
                    }
                    else
                    {
                        beforeSort.Add(new ArtistListModel()
                        {
                            Name = artist,
                            TrackCount = Global.Artists[artist].Count
                        });
                    }
                }

                List<ArtistListModel> afterSort = beforeSort.OrderBy(o => o.Name).ToList();

                if (unknown != null)
                    afterSort.Add(unknown);

                foreach(ArtistListModel artist in afterSort)
                {
                    model.Add(artist);
                }
            }
        }

        public static void Reload(ref ObservableCollection<ArtistListModel> model)
        {
            model.Clear();
            Load(ref model);
        }
    }
}