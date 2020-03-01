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
                    List<MediaSource> tracks = new List<MediaSource>();

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
    }
}