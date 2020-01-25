﻿using Android;
using Android.Support.V4.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PermissionPage : ContentPage
    {
        public PermissionPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(2), Check);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ActivityCompat.RequestPermissions(Global.Context, new string[] { Manifest.Permission.WriteExternalStorage }, 1);
        }

        private bool Check()
        {
            Console.WriteLine("PermissionPage "+ ActivityCompat.CheckSelfPermission(Global.Context, Manifest.Permission.WriteExternalStorage).ToString());
            if (ActivityCompat.CheckSelfPermission(Global.Context, Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted)
            {
                Global.SaveConfig();

                App.Instance.MainPage = new MainPage(new LobbyPage());
                Task.Run(async () => {
                    await PopToRootAsync();
                }).Wait();
                

                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task PopToRootAsync()
        {
            while (MainPage.Instance.Navigation.ModalStack.Count > 0)
            {
                await MainPage.Instance.Navigation.PopModalAsync(false);
            }
            while (MainPage.Instance.CurrentPage != MainPage.Instance.Navigation.NavigationStack[0])
            {
                await MainPage.Instance.PopAsync(false);
            }
        }
    }
}