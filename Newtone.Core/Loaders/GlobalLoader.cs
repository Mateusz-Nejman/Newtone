using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Newtone.Core.Loaders
{
    public static class GlobalLoader
    {
        public async static Task Load()
        {
            if(GlobalData.Audios.Count == 0)
            {
                List<string> listed = new List<string>();
                List<MediaSource> sources = new List<MediaSource>();

                foreach(string path in GlobalData.IncludedPaths)
                {
                    sources.AddRange(await FileProcessing.Scan(path, listed));
                }

                foreach(MediaSource source in sources)
                {
                    AddTrack(source);
                }
            }
        }

        public static void AddTrack(MediaSource source)
        {
            if(!GlobalData.Audios.ContainsKey(source.FilePath) && File.Exists(source.FilePath))
            {
                GlobalData.Audios.Add(source.FilePath, source);

                if (!GlobalData.Artists.ContainsKey(source.Artist))
                {
                    ConsoleDebug.WriteLine("Create artist " + source.Artist);
                    GlobalData.Artists.Add(source.Artist, new List<string>());
                }

                GlobalData.Artists[source.Artist].Add(source.FilePath);
            }
        }

        public static void RemoveTrack(string filePath)
        {
            MediaSource source = GlobalData.Audios[filePath];
            GlobalData.Artists[source.Artist].Remove(source.FilePath);

            if (GlobalData.Audios.ContainsKey(filePath))
                GlobalData.Audios.Remove(filePath);
        }

        public static void ChangeTrack(MediaSource oldSource, MediaSource newSource)
        {
            RemoveTrack(oldSource.FilePath);


            MediaSourceTag tag;
            if (GlobalData.AudioTags.ContainsKey(oldSource.FilePath))
            {
                tag = GlobalData.AudioTags[oldSource.FilePath];
                tag.Author = newSource.Artist;
                tag.Image = newSource.Image;
                tag.Title = newSource.Title;
                GlobalData.AudioTags[oldSource.FilePath] = tag;
                
            }
            else
            {
                tag = new MediaSourceTag
                {
                    Author = newSource.Artist,
                    Image = newSource.Image,
                    Title = newSource.Title
                };
                GlobalData.AudioTags.Add(oldSource.FilePath, tag);
            }
            AddTrack(newSource);

            if (GlobalData.MediaSource != null && GlobalData.MediaSource.FilePath == newSource.FilePath)
                GlobalData.MediaSource = newSource;
            ConsoleDebug.WriteLine("Save " + oldSource.FilePath + " " + tag.Author + " -> " + tag.Title);
            GlobalData.SaveTags();
        }
    }
}
