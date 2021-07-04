using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Implementations;
using Nejman.Newtone.Core.Localization;
using Nejman.Newtone.Mobile.Implementations;
using Nejman.Newtone.Mobile.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.ViewModels
{
    public class SettingsViewModel : PropertyChangedBase
    {
        #region Fields
        private ObservableCollection<SettingModel> items;
        private string version;
        private string title;
        #endregion
        #region Properties
        public ObservableCollection<SettingModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public string Version
        {
            get => version;
            set
            {
                version = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand gotoWWW;
        public ICommand GotoWWW
        {
            get
            {
                if (gotoWWW == null)
                    gotoWWW = new ActionCommand(parameter =>
                    {
                        Launcher.OpenAsync(new Uri("https://mateusz-nejman.pl/"));
                    });
                return gotoWWW;
            }
        }
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Constructors
        public SettingsViewModel()
        {
            Items = new ObservableCollection<SettingModel>
            {
                new SettingModel() { Name = Localization.Settings4 },
                new SettingModel() { Name = Localization.Settings5 }
            };

            Version = "v" + ApplicationImplementation.Current.GetVersion();
            Title = Localization.Settings;
        }
        #endregion
        #region Public Methods
        public async Task Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                if (e.SelectedItemIndex >= 0 && e.SelectedItem != null)
                {
                    if (e.SelectedItemIndex == 0)
                    {
                        ApplicationImplementation.Current.AddFolderToScan();

                    }
                    else if (e.SelectedItemIndex == 1)
                    {
                        string newLang = await Global.Page.DisplayActionSheet(Localization.Settings5, Localization.Cancel, null, Localization.LanguagePL, Localization.LanguageEN, Localization.LanguageRU);
                        if (newLang == Localization.LanguagePL)
                        {
                            CoreGlobal.SelectLanguage("pl");
                        }
                        else if (newLang == Localization.LanguageEN)
                        {
                            CoreGlobal.SelectLanguage("en");
                        }
                        else if (newLang == Localization.LanguageRU)
                        {
                            CoreGlobal.SelectLanguage("ru");
                        }

                        Localization.RefreshLanguage();
                        CoreGlobal.SaveData();
                        SnackbarImplementation.Current.Show(Localization.SettingsChanges);
                    }
                }
                (sender as ListView).SelectedItem = null;
            }
        }

        #endregion
    }
}
