using Newtone.Core;
using Newtone.Core.Media;
using Newtone.Core.Models;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
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

            settingsList.ItemsSource = Items = new ObservableCollection<SettingsModel>();
            Items.Add(new SettingsModel() { Name = Localization.Settings0, Description = "", Enabled = false, HasCheckbox = false });
            Items.Add(new SettingsModel() { Name = Localization.Settings2, Description = "", Enabled = false, HasCheckbox = false });
            Items.Add(new SettingsModel() { Name = Localization.Settings3, Description = Localization.SettingsChanges, Enabled = false, HasCheckbox = false });

        }

        private void SettingsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
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
                    settingsList.SelectedItem = null;
                }
                settingsList.SelectedItem = null;
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

        }

        private void ChangeTheme(string theme)
        {
            GlobalData.SaveFirstStart(theme);
            SnackbarBuilder.Show(Localization.SettingsChanges);
        }
    }
}