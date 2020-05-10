﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NSEC.Music_Player.Views.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AudioSliderControl), typeof(AudioSliderControlRenderer))]
namespace NSEC.Music_Player.Views.Custom
{
    public class AudioSliderControlRenderer : SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Slider> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;


        }
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean)
            {
                if (Control == null)
                { return; }

                Control.SetPadding(0, 0, 0, 0);

                GradientDrawable p = new GradientDrawable();
                p.SetColor(Android.Graphics.Color.Rgb((int)Colors.ProgressBarColor.R, (int)Colors.ProgressBarColor.G, (int)Colors.ProgressBarColor.B));
                ClipDrawable progress = new ClipDrawable(p, GravityFlags.Left, ClipDrawable.Horizontal);
                GradientDrawable background = new GradientDrawable();
                background.SetColor(Android.Graphics.Color.Rgb(26, 26, 26));
                LayerDrawable pd = new LayerDrawable(new Drawable[] { background, progress });
                Control.SetProgressDrawableTiled(pd);
            }
        }
    }
}