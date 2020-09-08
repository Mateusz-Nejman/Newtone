using System.Windows;
using System.Windows.Controls;

namespace Newtone.Desktop.Views.Custom
{
    public class TagButton:Button
    {
        #region Properties
        public string Value
        {
            get
            {
                return (string)base.GetValue(ValueProperty);
            }
            set
            {
                base.SetValue(ValueProperty, value);
            }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(TagButton));
        #endregion
    }
}
