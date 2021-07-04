using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Localization;
using Nejman.Newtone.Mobile.Views;
using System.Windows.Input;

namespace Nejman.Newtone.Mobile.ViewModels
{
    public class LanguageSelectViewModel : PropertyChangedBase
    {
        #region Commands
        private ICommand english;
        public ICommand English
        {
            get
            {
                if (english == null)
                    english = new ActionCommand(parameter =>
                    {
                        ChangeLanguage("us");
                    });

                return english;
            }
        }

        private ICommand polish;
        public ICommand Polish
        {
            get
            {
                if (polish == null)
                    polish = new ActionCommand(parameter =>
                    {
                        ChangeLanguage("pl");
                    });

                return polish;
            }
        }

        private ICommand russian;
        public ICommand Russian
        {
            get
            {
                if (russian == null)
                    russian = new ActionCommand(parameter =>
                    {
                        ChangeLanguage("ru");
                    });

                return russian;
            }
        }
        #endregion
        #region Constructors
        public LanguageSelectViewModel()
        {
        }
        #endregion
        #region Private Methods

        private void ChangeLanguage(string lang)
        {
            CoreGlobal.SelectLanguage(lang);
            Localization.RefreshLanguage();
            if (Global.TV)
            {
                //TODO App.Instance.MainPage = new Views.TV.PermissionPage();
            }
            else
            {
                Global.Handler.MainPage = new PermissionPage();
            }
        }
        #endregion
    }
}
