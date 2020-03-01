using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
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
    public partial class SettingsPage : ContentPage
    {
        private ObservableCollection<SettingsListModel> Items { get; set; }
        public SettingsPage()
        {
            InitializeComponent();
            settingsList.ItemsSource = Items = new ObservableCollection<SettingsListModel>();
            Items.Add(new SettingsListModel() { Name = Localization.Settings0, Description = "", Enabled = false, HasCheckbox = false });
            Items.Add(new SettingsListModel() { Name = Localization.Settings1, Description = "", Enabled = Global.AutoTags, HasCheckbox = true });
            Items.Add(new SettingsListModel() { Name = Localization.Settings2, Description = "", Enabled = false, HasCheckbox = false });
            Appearing += SettingsPage_Appearing;
        }

        private void SettingsPage_Appearing(object sender, EventArgs e)
        {
            Items.Clear();
            Items.Add(new SettingsListModel() { Name = Localization.Settings0, Description = "", Enabled = false, HasCheckbox = false });
            Items.Add(new SettingsListModel() { Name = Localization.Settings1, Description = "", Enabled = Global.AutoTags, HasCheckbox = true });
            Items.Add(new SettingsListModel() { Name = Localization.Settings2, Description = "", Enabled = false, HasCheckbox = false });
        }

        private void SettingsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItemIndex > 0 && e.SelectedItem != null)
            {
                if(e.SelectedItemIndex == 0)
                {
                    foreach (string filepath in Global.Audios.Keys)
                    {

                        if (!Global.AudioTags.ContainsKey(filepath))
                        {
                            MediaSource tag = Global.Audios[filepath];
                            if (tag.Artist == Localization.UnknownArtist)
                            {
                                FileInfo fileInfo = new FileInfo(filepath);

                                string name = fileInfo.Name.Replace(fileInfo.Extension, "");
                                string[] splitted = name.Split(new string[] { " - ", " – ", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries);

                                string artist = splitted.Length == 1 ? Localization.UnknownArtist : splitted[0];
                                string title = splitted[splitted.Length == 1 ? 0 : 1];
                                Global.AudioTags.Add(filepath, new MediaSourceTag() { Author = artist, Title = title});
                            }
                        }
                    }
                    Global.SaveTags();
                    SnackbarBuilder.Show(Localization.Ready);
                }
                else if(e.SelectedItemIndex == 1)
                {
                    Global.AutoTags = !Global.AutoTags;
                    SettingsPage_Appearing(null, null);
                    Global.SaveConfig();
                }
                else if(e.SelectedItemIndex == 2)
                {
                    string[] files = Directory.GetFiles(Global.DataPath, "*.nsec2");

                    foreach(string file in files)
                    {
                        File.Delete(file);
                    }

                    SnackbarBuilder.Show(Localization.Ready);
                }
                settingsList.SelectedItem = null;
            }
        }
    }
}