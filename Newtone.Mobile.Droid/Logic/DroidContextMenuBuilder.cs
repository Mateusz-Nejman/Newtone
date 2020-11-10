using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtone.Mobile.Droid.Views;
using Newtone.Mobile.UI.Logic;
using Xamarin.Forms;

namespace Newtone.Mobile.Droid.Logic
{
    public class DroidContextMenuBuilder : IContextMenuBuilder
    {
        #region Public Methods
        public void BuildForArtist(Xamarin.Forms.View sender, string artistName, List<string> elements, Func<Xamarin.Forms.View, string, string, Task> action)
        {
            Build(sender, elements, async (item) => await action(sender,artistName,item));
        }

        public void BuildForPlaylist(Xamarin.Forms.View sender, string playlistName, List<string> elements, Func<Xamarin.Forms.View, string, string, Task> action)
        {
            Build(sender, elements, async (item) => await action(sender, playlistName, item));
        }

        public void BuildForSearchResult(View sender, string modelInfo, List<string> elements, Func<View, string, string, Task> action)
        {
            Build(sender, elements, async(item) => await action(sender, modelInfo, item));
        }

        public void BuildForSyncList(Xamarin.Forms.View sender, string modelInfo, List<string> elements, Action<string> action)
        {
            Build(sender, elements, action);
        }

        public void BuildForTrack(Xamarin.Forms.View sender, string modelInfo, string filePath, string playlistName, List<string> elements, Func<string, string, string, Task> action)
        {
            Build(sender, elements, async (item) => await action(filePath, item, playlistName));
        }
        #endregion
        #region Private Methods
        private void Build(Xamarin.Forms.View sender, List<string> elements, Action<string> action)
        {
            PopupMenu popupMenu = new PopupMenu(MainActivity.Instance, sender, elements.ToArray());
            popupMenu.OnSelect += item => action(item);
            popupMenu.Show();
        }
        #endregion
    }
}