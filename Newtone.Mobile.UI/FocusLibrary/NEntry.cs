using Xamarin.Forms;

namespace Nejman.Xamarin.FocusLibrary
{
    public class NEntry : Entry, INFocusElement
    {
        #region Properties
        public static readonly BindableProperty IsNFocusedProperty =
            BindableProperty.Create("IsNFocused", typeof(bool), typeof(NEntry), false, propertyChanged: OnIsNFocusedChanged);
        public static readonly BindableProperty NFocusColorProperty =
            BindableProperty.Create("NFocusColor", typeof(Color), typeof(NEntry), Color.FromRgba(255, 255, 255, 60));

        public static readonly BindableProperty NextFocusLeftProperty =
            BindableProperty.Create("NextFocusLeft", typeof(INFocusElement), typeof(NEntry));
        public static readonly BindableProperty NextFocusRightProperty =
            BindableProperty.Create("NextFocusRight", typeof(INFocusElement), typeof(NEntry));
        public static readonly BindableProperty NextFocusUpProperty =
            BindableProperty.Create("NextFocusUp", typeof(INFocusElement), typeof(NEntry));
        public static readonly BindableProperty NextFocusDownProperty =
            BindableProperty.Create("NextFocusDown", typeof(INFocusElement), typeof(NEntry));

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

        public INFocusElement PrevionsElement { get; set; } //not used
        #endregion
        #region Constructors
        public NEntry()
        {
            FocusContext.Register(this);
        }

        ~NEntry()
        {
            FocusContext.Unregister(this);
        }
        #endregion
        #region Private Methods
        private static void OnIsNFocusedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NEntry focusButton = (NEntry)bindable;
            bool isFocused = (bool)newValue;

            focusButton.BackgroundColor = isFocused ? focusButton.NFocusColor : Color.Transparent;
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
            base.Focus();
        }
        #endregion
    }
}
