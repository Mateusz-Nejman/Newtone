using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Newtone.Core.Logic
{
    public class ObservableBridge<T>
    {
        public Action<T> Action;
        private List<T> Items;
        public ObservableBridge()
        {
            Items = new List<T>();
        }

        public void Add(T item)
        {
            Items.Add(item);
            Action(item);
            //ConsoleDebug.WriteLine("Add item");
        }

        public List<T> GetItems()
        {
            return Items;
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
