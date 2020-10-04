﻿using Nejman.NSEC2;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using System;
using System.IO;
using System.Text;

namespace Newtone.Core.Loaders
{
    public class CacheLoader
    {
        public static bool IsCacheAvailable()
        {
            return File.Exists(GlobalData.Current.DataPath + "/cache.nsec2");
        }

        public static void LoadCache()
        {
            if(IsCacheAvailable())
            {
                NSEC2 nsec = new NSEC2(GlobalData.PASSWORD);
                nsec.Load(File.OpenRead(GlobalData.Current.DataPath + "/cache.nsec2"));

                if(nsec.TryGet("cache",out byte[] data))
                {
                    string[] cache = Encoding.UTF8.GetString(data).Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine("Load " + cache.Length + " cached files");
                    cache.ForEach(filepath =>
                    {
                        if (File.Exists(filepath))
                            GlobalLoader.AddTrack(MediaProcessing.GetSource(filepath));
                    });
                }

                nsec.Dispose();
            }
        }

        public static void SaveCache()
        {
            NSEC2 nsec = new NSEC2(GlobalData.PASSWORD);
            string buffer = "";
            foreach(var filepath in GlobalData.Current.Audios.Keys)
            {
                buffer += filepath + "\n";
            }
            nsec.AddFile("cache", Encoding.UTF8.GetBytes(buffer));
            File.WriteAllBytes(GlobalData.Current.DataPath + "/cache.nsec2", nsec.Save());
        }
    }
}
