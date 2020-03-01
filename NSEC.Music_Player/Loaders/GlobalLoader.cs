using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Processing;

namespace NSEC.Music_Player.Loaders
{
    public static class GlobalLoader
    {
        public async static void Load()
        {
            if(Global.Audios.Count == 0)
            {
                MediaSource[] sources = await FileProcessing.LoadFiles(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath);

                foreach(MediaSource source in sources)
                {
                    AddTrack(source);
                }

                CacheString.Save();
            }

            Global.AsyncEndController.Invoke("authorstab");
            Global.AsyncEndController.Invoke("trackstab");
            Global.AsyncEndController.Invoke("playliststab");
            Global.AsyncEndController.Invoke("homepage");
        }

        public async static Task Reload()
        {
            MediaSource[] sources = await FileProcessing.LoadFiles(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath);

            foreach (MediaSource source in sources)
            {
                if(!Global.Audios.ContainsKey(source.FilePath))
                {
                    AddTrack(source);
                }
            }

            CacheString.Save();

            Global.AsyncEndController.Invoke("authorstab");
            Global.AsyncEndController.Invoke("trackstab");
            Global.AsyncEndController.Invoke("playliststab");
            Global.AsyncEndController.Invoke("homepage");
        }

        public static void AddTrack(MediaSource source)
        {
            if(!Global.Audios.ContainsKey(source.FilePath) && File.Exists(source.FilePath))
            {
                Global.Audios.Add(source.FilePath, source);

                if (!Global.Artists.ContainsKey(source.Artist))
                    Global.Artists.Add(source.Artist, new List<string>());

                Global.Artists[source.Artist].Add(source.FilePath);
            }
        }

        public static void RemoveTrack(string path, bool playlist, params ObservableCollection<string>[] sources)
        {
            if (!playlist)
            {
                foreach (string filepath in Global.Audios.Keys)
                {
                    MediaSource container = Global.Audios[filepath];
                    if (container.FilePath == path)
                    {
                        Global.Audios.Remove(filepath);
                        break;
                    }
                }
            }

            foreach (ObservableCollection<string> trackList in sources)
            {
                foreach (string trackName in trackList)
                {
                    MediaSource track = Global.Audios[trackName];
                    if (track.FilePath == path)
                    {
                        trackList.Remove(path);
                        break;
                    }
                }
            }
        }

        public static void AddToCounter(string filepath, int count)
        {
            List<TrackCounter> tracks = new List<TrackCounter>(Global.MostTracks);
            int index = tracks.FindIndex(o => o.Media.FilePath == filepath);

            if (index == -1)
                tracks.Add(new TrackCounter(Global.Audios[filepath], count));
            else
                tracks[index].Count += count;

            Global.MostTracks = tracks.ToArray();

            Global.SaveConfig();
        }

        public static void AddToLast(string filepath)
        {
            List<TrackCounter> tracks = new List<TrackCounter>(Global.LastTracks);

            int index = tracks.FindIndex(o => o.Media.FilePath == filepath);
            if (index >= 0)
                tracks.RemoveAt(index);
            tracks.Reverse();


            tracks.Add(new TrackCounter(Global.Audios[filepath], 0));
            tracks.Reverse();
            if (tracks.Count > 5)
                tracks.RemoveAt(tracks.Count - 1);

            Global.LastTracks = tracks.ToArray();
            Global.SaveConfig();
        }
    }
}