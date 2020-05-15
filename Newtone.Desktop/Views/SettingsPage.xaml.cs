using Microsoft.Win32;
using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Desktop.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        private ObservableCollection<SettingsModel> Items { get; set; }
        public SettingsPage()
        {
            InitializeComponent();

            settingsListView.ItemsSource = Items = new ObservableCollection<SettingsModel>();
            Refresh();
        }

        private void SearchListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int index = settingsListView.SelectedIndex;

            if(index >= 0 && index < Items.Count)
            {
                if(index == 0)
                {
                    foreach (string filepath in GlobalData.Audios.Keys)
                    {

                        if (!GlobalData.AudioTags.ContainsKey(filepath))
                        {
                            var tag = GlobalData.Audios[filepath];
                            if (tag.Artist == Newtone.Core.Languages.Localization.UnknownArtist)
                            {
                                FileInfo fileInfo = new FileInfo(filepath);

                                string name = fileInfo.Name.Replace(fileInfo.Extension, "");
                                string[] splitted = name.Split(new string[] { " - ", " – ", "- ", " -" }, StringSplitOptions.RemoveEmptyEntries);

                                string artist = splitted.Length == 1 ? Newtone.Core.Languages.Localization.UnknownArtist : splitted[0];
                                string title = splitted[splitted.Length == 1 ? 0 : 1];
                                GlobalData.AudioTags.Add(filepath, new MediaSourceTag() { Author = artist, Title = title });
                            }
                        }
                    }
                    GlobalData.SaveTags();
                }
                else if(index == 1)
                {
                    string[] files = Directory.GetFiles(GlobalData.DataPath, "*.nsec2");

                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                }
                else if(index == 2)
                {
                    OpenFileDialog folderBrowser = new OpenFileDialog
                    {
                        ValidateNames = false,
                        CheckFileExists = false,
                        CheckPathExists = true,
                        FileName = "Newtone"
                    };
                    if (folderBrowser.ShowDialog() == true)
                    {
                        string newPath = System.IO.Path.GetDirectoryName(folderBrowser.FileName);

                        if (!GlobalData.IncludedPaths.Contains(newPath))
                        {
                            GlobalData.IncludedPaths.Add(newPath);
                            Task.Run(async () => {
                                var files = await FileProcessing.Scan(newPath, new List<string>());

                                foreach (var file in files)
                                {
                                    GlobalLoader.AddTrack(file);
                                }
                            });
                            GlobalData.SaveConfig();
                        }
                    }
                }
                else if(index == 3)
                {
                    var menu = ContextMenuBuilder.BuildForLanguage();
                    menu.IsOpen = true;
                }
                settingsListView.SelectedItem = null;
            }
        }

        private void Refresh()
        {
            Items.Clear();
            Items.Add(new SettingsModel() { Name = Core.Languages.Localization.Settings0 });
            Items.Add(new SettingsModel() { Name = Core.Languages.Localization.Settings2 });
            Items.Add(new SettingsModel() { Name = Core.Languages.Localization.Settings4 });
            Items.Add(new SettingsModel() { Name = Core.Languages.Localization.Settings5 });
            settingsListView.Items.Refresh();
        }
    }
}
