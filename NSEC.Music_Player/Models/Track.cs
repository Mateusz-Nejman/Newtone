using NSEC.Music_Player.Logic;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace NSEC.Music_Player.Models
{
    public class Track : Item, INotifyPropertyChanged
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
        public string Text { get; set; }
        public string Description { get; set; }

        public string Tag { get; set; }

        public MP3Processing.Container Container { get; set; }

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

        public object[] Serialize() //0 = Text, 1 = Description, 2 = Tag, 3 = Container
        {
            return new object[] { Text, Description, Tag, Container, Id };
        }
    }
}