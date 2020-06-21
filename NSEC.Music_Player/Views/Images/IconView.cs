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
using Xamarin.Forms;

namespace NSEC.Music_Player.Views.Images
{
	public class IconView : Xamarin.Forms.View
	{
		#region Properties

		public static readonly BindableProperty ForegroundProperty = BindableProperty.Create(nameof(Foreground), typeof(Color), typeof(IconView), default(Color));

		public Color Foreground
		{
			get
			{
				return (Color)GetValue(ForegroundProperty);
			}
			set
			{
				SetValue(ForegroundProperty, value);
			}
		}

		public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(IconView), default(string));

		public string Source
		{
			get
			{
				return (string)GetValue(SourceProperty);
			}
			set
			{
				SetValue(SourceProperty, value);
			}
		}

		public static readonly BindableProperty TagProperty = BindableProperty.Create(nameof(Tag), typeof(string), typeof(IconView), default(string));

		public string Tag
		{
			get
			{
				return (string)GetValue(TagProperty);
			}
			set
			{
				SetValue(TagProperty, value);
			}
		}

		public static readonly BindableProperty ChangeColorProperty = BindableProperty.Create(nameof(ChangeColor), typeof(bool), typeof(IconView), true);

		public bool ChangeColor
		{
			get
			{
				return (bool)GetValue(ChangeColorProperty);
			}
			set
			{
				SetValue(ChangeColorProperty, value);
			}
		}

		#endregion
	}
}