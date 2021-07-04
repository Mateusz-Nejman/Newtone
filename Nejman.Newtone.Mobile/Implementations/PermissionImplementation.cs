using Nejman.Newtone.Mobile.Contracts;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Nejman.Newtone.Mobile.Implementations
{
    public class PermissionImplementation : IPermission
    {
        public bool IsValid()
        {
            return Task.Run(async () => { return await Permissions.CheckStatusAsync<Permissions.StorageWrite>() == PermissionStatus.Granted; }).Result;
        }

        public void Request()
        {
            Permissions.RequestAsync<Permissions.StorageWrite>();
        }
    }
}
