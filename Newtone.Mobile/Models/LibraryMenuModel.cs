using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core.Models;
using Xamarin.Forms;

namespace Newtone.Mobile.Models
{
    public class LibraryMenuModel:PropertyChangedBase
    {
        #region Fields
        private string title;
        private ImageSource image;
        private bool changeColor;
        #endregion
        #region Properties
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        public bool ChangeColor
        {
            get => changeColor;
            set
            {
                changeColor = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}