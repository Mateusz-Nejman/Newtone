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
using Newtone.Core;
using Newtone.Core.Languages;
using Xamarin.Forms;

namespace NSEC.Music_Player.Models
{
    public class TrackModel : Newtone.Core.Models.TrackModel, INotifyPropertyChanged
    {
        //TODO Visibility
        private bool isVisible;
        private string trackString;

        public string PlaylistName { get; set; }
        public string Info
        {
            get
            {
                return $"{FilePath}{GlobalData.SEPARATOR}{PlaylistName}";
            }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    OnPropertyChanged("IsVisible");
                }
            }
        }

        public string TrackString
        {
            get
            {
                return trackString;
            }
            set
            {
                string newValue = value;
                if (newValue != trackString)
                {
                    trackString = newValue;
                    OnPropertyChanged("TrackString");
                }
            }
        }
        public ImageSource Image { get; set; }

        public bool AllowContextMenu { get; set; }


        public TrackModel(Newtone.Core.Models.TrackModel model, string playlist = "", bool allowContextMenu = true)
        {
            this.Artist = model.Artist;
            this.Duration = model.Duration;
            this.FilePath = model.FilePath;
            this.Title = model.Title;
            this.PlaylistName = playlist;
            this.AllowContextMenu = allowContextMenu;
        }

        public void CheckChanges()
        {
            IsVisible = FilePath == GlobalData.MediaSourcePath;
            TrackString = Artist == Localization.UnknownArtist ? Title : $"{Artist} - {Title}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}