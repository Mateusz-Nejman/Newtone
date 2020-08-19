﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Mobile.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.ViewModels
{
    public class PermissionViewModel
    {
        #region Commands
        private ICommand grant;
        public ICommand Grant
        {
            get
            {
                if (grant == null)
                    grant = new ActionCommand(parameter =>
                    {
                        ActivityCompat.RequestPermissions(MainActivity.Instance, new string[] { Manifest.Permission.WriteExternalStorage }, 1);
                    });
                return grant;
            }
        }
        #endregion
        #region Constructors
        public PermissionViewModel()
        {
            Device.StartTimer(TimeSpan.FromSeconds(0.2), Check);
        }
        #endregion
        #region Private Methods
        private bool Check()
        {
            ConsoleDebug.WriteLine("PermissionPage " + ActivityCompat.CheckSelfPermission(MainActivity.Instance, Manifest.Permission.WriteExternalStorage).ToString());
            if (ActivityCompat.CheckSelfPermission(MainActivity.Instance, Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted)
            {
                GlobalData.Current.SaveConfig();

                string theme = GlobalData.Current.LoadFirstStart();
                if (theme == null)
                {
                    App.Instance.MainPage = new FirstStartPage();
                }
                else
                {
                    Colors.SetBase(theme);
                    App.Instance.MainPage = new NormalPage();
                    Task.Run(async () => {
                        await PopToRootAsync();
                    }).Wait();
                }



                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task PopToRootAsync()
        {
            while (App.Instance.MainPage.Navigation.ModalStack.Count > 0)
            {
                await App.Instance.MainPage.Navigation.PopModalAsync(false);
            }
        }

        #endregion
    }
}