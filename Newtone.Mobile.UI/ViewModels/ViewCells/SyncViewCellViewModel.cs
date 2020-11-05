using System.Windows.Input;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Logic;
using Newtone.Mobile.UI.Views.Custom;
using Xamarin.Forms;
namespace Newtone.Mobile.UI.ViewModels.ViewCells
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
