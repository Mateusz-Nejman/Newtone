using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Nejman.Xamarin.FocusLibrary
{
    public class NToggleButton : NImageButton, INFocusElement
    {
        #region Events
        public event EventHandler<ToggledEventArgs> Toggled;
        #endregion
        #region Properties
        public static readonly BindableProperty IsToggledProperty =
            BindableProperty.Create("IsToggled", typeof(bool), typeof(NToggleButton), false,
                                    propertyChanged: OnIsToggledChanged);

        public bool IsToggled
        {
            set { SetValue(IsToggledProperty, value); }
            get { return (bool)GetValue(IsToggledProperty); }
        }

        public static readonly BindableProperty TagProperty =
            BindableProperty.Create("Tag", typeof(string), typeof(NToggleButton), default(string));

        public string Tag
        {
            set { SetValue(TagProperty, value); }
            get { return (string)GetValue(TagProperty); }
        }
        #endregion
        #region Constructors
        public NToggleButton()
        {
            FocusContext.Register(this);
            this.BorderWidth = 2;
        }

        ~NToggleButton()
        {
            FocusContext.Unregister(this);
        }
        #endregion
        #region Private Methods
        private static void OnIsToggledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NToggleButton toggleButton = (NToggleButton)bindable;
            bool isToggled = (bool)newValue;

            // Fire event
            toggleButton.Toggled?.Invoke(toggleButton, new ToggledEventArgs(isToggled));
            Debug.WriteLine("Change toggle to " + isToggled);
            // Set the visual state
            VisualStateManager.GoToState(toggleButton, isToggled ? "ToggledOn" : "Normal");
        }
        #endregion
        #region Public Methods
        public new void FocusAction()
        {
            base.FocusAction();
            VisualStateManager.GoToState(this, IsToggled ? "ToggledOn" : "Normal");
        }
        #endregion
    }
}
