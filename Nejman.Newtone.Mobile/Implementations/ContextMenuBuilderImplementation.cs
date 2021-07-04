using Nejman.Newtone.Core.Exceptions;
using Nejman.Newtone.Mobile.Contracts;

namespace Nejman.Newtone.Mobile.Implementations
{
    public static class ContextMenuBuilderImplementation
    {
        private static IContextMenuBuilder contextMenuBuilder;

        public static IContextMenuBuilder Current => contextMenuBuilder;
        public static void Initialize(IContextMenuBuilder implementation)
        {
            if (contextMenuBuilder != null)
            {
                throw new ImplementationException("ContextMenuBuilder");
            }

            contextMenuBuilder = implementation;
        }
    }
}
