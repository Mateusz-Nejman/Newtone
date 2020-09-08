using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Mobile.Models;
using Newtone.Mobile.Processing;
using Xamarin.Forms;

namespace Newtone.Mobile.ViewModels
{
    public class ArtistViewModel
    {
        #region Properties
        public ObservableCollection<ArtistModel> Items { get; private set; }
        #endregion
        #region Constructors
        public ArtistViewModel()
        {
            Items = new ObservableCollection<ArtistModel>();

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

            foreach(var artistName in afterSort)
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
            }
        }
        #endregion
    }
}