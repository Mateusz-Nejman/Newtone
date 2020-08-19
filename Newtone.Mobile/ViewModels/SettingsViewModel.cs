using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Mobile.Logic;
using Newtone.Mobile.Models;
using Newtone.Mobile.Views;
using Newtone.Mobile.Views.Custom;
using Xamarin.Forms;
using SettingsModel = Newtone.Mobile.Models.SettingsModel;

namespace Newtone.Mobile.ViewModels
{
    public class SettingsViewModel : PropertyChangedBase
    {
        #region Fields
        private ObservableCollection<SettingsModel> items;
        private string version;
        #endregion
        #region Properties
        public ObservableCollection<SettingsModel> Items
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
                        Device.OpenUri(new Uri("https://mateusz-nejman.pl/"));
                    });
                return gotoWWW;
            }
        }
        #endregion
        #region Constructors
        public SettingsViewModel()
        {
            Items = new ObservableCollection<SettingsModel>
            {
                new SettingsModel() { Name = Localization.Settings0 },
                new SettingsModel() { Name = Localization.Settings2 },
                new SettingsModel() { Name = Localization.Settings4 },
                new SettingsModel() { Name = Localization.Settings5 },
                new SettingsModel() { Name = Localization.AutoDownload, Description = GlobalData.Current.AutoDownload ? Localization.Yes : Localization.No }
            };
            Version = "v" + MainActivity.Instance.PackageManager.GetPackageInfo(MainActivity.Instance.PackageName, 0).VersionName;
        }
        #endregion
        #region Private Methods
        private void Menu_OnItemSelected(string item)
        {
            if (item == Localization.ThemeLight)
                ChangeTheme("Light");
            else if (item == Localization.ThemeDark)
                ChangeTheme("Dark");
            else
                ChangeTheme("Default");

            SnackbarBuilder.Show(Localization.SettingsChanges);

        }

        private void ChangeTheme(string theme)
        {
            GlobalData.Current.SaveFirstStart(theme);
            SnackbarBuilder.Show(Localization.SettingsChanges);
        }
        #endregion
        #region Public Methods
        public async System.Threading.Tasks.Task Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                if (e.SelectedItemIndex > 0 && e.SelectedItem != null)
                {
                    if (e.SelectedItemIndex == 0)
                    {
                        foreach (string filepath in GlobalData.Current.Audios.Keys)
                        {

                            if (!GlobalData.Current.AudioTags.ContainsKey(filepath))
                            {
                                var tag = GlobalData.Current.Audios[filepath];
                                if (tag.Artist == Localization.UnknownArtist)
                                {
                                    FileInfo fileInfo = new FileInfo(filepath);

                                    string name = fileInfo.Name.Replace(fileInfo.Extension, "");
                                    string[] splitted = name.Split(new string[] { " - ", " – ", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries);

                                    string artist = splitted.Length == 1 ? Localization.UnknownArtist : splitted[0];
                                    string title = splitted[splitted.Length == 1 ? 0 : 1];
                                    GlobalData.Current.AudioTags.Add(filepath, new MediaSourceTag() { Author = artist, Title = title });
                                }
                            }
                        }
                        GlobalData.Current.SaveTags();
                        SnackbarBuilder.Show(Localization.Ready);
                    }
                    else if (e.SelectedItemIndex == 1)
                    {
                        string[] files = Directory.GetFiles(GlobalData.Current.DataPath, "*.nsec2");

                        foreach (string file in files)
                        {
                            File.Delete(file);
                        }

                        SnackbarBuilder.Show(Localization.Ready);
                    }
                    else if (e.SelectedItemIndex == 2)
                    {
                        Intent intent = new Intent(Intent.ActionOpenDocumentTree);
                        intent.AddCategory(Intent.CategoryDefault);
                        MainActivity.Instance.StartActivityForResult(Intent.CreateChooser(intent, "Newtone"), 9999);
                    }
                    else if (e.SelectedItemIndex == 3)
                    {
                        string newLang = await NormalPage.Instance.DisplayActionSheet(Localization.Settings5, Localization.Cancel, null, Localization.LanguagePL, Localization.LanguageEN, Localization.LanguageRU);
                        if (newLang == Localization.LanguagePL)
                            GlobalData.Current.CurrentLanguage = "pl";
                        else if (newLang == Localization.LanguageEN)
                            GlobalData.Current.CurrentLanguage = "en";
                        else if (newLang == Localization.LanguageRU)
                            GlobalData.Current.CurrentLanguage = "ru";

                        Localization.RefreshLanguage();
                        GlobalData.Current.SaveConfig();
                        SnackbarBuilder.Show(Localization.SettingsChanges);
                    }
                    else if(e.SelectedItemIndex == 4)
                    {
                        string newOption = await NormalPage.Instance.DisplayActionSheet(Localization.AutoDownload, Localization.Cancel, null, Localization.Yes, Localization.No);

                        if(newOption == Localization.Yes)
                        {
                            GlobalData.Current.AutoDownload = true;
                            Items[4].Description = Localization.Yes;
                        }
                        else if(newOption == Localization.No)
                        {
                            GlobalData.Current.AutoDownload = false;
                            Items[4].Description = Localization.No;
                        }
                        GlobalData.Current.SaveConfig();
                        SnackbarBuilder.Show(Localization.SettingsChanges);
                    }
                }
                (sender as ListView).SelectedItem = null;
            }
        }

        #endregion
    }
}