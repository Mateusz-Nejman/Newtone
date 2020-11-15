using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Mobile.UI.Models;
using Newtone.Mobile.UI.Processing;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.ViewModels
{
    public class ArtistViewModel
    {
        #region Properties
        public ObservableCollection<ArtistModel> Items { get; private set; }
        public ObservableCollection<NListViewItem> ListItems { get; private set; }
        public Func<NListViewItem, View> ItemTemplate
        {
            get
            {
                return item => new Views.TV.ViewCells.ArtistGridItem(item);
            }
        }
        public bool IsInitializing { get; set; }
        #endregion
        #region Constructors
        public ArtistViewModel()
        {
            Items = new ObservableCollection<ArtistModel>();
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
            string unknown = null;

            foreach (string artist in GlobalData.Current.Artists.Keys)
            {
                if (artist == Localization.UnknownArtist)
                    unknown = artist;
                else
                    beforeSort.Add(artist);
            }

            List<string> afterSort = beforeSort.OrderBy(o => o).ToList();

            if (unknown != null)
                afterSort.Add(unknown);

            foreach (var artistName in afterSort)
            {
                ImageSource image = ImageSource.FromFile("EmptyTrack.png");
                foreach (string filePath in GlobalData.Current.Artists[artistName])
                {
                    var source = GlobalData.Current.Audios[filePath];
                    if (source.Image != null)
                    {
                        image = ImageProcessing.FromArray(source.Image);
                        break;
                    }
                }

                Items.Add(new ArtistModel() { Image = image, Name = artistName, TrackCount = GlobalData.Current.Artists[artistName].Count });
                ListItems.Add(Items[^1]);
            }
            IsInitializing = false;
        }
        #endregion
    }
}
