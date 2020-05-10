﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PromptWindow.xaml
    /// </summary>
    public partial class AlertWindow : Window
    {
        public AlertWindow(string title, string message, string confirmText = "Tak", string cancelText = "Nie")
        {
            InitializeComponent();
            Title = title;
            messageText.Text = message;
            yesText.Text = confirmText;
            noText.Text = cancelText;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
