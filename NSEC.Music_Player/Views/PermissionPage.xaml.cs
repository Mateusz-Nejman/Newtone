using Android;
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
                App.Instance.OnCreate();
                Global.LoadConfig();
                MainPage.Instance.Navigation.InsertPageBefore(new LobbyPage(), MainPage.Instance.Navigation.NavigationStack[0]);
                MainPage.Instance.PopAsync();
                

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}