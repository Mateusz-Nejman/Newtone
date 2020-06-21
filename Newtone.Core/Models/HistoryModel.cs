using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Models
{
    public class HistoryModel:PropertyChangedBase
    {
        #region Fields
        private string text;
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
        #endregion
    }
}
