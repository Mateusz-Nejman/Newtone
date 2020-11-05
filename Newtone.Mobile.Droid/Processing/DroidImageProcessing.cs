﻿using System.IO;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Renderscripts;
using Newtone.Mobile.UI.Logic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Newtone.Mobile.Droid.Processing
{
    public class DroidImageProcessing : IImageProcessing
    {
        #region Public Methods
        public ImageSource Blur(byte[] source)
        {
            Bitmap b = BitmapFactory.DecodeByteArray(source, 0, source.Length);

            var bitmap = CreateBlurredImage(b, 25);

            byte[] bitmapData;
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }

            return ImageSource.FromStream(() => new MemoryStream(bitmapData));
        }
        public ImageSource Blur(ImageSource source)
        {
            IImageSourceHandler handler = null;
            if (source is FileImageSource)
            {
                handler = new FileImageSourceHandler();
            }
            else if (source is StreamImageSource)
            {
                handler = new StreamImagesourceHandler(); // sic
            }
            else if (source is UriImageSource)
            {
                handler = new ImageLoaderSourceHandler(); // sic
            }
            Bitmap b = null;

            Task.Run(async () => { b = await handler.LoadImageAsync(source, MainActivity.Instance); }).Wait();

            var bitmap = CreateBlurredImage(b, 25);

            byte[] bitmapData;
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }

            return ImageSource.FromStream(() => new MemoryStream(bitmapData));
        }

        public static ImageSource FromArray(byte[] source)
        {
            return ImageSource.FromStream(() => new MemoryStream(source));
        }
        #endregion

        #region Private Methods
        private static Bitmap CreateBlurredImage(Bitmap originalBitmap, int radius)
        {
            // Create another bitmap that will hold the results of the filter.  

            if (originalBitmap == null)
                return null;

            Bitmap blurredBitmap;
            blurredBitmap = Bitmap.CreateBitmap(originalBitmap);

            // Create the Renderscript instance that will do the work.  
            RenderScript rs = RenderScript.Create(MainActivity.Instance);

            // Allocate memory for Renderscript to work with  
            Allocation input = Allocation.CreateFromBitmap(rs, originalBitmap, Allocation.MipmapControl.MipmapFull, AllocationUsage.Script);
            Allocation output = Allocation.CreateTyped(rs, input.Type);

            // Load up an instance of the specific script that we want to use.  
            ScriptIntrinsicBlur script = ScriptIntrinsicBlur.Create(rs, Android.Renderscripts.Element.U8_4(rs));
            script.SetInput(input);

            // Set the blur radius  
            script.SetRadius(radius);

            // Start Renderscript working.  
            script.ForEach(output);

            // Copy the output to the blurred bitmap  
            output.CopyTo(blurredBitmap);

            return blurredBitmap;
        }
        #endregion
    }
}