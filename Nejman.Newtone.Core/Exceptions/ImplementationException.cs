using System;

namespace Nejman.Newtone.Core.Exceptions
{
    public class ImplementationException : Exception
    {
        public ImplementationException(string name) : base(name + " is already implemented!")
        {

        }
    }
}
