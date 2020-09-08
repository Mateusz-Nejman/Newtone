using System.Windows.Input;
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