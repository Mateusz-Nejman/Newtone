using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

using NSEC.Music_Player.Models;
using NSEC.Music_Player.Logic;

namespace NSEC.Music_Player.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : NavigationPage
    {
        public static MainPage Instance { get; set; }
        public MainPage(Page page)
        {
            InitializeComponent();
            Instance = this;

            this.Appearing += MainPage_Appearing;
            Global.LoadTags();
            Task.Run(async () => { await Helpers.LoadGlobalsOnce(); }).Wait();
            Global.LoadConfig();

            Navigation.PushAsync(page);
            //containers = new List<MP3Processing.Container>(AsyncHelper.RunSync<MP3Processing.Container[]>(() => FileProcessing.ListFiles(App.Directories)));

        }

        private async void MainPage_Appearing(object sender, EventArgs e)
        {
            base.OnAppearing();
            Global.LoadTags();
            await Helpers.LoadGlobalsOnce();
            Global.LoadConfig();

        }
    }
}