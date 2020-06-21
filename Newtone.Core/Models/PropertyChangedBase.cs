using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Newtone.Core.Models
{
    public class PropertyChangedBase : INotifyPropertyChanged, IPropertyChangeBase
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Public Methods
        public void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyExpression.Body as MemberExpression).Member.Name));
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
