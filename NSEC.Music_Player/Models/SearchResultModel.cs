using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NSEC.Music_Player.Logic;
using Xamarin.Forms;

namespace NSEC.Music_Player.Models
{
    public class SearchResultModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Youtube { get; set; }
        public string Id { get; set; }
        private ImageSource picture;
        public ImageSource Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
                OnPopertyChanged("Picture");
            }
        }
        public byte[] ImageData { get; set; }
        public double Duration { get; set; }
        public string ThumbUrl { get; set; }
        public string DurationString
        {
            get
            {
                return TickParser.FormatTick(Duration);
            }
        }

        public string VideoData { get; set; }
        void OnPopertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}