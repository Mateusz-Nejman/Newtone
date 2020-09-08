using System;

namespace Newtone.Core.Logic
{
    public interface IAsyncEndListener
    {
        event EventHandler AsyncEnded;

        void AsyncEnd();
    }
}
