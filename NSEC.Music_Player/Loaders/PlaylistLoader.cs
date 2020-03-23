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
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.Custom;
using Xamarin.Forms;

namespace NSEC.Music_Player.Loaders
{
    public static class PlaylistLoader
    {
        public static void Load(ref ObservableCollection<PlaylistListModel> model)
        {
            if (model.Count == 0)
            {
                List<PlaylistListModel> beforeSort = new List<PlaylistListModel>();

                foreach (string playlist in Global.Playlists.Keys)
                {
                    List<string> playlistItems = Global.Playlists[playlist];
                    List<Media.MediaSource> tracks = new List<Media.MediaSource>();

                    foreach(string filepath in playlistItems)
                    {
                        tracks.Add(Global.Audios[filepath]);
                    }

                    beforeSort.Add(new PlaylistListModel() { });
                }

                List<PlaylistListModel> afterSort = beforeSort.OrderBy(o => o.Name).ToList();

                foreach (PlaylistListModel playlist in afterSort)
                {
                    model.Add(playlist);
                }
            }
        }

        public static void Reload(ref ObservableCollection<PlaylistListModel> model)
        {
            model.Clear();
            Load(ref model);
        }

        public static void LoadGrid(ref StackLayout grid)
        {
            List<PlaylistListModel> beforeSort = new List<PlaylistListModel>();

            foreach (string playlist in Global.Playlists.Keys)
            {
                List<string> playlistItems = Global.Playlists[playlist];
                List<Media.MediaSource> tracks = new List<Media.MediaSource>();

                foreach (string filepath in playlistItems)
                {
                    tracks.Add(Global.Audios[filepath]);
                }

                beforeSort.Add(new PlaylistListModel() { });
            }

            List<PlaylistListModel> afterSort = beforeSort.OrderBy(o => o.Name).ToList();

            grid.Children.Clear();

            int pos = 0;
            PlaylistListModel model0 = null;

            foreach(PlaylistListModel playlist in afterSort)
            {
                if (pos == 0)
                {
                    model0 = playlist;
                    pos = 1;
                }
                else
                {
                    Xamarin.Forms.RelativeLayout layout = new Xamarin.Forms.RelativeLayout();
                    layout.Children.Add(new PlaylistGridItem(model0), null, null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.RelativeToParent(parent => parent.Width * 0.5));
                    layout.Children.Add(new PlaylistGridItem(playlist), Constraint.RelativeToParent(parent => parent.Width * 0.5), null, Constraint.RelativeToParent(parent => parent.Width * 0.5), Constraint.RelativeToParent(parent => parent.Width * 0.5));
                    grid.Children.Add(layout);
                    pos = 0;
                }
            }
        }
    }
}