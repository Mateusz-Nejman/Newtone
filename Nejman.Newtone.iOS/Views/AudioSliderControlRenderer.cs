using Nejman.Newtone.iOS.Views;
using Nejman.Newtone.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AudioSliderControl), typeof(AudioSliderControlRenderer))]
namespace Nejman.Newtone.iOS.Views
{
    public class AudioSliderControlRenderer : SliderRenderer
    {
        #region Protected Methods
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            AudioSliderControl control = Element as AudioSliderControl;

            if (control != null)
            {
                //control.ThumbColor = Color.Transparent;
                control.BackgroundColor = Color.FromRgb(26, 26, 26);
            }
        }
        #endregion
    }
}