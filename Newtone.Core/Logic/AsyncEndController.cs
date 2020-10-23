﻿using System.Collections.Generic;

namespace Newtone.Core.Logic
{
    public class AsyncEndController
    {
        #region Fields
        private readonly Dictionary<string, IAsyncEndListener> listeners = new Dictionary<string, IAsyncEndListener>();
        #endregion
        #region Public Methods
        public void Invoke(string name)
        {
            if (listeners.ContainsKey(name))
                listeners[name].AsyncEnd();


        }

        public void Add(string name, IAsyncEndListener listener)
        {
            if (!listeners.ContainsKey(name))
                listeners.Add(name, listener);
        }
        #endregion
    }
}
