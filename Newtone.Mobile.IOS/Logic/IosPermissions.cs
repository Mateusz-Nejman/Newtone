using MediaPlayer;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Logic;
using UIKit;

namespace Newtone.Mobile.IOS.Logic
{
    public class IosPermissions : IPermission
    {
        public bool IsValid()
        {
            if(!UIDevice.CurrentDevice.CheckSystemVersion(9,3))
            {
                return false;
            }

            return MPMediaLibrary.AuthorizationStatus == MPMediaLibraryAuthorizationStatus.Authorized;
        }

        public void Request()
        {
            if (!UIDevice.CurrentDevice.CheckSystemVersion(9, 3))
            {
                return;
            }
            MPMediaLibrary.RequestAuthorization(status =>
            {
                ConsoleDebug.WriteLine("IOS Permission status: " + status);
            });
        }
    }
}