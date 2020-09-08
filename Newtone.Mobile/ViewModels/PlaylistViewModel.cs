using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtone.Core;
using Newtone.Mobile.Models;
using Newtone.Mobile.Processing;
using Xamarin.Forms;

namespace Newtone.Mobile.ViewModels
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

            foreach (string playlist in GlobalData.Current.Playlists.Keys)
            {
                beforeSort.Add(playlist);
            }

            List<string> afterSort = beforeSort.OrderBy(o => o).ToList();

            foreach (var playlistName in afterSort)
            {
                ImageSource image = ImageSource.FromFile("EmptyTrack.png");
                foreach (string filePath in GlobalData.Current.Playlists[playlistName])
                {
                    var source = GlobalData.Current.Audios[filePath];
                    if (source.Image != null)
                    {
                        image = ImageProcessing.FromArray(source.Image);
                        break;
                    }
                }

                Items.Add(new PlaylistModel() { Image = image, Name = playlistName, TrackCount = GlobalData.Current.Playlists[playlistName].Count });
            }
        }
        #endregion
        #region Public Methods
        public int Init()
        {
            Items.Clear();

            List<string> beforeSort = new List<string>();

            foreach (string playlist in GlobalData.Current.Playlists.Keys)
            {
                beforeSort.Add(playlist);
            }

            List<string> afterSort = beforeSort.OrderBy(o => o).ToList();

            foreach (var playlistName in afterSort)
            {
                ImageSource image = ImageSource.FromFile("EmptyTrack.png");
                foreach (string filePath in GlobalData.Current.Playlists[playlistName])
                {
                    var source = GlobalData.Current.Audios[filePath];
                    if (source.Image != null)
                    {
                        image = ImageProcessing.FromArray(source.Image);
                        break;
                    }
                }

                Items.Add(new PlaylistModel() { Image = image, Name = playlistName, TrackCount = GlobalData.Current.Playlists[playlistName].Count });
            }

            return Items.Count;
        }

        #endregion
    }
}