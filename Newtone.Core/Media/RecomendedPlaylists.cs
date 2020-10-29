using Newtone.Core.Logic;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Newtone.Core.Media
{
    public static class RecomendedPlaylists
    {
        public static Dictionary<string, string> GetRecomendedPlaylists()
        {
            Dictionary<string, string> playlists = new Dictionary<string, string>(); //Name, url

            byte[] data;
            try
            {
                using WebClient client = new WebClient();
                data = client.DownloadData("https://mateusz-nejman.pl/recomended_playlists.txt");
            }
            catch
            {
                return playlists;
            }

            string buffer = Encoding.UTF8.GetString(data);

            string[] lines = buffer.Split('\n', System.StringSplitOptions.RemoveEmptyEntries);

            foreach(var line in lines)
            {
                string[] elems = line.Split(';');
                if(YoutubeExplodeExtensions.TryParsePlaylistId(elems[1], out string playlistId) && !GlobalData.Current.WebToLocalPlaylists.ContainsKey(playlistId))
                {
                    playlists.Add(elems[0], elems[1]);
                }
            }

            return playlists;
        }
    }
}
