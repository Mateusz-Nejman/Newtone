using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Xamarin.Forms;

namespace NSEC.Music_Player.Loaders
{
    public static class TracksLoader
    {
        public static void Load(ref ObservableCollection<TrackListModel> model)
        {
            if (model.Count == 0)
            {
                List<TrackListModel> beforeSort = new List<TrackListModel>();

                foreach (string filePath in Global.Audios.Keys)
                {
                    MediaSource source = Global.Audios[filePath];

                    beforeSort.Add(new TrackListModel() { Author = source.Artist, Image = source.Picture != null ? ImageSource.FromStream(() => new MemoryStream(source.Picture)) : Global.EmptyTrack, Tag = filePath, Title = source.Title });
                }

                List<TrackListModel> afterSort = beforeSort.OrderBy(o => o.Title).ToList();

                foreach (TrackListModel track in afterSort)
                {
                    model.Add(track);
                }
            }
        }

        public static void Reload(ref ObservableCollection<TrackListModel> model)
        {
            model.Clear();
            Load(ref model);
        }
    }
}