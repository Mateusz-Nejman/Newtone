using Newtone.Mobile.UI.Logic;
using Xamarin.Forms;

namespace Newtone.Mobile.UI
{
    public static class Global
    {
        public static IPermission Permissions { get; set; }
        public static IApplication Application { get; set; }
        public static IImageProcessing ImageProcessing { get; set; }
        public static IContextMenuBuilder ContextMenuBuilder { get; set; }
        public static bool Loaded { get; set; }
        public static bool TV { get; set; }
        public static NavigationWrapper NavigationInstance { get; set; }
        public static Page Page { get; set; }
    }
}
