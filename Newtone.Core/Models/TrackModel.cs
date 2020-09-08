namespace Newtone.Core.Models
{
    public class TrackModel:PropertyChangedBase
    {
        #region Fields
        private string filePath;
        private string title;
        private string duration;
        private string artist;
        #endregion
        #region Properties
        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
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
        public string Duration
        {
            get => duration;
            set
            {
                duration = value;
                OnPropertyChanged();
            }
        }

        public string Artist
        {
            get => artist;
            set
            {
                artist = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
