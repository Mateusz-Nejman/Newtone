using Newtone.Core.Media;
using Newtone.Core.Processing;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Newtone.Core.Loaders
{
    public static class GlobalLoader
    {
        #region Public Methods
        public async static Task Load()
        {
            if(GlobalData.Current.Audios.Count == 0)
            {
                List<MediaSource> sources = new List<MediaSource>();

                foreach(string path in GlobalData.Current.IncludedPaths)
                {
                    sources.AddRange(await FileProcessing.Scan(path));
                }

                sources.ForEach(AddTrack);
                CacheLoader.SaveCache();
            }
        }

        public static void AddTrack(MediaSource source)
        {
            if(!GlobalData.Current.Audios.ContainsKey(source.FilePath) && File.Exists(source.FilePath))
            {
                GlobalData.Current.Audios.Add(source.FilePath, source);

                if (!GlobalData.Current.Artists.ContainsKey(source.Artist))
                {
                    GlobalData.Current.Artists.Add(source.Artist, new List<string>());
                    GlobalData.Current.ArtistsNeedRefresh = true;
                }

                GlobalData.Current.Artists[source.Artist].Add(source.FilePath);
            }
        }

        public static void RemoveTrack(string filePath)
        {
            MediaSource source = GlobalData.Current.Audios[filePath];
            GlobalData.Current.Artists[source.Artist].Remove(source.FilePath);
            if (GlobalData.Current.Artists[source.Artist].Count == 0)
                GlobalData.Current.ArtistsNeedRefresh = true;

            if (GlobalData.Current.Audios.ContainsKey(filePath))
                GlobalData.Current.Audios.Remove(filePath);
        }

        public static void ChangeTrack(MediaSource oldSource, MediaSource newSource)
        {
            RemoveTrack(oldSource.FilePath);


            MediaSourceTag tag;
            if (GlobalData.Current.AudioTags.ContainsKey(oldSource.FilePath))
            {
                tag = GlobalData.Current.AudioTags[oldSource.FilePath];
                tag.Author = newSource.Artist;
                tag.Image = newSource.Image;
                tag.Title = newSource.Title;
                GlobalData.Current.AudioTags[oldSource.FilePath] = tag;
                
            }
            else
            {
                tag = new MediaSourceTag
                {
                    Author = newSource.Artist,
                    Image = newSource.Image,
                    Title = newSource.Title
                };
                GlobalData.Current.AudioTags.Add(oldSource.FilePath, tag);
            }
            if(oldSource.Artist != newSource.Artist)
            {
                GlobalData.Current.Artists[oldSource.Artist].Remove(oldSource.FilePath);
                if (GlobalData.Current.Artists[oldSource.Artist].Count == 0)
                    GlobalData.Current.Artists.Remove(oldSource.Artist);
            }
            AddTrack(newSource);

            if (GlobalData.Current.MediaSource != null && GlobalData.Current.MediaSource.FilePath == newSource.FilePath)
                GlobalData.Current.MediaSource = newSource;
            GlobalData.Current.SaveTags();
        }
        #endregion
    }
}
