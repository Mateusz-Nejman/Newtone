using Android.Content;
using Newtone.Mobile.Droid.Views;
using Newtone.Mobile.UI.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ImageRenderer = Xamarin.Forms.Platform.Android.FastRenderers.ImageRenderer;

[assembly: ExportRenderer(typeof(PressGestureMask), typeof(PressGestureMaskRenderer))]

namespace Newtone.Mobile.Droid.Views
{
    public class PressGestureMaskRenderer : ImageRenderer
    {
        #region Fields
        PressGestureMask view;
        #endregion
        #region Constructors
        public PressGestureMaskRenderer(Context context) : base(context)
        {
            this.LongClick += (sender, args) => {
                view?.HandleLongPress(sender, args);
            };
            this.Click += (sender, args) =>
            {
                view?.HandlePress(sender, args);
            };
        }
        #endregion
        #region Protected Methods
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                view = e.NewElement as PressGestureMask;
            }
        }
        #endregion
    }
}