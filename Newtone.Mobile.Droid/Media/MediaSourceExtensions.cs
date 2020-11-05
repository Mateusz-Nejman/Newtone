using Android.Support.V4.Media;
using Newtone.Core.Media;

namespace Newtone.Mobile.Droid.Media
{
    public static class MediaSourceExtensions
    {
        #region Public Methods
        public static MediaMetadataCompat ToMetadata(this MediaSource source)
        {
            Global.MetadataBuilder.PutString(MediaMetadataCompat.MetadataKeyTitle, source.Title);
            Global.MetadataBuilder.PutString(MediaMetadataCompat.MetadataKeyArtist, source.Artist);
            Global.MetadataBuilder.PutLong(MediaMetadataCompat.MetadataKeyDuration, (long)source.Duration.TotalMilliseconds);
            return Global.MetadataBuilder.Build();
        }
        #endregion
    }
}