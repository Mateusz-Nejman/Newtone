using Nejman.Newtone.Mobile.Contracts;
using System.IO;
using Xamarin.Forms;

namespace Nejman.Newtone.iOS.Implementations
{
    public class ImageProcessingImplementation : IImageProcessing
    {
        public ImageSource Blur(byte[] source)
        {
            return ImageSource.FromStream(() => new MemoryStream(source));
        }

        public ImageSource Blur(ImageSource source)
        {
            return source;
        }
    }
}