using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NSEC.Music_Player.Logic
{
    public static class FileProcessing
    {
        public static async Task<MP3Processing.Container[]> ListFiles(string directory, int subDirectoriesLevel, int currentLevel, List<string> listedDirectories)
        {
            MP3Processing.Container[] files = await Task.Run(async () =>
            {
                List<MP3Processing.Container> containers = new List<MP3Processing.Container>();

                if (subDirectoriesLevel > currentLevel)
                {
                    if(Directory.Exists(directory))
                    {
                        string[] dirs = Directory.GetDirectories(directory);

                        for (int a = 0; a < dirs.Length; a++)
                        {
                            if (!listedDirectories.Contains(dirs[a]))
                            {
                                listedDirectories.Add(dirs[a]);
                                containers.AddRange(await ListFiles(dirs[a], subDirectoriesLevel, currentLevel + 1, listedDirectories));
                            }
                        }
                    }
                    
                }

                string[] filePaths = Directory.GetFiles(directory, "*.mp3");



                for (int a = 0; a < filePaths.Length; a++)
                {
                    MP3Processing.Container container = MP3Processing.GetMeta(filePaths[a]);

                    if (container != null && !containers.Contains(container))
                        containers.Add(container);
                }

                return containers.ToArray();
            });

            return files;
        }

        public static async Task<MP3Processing.Container[]> ListFiles(string[] directories, List<string> listedDirectories)
        {
            MP3Processing.Container[] files = await Task.Run(async () =>
            {
                List<MP3Processing.Container> containers = new List<MP3Processing.Container>();

                foreach (string directory in directories)
                {
                    if (!listedDirectories.Contains(directory))
                    {
                        listedDirectories.Add(directory);
                        containers.AddRange(await ListFiles(directory, 1, 0, listedDirectories));
                    }
                }
                return containers.ToArray();
            });

            return files;
        }

        public static Stream GetStreamFromFile(string filename)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            return fileStream;
        }
    }
}
