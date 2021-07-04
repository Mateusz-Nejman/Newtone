using Nejman.Newtone.Core.Contracts;
using Nejman.Newtone.Core.Exceptions;

namespace Nejman.Newtone.Core.Implementations
{
    public static class MessageImplementation
    {
        private static IMessage message;

        public static void Initialize(IMessage implementation)
        {
            if (message != null)
            {
                throw new ImplementationException("Message");
            }

            message = implementation;
        }

        public static IMessage Current => message;
    }
}
