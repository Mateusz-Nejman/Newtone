using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Nejman.Newtone.Mobile.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nejman.Newtone.Droid.Implementations
{
    public class ApplicationImplementation :IApplication
    {
        public void AddFolderToScan()
        {
            Intent intent = new Intent(Intent.ActionOpenDocumentTree);
            intent.AddCategory(Intent.CategoryDefault);
            MainActivity.Handler.StartActivityForResult(Intent.CreateChooser(intent, "Newtone"), 9999);
        }

        public string GetVersion()
        {
            return MainActivity.Handler.PackageManager.GetPackageInfo(MainActivity.Handler.PackageName, 0).VersionName;
        }

        public bool HasInternet()
        {
            bool haveConnectedWifi = false;
            bool haveConnectedMobile = false;

            NetworkInfo[] netInfo = DroidGlobal.ConnectivityManager.GetAllNetworkInfo();

            foreach (NetworkInfo info in netInfo)
            {
                if (info.IsConnected)
                {
                    if (info.TypeName.Contains("WIFI", StringComparison.OrdinalIgnoreCase))
                    {
                        haveConnectedWifi = true;
                    }

                    if (info.TypeName.Contains("MOBILE", StringComparison.OrdinalIgnoreCase))
                    {
                        haveConnectedMobile = true;
                    }
                }
            }

            return haveConnectedWifi || haveConnectedMobile;
        }
    }
}