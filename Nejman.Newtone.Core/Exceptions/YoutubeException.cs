using System;

namespace Nejman.Newtone.Core.Exceptions
{
    public class YoutubeException : Exception
    {
        internal YoutubeException(string method) : base(Localization.Localization.YoutubeError +method)
        {

        }
    }
}
