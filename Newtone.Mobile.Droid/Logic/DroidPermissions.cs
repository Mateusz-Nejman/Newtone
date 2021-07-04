using Android;
using AndroidX.Core.App;
using Newtone.Mobile.UI.Logic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Newtone.Mobile.Droid.Logic
{
    public class DroidPermissions : IPermission
    {
        public bool IsValid()
        {
            return Task.Run(async() => { return await Permissions.CheckStatusAsync<Permissions.StorageWrite>() == PermissionStatus.Granted; }).Result;
        }

        public void Request()
        {
            Task.Run(async () =>
            {
                await Permissions.RequestAsync<Permissions.StorageWrite>();
            }).Wait();
        }
    }
}