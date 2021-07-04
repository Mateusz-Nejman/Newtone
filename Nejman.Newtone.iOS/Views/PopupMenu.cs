using Foundation;
using Nejman.Newtone.Core.Implementations;
using Nejman.Newtone.Core.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace Nejman.Newtone.iOS.Views
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
            var selected = await MessageImplementation.Current.Show("", Localization.Cancel, Items);
            OnSelect?.Invoke(selected);
        }

        #endregion
    }
}