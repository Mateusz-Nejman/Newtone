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
    /// Logika interakcji dla klasy AudioSliderControl.xaml
    /// </summary>
    public partial class AudioSliderControl : UserControl
    {
        public delegate void ValueChangedHandler(object sender, ValueChangedArgs e);
        private double max;
        private double value;

        public event ValueChangedHandler ValueChanged;
        public double Max
        {
            get
            {
                return max;
            }

            set
            {
                max = value;
                audioProgress.Maximum = value;
                audioSlider.Maximum = value;
            }
        }
        public double Value
        {
            get
            {
                return value;
            }
            private set
            {
                this.value = value;
                audioProgress.Value = this.value;
                audioSlider.Value = this.value;
            }
        }
        public AudioSliderControl()
        {
            InitializeComponent();

            audioSlider.ValueChanged += AudioSlider_ValueChanged;
        }

        private void AudioSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ValueChanged?.Invoke(sender, new ValueChangedArgs() { Value = e.NewValue});
        }

        public void SetValue(double value)
        {
            audioSlider.ValueChanged -= AudioSlider_ValueChanged;
            Value = value;
            audioSlider.ValueChanged += AudioSlider_ValueChanged;
        }

        public class ValueChangedArgs
        {
            public double Value { get; set; }
        }
    }
}
