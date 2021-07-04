using Nejman.Newtone.Core.Exceptions;
using Nejman.Newtone.Mobile.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nejman.Newtone.Mobile.Implementations
{
    public class ApplicationImplementation
    {
        private static IApplication application;

        public static IApplication Current => application;
        public static void Initialize(IApplication implementation)
        {
            if (application != null)
            {
                throw new ImplementationException("Application");
            }

            application = implementation;
        }
    }
}
