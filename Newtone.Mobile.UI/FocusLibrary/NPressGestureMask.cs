using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Xamarin.FocusLibrary
{
    public class NPressGestureMask : Frame, INFocusElement
    {
        #region Properties
        public static readonly BindableProperty IsNFocusedProperty =
            BindableProperty.Create("IsNFocused", typeof(bool), typeof(NPressGestureMask), false, propertyChanged: OnIsNFocusedChanged);
        public static readonly BindableProperty NFocusColorProperty =
            BindableProperty.Create("NFocusColor", typeof(Color), typeof(NPressGestureMask), Color.FromRgba(255,255,255,60));

        public static readonly BindableProperty NextFocusLeftProperty =
            BindableProperty.Create("NextFocusLeft", typeof(INFocusElement), typeof(NPressGestureMask));
        public static readonly BindableProperty NextFocusRightProperty =
            BindableProperty.Create("NextFocusRight", typeof(INFocusElement), typeof(NPressGestureMask));
        public static readonly BindableProperty NextFocusUpProperty =
            BindableProperty.Create("NextFocusUp", typeof(INFocusElement), typeof(NPressGestureMask));
        public static readonly BindableProperty NextFocusDownProperty =
            BindableProperty.Create("NextFocusDown", typeof(INFocusElement), typeof(NPressGestureMask));

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(NPressGestureMask));
        public static readonly BindableProperty LongCommandProperty =
            BindableProperty.Create("LongCommand", typeof(ICommand), typeof(NPressGestureMask));

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(NPressGestureMask));
        public static readonly BindableProperty LongCommandParameterProperty =
            BindableProperty.Create("LongCommandParameter", typeof(object), typeof(NPressGestureMask));

        public bool IsNFocused
        {
            set { SetValue(IsNFocusedProperty, value); }
            get { return (bool)GetValue(IsNFocusedProperty); }
        }

        public Color NFocusColor
        {
            set { SetValue(NFocusColorProperty, value); }
            get { return (Color)GetValue(NFocusColorProperty); }
        }

        public INFocusElement NextFocusLeft
        {
            set { SetValue(NextFocusLeftProperty, value); }
            get { return (INFocusElement)GetValue(NextFocusLeftProperty); }
        }

        public INFocusElement NextFocusRight
        {
            set { SetValue(NextFocusRightProperty, value); }
            get { return (INFocusElement)GetValue(NextFocusRightProperty); }
        }

        public INFocusElement NextFocusUp
        {
            set { SetValue(NextFocusUpProperty, value); }
            get { return (INFocusElement)GetValue(NextFocusUpProperty); }
        }

        public INFocusElement NextFocusDown
        {
            set { SetValue(NextFocusDownProperty, value); }
            get { return (INFocusElement)GetValue(NextFocusDownProperty); }
        }

        public ICommand Command
        {
            set { SetValue(CommandProperty, value); }
            get { return (ICommand)GetValue(CommandProperty); }
        }

        public ICommand LongCommand
        {
            set { SetValue(LongCommandProperty, value); }
            get { return (ICommand)GetValue(LongCommandProperty); }
        }

        public object CommandParameter
        {
            set { SetValue(CommandParameterProperty, value); }
            get { return GetValue(CommandParameterProperty); }
        }

        public object LongCommandParameter
        {
            set { SetValue(LongCommandParameterProperty, value); }
            get { return GetValue(LongCommandParameterProperty); }
        }
        #endregion
        #region Constructors
        public NPressGestureMask()
        {
            FocusContext.Register(this);
            this.BackgroundColor = Color.Transparent;
            this.BorderColor = Color.Transparent;
        }

        ~NPressGestureMask()
        {
            FocusContext.Unregister(this);
        }
        #endregion
        #region Private Methods
        private static void OnIsNFocusedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NPressGestureMask focusFrame = (NPressGestureMask)bindable;
            bool isFocused = (bool)newValue;

            focusFrame.BackgroundColor = isFocused ? focusFrame.NFocusColor : Color.Transparent;
        }
        #endregion
        #region Public Methods
        public void FocusLeft()
        {
            FocusContext.FocusLeft(this);
        }

        public void FocusRight()
        {
            FocusContext.FocusRight(this);
        }

        public void FocusUp()
        {
            FocusContext.FocusUp(this);
        }

        public void FocusDown()
        {
            FocusContext.FocusDown(this);
        }

        public void FocusAction()
        {
            if (Command?.CanExecute(CommandParameter) == true)
                Command.Execute(CommandParameter);
        }

        public void LongAction()
        {
            if (LongCommand?.CanExecute(LongCommandParameter) == true)
                LongCommand.Execute(LongCommandParameter);
        }
        #endregion
    }
}
