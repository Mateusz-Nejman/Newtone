using System;

namespace Newtone.Core.Media
{
    public class MediaSourceTag
    {
        #region Properties
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public byte[] Image { get; set; }
        public TimeSpan TempDuration { get; set; }
        #endregion
    }
}
