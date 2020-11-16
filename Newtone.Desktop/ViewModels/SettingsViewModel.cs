using Microsoft.Win32;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Loaders;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Desktop.Logic;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Newtone.Desktop.ViewModels
{
    public class SettingsViewModel : PropertyChangedBase
    {
        #region Fields
        private ObservableCollection<SettingsModel> items;
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
        #endregion
        #region Commands
        private ICommand selectedItem;
        public ICommand SelectedItem
        {
            get
            {
                if (selectedItem == null)
                    selectedItem = new ActionCommand(parameter =>
                    {
                        var listView = parameter as ListView;
                        int index = listView.SelectedIndex;

                        if (index >= 0 && index < Items.Count)
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
                            else if (index == 1)
                            {
                                string[] files = Directory.GetFiles(GlobalData.Current.DataPath, "*.nsec2");

                                foreach (string file in files)
                                {
                                    File.Delete(file);
                                }
                                SnackbarBuilder.Show(Localization.Ready);
                            }
                            else if (index == 2)
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
                                    string newPath = Path.GetDirectoryName(folderBrowser.FileName);

                                    if (!GlobalData.Current.IncludedPaths.Contains(newPath))
                                    {
                                        GlobalData.Current.IncludedPaths.Add(newPath);
                                        Task.Run(async () => {
                                            var files = await FileProcessing.Scan(newPath);

                                            foreach (var file in files)
                                            {
                                                GlobalLoader.AddTrack(file);
                                            }
                                        });
                                        SnackbarBuilder.Show(Localization.Ready);
                                        GlobalData.Current.SaveConfig();
                                    }
                                }
                            }
                            else if (index == 3)
                            {
                                var menu = ContextMenuBuilder.BuildForLanguage();
                                menu.IsOpen = true;
                            }
                            listView.SelectedItem = null;
                        }
                    });
                return selectedItem;
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
        }
        #endregion
    }
}
