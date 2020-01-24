using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NSEC.Music_Player.Logic
{
    public static class FileProcessing
    {
        public static async Task<MediaProcessing.MediaTag[]> ListFiles(string directory, int subDirectoriesLevel, int currentLevel, List<string> listedDirectories)
        {
            MediaProcessing.MediaTag[] files = await Task.Run(async () =>
            {
                List<MediaProcessing.MediaTag> containers = new List<MediaProcessing.MediaTag>();

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

                string[] mp3Files = Directory.GetFiles(directory, "*.mp3");
                string[] m4aFiles = Directory.GetFiles(directory, "*.m4a");
                List<string> filesList = new List<string>();

                for(int a = 0; a < mp3Files.Length; a++)
                {
                    filesList.Add(mp3Files[a]);
                }

                for(int a = 0; a < m4aFiles.Length; a++)
                {
                    filesList.Add(m4aFiles[a]);
                }

                string[] filePaths = filesList.ToArray();


                for (int a = 0; a < filePaths.Length; a++)
                {
                    MediaProcessing.MediaTag container = MediaProcessing.GetTags(filePaths[a]);

                    if (container != null && !containers.Contains(container))
                        containers.Add(container);
                }

                return containers.ToArray();
            });

            return files;
        }

        public static async Task<MediaProcessing.MediaTag[]> ListFiles(string[] directories, List<string> listedDirectories)
        {
            MediaProcessing.MediaTag[] files = await Task.Run(async () =>
            {
                List<MediaProcessing.MediaTag> containers = new List<MediaProcessing.MediaTag>();

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
