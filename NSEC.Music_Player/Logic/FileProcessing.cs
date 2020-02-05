using Nejman.NSEC2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NSEC.Music_Player.Logic
{
    public static class FileProcessing
    {
        private static CacheString Cache { get; set; }

        public static void SaveCache()
        {
            if(Cache != null || Cache.Count > 0)
            {
                NSEC2 nsec = new NSEC2(Global.password);
                nsec.AddFile("cache", Cache.ToBytes());
                File.WriteAllBytes(Global.DataPath + "/cache", nsec.Save());
            }
            
        }

        public static void LoadCache()
        {
            if(File.Exists(Global.DataPath+"/cache"))
            {
                FileStream fileStream = File.OpenRead(Global.DataPath + "/cache");
                NSEC2 nsec = new NSEC2(Global.password);
                nsec.Load(fileStream);

                CacheString tempCache = CacheString.FromBytes(nsec.Get("cache"));
                Cache = new CacheString();

                foreach(string cacheItem in tempCache)
                {
                    if (File.Exists(cacheItem))
                        Cache.Add(cacheItem);
                }

                nsec.Dispose();
            }
        }

        public static async Task<MediaProcessing.MediaTag[]> ChooseCorrectAndLoad(string directory)
        {
            LoadCache();

            if(Cache == null || Cache.Count == 0)
            {
                MediaProcessing.MediaTag[] tags = await ListFiles(directory, new List<string>());
                SaveCache();
                return tags;
            }
            else
            {
                return await ListFilesFromCache(directory, Cache);
            }
        }

        public static async Task<MediaProcessing.MediaTag[]> ListFilesFromCache(string directory, CacheString cache)
        {
            if(cache != null)
            {
                Cache = cache;
                List<MediaProcessing.MediaTag> containers = new List<MediaProcessing.MediaTag>();

                foreach (string filepath in cache)
                {

                    if(File.Exists(filepath))
                    {
                        MediaProcessing.MediaTag container = MediaProcessing.GetTags(filepath);

                        if (container != null && !containers.Contains(container))
                            containers.Add(container);
                    }
                }

                return containers.ToArray();
            }
            else
            {
                MediaProcessing.MediaTag[] tags = await ListFiles(directory, new List<string>());
                SaveCache();
                return tags;
            }
        }
        public static async Task<MediaProcessing.MediaTag[]> ListFiles(string directory, List<string> listedDirectories)
        {
            if (Cache == null)
                Cache = new CacheString();
            MediaProcessing.MediaTag[] files = await Task.Run(async () =>
            {
                List<MediaProcessing.MediaTag> containers = new List<MediaProcessing.MediaTag>();
                if (Directory.Exists(directory))
                {
                    string[] dirs = Directory.GetDirectories(directory);

                    for (int a = 0; a < dirs.Length; a++)
                    {
                        if (!listedDirectories.Contains(dirs[a]) && dirs[a] != Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Android")
                        {
                            listedDirectories.Add(dirs[a]);
                            containers.AddRange(await ListFiles(dirs[a], listedDirectories));
                        }
                    }
                }

                string[] mp3Files = Directory.GetFiles(directory, "*.mp3");
                string[] m4aFiles = Directory.GetFiles(directory, "*.m4a");
                List<string> filesList = new List<string>();

                for (int a = 0; a < mp3Files.Length; a++)
                {
                    filesList.Add(mp3Files[a]);
                }

                for (int a = 0; a < m4aFiles.Length; a++)
                {
                    filesList.Add(m4aFiles[a]);
                }

                string[] filePaths = filesList.ToArray();


                for (int a = 0; a < filePaths.Length; a++)
                {
                    MediaProcessing.MediaTag container = MediaProcessing.GetTags(filePaths[a]);

                    if (container != null && !containers.Contains(container))
                    {
                        Cache.Add(filePaths[a]);
                        containers.Add(container);
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
