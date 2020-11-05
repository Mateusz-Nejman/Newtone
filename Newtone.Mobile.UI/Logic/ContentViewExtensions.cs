using Newtone.Core.Logic;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.Logic
{
    public static class ContentViewExtensions
    {
        public static bool IsTimerView(this ContentView contentView)
        {
            return contentView is ITimerContent;
        }
    }
}
