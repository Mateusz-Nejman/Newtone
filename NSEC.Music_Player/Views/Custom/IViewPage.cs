using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NSEC.Music_Player.Views.Custom
{
    interface IViewPage
    {
        public event EventHandler Appearing;
        public event EventHandler Disappearing;
        public void InvokeD(object sender);
        public void InvokeA(object sender);
        public void SetTitleView(CustomTitleView titleView);
    }
}