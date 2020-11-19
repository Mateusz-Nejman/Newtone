using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Xamarin.FocusLibrary
{
    internal class NKeyboardImageButton : Grid, INFocusElement
    {
        #region Fields
        private readonly Image image;
        #endregion
        #region Properties
        public static readonly BindableProperty IsNFocusedProperty =
            BindableProperty.Create("IsNFocused", typeof(bool), typeof(NKeyboardImageButton), false, propertyChanged: OnIsNFocusedChanged);
        public static readonly BindableProperty NBackColorProperty =
            BindableProperty.Create("NBackColor", typeof(Color), typeof(NKeyboardImageButton), Color.White);
        public static readonly BindableProperty NFontColorProperty =
            BindableProperty.Create("NFontColor", typeof(Color), typeof(NKeyboardImageButton), Color.Black);
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(NKeyboardImageButton), Color.Black, propertyChanged: OnFontColorChanged);

        public static readonly BindableProperty NextFocusLeftProperty =
            BindableProperty.Create("NextFocusLeft", typeof(INFocusElement), typeof(NKeyboardImageButton));
        public static readonly BindableProperty NextFocusRightProperty =
            BindableProperty.Create("NextFocusRight", typeof(INFocusElement), typeof(NKeyboardImageButton));
        public static readonly BindableProperty NextFocusUpProperty =
            BindableProperty.Create("NextFocusUp", typeof(INFocusElement), typeof(NKeyboardImageButton));
        public static readonly BindableProperty NextFocusDownProperty =
            BindableProperty.Create("NextFocusDown", typeof(INFocusElement), typeof(NKeyboardImageButton));
        public static readonly BindableProperty NCommandProperty =
            BindableProperty.Create("NCommand", typeof(ICommand), typeof(NKeyboardImageButton));

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(NKeyboardImageButton));

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create("Source", typeof(ImageSource), typeof(NKeyboardImageButton), propertyChanged: OnSourceChanged);
        public static readonly BindableProperty SourceWhiteProperty =
            BindableProperty.Create("SourceWhite", typeof(ImageSource), typeof(NKeyboardImageButton));
        public static readonly BindableProperty SourceBlackProperty =
            BindableProperty.Create("SourceBlack", typeof(ImageSource), typeof(NKeyboardImageButton));

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

        public object CommandParameter
        {
            set { SetValue(CommandParameterProperty, value); }
            get { return GetValue(CommandParameterProperty); }
        }

        public ImageSource Source
        {
            set { SetValue(SourceProperty, value); }
            get { return (ImageSource)GetValue(SourceProperty); }
        }

        public ImageSource SourceBlack
        {
            set { SetValue(SourceBlackProperty, value); }
            get { return (ImageSource)GetValue(SourceBlackProperty); }
        }
        public ImageSource SourceWhite
        {
            set { SetValue(SourceWhiteProperty, value); }
            get { return (ImageSource)GetValue(SourceWhiteProperty); }
        }

        public Color TextColor
        {
            set { SetValue(TextColorProperty, value); }
            get { return (Color)GetValue(TextColorProperty); }
        }

        public INFocusElement PrevionsElement { get; set; } //not used
        #endregion
        #region Constructors
        public NKeyboardImageButton()
        {
            FocusContext.Register(this);

            image = new Image();
            this.Children.Add(image);
        }

        ~NKeyboardImageButton()
        {
            FocusContext.Unregister(this);
        }
        #endregion
        #region Private Methods
        internal static void OnIsNFocusedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NKeyboardImageButton focusButton = (NKeyboardImageButton)bindable;
            bool isFocused = (bool)newValue;
            focusButton.BackgroundColor = isFocused ? focusButton.NFontColor : focusButton.NBackColor;
            focusButton.TextColor = isFocused ? focusButton.NBackColor : focusButton.NFontColor;
            focusButton.PrevionsElement = null;
        }

        private static void OnSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NKeyboardImageButton focusButton = (NKeyboardImageButton)bindable;
            ImageSource source = (ImageSource)newValue;
            focusButton.image.Source = source;
        }
        private static void OnFontColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NKeyboardImageButton focusButton = (NKeyboardImageButton)bindable;
            Color newColor = (Color)newValue;
            focusButton.Source = newColor == Color.White ? focusButton.SourceWhite : focusButton.SourceBlack;
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
