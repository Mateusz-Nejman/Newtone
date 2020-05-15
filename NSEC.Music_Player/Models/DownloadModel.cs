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

namespace NSEC.Music_Player.Models
{
    public class DownloadModel : Newtone.Core.Models.DownloadModel, INotifyPropertyChanged
    {
        private string progressStringMobile;
        public string ProgressStringMobile
        {
            get
            {
                return progressStringMobile;
            }
            set
            {
                progressStringMobile = value;
                OnPropertyChanged("ProgressStringMobile");
            }
        }

        public DownloadModel(Newtone.Core.Models.DownloadModel model)
        {
            this.Id = model.Id;
            this.PlaylistName = model.PlaylistName;
            this.Progress = model.Progress;
            this.ProgressStringMobile = model.ProgressString;
            this.Title = model.Title;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}