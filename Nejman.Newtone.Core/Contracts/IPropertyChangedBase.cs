using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Nejman.Newtone.Core.Contracts
{
    public interface IPropertyChangeBase : INotifyPropertyChanged
    {
        void OnPropertyChanged<T>(Expression<Func<T>> property);
        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
}
