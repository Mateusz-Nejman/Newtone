﻿using Com.Xamarin.Formsviewgroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutTab : ContentPage
    {
        public AboutTab()
        {
            InitializeComponent();

            versionLabel.Text = Global.Context.PackageManager.GetPackageInfo(Global.Context.PackageName, 0).VersionName;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://mateusz-nejman.pl/");
        }
    }
}