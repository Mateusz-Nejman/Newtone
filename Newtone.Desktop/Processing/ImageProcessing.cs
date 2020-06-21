using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace Newtone.Desktop.Processing
{
    public static class ImageProcessing
    {
        #region Public Methods
        public static BitmapImage FromArray(byte[] array)
        {
            MemoryStream memoryStream = new MemoryStream(array);
            memoryStream.Seek(0, SeekOrigin.Begin);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            return bitmapImage;
        }
        #endregion
    }
}
