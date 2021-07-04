using System;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.Views
{
    public class LifecycleViewEffect : RoutingEffect
    {
        public const string EffectGroupName = "Newtone";
        public const string EffectName = "LifecycleEffect";

        public event EventHandler<EventArgs> Appearing;
        public event EventHandler<EventArgs> Disappearing;

        public LifecycleViewEffect() : base($"{EffectGroupName}.{EffectName}") { }

        public void RaiseLoaded(Element element) => Appearing?.Invoke(element, EventArgs.Empty);
        public void RaiseUnloaded(Element element) => Disappearing?.Invoke(element, EventArgs.Empty);
    }
}
