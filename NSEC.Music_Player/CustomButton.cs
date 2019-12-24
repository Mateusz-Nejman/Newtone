using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NSEC.Music_Player
{
    public class CustomButton : Button
    {
        public static readonly BindableProperty TagProperty = BindableProperty.Create(
    propertyName: "Tag",
    returnType: typeof(string),
    declaringType: typeof(CustomButton),
    defaultValue: "");

        public string Tag
        {
            get { return (string)GetValue(TagProperty); }
            set { SetValue(TagProperty, value); }
        }
    }
}