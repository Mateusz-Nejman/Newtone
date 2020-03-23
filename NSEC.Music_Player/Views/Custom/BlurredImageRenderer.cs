using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Renderscripts;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using NSEC.Music_Player.Views.Custom;
using System.ComponentModel;

#pragma warning disable CS0618 // Typ lub składowa jest przestarzała
[assembly: ExportRendererAttribute(typeof(BlurredImage), typeof(BlurredImageRenderer))]
namespace NSEC.Music_Player.Views.Custom
{
    public class BlurredImageRenderer : ViewRenderer<BlurredImage, Android.Widget.ImageView>
    {
        private bool _isDisposed;


        public BlurredImageRenderer()
        {
            base.AutoPackage = false;
        }


        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            _isDisposed = true;
            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BlurredImage> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                SetNativeControl(new ImageView(Context));
            }
            UpdateBitmap(e.OldElement);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == BlurredImage.SourceProperty.PropertyName)
            {
                UpdateBitmap(null);
            }
        }

        private void UpdateBitmap(BlurredImage previous = null)
        {
            
            if (!_isDisposed && Element.Source != null)
            {
                IImageSourceHandler handler = null;
                if (Element.Source is FileImageSource)
                {
                    handler = new FileImageSourceHandler();
                }
                else if (Element.Source is StreamImageSource)
                {
                    handler = new StreamImagesourceHandler(); // sic
                }
                else if (Element.Source is UriImageSource)
                {
                    handler = new ImageLoaderSourceHandler(); // sic
                }
                Bitmap b = null;
                Task.Run(async () => { b = await handler.LoadImageAsync(Element.Source, Global.Context); }).Wait();

                var newB = CreateBlurredImage(b, 25);
                Control.SetAdjustViewBounds(true);
                
                Control.SetScaleType(ImageView.ScaleType.FitCenter);
                Control.SetImageBitmap(newB);
               
                
                ((IVisualElementController)Element).NativeSizeChanged();
            }
        }

        private Bitmap CreateBlurredImage(Bitmap originalBitmap, int radius)
        {
            // Create another bitmap that will hold the results of the filter.  

            if (originalBitmap == null)
                return null;

            Bitmap blurredBitmap;
            blurredBitmap = Bitmap.CreateBitmap(originalBitmap);

            // Create the Renderscript instance that will do the work.  
            RenderScript rs = RenderScript.Create(Context);

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
    }
}
#pragma warning restore CS0618 // Typ lub składowa jest przestarzała