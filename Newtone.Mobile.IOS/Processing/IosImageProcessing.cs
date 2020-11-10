using System.IO;
using Newtone.Mobile.UI.Logic;
using Xamarin.Forms;

namespace Newtone.Mobile.IOS.Processing
{
    public class IosImageProcessing : IImageProcessing
    {
        public ImageSource Blur(byte[] source)
        {
            return ImageSource.FromStream(()=> new MemoryStream(source));
        }

        public ImageSource Blur(ImageSource source)
        {
            return source;
        }
    }
}