using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace NSEC.Music_Player.Models
{
    public class ArtistModel:Newtone.Core.Models.ArtistModel
    {
        #region Fields
        private ImageSource image;
        #endregion
        #region Properties
        public ImageSource Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}