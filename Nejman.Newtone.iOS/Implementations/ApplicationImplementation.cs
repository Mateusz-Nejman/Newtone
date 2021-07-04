using Foundation;
using Nejman.Newtone.Mobile.Contracts;
using SystemConfiguration;

namespace Nejman.Newtone.iOS.Implementations
{
    public class ApplicationImplementation : IApplication
    {
        public void AddFolderToScan()
        {
            //Ignore
        }

        public string GetVersion()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }

        public bool HasInternet()
        {
            NetworkReachability network = new NetworkReachability("https://mateusz-nejman.pl/");

            network.GetFlags(out NetworkReachabilityFlags flags);

            return flags == NetworkReachabilityFlags.Reachable;
        }
    }
}