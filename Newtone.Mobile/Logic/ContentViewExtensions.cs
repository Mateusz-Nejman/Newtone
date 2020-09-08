using Newtone.Core.Logic;
using Xamarin.Forms;

namespace Newtone.Mobile.Logic
{
    public static class ContentViewExtensions
    {
        public static bool IsTimerView(this ContentView contentView)
        {
            return contentView is ITimerContent;
        }
    }
}