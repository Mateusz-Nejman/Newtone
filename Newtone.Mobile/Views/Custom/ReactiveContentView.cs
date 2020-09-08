using System;
using System.Reactive.Linq;
using Xamarin.Forms;

namespace Newtone.Mobile.Views.Custom
{
    public class ReactiveContentView : ContentView
    {
        #region Fields
        private IDisposable loopSubscription;
        #endregion
        #region Properties
        public new object BindingContext
        {
            get
            {
                return base.BindingContext;
            }
            set
            {
                base.BindingContext = value;
            }
        }
        #endregion
        public virtual void Appearing()
        {
            var src = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(0.2)).Timestamp();
            loopSubscription = src.Subscribe(time => Tick());
        }

        public virtual void Disappearing()
        {
            loopSubscription?.Dispose();
            loopSubscription = null;
        }

        public virtual void Tick()
        {

        }
    }
}