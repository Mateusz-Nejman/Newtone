using Nejman.Newtone.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.ViewModels
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
                CoreGlobal.SaveData();
                if (Global.TV)
                {
                    //TODO App.Instance.MainPage = new Views.TV.NormalPage();
                }
                else
                {
                    Task.Run(async () => {
                        await PopToRootAsync();
                    }).Wait();
                    Global.Handler.MainPage = new AppShell();
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
            while (Global.Handler.MainPage.Navigation.ModalStack.Count > 0)
            {
                await Global.Handler.MainPage.Navigation.PopModalAsync(false);
            }
        }

        #endregion
    }
}
