﻿using Foundation;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Mobile.IOS.Media;
using Newtone.Mobile.UI;
using Newtone.Mobile.UI.Logic;
using System.Collections.Generic;
using UIKit;

namespace Newtone.Mobile.IOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();
            InitializeGlobalVariables();
            LoadApplication(new App());

            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        private void InitializeGlobalVariables()
        {
            Global.Application = new IosApplication();
            Global.Permissions = new IosPermissions();
            Global.ContextMenuBuilder = new IosContextMenuBuilder();

            GlobalData.Current.Initialize();
            GlobalData.Current.MediaPlayer = new CrossPlayer(new MobileMediaPlayer());
            //TODO GlobalData.Current.MediaPlayer.SetNativeActions(MediaPlayerHelper.Play);
            GlobalData.Current.Messenger = new MessageGenerator(new CoreMessenger());
            GlobalData.Current.MusicPath = NSBundle.MainBundle.BundlePath;
            ConsoleDebug.SetLogfile(GlobalData.Current.MusicPath + "/consoleDebug.txt");
            GlobalData.Current.IncludedPaths = new List<string>()
            {
                GlobalData.Current.MusicPath
        };
            GlobalData.Current.IncludedPathsToSkip = GlobalData.Current.IncludedPaths.Count;
        }
    }
}
