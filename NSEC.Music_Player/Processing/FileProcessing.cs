using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;

namespace NSEC.Music_Player.Processing
{
    public class FileProcessing
    {
        public static async Task<MediaSource[]> LoadFiles(string directory)
        {
            if(File.Exists(Global.DataPath+"/cache.nsec2"))
            {
                List<string> cache = CacheString.Load();

                if(cache.Count > 0)
                {
                    List<MediaSource> files = new List<MediaSource>();

                    foreach (string filepath in cache)
                    {
                        files.Add(MediaProcessing.GetSource(filepath));
                    }

                    return files.ToArray();
                }
                else
                    return await Scan(directory);

            }
            else
            {
                return await Scan(directory);
            }
        }

        public static async Task<MediaSource[]> Scan(string directory, List<string> listed = null)
        {
            if (listed == null)
                listed = new List<string>();

            return await Task.Run(async () => {
                List<MediaSource> containers = new List<MediaSource>();

                if (Directory.Exists(directory))
                {
                    foreach(string dir in Directory.GetDirectories(directory))
                    {
                        if(!listed.Contains(dir) && dir != Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Android")
                        {
                            listed.Add(dir);
                            containers.AddRange(await Scan(dir, listed));
                        }
                    }
                }

                string[] mp3Files = Directory.GetFiles(directory, "*.mp3");
                string[] m4aFiles = Directory.GetFiles(directory, "*.m4a");
                List<string> files = new List<string>();
                files.AddRange(mp3Files);
                files.AddRange(m4aFiles);

                foreach(string filepath in files)
                {
                    MediaSource source = MediaProcessing.GetSource(filepath);

                    if(source != null && !containers.Contains(source))
                    {
                        containers.Add(source);
                    }
                }

                return containers.ToArray();
            });
        }
    }
}