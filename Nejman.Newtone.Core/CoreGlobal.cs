using Nejman.Newtone.Core.IO;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Nejman.Newtone.Core
{
    public static class CoreGlobal
    {
        public const string SEPARATOR = "[NSEC2_SEPARATOR]";
        public static MediaFormat MediaFormat { get; set; } = MediaFormat.m4a;
        internal static Dictionary<string, DownloadModel> Downloads { get; } = new Dictionary<string, DownloadModel>();
        internal static Dictionary<string, MediaSource> Audios { get; } = new Dictionary<string, MediaSource>();
        internal static Dictionary<string, MediaSourceTag> AudioTags { get; } = new Dictionary<string, MediaSourceTag>();
        internal static Dictionary<string, List<string>> Artists { get; } = new Dictionary<string, List<string>>();
        internal static List<string> DownloadedIds { get; } = new List<string>();
        internal static Dictionary<string, List<string>> Playlists { get; } = new Dictionary<string, List<string>>();
        internal static List<MediaSource> CurrentPlaylist { get; } = new List<MediaSource>();
        internal static int CurrentPlaylistPosition { get; set; } = 0;
        internal static int QueuePosition { get; set; } = 0;
        public static PlaybackMode PlaybackMode { get; set; } = PlaybackMode.All;
        public static MediaSource CurrentSource { get; internal set; }
        public static string CurrentLanguage { get; internal set; }
        public static List<string> IncludedPaths { get; } = new List<string>();
        public static Subject<string> ArtistsRefresh { get; } = new Subject<string>();
        public static Subject<string> PlaylistsRefresh { get; } = new Subject<string>();
        public static Subject<bool> TracksRefresh { get; } = new Subject<bool>();
        public static string DataPath { get; set; }
        public static string MusicPath { get; set; }
        public static MediaPlayer MediaPlayer { get; } = new MediaPlayer();
        internal static List<string> History { get; } = new List<string>();
        public static int IncludedPathsToSkip { get; set; }

        public static void SelectLanguage(string language)
        {
            CurrentLanguage = language;
        }

        public static async Task LoadData()
        {
            DataFile.Load();
            DataFile.LoadTags();
            await AudiosLoader.Load();
            ArtistsRefresh.OnNext("");
            PlaylistsRefresh.OnNext("");
        }

        public static void SaveData()
        {
            DataFile.Save();
        }

        public static List<string> GetHistory()
        {
            return History;
        }
    }
}
