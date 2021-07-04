using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.Contracts
{
    public interface IImageProcessing
    {
        ImageSource Blur(byte[] source);
        ImageSource Blur(ImageSource source);
    }
}
