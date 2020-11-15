using Newtone.Core.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Xamarin.FocusLibrary
{
    public class NScreenKeyboard : Grid, INFocusElement
    {
        #region Events
        public event KeyboardClicked OnKeyboardClicked;
        public delegate void KeyboardClicked(string clickedButton);
        #endregion
        #region Fields
        public const string EnterButton = "NT";
        public const string RemoveButton = "RM";
        private readonly char[,] letters = new char[4, 7]
        {
            {'A','B','C','D','E','F','G' },
            {'H','I','J','K','L','M','N' },
            {'O','P','Q','R','S','T','U' },
            {'V','W','X','Y','Z','-','\'' }
        };

        private readonly char[,] variantLetters = new char[4, 7]
        {
            {'Ą','Ć','Ę','Ł','Ń','Ó','Ś' },
            {'Ż','Ź',' ',' ',' ', ' ',' ' },
            {' ',' ',' ',' ',' ', ' ',' ' },
            {' ',' ',' ',' ',' ', ' ',' ' }
        };

        private readonly char[,] numbers = new char[4, 7]
        {
            {'1','2','3','&','#','(',')' },
            {'4','5','6','@','!','?',':' },
            {'7','8','9','*','.','_','"' },
            {'|','0','/','\\','<','>',',' }
        };

        private int keyboardPage = 0;
        private readonly Dictionary<int, int[]> indexes = new Dictionary<int, int[]>();
        #endregion
        #region Properties
        public static readonly BindableProperty IsNFocusedProperty =
            BindableProperty.Create("IsNFocused", typeof(bool), typeof(NScreenKeyboard), false, propertyChanged: OnIsNFocusedChanged);
        public static readonly BindableProperty NFocusColorProperty =
            BindableProperty.Create("NFocusColor", typeof(Color), typeof(NScreenKeyboard), Color.White, propertyChanged: OnFocusColorChanged);

        public static readonly BindableProperty NextFocusLeftProperty =
            BindableProperty.Create("NextFocusLeft", typeof(INFocusElement), typeof(NScreenKeyboard), propertyChanged: OnElementChanged);
        public static readonly BindableProperty NextFocusRightProperty =
            BindableProperty.Create("NextFocusRight", typeof(INFocusElement), typeof(NScreenKeyboard), propertyChanged: OnElementChanged);
        public static readonly BindableProperty NextFocusUpProperty =
            BindableProperty.Create("NextFocusUp", typeof(INFocusElement), typeof(NScreenKeyboard), propertyChanged: OnElementChanged);
        public static readonly BindableProperty NextFocusDownProperty =
            BindableProperty.Create("NextFocusDown", typeof(INFocusElement), typeof(NScreenKeyboard), propertyChanged: OnElementChanged);

        public static readonly BindableProperty NBackColorProperty =
            BindableProperty.Create("NBackColor", typeof(Color), typeof(NScreenKeyboard), Color.White, propertyChanged: OnBackColorChanged);
        public static readonly BindableProperty NFontColorProperty =
            BindableProperty.Create("NFontColor", typeof(Color), typeof(NScreenKeyboard), Color.Black, propertyChanged: OnFontColorChanged);

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
        #endregion
        #region Commands
        private ICommand ButtonCommand => new ActionCommand(parameter =>
        {
            string clicked = parameter.ToString();
            if (clicked.Length <= 2)
                OnKeyboardClicked?.Invoke(clicked);
            else
            {
                if (clicked == "[INVARIANT]")
                {
                    if (keyboardPage != 1)
                    {
                        for (int x = 0; x < 7; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                var kp = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                                (Children[kp.Key] as NButton).Text = variantLetters[y, x].ToString();
                                (Children[kp.Key] as NButton).CommandParameter = variantLetters[y, x].ToString();
                            }
                        }
                        keyboardPage = 1;
                    }
                    else
                    {
                        for (int x = 0; x < 7; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                var kp = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                                (Children[kp.Key] as NButton).Text = letters[y, x].ToString();
                                (Children[kp.Key] as NButton).CommandParameter = letters[y, x].ToString();
                            }
                        }
                        keyboardPage = 0;
                    }
                }
                else if (clicked == "[NUMBERS]")
                {
                    if (keyboardPage != 2)
                    {
                        for (int x = 0; x < 7; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                var kp = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                                (Children[kp.Key] as NButton).Text = numbers[y, x].ToString();
                                (Children[kp.Key] as NButton).CommandParameter = numbers[y, x].ToString();
                            }
                        }
                        keyboardPage = 2;
                    }
                    else
                    {
                        for (int x = 0; x < 7; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                var kp = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                                (Children[kp.Key] as NButton).Text = letters[y, x].ToString();
                                (Children[kp.Key] as NButton).CommandParameter = letters[y, x].ToString();
                            }
                        }
                        keyboardPage = 0;
                    }
                }
            }
        });
        #endregion
        #region Constructors
        public NScreenKeyboard()
        {
            FocusContext.Register(this);
            RowDefinitions = new RowDefinitionCollection()
            {
                new RowDefinition() { Height = GridLength.Star },
                new RowDefinition() { Height = GridLength.Star },
                new RowDefinition() { Height = GridLength.Star },
                new RowDefinition() { Height = GridLength.Star },
                new RowDefinition() { Height = GridLength.Star }
            };
            ColumnDefinitions = new ColumnDefinitionCollection()
            {
                new ColumnDefinition(){Width = GridLength.Star},
                new ColumnDefinition(){Width = GridLength.Star},
                new ColumnDefinition(){Width = GridLength.Star},
                new ColumnDefinition(){Width = GridLength.Star},
                new ColumnDefinition(){Width = GridLength.Star},
                new ColumnDefinition(){Width = GridLength.Star},
                new ColumnDefinition(){Width = GridLength.Star},
                new ColumnDefinition(){Width = new GridLength(2.5, GridUnitType.Star)},
            };
            this.ColumnSpacing = 4;
            this.RowSpacing = 4;
            BuildKeyboard();
        }

        ~NScreenKeyboard()
        {
            FocusContext.Unregister(this);
        }
        #endregion
        #region Private Methods
        private void BuildKeyboard()
        {
            this.Children.Clear();
            indexes.Clear();

            char[,] currentPage = null;

            if (keyboardPage == 1)
                currentPage = variantLetters;
            else if (keyboardPage == 2)
                currentPage = numbers;
            else
                currentPage = letters;

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    this.Children.Add(new NButton() { Text = currentPage[y, x].ToString(), BackgroundColor = NBackColor, TextColor = NFontColor, NFocusColor = NFocusColor, NCommand = ButtonCommand, CommandParameter = currentPage[y, x].ToString(), Margin = 0, Padding = 0 }, x, y);
                    indexes.Add(this.Children.Count - 1, new int[] { x, y });
                }
            }

            this.Children.Add(new NButton() { Text = "<----", BackgroundColor = NBackColor, TextColor = NFontColor, NFocusColor = NFocusColor, NCommand = ButtonCommand, CommandParameter = RemoveButton }, 7, 8, 0, 1);
            indexes.Add(this.Children.Count - 1, new int[] { 7, 0 });
            this.Children.Add(new NButton() { Text = "ĄĆŹ", BackgroundColor = NBackColor, TextColor = NFontColor, NFocusColor = NFocusColor, NCommand = ButtonCommand, CommandParameter = "[INVARIANT]" }, 7, 8, 1, 2);
            indexes.Add(this.Children.Count - 1, new int[] { 7, 1 });
            this.Children.Add(new NButton() { Text = "123", BackgroundColor = NBackColor, TextColor = NFontColor, NFocusColor = NFocusColor, NCommand = ButtonCommand, CommandParameter = "[NUMBERS]" }, 7, 8, 2, 3);
            indexes.Add(this.Children.Count - 1, new int[] { 7, 2 });
            this.Children.Add(new NButton() { Text = "Enter", BackgroundColor = NBackColor, TextColor = NFontColor, NFocusColor = NFocusColor, NCommand = ButtonCommand, CommandParameter = EnterButton }, 7, 8, 3, 4);
            indexes.Add(this.Children.Count - 1, new int[] { 7, 3 });
            this.Children.Add(new NButton() { Text = "|___|", BackgroundColor = NBackColor, TextColor = NFontColor, NFocusColor = NFocusColor, NCommand = ButtonCommand, CommandParameter = " " }, 0, 8, 4, 5);
            indexes.Add(this.Children.Count - 1, new int[] { 0, 4 });
            (this.Children[this.Children.Count - 1] as INFocusElement).NextFocusDown = NextFocusDown;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    bool left = x > 0;
                    bool up = y > 0;
                    bool down = y < 3;
                    bool right = x < 7;

                    var kp = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                    if(left)
                    {
                        var kpl = indexes.First(keypair => keypair.Value[0] == x - 1 && keypair.Value[1] == y);
                        (Children[kpl.Key] as INFocusElement).NextFocusRight = (Children[kp.Key] as INFocusElement);
                        (Children[kp.Key] as INFocusElement).NextFocusLeft = (Children[kpl.Key] as INFocusElement);
                    }
                    else
                    {
                        (Children[kp.Key] as INFocusElement).NextFocusLeft = NextFocusLeft;
                    }

                    if (right)
                    {
                        var kpr = indexes.First(keypair => keypair.Value[0] == x + 1 && keypair.Value[1] == y);
                        (Children[kpr.Key] as INFocusElement).NextFocusLeft = (Children[kp.Key] as INFocusElement);
                        (Children[kp.Key] as INFocusElement).NextFocusRight = (Children[kpr.Key] as INFocusElement);
                    }
                    else
                    {
                        (Children[kp.Key] as INFocusElement).NextFocusRight = NextFocusRight;
                    }

                    if (up)
                    {
                        var kpu = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y-1);
                        (Children[kpu.Key] as INFocusElement).NextFocusDown = (Children[kp.Key] as INFocusElement);
                        (Children[kp.Key] as INFocusElement).NextFocusUp = (Children[kpu.Key] as INFocusElement);
                    }
                    else
                    {
                        (Children[kp.Key] as INFocusElement).NextFocusUp = NextFocusUp;
                    }

                    if (down)
                    {
                        var kpd = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y + 1);
                        (Children[kpd.Key] as INFocusElement).NextFocusUp = (Children[kp.Key] as INFocusElement);
                        (Children[kp.Key] as INFocusElement).NextFocusDown = (Children[kpd.Key] as INFocusElement);
                    }
                    else
                    {
                        var kpd = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == 3);
                        (Children[Children.Count - 1] as INFocusElement).NextFocusUp = (Children[Children.Count - 2] as INFocusElement);
                        (Children[kpd.Key] as INFocusElement).NextFocusDown = (Children[Children.Count - 1] as INFocusElement);
                    }
                }
            }

            (Children[0] as INFocusElement).IsNFocused = true;
        }
        private static void OnIsNFocusedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NScreenKeyboard focusButton = (NScreenKeyboard)bindable;
            bool isFocused = (bool)newValue;
            
            if(isFocused)
                focusButton.FocusFirst();
        }

        private static void OnElementChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NScreenKeyboard focusButton = (NScreenKeyboard)bindable;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    bool left = x > 0;
                    bool up = y > 0;
                    bool down = y < 3;
                    bool right = x < 7;

                    var kp = focusButton.indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                    if (left)
                    {
                        var kpl = focusButton.indexes.First(keypair => keypair.Value[0] == x - 1 && keypair.Value[1] == y);
                        (focusButton.Children[kpl.Key] as INFocusElement).NextFocusRight = (focusButton.Children[kp.Key] as INFocusElement);
                        (focusButton.Children[kp.Key] as INFocusElement).NextFocusLeft = (focusButton.Children[kpl.Key] as INFocusElement);
                    }
                    else
                    {
                        (focusButton.Children[kp.Key] as INFocusElement).NextFocusLeft = focusButton.NextFocusLeft;
                    }

                    if (right)
                    {
                        var kpr = focusButton.indexes.First(keypair => keypair.Value[0] == x + 1 && keypair.Value[1] == y);
                        (focusButton.Children[kpr.Key] as INFocusElement).NextFocusLeft = (focusButton.Children[kp.Key] as INFocusElement);
                        (focusButton.Children[kp.Key] as INFocusElement).NextFocusRight = (focusButton.Children[kpr.Key] as INFocusElement);
                    }
                    else
                    {
                        (focusButton.Children[kp.Key] as INFocusElement).NextFocusRight = focusButton.NextFocusRight;
                    }

                    if (up)
                    {
                        var kpu = focusButton.indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y - 1);
                        (focusButton.Children[kpu.Key] as INFocusElement).NextFocusDown = (focusButton.Children[kp.Key] as INFocusElement);
                        (focusButton.Children[kp.Key] as INFocusElement).NextFocusUp = (focusButton.Children[kpu.Key] as INFocusElement);
                    }
                    else
                    {
                        (focusButton.Children[kp.Key] as INFocusElement).NextFocusUp = focusButton.NextFocusUp;
                    }

                    if (down)
                    {
                        var kpd = focusButton.indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y + 1);
                        (focusButton.Children[kpd.Key] as INFocusElement).NextFocusUp = (focusButton.Children[kp.Key] as INFocusElement);
                        (focusButton.Children[kp.Key] as INFocusElement).NextFocusDown = (focusButton.Children[kpd.Key] as INFocusElement);
                    }
                    else
                    {
                        var kpd = focusButton.indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == 3);
                        (focusButton.Children[focusButton.Children.Count - 1] as INFocusElement).NextFocusUp = (focusButton.Children[focusButton.Children.Count - 2] as INFocusElement);
                        (focusButton.Children[kpd.Key] as INFocusElement).NextFocusDown = (focusButton.Children[focusButton.Children.Count - 1] as INFocusElement);
                    }
                }
            }
        }

        private static void OnBackColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NScreenKeyboard focusButton = (NScreenKeyboard)bindable;
            Color newColor = (Color)newValue;

            foreach(var element in focusButton.Children)
            {
                (element as NButton).BackgroundColor = newColor;
            }
        }

        private static void OnFocusColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NScreenKeyboard focusButton = (NScreenKeyboard)bindable;
            Color newColor = (Color)newValue;

            foreach (var element in focusButton.Children)
            {
                (element as NButton).NFocusColor = newColor;
            }
        }

        private static void OnFontColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NScreenKeyboard focusButton = (NScreenKeyboard)bindable;
            Color newColor = (Color)newValue;

            foreach (var element in focusButton.Children)
            {
                (element as NButton).TextColor = newColor;
            }
        }

        private void FocusFirst()
        {
            (Children[0] as INFocusElement).IsNFocused = true;
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
            //Not implemented
        }
        #endregion
    }
}
