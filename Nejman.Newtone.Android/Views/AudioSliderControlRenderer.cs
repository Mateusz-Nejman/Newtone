using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Nejman.Newtone.Droid.Views;
using Nejman.Newtone.Mobile;
using Nejman.Newtone.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AudioSliderControl), typeof(AudioSliderControlRenderer))]

namespace Nejman.Newtone.Droid.Views
{
    public class AudioSliderControlRenderer : SliderRenderer
    {
        public AudioSliderControlRenderer(Context context) : base(context)
        {

        }
        #region Protected Methods
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.JellyBean)
            {
                if (Control == null)
                { return; }

                Control.SetPadding(0, 0, 0, 0);

                GradientDrawable p = new GradientDrawable();

                p.SetColor(Android.Graphics.Color.Rgb((int)(Colors.ThirdaryBackground.R * 255), (int)(Colors.ThirdaryBackground.G * 255), (int)(Colors.ThirdaryBackground.B * 255)));
                ClipDrawable progress = new ClipDrawable(p, GravityFlags.Left, ClipDrawableOrientation.Horizontal);
                GradientDrawable background = new GradientDrawable();
                background.SetColor(Android.Graphics.Color.Rgb(26, 26, 26));
                LayerDrawable pd = new LayerDrawable(new Drawable[] { background, progress });
                Control.SetProgressDrawableTiled(pd);

            }
        }
        #endregion
    }
}