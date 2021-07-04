using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using Newtone.Core.Languages;
using Newtone.Mobile.UI;
using UIKit;
using Xamarin.Forms;

namespace Newtone.Mobile.IOS.Views
{
    public class PopupMenu
    {
        #region Events & Delegates
        public delegate void PopupMenuEventHandler(string item);
        public event PopupMenuEventHandler OnSelect;
        #endregion
        #region Properties
        private string[] Items { get; set; }
        #endregion
        #region Constructors
        public PopupMenu(params string[] items)
        {
            Items = items;
        }
        #endregion
        #region Public Methods
        public async Task Show()
        {
            var selected = await Global.Page.DisplayActionSheet("", Localization.Cancel, Localization.Cancel, Items);
            OnSelect?.Invoke(selected);
        }

        #endregion
    }
}