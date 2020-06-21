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
        #region Fields
        private double max;
        private double value;
        #endregion
        #region Events & Delegates
        public delegate void ValueChangedHandler(object sender, ValueChangedArgs e);
        public event ValueChangedHandler ValueChanged;
        #endregion
        #region Properties
        public static readonly DependencyProperty MaxChangeProperty =
    DependencyProperty.Register(nameof(MaxChange), typeof(double), typeof(AudioSliderControl),
        new UIPropertyMetadata(OnMaxChangePropertyChanged));
        public static readonly DependencyProperty ValueChangeProperty =
    DependencyProperty.Register(nameof(ValueChange), typeof(double), typeof(AudioSliderControl),
        new UIPropertyMetadata(OnValueChangePropertyChanged));
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

        public double MaxChange
        {
            set => SetMax(value);
        }

        public double ValueChange
        {
            set => SetValue(value);
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
        #endregion
        #region Constructors
        public AudioSliderControl()
        {
            InitializeComponent();

            audioSlider.ValueChanged += AudioSlider_ValueChanged;
        }
        #endregion
        #region Private Methods
        private void AudioSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ValueChanged?.Invoke(sender, new ValueChangedArgs() { Value = e.NewValue });
        }

        private void OnMaxChangePropertyChanged(double value)
        {
            SetMax(value);
        }

        private void OnValueChangePropertyChanged(double value)
        {
            SetValue(value);
        }

        private static void OnMaxChangePropertyChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AudioSliderControl)d).OnMaxChangePropertyChanged((double)e.NewValue);
        }
        private static void OnValueChangePropertyChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AudioSliderControl)d).OnValueChangePropertyChanged((double)e.NewValue);
        }
        #endregion
        #region Public Methods
        public void SetValue(double value)
        {
            audioSlider.ValueChanged -= AudioSlider_ValueChanged;
            Value = value;
            audioSlider.ValueChanged += AudioSlider_ValueChanged;
        }

        public void SetMax(double max)
        {
            audioSlider.ValueChanged -= AudioSlider_ValueChanged;
            Max = max;
            audioSlider.ValueChanged += AudioSlider_ValueChanged;
        }
        #endregion
        #region Nested Types
        public class ValueChangedArgs
        {
            public double Value { get; set; }
        }
        #endregion
    }
}
