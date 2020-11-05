﻿using CoreFoundation;
using CoreTelephony;
using Foundation;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Logic;
using System;
using System.Net;
using SystemConfiguration;

namespace Newtone.Mobile.IOS.Media
{
    public class IosApplication : IApplication
    {
        public void AddFolderToScan()
        {
            throw new System.NotImplementedException();
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

        public void ShowSnackbar(string message)
        {
            ConsoleDebug.WriteLine(message);
        }
    }
}