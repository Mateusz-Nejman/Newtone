using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NSEC.Music_Player.Logic
{
    public static class MP3Processing
    {
        [Serializable]
        public class Container
        {
            public string FilePath { get; set; }
            public string Title { get; set; }
            public string Artist { get; set; }
            public string Album { get; set; }

            public string Duration { get; set; }
        }

        public static Container GetMeta(string filePath)
        {
            Container container = new Container();
            container.FilePath = filePath;
            
            try
            {
                TagLib.File audioFile = TagLib.File.Create(filePath);
                Console.WriteLine("Title: [" + audioFile.Tag.Title + "][" + new FileInfo(filePath).Name + "]");
                container.Title = audioFile.Tag.Title == "" || audioFile.Tag.Title == null ? new FileInfo(filePath).Name : audioFile.Tag.Title;
                Console.WriteLine(container.Title);
                container.Album = audioFile.Tag.Album;
                string artistsJoin = string.Join(", ", audioFile.Tag.Performers);
                container.Artist = artistsJoin == "" ? "Nieznany" : artistsJoin;
                container.Duration = audioFile.Properties.Duration.ToString(@"mm\:ss");
            }
            catch (Exception e)
            {
                Console.WriteLine("MP3Processing.cs -> " + e);
                container.Title = new FileInfo(filePath).Name;
                container.Artist = "Nieznany";
                container.Duration = "00:00";
            }
            return container;

        }


    }
}
