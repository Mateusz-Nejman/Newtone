using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Newtone.Mobile.IOS.Views;
using Newtone.Mobile.UI.Views.Custom;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AudioSliderControl), typeof(AudioSliderControlRenderer))]
namespace Newtone.Mobile.IOS.Views
{
    public class AudioSliderControlRenderer : SliderRenderer
    {
        #region Protected Methods
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            AudioSliderControl control = Element as AudioSliderControl;

            if(control != null)
            {
                //control.ThumbColor = Color.Transparent;
                control.BackgroundColor = Color.FromRgb(26, 26, 26);
            }
        }
        #endregion
    }
}