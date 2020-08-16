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

namespace Newtone.Mobile.Models
{
    public class PlaylistModel : Newtone.Core.Models.PlaylistModel
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