using System.Collections.Generic;

namespace NSEC.Music_Player.Services
{
    public class AsyncEndController
    {
        public Dictionary<string, IAsyncEndListener> listeners = new Dictionary<string, IAsyncEndListener>();

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
    }
}
