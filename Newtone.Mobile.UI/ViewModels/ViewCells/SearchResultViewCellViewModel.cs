using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Mobile.UI.Logic;
using Newtone.Mobile.UI.Views;
using Newtone.Mobile.UI.Views.Custom;
using YoutubeExplode;

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
                    downloadClicked = new ActionCommand(async (parameter) =>
                    {
                        ContextMenuBuilder.BuildForSearchResult(parameter as Xamarin.Forms.View, (parameter as CustomImageButton).Tag);
                    });

                return downloadClicked;
            }
        }
        #endregion
    }
}
