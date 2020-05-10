using Android;
using Android.Support.V4.App;
using Newtone.Core;
using Newtone.Core.Logic;
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
            ActivityCompat.RequestPermissions(MainActivity.Instance, new string[] { Manifest.Permission.WriteExternalStorage }, 1);
        }

        private bool Check()
        {
            ConsoleDebug.WriteLine("PermissionPage " + ActivityCompat.CheckSelfPermission(MainActivity.Instance, Manifest.Permission.WriteExternalStorage).ToString());
            if (ActivityCompat.CheckSelfPermission(MainActivity.Instance, Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted)
            {
                GlobalData.SaveConfig();

                string theme = GlobalData.LoadFirstStart();
                if(theme == null)
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
    }
}