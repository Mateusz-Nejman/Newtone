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
using NSEC.Music_Player.Views.Custom;
using Xamarin.Forms;

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

        public static void LoadGrid(ref StackLayout grid)
        {
            ArtistListModel unknown = null;
            List<ArtistListModel> beforeSort = new List<ArtistListModel>();

            foreach (string artist in Global.Artists.Keys)
            {
                if (artist == Localization.UnknownArtist)
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

            grid.Children.Clear();

            int pos = 0;
            ArtistListModel model0 = null;
            foreach (ArtistListModel artist in afterSort)
            {
                if (pos == 0)
                {
                    model0 = artist;
                    pos = 1;
                }
                else
                {
                    Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                    layout.Children.Add(new ArtistGridItem(model0), null, null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.RelativeToParent(parent => parent.Width * 0.5));
                    layout.Children.Add(new ArtistGridItem(artist), Constraint.RelativeToParent(parent => parent.Width * 0.5), null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.RelativeToParent(parent => parent.Width * 0.5));
                    grid.Children.Add(layout);
                    pos = 0;
                }

            }

            if(pos == 1)
            {
                Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                layout.Children.Add(new ArtistGridItem(model0), null, null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.RelativeToParent(parent => parent.Width * 0.5));
                grid.Children.Add(layout);
            }

            Console.WriteLine("Count: " + grid.Children.Count);

        }
    }
}