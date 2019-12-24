using System.ComponentModel;
using Xamarin.Forms;

namespace NSEC.Music_Player.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Library,
        Youtube
    }
    class MenuItem : INotifyPropertyChanged
    {
        Color backgroundColor = Color.White;
        Color backgroundColorSelected = Color.FromHex("#1565C0");
        Color textColor = Color.Black;
        Color textColorSelected = Color.White;

        Color labelColor = Color.Black;
        Color backColor = Color.White;
        public Color LabelColor
        {
            set
            {
                labelColor = value;
                OnPopertyChanged("LabelColor");
            }
            get
            {
                return labelColor;
            }
        }

        public Color BackgroundColor
        {
            set
            {
                backColor = value;
                OnPopertyChanged("BackgroundColor");
            }
            get
            {
                return backColor;
            }
        }

        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPopertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Selected(bool selected)
        {
            LabelColor = selected ? textColorSelected : textColor;
            BackgroundColor = selected ? backgroundColorSelected : backgroundColor;
        }
    }
}
