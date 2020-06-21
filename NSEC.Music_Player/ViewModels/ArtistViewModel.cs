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
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Processing;
using Xamarin.Forms;

namespace NSEC.Music_Player.ViewModels
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

            foreach (string artist in GlobalData.Artists.Keys)
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
                foreach (string filePath in GlobalData.Artists[artistName])
                {
                    var source = GlobalData.Audios[filePath];
                    if (source.Image != null)
                    {
                        image = ImageProcessing.FromArray(source.Image);
                        break;
                    }
                }

                Items.Add(new ArtistModel() { Image = image, Name = artistName, TrackCount = GlobalData.Artists[artistName].Count });
                ConsoleDebug.WriteLine("Artist Item Add");
            }
        }
        #endregion
    }
}