using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Media;
using System;
using System.IO;

namespace Newtone.Mobile.UI.Models
{
    public class SettingsModel : NListViewItem
    {
        #region Fields
        private string name;
        private string description;
        #endregion
        #region Properties
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Public Methods
        public override async void FocusAction()
        {
            int index = ParentListView.NFocusedIndex;

            if (index >= 0 && index < ParentListView.NItemSource.Count)
            {
                if (index == 0)
                {
                    foreach (string filepath in GlobalData.Current.Audios.Keys)
                    {

                        if (!GlobalData.Current.AudioTags.ContainsKey(filepath))
                        {
                            var tag = GlobalData.Current.Audios[filepath];
                            if (tag.Artist == Localization.UnknownArtist)
                            {
                                FileInfo fileInfo = new FileInfo(filepath);

                                string _name = fileInfo.Name.Replace(fileInfo.Extension, "");
                                string[] splitted = _name.Split(new string[] { " - ", " – ", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries);

                                string artist = splitted.Length == 1 ? Localization.UnknownArtist : splitted[0];
                                string title = splitted[splitted.Length == 1 ? 0 : 1];
                                GlobalData.Current.AudioTags.Add(filepath, new MediaSourceTag() { Author = artist, Title = title });
                            }
                        }
                    }
                    GlobalData.Current.SaveTags();
                    Global.Application.ShowSnackbar(Localization.Ready);
                }
                else if (index == 1)
                {
                    string[] files = Directory.GetFiles(GlobalData.Current.DataPath, "*.nsec2");

                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }

                    UI.Global.Application.ShowSnackbar(Localization.Ready);
                }
                else if (index == 2)
                {
                    Global.Application.AddFolderToScan();
                }
                else if (index == 3)
                {
                    string newLang = await Global.Page.DisplayActionSheet(Localization.Settings5, Localization.Cancel, null, Localization.LanguagePL, Localization.LanguageEN, Localization.LanguageRU);
                    if (newLang == Localization.LanguagePL)
                        GlobalData.Current.CurrentLanguage = "pl";
                    else if (newLang == Localization.LanguageEN)
                        GlobalData.Current.CurrentLanguage = "en";
                    else if (newLang == Localization.LanguageRU)
                        GlobalData.Current.CurrentLanguage = "ru";

                    Localization.RefreshLanguage();
                    GlobalData.Current.SaveConfig();
                    Global.Application.ShowSnackbar(Localization.SettingsChanges);
                }
                else if (index == 4)
                {
                    string newOption = await Global.Page.DisplayActionSheet(Localization.AutoDownload, Localization.Cancel, null, Localization.Yes, Localization.No);

                    if (newOption == Localization.Yes)
                    {
                        GlobalData.Current.AutoDownload = true;
                        (ParentListView.NItemSource[4] as SettingsModel).Description = Localization.Yes;
                    }
                    else if (newOption == Localization.No)
                    {
                        GlobalData.Current.AutoDownload = false;
                        (ParentListView.NItemSource[4] as SettingsModel).Description = Localization.No;
                    }
                    GlobalData.Current.SaveConfig();
                    Global.Application.ShowSnackbar(Localization.SettingsChanges);
                }
                else if (index == 5)
                {
                    string newOption = await Global.Page.DisplayActionSheet(Localization.Settings3, Localization.Cancel, null, Localization.Yes, Localization.No);

                    if (newOption == Localization.Yes)
                    {
                        GlobalData.Current.IgnoreAutoFocus = true;
                        (ParentListView.NItemSource[5] as SettingsModel).Description = Localization.Yes;
                    }
                    else if (newOption == Localization.No)
                    {
                        GlobalData.Current.IgnoreAutoFocus = false;
                        (ParentListView.NItemSource[5] as SettingsModel).Description = Localization.No;
                    }
                    GlobalData.Current.SaveConfig();
                    Global.Application.ShowSnackbar(Localization.Ready);
                }
            }
        }
        #endregion
    }
}
