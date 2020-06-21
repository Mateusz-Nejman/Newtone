using Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace NSEC.Music_Player.Views.Custom
{
    public class AudioSliderControl:Slider, INotifyPropertyChanged
    {
        #region Fields
        private double value;
        #endregion
        #region Properties
        private static AudioSliderControl Instance { get; set; }
        public static readonly BindableProperty MaxProperty = BindableProperty.Create("Max", typeof(double), typeof(AudioSliderControl), null, propertyChanged: OnMax);
        public static readonly BindableProperty ValueChangeProperty = BindableProperty.Create("ValueChange", typeof(double), typeof(AudioSliderControl), null, propertyChanged: OnValueChanged);
        public double Max
        {
            get => (double)GetValue(MaxProperty);

            set
            {
                //SetValue(MaxProperty, value);
                Maximum = value;
                OnPropertyChanged();
                OnPropertyChanged("Maximum");
            }
        }
        public double ValueNew
        {
            get
            {
                return value;
            }
            private set
            {
                this.value = value;
                Value = value;
                OnPropertyChanged("Value");
            }
        }

        public double ValueChange
        {
            get => value;
            set
            {
                //SetValue(ValueChangeProperty, value);
                SetValue(value);
                OnPropertyChanged("Value");
            }
        }
        #endregion
        #region Events & Delegates
        public delegate void ValueChangedHandler(object sender, ValueChangedArgs e);
        public event ValueChangedHandler ValueNewChanged;
        #endregion
        #region Constructors
        public AudioSliderControl()
        {
            ValueChanged += AudioSlider_ValueChanged;
            Instance = this;
        }
        #endregion
        #region Private Methods
        private void AudioSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ValueNewChanged?.Invoke(sender, new ValueChangedArgs() { Value = e.NewValue });
        }
        private static void OnValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Instance.ValueChange = (double)newValue;
        }

        private static void OnMax(BindableObject bindable, object oldValue, object newValue)
        {
            Instance.Max = (double)newValue;
        }
        #endregion
        #region Public Methods
        public void SetValue(double value)
        {
            ValueChanged -= AudioSlider_ValueChanged;
            Value = value;
            ValueChanged += AudioSlider_ValueChanged;
        }

        public void SetMax(double value)
        {
            ValueChanged -= AudioSlider_ValueChanged;
            Max = value;
            ValueChanged += AudioSlider_ValueChanged;
        }
        #endregion
        #region Nested Classes
        public class ValueChangedArgs
        {
            public double Value { get; set; }
        }
        #endregion
    }
}