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
    /// Logika interakcji dla klasy AudioRangeSlider.xaml
    /// </summary>
    public partial class AudioRangeSlider : UserControl
    {
        #region Properties
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(AudioRangeSlider), new UIPropertyMetadata(0d));

        public double LowerValue
        {
            get { return (double)GetValue(LowerValueProperty); }
            set { SetValue(LowerValueProperty, value); }
        }

        public static readonly DependencyProperty LowerValueProperty =
            DependencyProperty.Register("LowerValue", typeof(double), typeof(AudioRangeSlider), new UIPropertyMetadata(0d));

        public double UpperValue
        {
            get { return (double)GetValue(UpperValueProperty); }
            set { SetValue(UpperValueProperty, value); }
        }

        public static readonly DependencyProperty UpperValueProperty =
            DependencyProperty.Register("UpperValue", typeof(double), typeof(AudioRangeSlider), new UIPropertyMetadata(0d));

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(AudioRangeSlider), new UIPropertyMetadata(1d));

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(AudioRangeSlider), new UIPropertyMetadata(0d));
        #endregion
        #region Constructors
        public AudioRangeSlider()
        {
            InitializeComponent();
            this.Loaded += RangeSlider_Loaded;
        }
        #endregion
        #region Private Methods
        void RangeSlider_Loaded(object sender, RoutedEventArgs e)
        {
            LowerSlider.ValueChanged += LowerSlider_ValueChanged;
            UpperSlider.ValueChanged += UpperSlider_ValueChanged;
            ValueSlider.ValueChanged += ValueSlider_ValueChanged;

            ValueSlider_ValueChanged(sender, null);
        }

        private void ValueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Value < LowerValue)
                ValueSlider.Value = LowerValue;
            else if (Value > UpperValue)
                ValueSlider.Value = UpperValue;
            else
                ValueSlider.Value = Newtone.Core.Logic.Range.GetRangeDbl(LowerValue, UpperValue, Value);
        }

        private void LowerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpperSlider.Value = Math.Max(UpperSlider.Value, LowerSlider.Value);
            ValueSlider_ValueChanged(sender, e);
        }

        private void UpperSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LowerSlider.Value = Math.Min(UpperSlider.Value, LowerSlider.Value);
            ValueSlider_ValueChanged(sender, e);
        }
        #endregion
    }
}
