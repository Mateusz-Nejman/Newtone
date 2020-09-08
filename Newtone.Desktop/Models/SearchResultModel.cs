using Newtone.Desktop.Processing;
using System.Windows.Media;

namespace Newtone.Desktop.Models
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
                if (thumb == null && Image != null)
                    thumb = ImageProcessing.FromArray(Image);
                return thumb;
            }
        }
        public Color BackgroundColor
        {
            get => Color.FromArgb((byte)(IsOffline ? 32 : 0), 255, 255, 255);
        }
        #endregion
        #region Constructors
        public SearchResultModel(Core.Models.SearchResultModel model)
        {
            this.Author = model.Author;
            this.Duration = model.Duration;
            this.Id = model.Id;
            this.Image = model.Image;
            this.MixId = model.MixId;
            this.ThumbUrl = model.ThumbUrl;
            this.Title = model.Title;
            this.VideoData = model.VideoData;
            OnPropertyChanged(() => BackgroundColor);
        }
        #endregion
    }
}
