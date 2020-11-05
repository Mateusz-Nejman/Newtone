using Android.Content;
using Android.Net;
using Android.Widget;
using Newtone.Mobile.UI.Logic;
using System;

namespace Newtone.Mobile.Droid.Logic
{
    public class DroidApplication : IApplication
    {
        public void AddFolderToScan()
        {
            Intent intent = new Intent(Intent.ActionOpenDocumentTree);
            intent.AddCategory(Intent.CategoryDefault);
            MainActivity.Instance.StartActivityForResult(Intent.CreateChooser(intent, "Newtone"), 9999);
        }

        public string GetVersion()
        {
            return MainActivity.Instance.PackageManager.GetPackageInfo(MainActivity.Instance.PackageName, 0).VersionName;
        }

        public bool HasInternet()
        {
            bool haveConnectedWifi = false;
            bool haveConnectedMobile = false;

            NetworkInfo[] netInfo = Global.ConnectivityManager.GetAllNetworkInfo();

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

        public void ShowSnackbar(string message)
        {
            MainActivity.Instance.RunOnUiThread(() => Toast.MakeText(MainActivity.Instance, message, ToastLength.Short).Show());
        }
    }
}