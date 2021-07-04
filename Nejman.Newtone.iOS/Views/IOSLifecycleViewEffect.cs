using System;
using System.Linq;
using Foundation;
using Nejman.Newtone.iOS.Views;
using Nejman.Newtone.Mobile.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName(LifecycleViewEffect.EffectGroupName)]
[assembly: ExportEffect(typeof(IOSLifecycleViewEffect), LifecycleViewEffect.EffectName)]
namespace Nejman.Newtone.iOS.Views
{
    public class IOSLifecycleViewEffect : PlatformEffect
    {
        private const NSKeyValueObservingOptions ObservingOptions = NSKeyValueObservingOptions.Initial | NSKeyValueObservingOptions.OldNew | NSKeyValueObservingOptions.Prior;

        private LifecycleViewEffect effect;
        private IDisposable isLoaded;

        protected override void OnAttached()
        {
            effect = Element.Effects.OfType<LifecycleViewEffect>().FirstOrDefault();

            UIView nativeView = Control ?? Container;
            isLoaded = nativeView?.AddObserver("superview", ObservingOptions, IsViewLoadedObserver);
        }

        protected override void OnDetached()
        {
            effect.RaiseUnloaded(Element);
            isLoaded.Dispose();
        }

        private void IsViewLoadedObserver(NSObservedChange nsObservedChange)
        {
            if (!nsObservedChange.NewValue.Equals(NSNull.Null))
                effect?.RaiseLoaded(Element);
            else if (!nsObservedChange.OldValue.Equals(NSNull.Null))
                effect?.RaiseUnloaded(Element);
        }
    }
}