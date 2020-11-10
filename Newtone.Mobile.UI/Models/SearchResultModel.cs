using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Processing;
using Newtone.Mobile.UI.Logic;
using Newtone.Mobile.UI.Processing;
using Newtone.Mobile.UI.Views;
using Newtone.Mobile.UI.Views.Custom;
using Xamarin.Forms;
using YoutubeExplode;

namespace Newtone.Mobile.UI.Models
{
    public class SearchResultModel : Newtone.Core.Models.SearchResultModel
    {
        #region Fields
        private ImageSource thumb;
        #endregion

        #region Properties
        public ImageSource Thumb
        {
            get
            {
                CheckThumb();
                return thumb;
            }
            set
            {
                if (thumb != value)
                {
                    thumb = value;
                    OnPropertyChanged();
                }
            }
        }
        public Color BackgroundColor
        {
            get => IsOffline ? Color.FromHex("#060606") : Color.Transparent;
        }

        public bool IsVisible => !IsOffline;
        #endregion
        #region Commands
        private ICommand downloadClicked;
        public ICommand DownloadClicked
        {
            get
            {
                if (downloadClicked == null)
                    downloadClicked = new ActionCommand(async (parameter) =>
                    {
                        ContextMenuBuilder.BuildForSearchResult(parameter as View, (parameter as CustomImageButton).Tag);
                    });

                return downloadClicked;
            }
            set => downloadClicked = value;
        }
        #endregion
        #region Constructors
        public SearchResultModel(Newtone.Core.Models.SearchResultModel model)
        {
            this.Author = model.Author;
            this.Duration = model.Duration;
            this.Id = model.Id;
            this.Image = model.Image;
            this.MixId = model.MixId;
            this.ThumbUrl = model.ThumbUrl;
            this.Title = model.Title;
            this.VideoData = model.VideoData;
        }
        #endregion
        #region Public Methods
        public void CheckChanges()
        {
            CheckThumb();
        }
        #endregion
        #region Private Methods
        private void CheckThumb()
        {
            if (thumb == null && Image != null)
            {
                thumb = ImageProcessing.FromArray(Image);
                OnPropertyChanged(() => Thumb);
            }
        }
        #endregion
    }
}
