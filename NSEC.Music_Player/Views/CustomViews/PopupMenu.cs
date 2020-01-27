using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Java.Lang;
using NSEC.Music_Player.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace NSEC.Music_Player.Views.CustomViews
{
    public class PopupMenu
    {
        public delegate void PopupMenuEventHandler(string item);
        private Context Context { get; set; }
        private View Anchor { get; set; }
        private string[] Items { get; set; }
        public PopupMenuEventHandler OnSelect;

        private Android.Widget.PopupMenu Menu { get; set; }
        public PopupMenu(Context context, View anchor, params string[] items)
        {
            Context = context;
            Anchor = anchor;
            Items = items;

            
            Menu = new Android.Widget.PopupMenu(Context, Anchor.GetRenderer().View);

            for(int a = 0; a < Items.Length; a++)
            {
                ICharSequence item = new Java.Lang.String(Items[a]);
                Menu.Menu.Add(item);
            }
            Menu.MenuItemClick += Menu_MenuItemClick;
        }

        private void Menu_MenuItemClick(object sender, Android.Widget.PopupMenu.MenuItemClickEventArgs e)
        {
            OnSelect?.Invoke(e.Item.TitleFormatted.ToString());
        }

        public void Show()
        {
            Menu.Show();
        }
    }
}