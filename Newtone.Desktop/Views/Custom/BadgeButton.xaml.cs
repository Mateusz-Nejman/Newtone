using Newtone.Desktop.Processing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Newtone.Desktop.Views.Custom
{
    /// <summary>
    /// Logika interakcji dla klasy BadgeButton.xaml
    /// </summary>
    public partial class BadgeButton : UserControl
    {
        private int badgeCount;
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

        public RoutedEventHandler Click
        {
            get
            {
                return (RoutedEventHandler)base.GetValue(ClickProperty);
            }
            set
            {
                base.SetValue(ClickProperty, value);
            }

        }
        public static readonly DependencyProperty ClickProperty = DependencyProperty.Register("Click", typeof(RoutedEventHandler), typeof(BadgeButton));
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(BadgeButton));

        public BadgeButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(sender, e);
        }
    }
}
