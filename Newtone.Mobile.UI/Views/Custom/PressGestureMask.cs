using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.Views.Custom
{
    public class PressGestureMask : Xamarin.Forms.Image
    {
        #region Properties
        public static BindableProperty PressedCommandProperty =
            BindableProperty.Create("PressedCommand", typeof(ICommand), typeof(PressGestureMask));
        public static BindableProperty LongPressedCommandProperty =
            BindableProperty.Create("LongPressedCommand", typeof(ICommand), typeof(PressGestureMask));

        #endregion
        #region Events
        public event EventHandler LongPressed;
        public event EventHandler Pressed;
        #endregion
        #region Commands
        public ICommand PressedCommand
        {
            get => (ICommand)GetValue(PressedCommandProperty);
            set => SetValue(PressedCommandProperty, value);
        }

        public ICommand LongPressedCommand
        {
            get => (ICommand)GetValue(LongPressedCommandProperty);
            set => SetValue(LongPressedCommandProperty, value);
        }

        #endregion
        #region Public Methods

        public void HandleLongPress(object sender, EventArgs e)
        {
            LongPressed?.Invoke(sender, e);
            LongPressedCommand?.Execute(null);

        }

        public void HandlePress(object sender, EventArgs e)
        {
            Pressed?.Invoke(sender, e);
            PressedCommand?.Execute(null);
        }
        #endregion
    }
}
