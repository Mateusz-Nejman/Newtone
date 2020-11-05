using System;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.Views.Custom
{
    public class CustomImageButton : ImageButton
    {
        #region Events
        public event EventHandler<ToggledEventArgs> Toggled;
        #endregion
        #region Properties
        public static BindableProperty IsToggledProperty =
            BindableProperty.Create("IsToggled", typeof(bool), typeof(CustomImageButton), false,
                                    propertyChanged: OnIsToggledChanged);

        public bool IsToggled
        {
            set { SetValue(IsToggledProperty, value); }
            get { return (bool)GetValue(IsToggledProperty); }
        }

        public static BindableProperty TagProperty =
            BindableProperty.Create("Tag", typeof(string), typeof(CustomImageButton), default(string));

        public string Tag
        {
            set { SetValue(TagProperty, value); }
            get { return (string)GetValue(TagProperty); }
        }
        #endregion
        #region Constructor
        public CustomImageButton()
        {
            Clicked += CustomImageButton_Clicked;
        }
        #endregion
        #region Private Methods
        private static void OnIsToggledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CustomImageButton toggleButton = (CustomImageButton)bindable;
            bool isToggled = (bool)newValue;

            // Fire event
            toggleButton.Toggled?.Invoke(toggleButton, new ToggledEventArgs(isToggled));
            Console.WriteLine("Change toggle to " + isToggled);
            // Set the visual state
            VisualStateManager.GoToState(toggleButton, isToggled ? "ToggledOn" : "Normal");
        }

        private void CustomImageButton_Clicked(object sender, EventArgs e)
        {
            VisualStateManager.GoToState(this, IsToggled ? "ToggledOn" : "Normal");
        }
        #endregion
    }
}
