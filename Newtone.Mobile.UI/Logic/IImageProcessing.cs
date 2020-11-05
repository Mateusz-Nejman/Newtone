using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.Logic
{
    public interface IImageProcessing
    {
        ImageSource Blur(byte[] source);
        ImageSource Blur(ImageSource source);
    }
}
