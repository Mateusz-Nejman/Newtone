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
using Xamarin.Forms;

namespace NSEC.Music_Player.Models
{
    public class DownloadListModel : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private double progress;
        public double Progress
        {
            get
            {
                return progress;
            }
            set
            {
                progress = value;
                OnPopertyChanged("Progress");
                OnPopertyChanged("ProgressString");
            }
        }
        public bool Downloaded { get; set; }
        public string Url { get; set; }
        public string ProgressString
        {
            get
            {
                return string.Format("{0:0.00}", Progress * 100.0) + "%";
            }
        }

        public string PlaylistName { get; set; }
        public ImageSource Image { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPopertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}