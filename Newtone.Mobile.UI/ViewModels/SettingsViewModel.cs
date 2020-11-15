using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Mobile.UI.Views.TV.ViewCells;
using Xamarin.Forms;
using SettingsModel = Newtone.Mobile.UI.Models.SettingsModel;

namespace Newtone.Mobile.UI.ViewModels
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

        public ObservableCollection<NListViewItem> ListItems { get; set; }

        public string Version
        {
            get => version;
            set
            {
                version = value;
                OnPropertyChanged();
            }
        }

        public Func<NListViewItem, View> ItemTemplate => item => new SettingsViewCell(item);
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
                new SettingsModel() { Name = Localization.AutoDownload, Description = GlobalData.Current.AutoDownload ? Localization.Yes : Localization.No },
                new SettingsModel() { Name = Localization.Settings3, Description = GlobalData.Current.IgnoreAutoFocus ? Localization.Yes : Localization.No }
            };

            ListItems = new ObservableCollection<NListViewItem>();
            foreach(var item in Items)
            {
                ListItems.Add(item);
            }

            Version = "v" + Global.Application.GetVersion();
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
                        Global.Application.ShowSnackbar(Localization.Ready);
                    }
                    else if (e.SelectedItemIndex == 1)
                    {
                        string[] files = Directory.GetFiles(GlobalData.Current.DataPath, "*.nsec2");

                        foreach (string file in files)
                        {
                            File.Delete(file);
                        }

                        UI.Global.Application.ShowSnackbar(Localization.Ready);
                    }
                    else if (e.SelectedItemIndex == 2)
                    {
                        Global.Application.AddFolderToScan();
                    }
                    else if (e.SelectedItemIndex == 3)
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
                    else if (e.SelectedItemIndex == 4)
                    {
                        string newOption = await Global.Page.DisplayActionSheet(Localization.AutoDownload, Localization.Cancel, null, Localization.Yes, Localization.No);

                        if (newOption == Localization.Yes)
                        {
                            GlobalData.Current.AutoDownload = true;
                            Items[4].Description = Localization.Yes;
                        }
                        else if (newOption == Localization.No)
                        {
                            GlobalData.Current.AutoDownload = false;
                            Items[4].Description = Localization.No;
                        }
                        GlobalData.Current.SaveConfig();
                        Global.Application.ShowSnackbar(Localization.SettingsChanges);
                    }
                    else if (e.SelectedItemIndex == 5)
                    {
                        string newOption = await Global.Page.DisplayActionSheet(Localization.Settings3, Localization.Cancel, null, Localization.Yes, Localization.No);

                        if (newOption == Localization.Yes)
                        {
                            GlobalData.Current.IgnoreAutoFocus = true;
                            Items[5].Description = Localization.Yes;
                        }
                        else if (newOption == Localization.No)
                        {
                            GlobalData.Current.IgnoreAutoFocus = false;
                            Items[5].Description = Localization.No;
                        }
                        GlobalData.Current.SaveConfig();
                        Global.Application.ShowSnackbar(Localization.Ready);
                    }
                }
                (sender as ListView).SelectedItem = null;
            }
        }

        #endregion
    }
}
