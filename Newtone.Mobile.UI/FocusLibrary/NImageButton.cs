using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Xamarin.FocusLibrary
{
    public class NImageButton : ImageButton, INFocusElement
    {
        #region Properties
        public static readonly BindableProperty IsNFocusedProperty =
            BindableProperty.Create("IsNFocused", typeof(bool), typeof(NImageButton), false, propertyChanged: OnIsNFocusedChanged);
        public static readonly BindableProperty NFocusColorProperty =
            BindableProperty.Create("NFocusColor", typeof(Color), typeof(NImageButton), Color.White);

        public static readonly BindableProperty NextFocusLeftProperty =
            BindableProperty.Create("NextFocusLeft", typeof(INFocusElement), typeof(NImageButton));
        public static readonly BindableProperty NextFocusRightProperty =
            BindableProperty.Create("NextFocusRight", typeof(INFocusElement), typeof(NImageButton));
        public static readonly BindableProperty NextFocusUpProperty =
            BindableProperty.Create("NextFocusUp", typeof(INFocusElement), typeof(NImageButton));
        public static readonly BindableProperty NextFocusDownProperty =
            BindableProperty.Create("NextFocusDown", typeof(INFocusElement), typeof(NImageButton));
        public static readonly BindableProperty NCommandProperty =
            BindableProperty.Create("NCommand", typeof(ICommand), typeof(NImageButton));

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

        public ICommand NCommand
        {
            set { SetValue(NCommandProperty, value); }
            get { return (ICommand)GetValue(NCommandProperty); }
        }
        #endregion
        #region Constructors
        public NImageButton()
        {
            FocusContext.Register(this);
            this.BorderWidth = 2;
        }

        ~NImageButton()
        {
            FocusContext.Unregister(this);
        }
        #endregion
        #region Private Methods
        private static void OnIsNFocusedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NImageButton focusButton = (NImageButton)bindable;
            bool isFocused = (bool)newValue;

            focusButton.BorderColor = isFocused ? focusButton.NFocusColor : Color.Transparent;
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
