using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "NSEC.Music_Player.Resources.AppResource";
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;
            ResourceManager resourceManager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);

            return resourceManager.GetString(Text, CultureInfo.CurrentCulture);
        }
    }
}