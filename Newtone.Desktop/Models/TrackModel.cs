using Newtone.Core;
using Newtone.Desktop.Properties;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Newtone.Desktop.Models
{
    public class TrackModel : Newtone.Core.Models.TrackModel
    {
        #region Fields
        private Visibility visibility = Visibility.Hidden;
        private string trackString;
        private BitmapSource image;
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
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }

        public BitmapSource Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
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
            bool isTag = GlobalData.Current.AudioTags.Keys.Any(key => key == FilePath);

            if(isTag)
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(GlobalData.Current.AudioTags[FilePath].Image ?? Resources.EmptyTrack);
                bmp.EndInit();
                Image = bmp;
            }
            else
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(Resources.EmptyTrack);
                bmp.EndInit();
                Image = bmp;
            }
        }
        #endregion
        #region Public Methods

        public TrackModel CheckChanges()
        {
            Visibility = FilePath == GlobalData.Current.MediaSourcePath ? Visibility.Visible : Visibility.Hidden;
            TrackString = this.Artist == Newtone.Core.Languages.Localization.UnknownArtist ? Title : string.Concat(Artist," - ",Title);
            return this;
        }
        #endregion
    }
}
