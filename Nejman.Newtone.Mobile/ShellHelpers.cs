using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile
{
    public static class ShellHelpers
    {
        public static void SetTitleView(BindableObject bindableObject, View view)
        {
            Device.BeginInvokeOnMainThread(() => Shell.SetTitleView(bindableObject, view));
        }

        public static void GoTo(string query)
        {
            Device.BeginInvokeOnMainThread(async () => await Shell.Current.GoToAsync(query, true));
        }
    }
}
