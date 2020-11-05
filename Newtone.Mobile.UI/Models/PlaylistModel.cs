using Xamarin.Forms;

namespace Newtone.Mobile.UI.Models
{
    public class PlaylistModel : Newtone.Core.Models.PlaylistModel
    {
        #region Fields
        private ImageSource image;
        #endregion

        #region Properties
        public ImageSource Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
