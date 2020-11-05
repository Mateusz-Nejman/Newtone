using Newtone.Mobile.IOS.Views;
using Newtone.Mobile.UI.Views.Custom;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PressGestureMask), typeof(PressGestureMaskRenderer))]
namespace Newtone.Mobile.IOS.Views
{
    public class PressGestureMaskRenderer : ImageRenderer
    {
        #region Fields
        PressGestureMask view;
        #endregion
        #region Constructors
        public PressGestureMaskRenderer()
        {
            UILongPressGestureRecognizer longPressGestureRecognizer = new UILongPressGestureRecognizer(() => view?.HandleLongPress(view, EventArgs.Empty));
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) => view?.HandlePress(view, EventArgs.Empty);
            this.AddGestureRecognizer(longPressGestureRecognizer);
            this.Element.GestureRecognizers.Add(tapGestureRecognizer);
        }
        #endregion
        #region Protected Methods
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if(e.NewElement != null)
            {
                view = e.NewElement as PressGestureMask;
            }
        }
        #endregion
    }
}