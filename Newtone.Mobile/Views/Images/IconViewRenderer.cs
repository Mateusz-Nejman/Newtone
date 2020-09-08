﻿using System.ComponentModel;
using Android.Graphics;
using Android.Widget;
using Newtone.Mobile.Views.Images;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0618 // Typ lub składowa jest przestarzała
[assembly: ExportRendererAttribute(typeof(IconView), typeof(IconViewRenderer))]
namespace Newtone.Mobile.Views.Images
{
    public class IconViewRenderer : ViewRenderer<IconView, ImageView>
    {
        #region Fields
        private bool _isDisposed;
        #endregion
        #region Constructors
        public IconViewRenderer()
        {
            base.AutoPackage = false;
        }
        #endregion
        #region Protected Methods
        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            _isDisposed = true;
            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<IconView> e)
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
            if (e.PropertyName == IconView.SourceProperty.PropertyName)
            {
                UpdateBitmap(null);
            }
            else if (e.PropertyName == IconView.ForegroundProperty.PropertyName)
            {
                UpdateBitmap(null);
            }
        }
        #endregion
        #region Private Methods
        private void UpdateBitmap(IconView previous = null)
        {
            if (!_isDisposed && !string.IsNullOrWhiteSpace(Element.Source))
            {
                var d = Resources.GetDrawable(Element.Source).Mutate();

                if (Element.ChangeColor)
                {
                    d.SetColorFilter(new LightingColorFilter(Element.Foreground.ToAndroid(), Element.Foreground.ToAndroid()));
                    d.Alpha = Element.Foreground.ToAndroid().A;
                }
                Control.SetImageDrawable(d);
                ((IVisualElementController)Element).NativeSizeChanged();
            }
        }
        #endregion
    }
}
#pragma warning restore CS0618 // Typ lub składowa jest przestarzała