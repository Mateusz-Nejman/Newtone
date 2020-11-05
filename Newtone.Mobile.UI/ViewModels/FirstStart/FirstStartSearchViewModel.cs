using System.Threading.Tasks;
using System.Windows.Input;
using Newtone.Core.Logic;
using Newtone.Mobile.UI.Views;

namespace Newtone.Mobile.UI.ViewModels.FirstStart
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
                        Task.Run(async () =>
                        {
                            await PopToRootAsync();
                        });
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
