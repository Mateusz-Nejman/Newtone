using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Newtone.Core.Models
{
    public class DownloadModel: INotifyPropertyChanged
    {
        private double progress { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public double Progress
        {
            get
            {
                return progress;
            }
            set
            {
                if(progress != value)
                {
                    progress = value;
                    OnPropertyChanged("Progress");
                    OnPropertyChanged("ProgressString");
                }
            }
        }

        public string PlaylistName { get; set; }

        public string ProgressString
        {
            get
            {
                return string.Format("{0:0.00}", Progress * 100.0) + "%";
            }
        }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
}
