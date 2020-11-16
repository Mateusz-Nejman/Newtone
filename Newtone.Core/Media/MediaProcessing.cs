using Newtone.Core.Languages;
using System;
using System.IO;

namespace Newtone.Core.Media
{
    public static class MediaProcessing
    {
        #region Constants
        private const int MINIMUM_TRACK_DURATION = 10;
        #endregion
        #region Properties
        public static MediaSource GetSource(string filePath)
        {
            MediaSource container = new MediaSource
            {
                FilePath = filePath
            };
            try
            {
                ATL.Track audioFile = new ATL.Track(filePath);
                container.Title = audioFile.Title == "" || audioFile.Title == null ? new FileInfo(filePath).Name : audioFile.Title;

                container.Artist = audioFile.Artist == "" ? Localization.UnknownArtist : audioFile.Artist;


                for (int a = 0; a < audioFile.EmbeddedPictures.Count; a++)
                {
                    if (audioFile.EmbeddedPictures[a] != null && audioFile.EmbeddedPictures[a].PictureData.Length > 0)
                    {
                        container.Image = audioFile.EmbeddedPictures[a].PictureData;
                        break;
                    }
                }

                container.Duration = TimeSpan.FromSeconds(audioFile.Duration);

            }
            catch
            {
                container.Title = new FileInfo(filePath).Name;
                container.Artist = Localization.UnknownArtist;
            }

            if (GlobalData.Current.AudioTags.ContainsKey(filePath))
            {
                MediaSourceTag newTags = GlobalData.Current.AudioTags[filePath];

                container.Artist = newTags.Author;
                container.Title = newTags.Title;
                container.Image ??= newTags.Image;

                if(container.Duration.TotalMilliseconds == 0)
                {
                    container.Duration = newTags.TempDuration;
                }


                if (!string.IsNullOrEmpty(newTags.Id) && !GlobalData.Current.DownloadedIds.Contains(newTags.Id))
                    GlobalData.Current.DownloadedIds.Add(newTags.Id);
            }
            return container;
        }
        #endregion
    }
}
