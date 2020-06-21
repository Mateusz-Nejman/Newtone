using Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Desktop.Models
{
    public class ListViewTextModel:PropertyChangedBase
    {
        #region Fields
        private string text;
        private string filepath;
        #endregion
        #region Properties
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }
        public string FilePath
        {
            get => filepath;
            set
            {
                filepath = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
