using Nejman.Newtone.Core.Contracts;
using Nejman.Newtone.Core.Exceptions;

namespace Nejman.Newtone.Core.Implementations
{
    public static class NotificationImplementation
    {
        private static INotification notification;

        public static void Initialize(INotification implementation)
        {
            if(notification != null)
            {
                throw new ImplementationException("Notification");
            }

            notification = implementation;
        }

        public static INotification Current => notification;
    }
}
