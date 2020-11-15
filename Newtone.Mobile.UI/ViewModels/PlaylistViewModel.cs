using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Media;
using Newtone.Mobile.UI.Models;
using Newtone.Mobile.UI.Processing;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.ViewModels
{
    public class PlaylistViewModel
    {
        #region Properties
        public ObservableCollection<PlaylistModel> Items { get; private set; }
        public ObservableCollection<NListViewItem> ListItems { get; private set; }
        public Func<NListViewItem, View> ItemTemplate
        {
            get
            {
                return item => new Views.TV.ViewCells.PlaylistGridItem(item);
            }
        }

        public bool IsInitializing { get; set; }
        #endregion
        #region Constructors
        public PlaylistViewModel()
        {
            Items = new ObservableCollection<PlaylistModel>();
            ListItems = new ObservableCollection<NListViewItem>();
            Initialize();
        }
        #endregion
        #region Public Methods
        public void Initialize()
        {
            IsInitializing = true;
            Items.Clear();
            ListItems.Clear();
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
                    MediaSource source = null;
                    if (filePath.Length == 11)
                        source = GlobalData.Current.SavedTracks[filePath];
                    else
                        source = GlobalData.Current.Audios[filePath];
                    if (source.Image != null)
                    {
                        image = ImageProcessing.FromArray(source.Image);
                        break;
                    }
                }

                Items.Add(new PlaylistModel() { Image = image, Name = playlistName, TrackCount = GlobalData.Current.Playlists[playlistName].Count });
                ListItems.Add(Items[Items.Count - 1]);
            }
            IsInitializing = false;
        }
        #endregion
    }
}
