using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NSEC.Music_Player.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.FastRenderers;
using ImageRenderer = Xamarin.Forms.Platform.Android.FastRenderers.ImageRenderer;

[assembly: ExportRenderer(typeof(PressGestureMask), typeof(PressGestureMaskRenderer))]
namespace NSEC.Music_Player.Views.Custom
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