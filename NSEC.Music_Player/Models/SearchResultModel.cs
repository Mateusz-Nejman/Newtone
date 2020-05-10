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
using NSEC.Music_Player.Processing;
using Xamarin.Forms;

namespace NSEC.Music_Player.Models
{
    public class SearchResultModel : Newtone.Core.Models.SearchResultModel, INotifyPropertyChanged
    {
        private ImageSource thumb;

        public ImageSource Thumb
        {
            get
            {
                if (thumb == null && Image != null)
                {
                    thumb = ImageProcessing.FromArray(Image);
                    OnPropertyChanged("Thumb");
                }
                return thumb;
            }
            set
            {
                if (thumb != value)
                {
                    thumb = value;
                    OnPropertyChanged("Thumb");
                }
            }
        }

        public SearchResultModel(Newtone.Core.Models.SearchResultModel model)
        {
            this.Author = model.Author;
            this.Duration = model.Duration;
            this.Id = model.Id;
            this.Image = model.Image;
            this.MixId = model.MixId;
            this.ThumbUrl = model.ThumbUrl;
            this.Title = model.Title;
            this.VideoData = model.VideoData;
        }

        public void CheckChanges()
        {
            var thumb = Thumb;
            thumb.GetType(); //WTF
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}