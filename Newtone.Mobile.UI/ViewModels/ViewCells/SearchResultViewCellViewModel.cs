using System.Windows.Input;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Logic;
using Newtone.Mobile.UI.Views.Custom;

namespace Newtone.Mobile.UI.ViewModels.ViewCells
{
    public class SearchResultViewCellViewModel
    {
        #region Commands
        private ICommand downloadClicked;
        public ICommand DownloadClicked
        {
            get
            {
                if (downloadClicked == null)
                    downloadClicked = new ActionCommand(parameter =>
                    {
                        ContextMenuBuilder.BuildForSearchResult(parameter as Xamarin.Forms.View, (parameter as CustomImageButton).Tag);
                    });

                return downloadClicked;
            }
        }
        #endregion
    }
}
