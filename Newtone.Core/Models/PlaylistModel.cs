namespace Newtone.Core.Models
{
    public class PlaylistModel:PropertyChangedBase
    {
        #region Fields
        private string name;
        private int trackCount;
        #endregion
        #region Properties
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
                OnPropertyChanged(() => TrackElem);
            }
        }
        public int TrackCount
        {
            get => trackCount;
            set
            {
                trackCount = value;
                OnPropertyChanged();
                OnPropertyChanged(() => TrackElem);
            }
        }
        public string TrackElem
        {
            get
            {
                return string.Concat(Name, " (", TrackCount, ")");
            }
        }
        #endregion
    }
}
