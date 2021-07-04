using Nejman.Newtone.Droid.Views;
using Nejman.Newtone.Mobile.Views;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ResolutionGroupName(LifecycleViewEffect.EffectGroupName)]
[assembly: ExportEffect(typeof(AndroidLifecycleViewEffect), LifecycleViewEffect.EffectName)]
namespace Nejman.Newtone.Droid.Views
{
    
    public class AndroidLifecycleViewEffect : PlatformEffect
    {
        private View nativeView;
        private LifecycleViewEffect effect;

        protected override void OnAttached()
        {
            effect = Element.Effects.OfType<LifecycleViewEffect>().FirstOrDefault();

            nativeView = Control ?? Container;
            nativeView.ViewAttachedToWindow += OnViewAttachedToWindow;
            nativeView.ViewDetachedFromWindow += OnViewDetachedFromWindow;
        }

        protected override void OnDetached()
        {
            effect.RaiseUnloaded(Element);
            nativeView.ViewAttachedToWindow -= OnViewAttachedToWindow;
            nativeView.ViewDetachedFromWindow -= OnViewDetachedFromWindow;
        }

        private void OnViewAttachedToWindow(object sender, View.ViewAttachedToWindowEventArgs e) => effect?.RaiseLoaded(Element);
        private void OnViewDetachedFromWindow(object sender, View.ViewDetachedFromWindowEventArgs e) => effect?.RaiseUnloaded(Element);
    }
}