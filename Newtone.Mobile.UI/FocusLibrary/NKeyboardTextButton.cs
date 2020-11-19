using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Xamarin.FocusLibrary
{
    internal class NKeyboardTextButton : Button, INFocusElement
    {
        #region Properties
        public static readonly BindableProperty IsNFocusedProperty =
            BindableProperty.Create("IsNFocused", typeof(bool), typeof(NKeyboardTextButton), false, propertyChanged: OnIsNFocusedChanged);
        public static readonly BindableProperty NBackColorProperty =
            BindableProperty.Create("NBackColor", typeof(Color), typeof(NKeyboardTextButton), Color.White);
        public static readonly BindableProperty NFontColorProperty =
            BindableProperty.Create("NFontColor", typeof(Color), typeof(NKeyboardTextButton), Color.Black);

        public static readonly BindableProperty NextFocusLeftProperty =
            BindableProperty.Create("NextFocusLeft", typeof(INFocusElement), typeof(NKeyboardTextButton));
        public static readonly BindableProperty NextFocusRightProperty =
            BindableProperty.Create("NextFocusRight", typeof(INFocusElement), typeof(NKeyboardTextButton));
        public static readonly BindableProperty NextFocusUpProperty =
            BindableProperty.Create("NextFocusUp", typeof(INFocusElement), typeof(NKeyboardTextButton));
        public static readonly BindableProperty NextFocusDownProperty =
            BindableProperty.Create("NextFocusDown", typeof(INFocusElement), typeof(NKeyboardTextButton));
        public static readonly BindableProperty NCommandProperty =
            BindableProperty.Create("NCommand", typeof(ICommand), typeof(NKeyboardTextButton));

        public bool IsNFocused
        {
            set { SetValue(IsNFocusedProperty, value); }
            get { return (bool)GetValue(IsNFocusedProperty); }
        }

        public Color NBackColor
        {
            set { SetValue(NBackColorProperty, value); }
            get { return (Color)GetValue(NBackColorProperty); }
        }

        public Color NFontColor
        {
            set { SetValue(NFontColorProperty, value); }
            get { return (Color)GetValue(NFontColorProperty); }
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

        public ICommand NCommand
        {
            set { SetValue(NCommandProperty, value); }
            get { return (ICommand)GetValue(NCommandProperty); }
        }

        public INFocusElement PrevionsElement { get; set; } //not used
        #endregion
        #region Constructors
        public NKeyboardTextButton()
        {
            FocusContext.Register(this);
            this.BorderWidth = 0;
            this.BorderColor = Color.Transparent;
            TextTransform = TextTransform.None;
        }

        ~NKeyboardTextButton()
        {
            FocusContext.Unregister(this);
        }
        #endregion
        #region Private Methods
        internal static void OnIsNFocusedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NKeyboardTextButton focusButton = (NKeyboardTextButton)bindable;
            bool isFocused = (bool)newValue;
            focusButton.BackgroundColor = isFocused ? focusButton.NFontColor : focusButton.NBackColor;
            focusButton.TextColor = isFocused ? focusButton.NBackColor : focusButton.NFontColor;
            focusButton.PrevionsElement = null;
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
            if (NCommand?.CanExecute(CommandParameter) == true)
                NCommand.Execute(CommandParameter);
        }
        #endregion
    }
}
