using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.Contracts
{
    public interface IContextMenuBuilder
    {
        void BuildForTrack(View sender, string modelInfo, string filePath, string playlistName, List<string> elements, Func<string, string, string, Task> action);
        void BuildForSyncList(View sender, string modelInfo, List<string> elements, Action<string> action);
        void BuildForPlaylist(View sender, string playlistName, List<string> elements, Func<View, string, string, Task> action);
        void BuildForArtist(View sender, string artistName, List<string> elements, Func<View, string, string, Task> action);
        void BuildForSearchResult(View sender, string modelInfo, List<string> elements, Func<View, string, string, Task> action);
    }
}
