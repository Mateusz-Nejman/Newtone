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
using Newtone.Core;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Processing;
using Xamarin.Forms;

namespace NSEC.Music_Player.ViewModels
{
    public class PlaylistViewModel
    {
        #region Properties
        public ObservableCollection<PlaylistModel> Items { get; private set; }
        #endregion
        #region Constructors
        public PlaylistViewModel()
        {
            Items = new ObservableCollection<PlaylistModel>();

            List<string> beforeSort = new List<string>();

            foreach (string playlist in GlobalData.Playlists.Keys)
            {
                beforeSort.Add(playlist);
            }

            List<string> afterSort = beforeSort.OrderBy(o => o).ToList();

            foreach (var playlistName in afterSort)
            {
                ImageSource image = ImageSource.FromFile("EmptyTrack.png");
                foreach (string filePath in GlobalData.Playlists[playlistName])
                {
                    var source = GlobalData.Audios[filePath];
                    if (source.Image != null)
                    {
                        image = ImageProcessing.FromArray(source.Image);
                        break;
                    }
                }

                Items.Add(new PlaylistModel() { Image = image, Name = playlistName, TrackCount = GlobalData.Playlists[playlistName].Count });
            }
        }
        #endregion
        #region Public Methods
        public int Init()
        {
            Items.Clear();

            List<string> beforeSort = new List<string>();

            foreach (string playlist in GlobalData.Playlists.Keys)
            {
                beforeSort.Add(playlist);
            }

            List<string> afterSort = beforeSort.OrderBy(o => o).ToList();

            foreach (var playlistName in afterSort)
            {
                ImageSource image = ImageSource.FromFile("EmptyTrack.png");
                foreach (string filePath in GlobalData.Playlists[playlistName])
                {
                    var source = GlobalData.Audios[filePath];
                    if (source.Image != null)
                    {
                        image = ImageProcessing.FromArray(source.Image);
                        break;
                    }
                }

                Items.Add(new PlaylistModel() { Image = image, Name = playlistName, TrackCount = GlobalData.Playlists[playlistName].Count });
            }

            return Items.Count;
        }

        #endregion
    }
}