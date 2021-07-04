using Android.Support.V4.Media;
using Nejman.Newtone.Core.Media;

namespace Nejman.Newtone.Droid.Media
{
    public static class MediaSourceExtensions
    {
        #region Public Methods
        public static MediaMetadataCompat ToMetadata(this MediaSource source)
        {
            DroidGlobal.MetadataBuilder.PutString(MediaMetadataCompat.MetadataKeyTitle, source.Title);
            DroidGlobal.MetadataBuilder.PutString(MediaMetadataCompat.MetadataKeyArtist, source.Artist);
            DroidGlobal.MetadataBuilder.PutLong(MediaMetadataCompat.MetadataKeyDuration, (long)source.Duration.TotalMilliseconds);
            return DroidGlobal.MetadataBuilder.Build();
        }
        #endregion
    }
}