using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Views;
using Xamarin.Forms;

namespace Newtone.Mobile.UI.ViewModels
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
                        System.Diagnostics.Debug.WriteLine("Permission Grant");
                        Global.Permissions.Request();
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
            if (Global.Permissions.IsValid())
            {
                GlobalData.Current.SaveConfig();

                if(Global.TV)
                {
                    App.Instance.MainPage = new Views.TV.NormalPage();
                }
                else
                {
                    App.Instance.MainPage = new NormalPage();
                }
                
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
            while (App.Instance.MainPage.Navigation.ModalStack.Count > 0)
            {
                await App.Instance.MainPage.Navigation.PopModalAsync(false);
            }
        }

        #endregion
    }
}
