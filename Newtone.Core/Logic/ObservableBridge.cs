using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Newtone.Core.Logic
{
    public class ObservableBridge<T>
    {
        #region Fields
        public Action<T> Action;
        private List<T> Items;
        #endregion
        #region Constructors
        public ObservableBridge()
        {
            Items = new List<T>();
        }
        #endregion

        #region Public Methods

        public void Add(T item)
        {
            Items.Add(item);
            Action?.Invoke(item);
        }

        public List<T> GetItems()
        {
            return Items;
        }

        public void Clear()
        {
            Items.Clear();
        }
        #endregion
    }
}
