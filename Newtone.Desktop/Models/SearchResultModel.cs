using Newtone.Desktop.Processing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Newtone.Desktop.Models
{
    public class SearchResultModel : Newtone.Core.Models.SearchResultModel
    {
        private ImageSource thumb;
        public ImageSource Thumb
        {
            get
            {
                if (thumb == null && Image != null)
                    thumb = ImageProcessing.FromArray(Image);
                return thumb;
            }
        }

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
        }
    }
}
