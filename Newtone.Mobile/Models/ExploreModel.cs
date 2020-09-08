using Newtone.Core.Models;
using Xamarin.Forms;

namespace Newtone.Mobile.Models
{
    public class ExploreModel:PropertyChangedBase
    {
        #region Fields
        private string artist;
        private string title;
        private ImageSource imageSource;
        #endregion
        #region Properties
        public string Artist
        {
            get => artist;
            set
            {
                artist = value;
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
        public ImageSource ImageSource
        {
            get => imageSource;
            set
            {
                imageSource = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}