using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Nejman.NSEC2;

namespace NSEC.Music_Player.Logic
{
    public class CacheString
    {
        public const string SEPARATOR = "[NSEC2_SEPARATOR]";
        public static List<string> Load()
        {
            List<string> returnData = new List<string>();
            if(File.Exists(Global.DataPath+"/cache.nsec2"))
            {
                FileStream fileStream = File.OpenRead(Global.DataPath + "/cache.nsec2");
                NSEC2 nsec = new NSEC2(Global.PASSWORD);
                nsec.Load(fileStream);
                byte[] data = nsec.Get("content");
                string buffer = Encoding.UTF8.GetString(data);
                string[] files = buffer.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries);

                foreach(string file in files)
                {
                    if(File.Exists(file))
                        returnData.Add(file);
                }

                nsec.Dispose();
            }

            return returnData;
        }
        public static void Save()
        {
            NSEC2 nsec = new NSEC2(Global.PASSWORD);
            string buffer = "";
            foreach(string filepath in Global.Audios.Keys)
            {
                buffer += filepath + SEPARATOR;
            }

            byte[] data = Encoding.UTF8.GetBytes(buffer);
            nsec.AddFile("content", data);
            File.WriteAllBytes(Global.DataPath + "/cache.nsec2", nsec.Save());
            nsec.Dispose();
        }
    }
}