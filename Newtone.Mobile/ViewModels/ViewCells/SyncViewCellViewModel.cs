using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Newtone.Core.Logic;
using Newtone.Mobile.Logic;
using Newtone.Mobile.Views.Images;
using Xamarin.Forms;

namespace Newtone.Mobile.ViewModels.ViewCells
{
    public class SyncViewCellViewModel
    {
        #region Commands
        private ICommand openMenu;
        public ICommand OpenMenu
        {
            get
            {
                if (openMenu == null)
                    openMenu = new ActionCommand(parameter =>
                    {
                        ContextMenuBuilder.BuildForSyncList((View)parameter, ((CustomImageButton)parameter).Tag);
                    });
                return openMenu;
            }
        }
        #endregion
    }
}