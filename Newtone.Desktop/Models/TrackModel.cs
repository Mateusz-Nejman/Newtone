using Newtone.Core;
using Newtone.Core.Media;
using Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Windows;

namespace Newtone.Desktop.Models
{
    public class TrackModel : Newtone.Core.Models.TrackModel
    {
        #region Fields
        private Visibility visibility = Visibility.Hidden;
        private string trackString;
        #endregion
        #region Properties
        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
               if(visibility != value)
                {
                    visibility = value;
                    OnPropertyChanged(() => Visibility);
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
                    OnPropertyChanged(() => TrackString);
                }
            }
        }
        #endregion
        #region Constructors
        public TrackModel(Newtone.Core.Models.TrackModel model)
        {
            this.Artist = model.Artist;
            this.Duration = model.Duration;
            this.FilePath = model.FilePath;
            this.Title = model.Title;
        }
        #endregion
        #region Public Methods

        public TrackModel CheckChanges()
        {
            Visibility = FilePath == GlobalData.MediaSourcePath ? Visibility.Visible : Visibility.Hidden;
            TrackString = this.Artist == Newtone.Core.Languages.Localization.UnknownArtist ? Title : $"{Artist} - {Title}";
            return this;
        }
        #endregion
    }
}
