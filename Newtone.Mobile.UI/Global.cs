using Newtone.Mobile.UI.Logic;

namespace Newtone.Mobile.UI
{
    public static class Global
    {
        public static IPermission Permissions { get; set; }
        public static IApplication Application { get; set; }
        public static IImageProcessing ImageProcessing { get; set; }
        public static IContextMenuBuilder ContextMenuBuilder { get; set; }
        public static bool Loaded { get; set; }
    }
}
