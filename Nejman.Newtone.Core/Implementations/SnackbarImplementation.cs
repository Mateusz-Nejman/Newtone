using Nejman.Newtone.Core.Contracts;
using Nejman.Newtone.Core.Exceptions;

namespace Nejman.Newtone.Core.Implementations
{
    public static class SnackbarImplementation
    {
        private static ISnackbar snackbar;

        public static void Initialize(ISnackbar implementation)
        {
            if (snackbar != null)
            {
                throw new ImplementationException("Snackbar");
            }

            snackbar = implementation;
        }

        public static ISnackbar Current => snackbar;
    }
}
