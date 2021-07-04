using Nejman.Newtone.Core.Contracts;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Nejman.Newtone.Core
{
    public class PropertyChangedBase : IPropertyChangeBase
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Public Methods
        public void OnPropertyChanged<T>(Expression<Func<T>> property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((property.Body as MemberExpression).Member.Name));
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
