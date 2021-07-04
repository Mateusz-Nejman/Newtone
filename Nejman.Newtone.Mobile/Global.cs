using Nejman.Newtone.Mobile.Contracts;
using Nejman.Newtone.Mobile.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile
{
    public static class Global
    {
        public static IPermission Permissions { get; } = new PermissionImplementation();
        public static bool Loaded { get; set; }
        public static bool TV { get; set; }
        public static Page Page => Xamarin.Forms.Application.Current.MainPage;
        public static Application Handler => App.Current;
        public static ImageSource EmptyTrackImage => ImageSource.FromFile("EmptyTrack.png");
    }
}
