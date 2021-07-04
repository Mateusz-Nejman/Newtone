using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Mobile.Implementations;
using Nejman.Newtone.Mobile.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.Models
{
    public class SearchModel : PropertyChangedBase
    {
        private ImageSource image;
        public string Artist { get; }
        public string Title { get; }
        public TimeSpan Duration { get; }
        public string ID { get; }
        public ImageSource Image
        {
            get => image;
            private set
            {
                image = value;
                OnPropertyChanged();
            }
        }

        public string ImageUrl { get; }
        public byte[] ImageBytes { get; private set; }

        private ICommand downloadClicked;
        public ICommand DownloadClicked
        {
            get
            {
                if (downloadClicked == null)
                    downloadClicked = new ActionCommand(parameter =>
                    {
                        ContextMenuBuilder.BuildForSearchResult(parameter as View, Title+CoreGlobal.SEPARATOR+ID);
                    });

                return downloadClicked;
            }
            set => downloadClicked = value;
        }

        public SearchModel(MediaSource source)
        {
            Artist = source.Artist;
            Title = source.Title;
            Duration = source.Duration;
            ID = source.ID;
            ImageUrl = source.ImageUrl;
            ImageBytes = source.Image;
        }

        public void DownloadImage()
        {
            if(ImageUrl == null || ImageUrl.Length == 0)
            {
                Image = ImageProcessingImplementation.FromArray(ImageBytes);
            }
            else
            {
                using (WebClient webClient = new WebClient())
                {
                    ImageBytes = webClient.DownloadData(ImageUrl);
                    Image = ImageProcessingImplementation.FromArray(ImageBytes);
                }
            }
        }
    }
}
