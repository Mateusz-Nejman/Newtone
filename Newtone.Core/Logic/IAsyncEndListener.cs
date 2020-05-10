using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Logic
{
    public interface IAsyncEndListener
    {
        event EventHandler AsyncEnded;

        void AsyncEnd();
    }
}
