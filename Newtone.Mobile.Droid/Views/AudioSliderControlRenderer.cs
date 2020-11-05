﻿using System;
using System.Collections.Generic;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Newtone.Mobile.Droid.Views;
using Newtone.Mobile.UI;
using Newtone.Mobile.UI.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AudioSliderControl), typeof(AudioSliderControlRenderer))]
namespace Newtone.Mobile.Droid.Views
{
    public class AudioSliderControlRenderer : SliderRenderer
    {
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
                
                p.SetColor(Android.Graphics.Color.Rgb((int)Colors.ProgressBarColor.R, (int)Colors.ProgressBarColor.G, (int)Colors.ProgressBarColor.B));
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