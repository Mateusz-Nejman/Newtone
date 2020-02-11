using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.CustomViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsTab : ContentPage
    {
        private readonly ObservableCollection<SettingsModel> Items;
        public SettingsTab()
        {
            InitializeComponent();
            Items = new ObservableCollection<SettingsModel>();
            settingsView.ItemsSource = Items;

            

            Appearing += SettingsTab_Appearing;
        }

        private void SettingsTab_Appearing(object sender, EventArgs e)
        {
            Items.Clear();
            Items.Add(new SettingsModel() { Id = 0, Text = Localization.SettingsAddTags, Description = Localization.SettingsChanges, CheckboxVisible = false, CheckboxValue = false });
            Items.Add(new SettingsModel() { Id = 1, Text = Localization.SettingsClear, Description = Localization.SettingsChanges, CheckboxVisible = false, CheckboxValue = false });
            Items.Add(new SettingsModel() { Id = 2, Text = "Automatyczne tagi", Description = "Tagi będą się dodawać automatycznie", CheckboxVisible = true, CheckboxValue = Global.AutoTags });
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = Items.IndexOf((SettingsModel)settingsView.SelectedItem);
            SettingsSelected(index);
            
            settingsView.SelectedItem = null;
        }

        private void SettingsSelected(int index)
        {
            if (index >= 0)
            {
                SettingsModel settingsModel = Items[index];
                if (settingsModel.Id == 0)
                {
                    foreach (string filepath in Global.Audios.Keys)
                    {

                        if (!Global.AudioTags.ContainsKey(filepath))
                        {
                            MediaProcessing.MediaTag tag = Global.Audios[filepath];
                            if (tag.Artist == Localization.UnknownArtist)
                            {
                                FileInfo fileInfo = new FileInfo(filepath);

                                string name = fileInfo.Name.Replace(fileInfo.Extension, "");
                                string[] splitted = name.Split(new string[] { " - ", " – ", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries);

                                string artist = splitted.Length == 1 ? Localization.UnknownArtist : splitted[0];
                                string title = splitted[splitted.Length == 1 ? 0 : 1];
                                Console.WriteLine("SettingsTab " + name + " " + splitted.Length + "(" + artist + "," + title + ")");
                                Global.AudioTags.Add(filepath, new MediaProcessing.MediaTag() { Artist = artist, Title = title });
                            }
                        }
                    }
                    Global.SaveTags();
                    SnackbarBuilder.Show(Localization.YoutubeReady);
                }
                else if (settingsModel.Id == 1)
                {
                    if (File.Exists(Global.DataPath + "/data.nsec2"))
                        File.Delete(Global.DataPath + "/data.nsec2");
                    if (File.Exists(Global.DataPath + "/tags.nsec2"))
                        File.Delete(Global.DataPath + "/tags.nsec2");

                    SnackbarBuilder.Show(Localization.YoutubeReady);
                }
                else if(settingsModel.Id == 2)
                {
                    Global.AutoTags = !Global.AutoTags;
                    SettingsTab_Appearing(null, null);
                    Global.SaveConfig();
                }
            }
        }

        private void CustomCheckbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CustomCheckbox cc = (CustomCheckbox)sender;
            Console.WriteLine("CustomCheckBox " + cc.Tag);
            if(cc.Tag != "")
            {
                int id = int.Parse(cc.Tag);
                int index = -1;

                for (int a = 0; a < Items.Count; a++)
                {
                    if (Items[a].Id == id)
                    {
                        index = a;
                        break;
                    }
                }

                SettingsSelected(index);
            }
        }
    }
}