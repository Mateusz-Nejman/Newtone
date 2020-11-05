using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.Processing
{
    public static class ImageProcessing
    {
        #region Public Methods
        public static ImageSource Blur(byte[] source)
        {
            return Global.ImageProcessing.Blur(source);
        }
        public static ImageSource Blur(ImageSource source)
        {
            return Global.ImageProcessing.Blur(source);
        }

        public static ImageSource FromArray(byte[] source)
        {
            return ImageSource.FromStream(() => new MemoryStream(source));
        }
        #endregion
    }
}
