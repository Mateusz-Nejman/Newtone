using Nejman.Newtone.Core.Exceptions;
using Nejman.Newtone.Mobile.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.Implementations
{
    public static class ImageProcessingImplementation
    {
        private static IImageProcessing imageProcessing;

        public static IImageProcessing Current => imageProcessing;
        public static void Initialize(IImageProcessing implementation)
        {
            if(imageProcessing != null)
            {
                throw new ImplementationException("ImageProcessing");
            }

            imageProcessing = implementation;
        }

        public static ImageSource FromArray(byte[] source)
        {
            return source == null || source.Length == 0 ? Global.EmptyTrackImage : ImageSource.FromStream(() => new MemoryStream(source));
        }
    }
}
