using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtone.Mobile.UI.Logic;
using Xamarin.Forms;

namespace Newtone.Mobile.IOS.Media
{
    public class IosContextMenuBuilder : IContextMenuBuilder
    {
        public void BuildForArtist(View sender, string artistName, List<string> elements, Func<View, string, string, Task> action)
        {
            throw new NotImplementedException();
        }

        public void BuildForPlaylist(View sender, string playlistName, List<string> elements, Func<View, string, string, Task> action)
        {
            throw new NotImplementedException();
        }

        public void BuildForSyncList(View sender, string modelInfo, List<string> elements, Action<string> action)
        {
            throw new NotImplementedException();
        }

        public void BuildForTrack(View sender, string modelInfo, string filePath, string playlistName, List<string> elements, Func<string, string, string, Task> action)
        {
            throw new NotImplementedException();
        }
    }
}