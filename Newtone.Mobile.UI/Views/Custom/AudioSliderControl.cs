using Xamarin.Forms;

namespace Newtone.Mobile.UI.Views.Custom
{
    public class AudioSliderControl : Slider
    {
        #region Properties
        private static AudioSliderControl Instance { get; set; }
        public static readonly BindableProperty ValueWithoutBaseEventsProperty = BindableProperty.Create("ValueWithoutBaseEvents", typeof(double), typeof(AudioSliderControl), null, propertyChanged: OnValueWithoutBaseEventsChanged); //Without seek
        public static readonly BindableProperty MaxWithoutBaseEventsProperty = BindableProperty.Create("MaxWithoutBaseEvents", typeof(double), typeof(AudioSliderControl), null, propertyChanged: OnMaxWithoutBaseEventsChanged); //Without seek

        public double ValueWithoutBaseEvents
        {
            get => Value;
            set
            {
                InvokeEvents = false;
                Value = value;
                OnPropertyChanged("Value");
            }
        }

        public double MaxWithoutBaseEvents
        {
            get => Maximum;
            set
            {
                InvokeEvents = false;
                Maximum = value;
                OnPropertyChanged("Maximum");
            }
        }

        private bool InvokeEvents { get; set; }
        #endregion
        #region Events & Delegates
        public delegate void ValueChangedHandler(object sender, ValueChangedArgs e);
        public event ValueChangedHandler ValueNewChanged; //With seek
        #endregion
        #region Constructors
        public AudioSliderControl()
        {
            ValueChanged += AudioSlider_ValueChanged;
            Instance = this;
            InvokeEvents = true;
        }
        #endregion
        #region Private Methods
        private void AudioSlider_ValueChanged(object sender, ValueChangedEventArgs e) //With seek
        {
            if (InvokeEvents)
                ValueNewChanged?.Invoke(sender, new ValueChangedArgs() { Value = e.NewValue });

            InvokeEvents = true;
        }
        private static void OnValueWithoutBaseEventsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Instance.ValueWithoutBaseEvents = (double)newValue;
        }

        private static void OnMaxWithoutBaseEventsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Instance.MaxWithoutBaseEvents = (double)newValue;
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
