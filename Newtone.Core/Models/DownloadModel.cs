namespace Newtone.Core.Models
{
    public class DownloadModel:PropertyChangedBase
    {
        #region Fields
        private double progress;
        private string id;
        private string title;
        private string url;
        private string playlistName;
        private string playlistId;
        #endregion
        #region Properties
        public string Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public string Url
        {
            get => url;
            set
            {
                url = value;
                OnPropertyChanged();
            }
        }
        public double Progress
        {
            get
            {
                return progress;
            }
            set
            {
                progress = value;
                OnPropertyChanged();
                OnPropertyChanged(() => ProgressString);
            }
        }

        public string PlaylistName
        {
            get => playlistName;
            set
            {
                playlistName = value;
                OnPropertyChanged();
            }
        }

        public string PlaylistID
        {
            get => playlistId;
            set
            {
                playlistId = value;
                OnPropertyChanged();
            }
        }

        public string ProgressString
        {
            get
            {
                return string.Format("{0:0.00}", Progress * 100.0) + "%";
            }
        }
        #endregion
    }
}
