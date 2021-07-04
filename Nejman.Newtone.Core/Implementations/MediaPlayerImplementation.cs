using Nejman.Newtone.Core.Contracts;
using Nejman.Newtone.Core.Exceptions;

namespace Nejman.Newtone.Core.Implementations
{
    public static class MediaPlayerImplementation
    {
        private static IMediaPlayer provider;

        public static void Initialize(IMediaPlayer implementation)
        {
            if (provider != null)
            {
                throw new ImplementationException("MediaPlayer");
            }

            provider = implementation;
        }

        public static IMediaPlayer Current => provider;
    }
}
