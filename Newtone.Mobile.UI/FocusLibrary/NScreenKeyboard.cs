using Newtone.Core.Logic;
using System;
using System.Collections.Generic;
using System.IO;
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

        private readonly string upIconBlack = "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAz0lEQVRYR+2U2w3CMAxFk0VssQAzwBwM0zIMc8AMLIDsRYIqESlCpH70I0Vy/6raviendXMafOXB+SkAwsB/G0DE17JFRHTwbpPbACLe2lAiunggXAA1vIZ+31tAzAC9MC+ECUAKkZ7/MqMG0A7X1lUYFYB1qKVeBLAMaxVr+1YBAOC5DGXmo+XLrrWafglg+gBcnQBifwCsGkDEe0rp5NHf9DyI6NybIW7BxnCxPQD2bQAAppzzLL7IlYJSyszM3f/Ivg1sObm2NwyEgeEG3uC2ZSF3DJmlAAAAAElFTkSuQmCC";
        private readonly string upIconWhite = "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAxElEQVRYR+2Uyw2DQAxEPaWkgdRA6kgxIcVQB6khDaSUiZBYaRWx+MNhiWRuCNvz9oGBdL7QOV8SIA38twGSn2WLAFyi2xQ2QHKqQwHcIxAhgBJeQn/vPSBugFZYFMIFoIVoz7fMmAGsw611BcYE4B3qqVcBPMNqxda+XQCS73XPr54vu9Ra+jWAxwrwDAKo/QmgGZhFZIjor3peAG6tGeoWHAxX2xPg3AZILns8qi9yv2AE0PyPnNvAwZOb2tNAGuhu4AtMJWIhZys20gAAAABJRU5ErkJggg==";
        private readonly string removeIconBlack = "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAA8ElEQVRYR+2WzQ3CMAyF7UXsVeAMOwHDwASwTG/JIkGWWikq+bEjlICUXipFfn1fXpw0CIMfHOwPE2Am8F8JMPNddk0IYWnZPYh4EJ1z7rjp1Qkw8wkAngDw6A4QmZ+dc6+W2YuGiC7y9t7f1AnkzNdxibMIFNeZAUoz16SyrzEBtBjES5PSqwE05ptZqjanVwFYzFMQ65jslo+GrQIQ0RURpVPN3R6BC0NS//sAgj50CUqNlTt8vt6EFgjrOVHtgf0srQY1vRmg1BNdjmLLcmh+UE0JJCD6/44jiHEXEk3ELTXqG1HLxzWaCTATGJ7AGzRsAjBT7CK4AAAAAElFTkSuQmCC";
        private readonly string removeIconWhite = "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAA5ElEQVRYR+2WWw5CIQxEpzvTb92TuhhdgW7GzYxpAgleebTEgCbcT0LvnA7DQzD5k8n6WADLgf9ygOQ17Jpn5+7ZaZ2I7GO92QGSBwB3ADcAYwES8aOIPDq7B8lTcOBidqAkHsbVzipQOs8NUOvc4sp2jgugRyBdmly9GcAiHsUKQjGwb5kxAXjEcxBhTHfLR2CbACTPADSp7rQn4MqQrf99AEWfugS1YJUOn6+H0APhPSeaGdh26RVo1bsBapkYchR7lsNyQXU5kIEYfx0nEPMeJBaLe+aYX0Q9P7fULIDlwHQHXn099iHqj3h/AAAAAElFTkSuQmCC";
        private readonly string enterIconBlack = "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAs0lEQVRYR+2W0Q2AIAwFyyIwkA7lUDoQTGJqNEEFbMFqouWHH8Idj+SBgZeHeZkPKqAJaAL/SsA512HveO+nrX8eS2CFjwDQPy6Qg2MK4gmU4OICV3BRAQpcTIAKFxHgwG8X4MJJAqnySH1iauAcgVOBxBK1cJIALioBWuBkgZxEK5wlcJRYr6B4NZQPL7uKo1Pj/ruHhQI8rmEL4AbW2gHnEMIyt4wqgRbgLQmogCbwqQRmfYFiIVZQdr8AAAAASUVORK5CYII=";
        private readonly string enterIconWhite = "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAq0lEQVRYR+2VQQ6AIAwE2/fpo3yUvg8DwQQRsAUKiZYLF8IMS1gQJg+czAcV0AQ0gX8lYIxZbO8g4nH1z7AEPHwHgHW4QA7u0pCu4hJcXOANLipAgYsJUOEiAhx4dwEunCSQKo/Uy6mBcwQeBRJK1MJJAnZRCdACJwvkJFrhLIFYwl9B8WooLcuu4uDUdv/bx0IBxmvYAj6JzX+rbm4ZVQItwC4JqIAm8KkETv43YiEsU54BAAAAAElFTkSuQmCC";

        private readonly char[,] upperLetters = new char[4, 7]
        {
            {'A','B','C','D','E','F','G' },
            {'H','I','J','K','L','M','N' },
            {'O','P','Q','R','S','T','U' },
            {'V','W','X','Y','Z','-','\'' }
        };

        private readonly char[,] lowerLetters = new char[4, 7]
        {
            {'a','b','c','d','e','f','g' },
            {'h','i','j','k','l','m','n' },
            {'o','p','q','r','s','t','u' },
            {'v','w','x','y','z','-','\'' }
        };

        private readonly char[,] variantLetters = new char[4, 7]
        {
            {'Ą','Ć','Ę','Ł','Ń','Ó','Ś' },
            {'Ż','Ź','ą','ć','ę', 'ł','ń' },
            {'ó','ś','ż','ź',' ', ' ',' ' },
            {' ',' ',' ',' ',' ', ' ',' ' }
        };

        private readonly char[,] numbers = new char[4, 7]
        {
            {'1','2','3','&','#','(',')' },
            {'4','5','6','@','!','?',':' },
            {'7','8','9','*','.','_','"' },
            {'|','0','/','\\','<','>',',' }
        };

        private int keyboardPage = 3;
        private readonly Dictionary<int, int[]> indexes = new Dictionary<int, int[]>();
        private int spaceIndex = -1;
        private int enterIndex = -1;
        private int variantIndex = -1;
        private int numberIndex = -1;
        private int upperIndex = -1;
        private int removeIndex = -1;
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

        public static readonly BindableProperty NFontFamilyProperty =
            BindableProperty.Create("NFontFamily", typeof(string), typeof(NScreenKeyboard), propertyChanged: OnFontFamilyChanged);

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

        public string NFontFamily
        {
            set { SetValue(NFontFamilyProperty, value); }
            get { return (string)GetValue(NFontFamilyProperty); }
        }

        public INFocusElement PrevionsElement { get; set; } //not used
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

                                (Children[kp.Key] as NKeyboardTextButton).Text = variantLetters[y, x].ToString();
                                (Children[kp.Key] as NKeyboardTextButton).CommandParameter = variantLetters[y, x].ToString();
                            }
                        }

                        (Children[numberIndex] as NKeyboardTextButton).Text = "123";
                        keyboardPage = 1;
                    }
                    else
                    {
                        for (int x = 0; x < 7; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                var kp = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                                (Children[kp.Key] as NKeyboardTextButton).Text = lowerLetters[y, x].ToString();
                                (Children[kp.Key] as NKeyboardTextButton).CommandParameter = lowerLetters[y, x].ToString();
                            }
                        }

                        (Children[numberIndex] as NKeyboardTextButton).Text = "123";
                        keyboardPage = 3;
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

                                (Children[kp.Key] as NKeyboardTextButton).Text = numbers[y, x].ToString();
                                (Children[kp.Key] as NKeyboardTextButton).CommandParameter = numbers[y, x].ToString();
                            }
                        }

                        (Children[numberIndex] as NKeyboardTextButton).Text = "ABC";
                        keyboardPage = 2;
                    }
                    else
                    {
                        for (int x = 0; x < 7; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                var kp = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                                (Children[kp.Key] as NKeyboardTextButton).Text = lowerLetters[y, x].ToString();
                                (Children[kp.Key] as NKeyboardTextButton).CommandParameter = lowerLetters[y, x].ToString();
                            }
                        }

                        (Children[numberIndex] as NKeyboardTextButton).Text = "123";
                        keyboardPage = 3;
                    }
                }
                else if (clicked == "[UP]")
                {
                    if (keyboardPage != 3)
                    {
                        for (int x = 0; x < 7; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                var kp = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                                (Children[kp.Key] as NKeyboardTextButton).Text = lowerLetters[y, x].ToString();
                                (Children[kp.Key] as NKeyboardTextButton).CommandParameter = lowerLetters[y, x].ToString();
                            }
                        }

                        (Children[numberIndex] as NKeyboardTextButton).Text = "123";
                        keyboardPage = 3;
                    }
                    else
                    {
                        for (int x = 0; x < 7; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                var kp = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                                (Children[kp.Key] as NKeyboardTextButton).Text = upperLetters[y, x].ToString();
                                (Children[kp.Key] as NKeyboardTextButton).CommandParameter = upperLetters[y, x].ToString();
                            }
                        }

                        (Children[numberIndex] as NKeyboardTextButton).Text = "123";
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

            if (keyboardPage == 0)
                currentPage = upperLetters;
            else if (keyboardPage == 1)
                currentPage = variantLetters;
            else if (keyboardPage == 2)
                currentPage = numbers;
            else
                currentPage = lowerLetters;

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    this.Children.Add(new NKeyboardTextButton() { Text = currentPage[y, x].ToString(), FontFamily = NFontFamily, BackgroundColor = NBackColor, TextColor = NFontColor, NFontColor = NFontColor, NBackColor = NBackColor, NCommand = ButtonCommand, CommandParameter = currentPage[y, x].ToString(), Margin = 0, Padding = 0 }, x, y);
                    indexes.Add(this.Children.Count - 1, new int[] { x, y });
                }
            }

            this.Children.Add(new NKeyboardImageButton() { SourceWhite = ImageSource.FromStream(() => new MemoryStream(Base64.FromString(removeIconWhite))), SourceBlack = ImageSource.FromStream(() => new MemoryStream(Base64.FromString(removeIconBlack))), Padding = 5, BackgroundColor = NBackColor, TextColor = NFontColor, NFontColor = NFontColor, NBackColor = NBackColor, NCommand = ButtonCommand, CommandParameter = RemoveButton }, 7, 8, 0, 1);
            indexes.Add(this.Children.Count - 1, new int[] { 7, 0 });
            removeIndex = this.Children.Count - 1;
            this.Children.Add(new NKeyboardTextButton() { Text = "ĄĆŹ", FontFamily = NFontFamily, BackgroundColor = NBackColor, TextColor = NFontColor, NCommand = ButtonCommand, CommandParameter = "[INVARIANT]" }, 7, 8, 1, 2);
            indexes.Add(this.Children.Count - 1, new int[] { 7, 1 });
            variantIndex = this.Children.Count - 1;
            this.Children.Add(new NKeyboardTextButton() { Text = "123", FontFamily = NFontFamily, BackgroundColor = NBackColor, TextColor = NFontColor, NFontColor = NFontColor, NBackColor = NBackColor, NCommand = ButtonCommand, CommandParameter = "[NUMBERS]" }, 7, 8, 2, 3);
            indexes.Add(this.Children.Count - 1, new int[] { 7, 2 });
            numberIndex = this.Children.Count - 1;
            this.Children.Add(new NKeyboardImageButton() { SourceWhite = ImageSource.FromStream(() => new MemoryStream(Base64.FromString(upIconWhite))), SourceBlack = ImageSource.FromStream(() => new MemoryStream(Base64.FromString(upIconBlack))), Padding = 5, BackgroundColor = NBackColor, TextColor = NFontColor, NFontColor = NFontColor, NBackColor = NBackColor, NCommand = ButtonCommand, CommandParameter = "[UP]" }, 7, 8, 3, 4);
            indexes.Add(this.Children.Count - 1, new int[] { 7, 3 });
            this.upperIndex = this.Children.Count - 1;

            this.Children.Add(new NKeyboardTextButton() { Text = "", FontFamily = NFontFamily, BackgroundColor = NBackColor, TextColor = NFontColor, NFontColor = NFontColor, NBackColor = NBackColor, NCommand = ButtonCommand, CommandParameter = " " }, 0, 7, 4, 5);
            indexes.Add(this.Children.Count - 1, new int[] { 0, 4 });
            this.spaceIndex = this.Children.Count - 1;
            this.Children.Add(new NKeyboardImageButton() { SourceWhite = ImageSource.FromStream(() => new MemoryStream(Base64.FromString(enterIconWhite))), SourceBlack = ImageSource.FromStream(() => new MemoryStream(Base64.FromString(enterIconBlack))), Padding = 5, BackgroundColor = NBackColor, TextColor = NFontColor, NFontColor = NFontColor, NBackColor = NBackColor, NCommand = ButtonCommand, CommandParameter = EnterButton }, 7, 8, 4, 5);
            indexes.Add(this.Children.Count - 1, new int[] { 5, 4 });
            this.enterIndex = this.Children.Count - 1;

            (this.Children[spaceIndex] as INFocusElement).NextFocusDown = NextFocusDown;
            (this.Children[enterIndex] as INFocusElement).NextFocusDown = NextFocusDown;

            (this.Children[spaceIndex] as INFocusElement).NextFocusRight = this.Children[enterIndex] as INFocusElement;
            (this.Children[enterIndex] as INFocusElement).NextFocusLeft = this.Children[spaceIndex] as INFocusElement;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    bool left = x > 0;
                    bool up = y > 0;
                    bool down = y < 3;
                    bool right = x < 7;

                    var kp = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                    if (left)
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
                        var kpu = indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y - 1);
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

                        int mod = x < 7 ? 2 : 1;
                        (Children[Children.Count - mod] as INFocusElement).NextFocusUp = (Children[kpd.Key] as INFocusElement);
                        (Children[kpd.Key] as INFocusElement).NextFocusDown = (Children[Children.Count - mod] as INFocusElement);
                    }
                }
            }

            (Children[0] as INFocusElement).IsNFocused = true;
        }
        private static void OnIsNFocusedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NScreenKeyboard focusKeyboard = (NScreenKeyboard)bindable;
            bool isFocused = (bool)newValue;

            if (isFocused)
                focusKeyboard.FocusFirst();
        }

        private static void OnElementChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NScreenKeyboard focusKeyboard = (NScreenKeyboard)bindable;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    bool left = x > 0;
                    bool up = y > 0;
                    bool down = y < 3;
                    bool right = x < 7;

                    var kp = focusKeyboard.indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y);

                    if (left)
                    {
                        var kpl = focusKeyboard.indexes.First(keypair => keypair.Value[0] == x - 1 && keypair.Value[1] == y);
                        (focusKeyboard.Children[kpl.Key] as INFocusElement).NextFocusRight = (focusKeyboard.Children[kp.Key] as INFocusElement);
                        (focusKeyboard.Children[kp.Key] as INFocusElement).NextFocusLeft = (focusKeyboard.Children[kpl.Key] as INFocusElement);
                    }
                    else
                    {
                        (focusKeyboard.Children[kp.Key] as INFocusElement).NextFocusLeft = focusKeyboard.NextFocusLeft;
                    }

                    if (right)
                    {
                        var kpr = focusKeyboard.indexes.First(keypair => keypair.Value[0] == x + 1 && keypair.Value[1] == y);
                        (focusKeyboard.Children[kpr.Key] as INFocusElement).NextFocusLeft = (focusKeyboard.Children[kp.Key] as INFocusElement);
                        (focusKeyboard.Children[kp.Key] as INFocusElement).NextFocusRight = (focusKeyboard.Children[kpr.Key] as INFocusElement);
                    }
                    else
                    {
                        (focusKeyboard.Children[kp.Key] as INFocusElement).NextFocusRight = focusKeyboard.NextFocusRight;
                    }

                    if (up)
                    {
                        var kpu = focusKeyboard.indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y - 1);
                        (focusKeyboard.Children[kpu.Key] as INFocusElement).NextFocusDown = (focusKeyboard.Children[kp.Key] as INFocusElement);
                        (focusKeyboard.Children[kp.Key] as INFocusElement).NextFocusUp = (focusKeyboard.Children[kpu.Key] as INFocusElement);
                    }
                    else
                    {
                        (focusKeyboard.Children[kp.Key] as INFocusElement).NextFocusUp = focusKeyboard.NextFocusUp;
                    }

                    if (down)
                    {
                        var kpd = focusKeyboard.indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == y + 1);
                        (focusKeyboard.Children[kpd.Key] as INFocusElement).NextFocusUp = (focusKeyboard.Children[kp.Key] as INFocusElement);
                        (focusKeyboard.Children[kp.Key] as INFocusElement).NextFocusDown = (focusKeyboard.Children[kpd.Key] as INFocusElement);
                    }
                    else
                    {
                        var kpd = focusKeyboard.indexes.First(keypair => keypair.Value[0] == x && keypair.Value[1] == 3);
                        (focusKeyboard.Children[focusKeyboard.Children.Count - 1] as INFocusElement).NextFocusUp = (focusKeyboard.Children[focusKeyboard.Children.Count - 2] as INFocusElement);
                        (focusKeyboard.Children[kpd.Key] as INFocusElement).NextFocusDown = (focusKeyboard.Children[focusKeyboard.Children.Count - 1] as INFocusElement);
                    }
                }
            }
        }

        private static void OnBackColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NScreenKeyboard focusKeyboard = (NScreenKeyboard)bindable;
            Color newColor = (Color)newValue;

            foreach (var element in focusKeyboard.Children)
            {
                if (element is NKeyboardTextButton keyboardTextButton)
                {
                    keyboardTextButton.NBackColor = newColor;
                    keyboardTextButton.BackgroundColor = newColor;

                    if (keyboardTextButton.IsNFocused)
                        NKeyboardTextButton.OnIsNFocusedChanged(keyboardTextButton, false, true);
                }
                else if (element is NKeyboardImageButton keyboardImageButton)
                {
                    keyboardImageButton.NBackColor = newColor;
                    keyboardImageButton.BackgroundColor = newColor;

                    if (keyboardImageButton.IsNFocused)
                        NKeyboardImageButton.OnIsNFocusedChanged(keyboardImageButton, false, true);
                }
                else
                {
                    (element as NButton).BackgroundColor = newColor;
                }
            }
        }

        private static void OnFocusColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NScreenKeyboard focusKeyboard = (NScreenKeyboard)bindable;
            Color newColor = (Color)newValue;

            foreach (var element in focusKeyboard.Children)
            {
                if (element is NButton button)
                {
                    button.NFocusColor = newColor;
                }
            }
        }

        private static void OnFontColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NScreenKeyboard focusKeyboard = (NScreenKeyboard)bindable;
            Color newColor = (Color)newValue;

            foreach (var element in focusKeyboard.Children)
            {
                if (element is NKeyboardTextButton keyboardTextButton)
                {
                    keyboardTextButton.NFontColor = newColor;
                    keyboardTextButton.TextColor = newColor;

                    if (keyboardTextButton.IsNFocused)
                        NKeyboardTextButton.OnIsNFocusedChanged(keyboardTextButton, false, true);
                }
                else if (element is NKeyboardImageButton keyboardImageButton)
                {
                    keyboardImageButton.NFontColor = newColor;
                    keyboardImageButton.TextColor = newColor;

                    if (keyboardImageButton.IsNFocused)
                        NKeyboardImageButton.OnIsNFocusedChanged(keyboardImageButton, false, true);
                }
                else
                {
                    (element as NButton).TextColor = newColor;
                }
            }
        }

        private static void OnFontFamilyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NScreenKeyboard focusKeyboard = (NScreenKeyboard)bindable;
            string newFamily = newValue.ToString();

            foreach (var element in focusKeyboard.Children)
            {
                if (element is NKeyboardTextButton keyboardTextButton)
                {
                    keyboardTextButton.FontFamily = newFamily;
                }
                else if (element is NButton nButton)
                {
                    nButton.FontFamily = newFamily;
                }
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
