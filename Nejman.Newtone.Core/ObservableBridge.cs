using System;
using System.Collections.Generic;

namespace Nejman.Newtone.Core
{
    public class ObservableBridge<T>
    {
        #region Fields
        private readonly List<T> items;
        #endregion
        #region Properties
        public Action<T> Action { get; set; }
        #endregion
        #region Constructors
        public ObservableBridge()
        {
            items = new List<T>();
        }
        #endregion

        #region Public Methods

        public void Add(T item)
        {
            items.Add(item);
            Action?.Invoke(item);
        }

        public List<T> GetItems()
        {
            return items;
        }

        public void Clear()
        {
            items.Clear();
        }
        #endregion
    }
}
