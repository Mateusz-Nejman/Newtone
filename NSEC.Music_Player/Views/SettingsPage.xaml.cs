using Android.Content;
using Newtone.Core;
using Newtone.Core.Media;
using Newtone.Core.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentView
    {
        private ObservableCollection<SettingsModel> Items { get; set; }
        public SettingsPage()
        {
            InitializeComponent();

            settingsListView.ItemsSource = Items = new ObservableCollection<SettingsModel>();
            Items.Add(new SettingsModel() { Name = Localization.Settings0});
            Items.Add(new SettingsModel() { Name = Localization.Settings2});
            Items.Add(new SettingsModel() { Name = Localization.Settings3});
            Items.Add(new SettingsModel() { Name = Localization.Settings4 });
            Items.Add(new SettingsModel() { Name = Localization.Settings5 });
            versionLabel.Text = "v" + MainActivity.Instance.PackageManager.GetPackageInfo(MainActivity.Instance.PackageName, 0).VersionName;
        }

        private async void SettingsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if(index >= 0 && index < Items.Count)
            {
                if (e.SelectedItemIndex > 0 && e.SelectedItem != null)
                {
                    if (e.SelectedItemIndex == 0)
                    {
                        foreach (string filepath in GlobalData.Audios.Keys)
                        {

                            if (!GlobalData.AudioTags.ContainsKey(filepath))
                            {
                                var tag = GlobalData.Audios[filepath];
                                if (tag.Artist == Localization.UnknownArtist)
                                {
                                    FileInfo fileInfo = new FileInfo(filepath);

                                    string name = fileInfo.Name.Replace(fileInfo.Extension, "");
                                    string[] splitted = name.Split(new string[] { " - ", " – ", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries);

                                    string artist = splitted.Length == 1 ? Localization.UnknownArtist : splitted[0];
                                    string title = splitted[splitted.Length == 1 ? 0 : 1];
                                    GlobalData.AudioTags.Add(filepath, new MediaSourceTag() { Author = artist, Title = title });
                                }
                            }
                        }
                        GlobalData.SaveTags();
                        SnackbarBuilder.Show(Localization.Ready);
                    }
                    else if (e.SelectedItemIndex == 1)
                    {
                        string[] files = Directory.GetFiles(GlobalData.DataPath, "*.nsec2");

                        foreach (string file in files)
                        {
                            File.Delete(file);
                        }

                        SnackbarBuilder.Show(Localization.Ready);
                    }
                    else if (e.SelectedItemIndex == 2)
                    {
                        PopupMenu popup = new PopupMenu(MainActivity.Instance, (View)sender, Localization.ThemeDefault, Localization.ThemeLight, Localization.ThemeDark);
                        popup.OnSelect += Menu_OnItemSelected;
                        popup.Show();
                    }
                    else if(e.SelectedItemIndex == 3)
                    {
                        Intent intent = new Intent(Intent.ActionOpenDocumentTree);
                        intent.AddCategory(Intent.CategoryDefault);
                        MainActivity.Instance.StartActivityForResult(Intent.CreateChooser(intent, "Newtone"), 9999);
                    }
                    else if(e.SelectedItemIndex == 4)
                    {
                        string newLang = await NormalPage.Instance.DisplayActionSheet(Localization.Settings5, Localization.Cancel, null, Localization.LanguagePL, Localization.LanguageEN, Localization.LanguageRU);
                        if (newLang == Localization.LanguagePL)
                            GlobalData.CurrentLanguage = "pl";
                        else if (newLang == Localization.LanguageEN)
                            GlobalData.CurrentLanguage = "en";
                        else if (newLang == Localization.LanguageRU)
                            GlobalData.CurrentLanguage = "ru";

                        Localization.RefreshLanguage();
                        GlobalData.SaveConfig();
                        SnackbarBuilder.Show(Localization.SettingsChanges);
                    }
                }
                settingsListView.SelectedItem = null;
            }
        }

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
            GlobalData.SaveFirstStart(theme);
            SnackbarBuilder.Show(Localization.SettingsChanges);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://mateusz-nejman.pl/"));
        }
    }
}