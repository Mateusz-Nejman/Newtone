using Nejman.Newtone.Core.Data;
using Nejman.Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Local = Nejman.Newtone.Core.Localization.Localization;

namespace Nejman.Newtone.Core.IO
{
    public static class AudiosLoader
    {
        internal static async Task Load()
        {
            if (CoreGlobal.Audios.Count == 0)
            {
                List<MediaSource> sources = new List<MediaSource>();

                foreach (string path in CoreGlobal.IncludedPaths)
                {
                    sources.AddRange(await Scan(path));
                }

                sources.ForEach(Tracks.Add);
            }
        }

        public static async Task ScanAsync(string directory)
        {
            List<MediaSource> sources = new List<MediaSource>();

            sources.AddRange(await Scan(directory));

            sources.ForEach(Tracks.Add);
        }
        #region Private Methods
        private static async Task<MediaSource[]> Scan(string directory)
        {
            return await Task.Run(() => {
                List<MediaSource> containers = new List<MediaSource>();

                string[] mp3Files = null;
                string[] m4aFiles = null;
                string[] oggFiles = null;
                string[] opusFiles = null;
                try
                {
                    mp3Files = Directory.GetFiles(directory, "*.mp3");
                    m4aFiles = Directory.GetFiles(directory, "*.m4a");
                    oggFiles = Directory.GetFiles(directory, "*.ogg");
                    opusFiles = Directory.GetFiles(directory, "*.opus");
                }
                catch
                {
                    //If don't have access to directory, ignore
                }

                List<string> files = new List<string>();
                files.AddRange(mp3Files);
                files.AddRange(m4aFiles);
                files.AddRange(oggFiles);
                files.AddRange(opusFiles);

                files.ForEach(filepath =>
                {
                    MediaSource source = GetSource(filepath);

                    if (source != null && !containers.Contains(source))
                    {
                        containers.Add(source);
                    }
                });

                return containers.ToArray();
            });
        }

        public static MediaSource GetSource(string filePath)
        {
            string title = null;
            string artist = null;
            byte[] image = null;
            TimeSpan duration = TimeSpan.Zero;
            string id = null;
            try
            {
                ATL.Track audioFile = new ATL.Track(filePath);
                title = audioFile.Title == "" || audioFile.Title == null ? new FileInfo(filePath).Name : audioFile.Title;

                artist = audioFile.Artist == "" ? Local.UnknownArtist : audioFile.Artist;


                for (int a = 0; a < audioFile.EmbeddedPictures.Count; a++)
                {
                    if (audioFile.EmbeddedPictures[a] != null && audioFile.EmbeddedPictures[a].PictureData.Length > 0)
                    {
                        image = audioFile.EmbeddedPictures[a].PictureData;
                        break;
                    }
                }

                duration = TimeSpan.FromSeconds(audioFile.Duration);

            }
            catch
            {
                title = new FileInfo(filePath).Name;
                artist = Local.UnknownArtist;
            }

            if (CoreGlobal.AudioTags.ContainsKey(filePath))
            {
                MediaSourceTag newTags = CoreGlobal.AudioTags[filePath];

                artist = newTags.Author;
                title = newTags.Title;
                image = image == null ? newTags.Image : image;

                if (duration.TotalMilliseconds == 0)
                {
                    duration = newTags.TempDuration;
                }


                if (!string.IsNullOrEmpty(newTags.Id) && !CoreGlobal.DownloadedIds.Contains(newTags.Id))
                {
                    CoreGlobal.DownloadedIds.Add(newTags.Id);
                    id = newTags.Id;
                }
            }
            return new MediaSource(filePath,artist,title,duration,image,id);
        }
        #endregion
    }
}
