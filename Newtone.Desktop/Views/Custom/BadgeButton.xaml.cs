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

        public RoutedEventHandler Click
        {
            get
            {
                return (RoutedEventHandler)base.GetValue(ClickProperty);
            }
            set
            {
                base.SetValue(ClipProperty, value);
            }

        }
        public static readonly DependencyProperty ClickProperty = DependencyProperty.Register("Click", typeof(RoutedEventHandler), typeof(BadgeButton));
            
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
