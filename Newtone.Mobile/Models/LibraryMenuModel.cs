using Newtone.Core.Models;
using Xamarin.Forms;

namespace Newtone.Mobile.Models
{
    public class LibraryMenuModel:PropertyChangedBase
    {
        #region Fields
        private string title;
        private ImageSource image;
        private bool changeColor;
        #endregion
        #region Properties
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }
        public bool ChangeColor
        {
            get => changeColor;
            set
            {
                changeColor = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}