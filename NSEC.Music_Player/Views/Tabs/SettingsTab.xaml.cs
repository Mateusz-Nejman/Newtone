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

            Items.Add(new SettingsModel() { Id = 0, Text = Localization.SettingsAddTags, Description = Localization.SettingsChanges });
            Items.Add(new SettingsModel() { Id = 1, Text = Localization.SettingsClear, Description = Localization.SettingsChanges });
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = Items.IndexOf((SettingsModel)settingsView.SelectedItem);

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
            }
            settingsView.SelectedItem = null;
        }
    }
}