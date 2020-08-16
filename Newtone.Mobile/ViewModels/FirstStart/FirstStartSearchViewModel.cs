using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core.Logic;
using Newtone.Mobile.Views;

namespace Newtone.Mobile.ViewModels.FirstStart
{
    public class FirstStartSearchViewModel
    {
        #region Commands
        private ICommand next;
        public ICommand Next
        {
            get
            {
                if (next == null)
                    next = new ActionCommand(parameter =>
                    {
                        App.Instance.MainPage = new NormalPage();
                        Task.Run(async () => {
                            await PopToRootAsync();
                        }).Wait();
                    });

                return next;
            }
        }
        #endregion

        #region Private Methods
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