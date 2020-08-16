using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Logic
{
    public interface INavigationContainer
    {
        void Block();
        void Unblock();
        bool IsBlocked();
    }
}
