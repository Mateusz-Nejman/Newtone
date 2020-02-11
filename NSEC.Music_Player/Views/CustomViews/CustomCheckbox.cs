using Xamarin.Forms;

namespace NSEC.Music_Player.Views.CustomViews
{
    public class CustomCheckbox : CheckBox
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