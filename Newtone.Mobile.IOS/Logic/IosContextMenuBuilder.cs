using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtone.Core.Languages;
using Newtone.Mobile.UI;
using Newtone.Mobile.UI.Logic;
using Newtone.Mobile.UI.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.IOS.Logic
{
    public class IosContextMenuBuilder : IContextMenuBuilder
    {
        private bool opened = false;
        public async void BuildForArtist(View sender, string artistName, List<string> elements, Func<View, string, string, Task> action)
        {
            if(!opened)
            {
                opened = true;
                string selected = await Global.Page.DisplayActionSheet("", Localization.Cancel, null, elements.ToArray());

                if (selected != Localization.Cancel)
                {
                    await action(sender, artistName, selected);
                }
                opened = false;
            }
        }

        public async void BuildForPlaylist(View sender, string playlistName, List<string> elements, Func<View, string, string, Task> action)
        {
            if(!opened)
            {
                opened = true;
                string selected = await Global.Page.DisplayActionSheet("", Localization.Cancel, Localization.Cancel, elements.ToArray());

                if (selected != Localization.Cancel)
                {
                    await action(sender, playlistName, selected);
                }
                opened = false;
            }
        }

        public async void BuildForSyncList(View sender, string modelInfo, List<string> elements, Action<string> action)
        {
            if(!opened)
            {
                opened = true;
                string selected = await Global.Page.DisplayActionSheet("", Localization.Cancel, Localization.Cancel, elements.ToArray());

                if (selected != Localization.Cancel)
                {
                    action(selected);
                }
                opened = false;
            }
        }

        public async void BuildForTrack(View sender, string modelInfo, string filePath, string playlistName, List<string> elements, Func<string, string, string, Task> action)
        {
            if(!opened)
            {
                opened = true;
                string selected = await Global.Page.DisplayActionSheet("", Localization.Cancel, Localization.Cancel, elements.ToArray());

                if (selected != Localization.Cancel)
                {
                    await action(filePath, selected, playlistName);
                }
                opened = false;
            }
        }
    }
}