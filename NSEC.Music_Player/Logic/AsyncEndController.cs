using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NSEC.Music_Player.Logic
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