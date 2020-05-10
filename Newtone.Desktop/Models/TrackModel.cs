using Newtone.Core;
using Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace Newtone.Desktop.Models
{
    public class TrackModel : Newtone.Core.Models.TrackModel, INotifyPropertyChanged
    {
        private Visibility visibility = Visibility.Hidden;
        private string trackString;
        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
               if(visibility != value)
                {
                    visibility = value;
                    OnPropertyChanged("Visibility");
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
                if(newValue != trackString)
                {
                    trackString = newValue;
                    OnPropertyChanged("TrackString");
                }
            }
        }

        public TrackModel(Newtone.Core.Models.TrackModel model)
        {
            this.Artist = model.Artist;
            this.Duration = model.Duration;
            this.FilePath = model.FilePath;
            this.Title = model.Title;
        }

        public void CheckChanges()
        {
            Visibility = FilePath == GlobalData.MediaSourcePath ? Visibility.Visible : Visibility.Hidden;
            TrackString = this.Artist == GlobalData.LanguageUnknownArtist ? Title : $"{Artist} - {Title}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
