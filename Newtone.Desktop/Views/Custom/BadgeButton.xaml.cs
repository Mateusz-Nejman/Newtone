﻿using Newtone.Desktop.Processing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Newtone.Desktop.Views.Custom
{
    /// <summary>
    /// Logika interakcji dla klasy BadgeButton.xaml
    /// </summary>
    public partial class BadgeButton : UserControl
    {
        #region Fields
        private int badgeCount;
        #endregion
        #region Properties
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(BadgeButton));
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(BadgeButton));
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(nameof(Source), typeof(string), typeof(BadgeButton));
        public int BadgeCount
        {
            get
            {
                return badgeCount;
            }
            set
            {
                badgeCount = value;
                badgeText.Text = badgeCount < 10 ? badgeCount.ToString() : "9+";
            }
        }

        public string Source
        {
            get
            {
                return (string)base.GetValue(SourceProperty);
            }
            set
            {
                base.SetValue(SourceProperty, value);

                if (Source == "DownloadPageIcon.png")
                {
                    badgeImage.Source = ImageProcessing.FromArray(Properties.Resources.DownloadPageIcon);
                }
                else if(Source == "UploadPageIcon.png")
                {
                    badgeImage.Source = ImageProcessing.FromArray(Properties.Resources.UploadPageIcon);
                }
            }
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }
        #endregion
        #region Commands
        public ICommand Command
        {
            get
            {
                return (ICommand)base.GetValue(CommandProperty);
            }
            set
            {
                base.SetValue(CommandProperty, value);
                button.Command = Command;
            }

        }
        
        #endregion
        #region Constructors
        public BadgeButton()
        {
            InitializeComponent();
        }
        #endregion
        #region Private Methods
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Command?.Execute(CommandParameter);
        }
        #endregion
    }
}
