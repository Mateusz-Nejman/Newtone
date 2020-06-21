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
using Newtone.Core.Models;

namespace NSEC.Music_Player.Models
{
    public class DownloadModel : Newtone.Core.Models.DownloadModel
    {
        #region Fields
        private string progressStringMobile;
        #endregion
        #region Properties
        public string ProgressStringMobile
        {
            get
            {
                return progressStringMobile;
            }
            set
            {
                progressStringMobile = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Constructors
        public DownloadModel(Newtone.Core.Models.DownloadModel model)
        {
            this.Id = model.Id;
            this.PlaylistName = model.PlaylistName;
            this.Progress = model.Progress;
            this.ProgressStringMobile = model.ProgressString;
            this.Title = model.Title;
        }
        #endregion
    }
}