using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Mobile.UI.Views;

namespace Newtone.Mobile.UI.ViewModels
{
    public class LanguageSelectViewModel : PropertyChangedBase
    {
        #region Fields
        private string nextPage;
        #endregion
        #region Properties
        public string NextPage
        {
            get => nextPage;
            set
            {
                nextPage = value;
                OnPropertyChanged();
            }
        }
        #endregion

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
        public LanguageSelectViewModel(string nextPage)
        {
            NextPage = nextPage;
        }
        #endregion
        #region Private Methods

        private void ChangeLanguage(string lang)
        {
            GlobalData.Current.CurrentLanguage = lang;
            Localization.RefreshLanguage();
            if (NextPage == "permissions")
                App.Instance.MainPage = new PermissionPage();
            else if (NextPage == "firststart")
                App.Instance.MainPage = new FirstStartPage();
        }
        #endregion
    }
}
