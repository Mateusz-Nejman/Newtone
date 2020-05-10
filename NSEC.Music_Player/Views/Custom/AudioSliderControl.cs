using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NSEC.Music_Player.Views.Custom
{
    public class AudioSliderControl:Slider
    {
        public delegate void ValueChangedHandler(object sender, ValueChangedArgs e);
        private double max;
        private double value;

        public event ValueChangedHandler ValueNewChanged;
        public double Max
        {
            get
            {
                return max;
            }

            set
            {
                max = value;
                Maximum = value;
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
            }
        }

        public class ValueChangedArgs
        {
            public double Value { get; set; }
        }

        public AudioSliderControl()
        {
            ValueChanged += AudioSlider_ValueChanged;
        }

        private void AudioSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ValueNewChanged?.Invoke(sender, new ValueChangedArgs() { Value = e.NewValue });
        }

        public void SetValue(double value)
        {
            ValueChanged -= AudioSlider_ValueChanged;
            Value = value;
            ValueChanged += AudioSlider_ValueChanged;
        }
    }
}