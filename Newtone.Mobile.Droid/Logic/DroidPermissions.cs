using Android;
using AndroidX.Core.App;
using Newtone.Mobile.UI.Logic;

namespace Newtone.Mobile.Droid.Logic
{
    public class DroidPermissions : IPermission
    {
        public bool IsValid()
        {
            return ActivityCompat.CheckSelfPermission(MainActivity.Instance, Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted;
        }

        public void Request()
        {
            ActivityCompat.RequestPermissions(MainActivity.Instance, new string[] { Manifest.Permission.WriteExternalStorage }, 1);
        }
    }
}