using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Loaders;
using Newtone.Core.Processing;
using Newtone.Desktop.Views;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace Newtone.Desktop.Logic
{
    public static class ContextMenuBuilder
    {
        #region Properties
        private static string FilePath { get; set; }
        private static string Playlist { get; set; }
        #endregion
        #region Public Methods
        public static ContextMenu BuildForTrack(string filePath, string playlist = "")
        {
            FilePath = filePath;
            Playlist = playlist;
            ContextMenu menu = new ContextMenu();

            MenuItem menuEdit = new MenuItem
            {
                Header = Localization.TrackMenuEdit
            };
            menuEdit.Click += MenuEdit_Click;
            menu.Items.Add(menuEdit);

            MenuItem ItemNew = new MenuItem
            {
                Header = Localization.NewPlaylist
            };
            ItemNew.Click += ItemNew_Click;
            MenuItem menuAdd = new MenuItem
            {
                Header = Localization.TrackMenuPlaylist
            };
            menuAdd.Items.Add(ItemNew);
            foreach(var item in GlobalData.Current.Playlists.Keys)
            {
                MenuItem playlistItem = new MenuItem
                {
                    Header = item
                };
                playlistItem.Click += (sender, e) =>
                {
                   if(!GlobalData.Current.Playlists[item].Contains(FilePath))
                    {
                        GlobalData.Current.Playlists[item].Add(FilePath);
                        GlobalData.Current.SaveConfig();
                    }
                };
                menuAdd.Items.Add(playlistItem);
            }

            MenuItem menuSync = new MenuItem
            {
                Header = Localization.SyncAdd
            };
            menuSync.Click += MenuSync_Click;

            MenuItem menuSyncPlaylist = new MenuItem
            {
                Header = Localization.SyncAddPlaylist
            };
            menuSyncPlaylist.Click += MenuSyncPlaylist_Click;

            

            MenuItem menuDelete = new MenuItem
            {
                Header = Localization.TrackMenuDelete
            };
            menuDelete.Click += MenuDelete_Click;

            menu.Items.Add(menuAdd);
            menu.Items.Add(menuSync);
            if (!string.IsNullOrEmpty(Playlist))
                menu.Items.Add(menuSyncPlaylist);

            menu.Items.Add(menuDelete);

            return menu;
        }

        public static ContextMenu BuildForSync(string filePath)
        {
            FilePath = filePath;
            ContextMenu menu = new ContextMenu();

            MenuItem menuSyncDelete = new MenuItem
            {
                Header = Localization.TrackMenuDelete
            };
            menuSyncDelete.Click += MenuSyncDelete_Click;
            menu.Items.Add(menuSyncDelete);

            MenuItem menuSyncClear = new MenuItem
            {
                Header = Localization.Clear
            };
            menuSyncClear.Click += MenuSyncClear_Click;

            menu.Items.Add(menuSyncClear);


            return menu;
        }

        public static ContextMenu BuildForLanguage()
        {
            ContextMenu menu = new ContextMenu();

            MenuItem menuLangPL = new MenuItem
            {
                Header = Localization.LanguagePL
            };
            menuLangPL.Click += (sender, e) => { GlobalData.Current.CurrentLanguage = "pl"; Localization.RefreshLanguage(); SnackbarBuilder.Show(Localization.SettingsChanges); GlobalData.Current.SaveConfig(); };
            MenuItem menuLangEN = new MenuItem
            {
                Header = Localization.LanguageEN
            };
            menuLangEN.Click += (sender, e) => { GlobalData.Current.CurrentLanguage = "en"; Localization.RefreshLanguage(); SnackbarBuilder.Show(Localization.SettingsChanges); GlobalData.Current.SaveConfig(); };
            MenuItem menuLangRU = new MenuItem
            {
                Header = Localization.LanguageRU
            };
            menuLangRU.Click += (sender, e) => { GlobalData.Current.CurrentLanguage = "ru"; Localization.RefreshLanguage(); SnackbarBuilder.Show(Localization.SettingsChanges); GlobalData.Current.SaveConfig(); };


            menu.Items.Add(menuLangPL);
            menu.Items.Add(menuLangEN);
            menu.Items.Add(menuLangRU);

            return menu;
        }

        public static ContextMenu BuildForIcon()
        {
            ContextMenu menu = new ContextMenu();

            MenuItem menuConvert = new MenuItem
            {
                Header = Localization.Conversion
            };
            menuConvert.Click += (sender, e) =>
            {
                ConvertWindow window = new ConvertWindow();
                window.CenterToMainWindow();
                window.ShowDialog();
            };

            MenuItem menuInfo = new MenuItem
            {
                Header = Localization.Informations,
            };
            menuInfo.Click += (sender, e) =>
            {
                AboutWindow about = new AboutWindow();
                about.CenterToMainWindow();
                about.ShowDialog();
            };
            menu.Items.Add(menuConvert);
            menu.Items.Add(menuInfo);
            
            return menu;
        }
        #endregion

        #region Private Methods
        private static void MenuSyncClear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SyncProcessing.Audios.Clear();
            SnackbarBuilder.Show(Localization.Ready);
        }

        private static void MenuSyncDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SyncProcessing.Audios.Remove(FilePath);
            SnackbarBuilder.Show(Localization.Ready);
        }

        private static void MenuSyncPlaylist_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SyncProcessing.AddFiles(GlobalData.Current.Playlists[Playlist]);
            SnackbarBuilder.Show(Localization.Ready);
        }

        private static void MenuSync_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SyncProcessing.AddFile(FilePath);
            SnackbarBuilder.Show(Localization.Ready);
        }

        private static void MenuEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow(FilePath);
            editWindow.CenterToMainWindow();
            editWindow.ShowDialog();
        }

        private static void MenuDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(FilePath);
            AlertWindow prompt = new AlertWindow(Localization.Warning, Localization.QuestionDelete + " " + fileInfo.Name + (Playlist == "" ? "?" : " " + Localization.QuestionDeleteFromPlaylist + "?"), Localization.Yes, Localization.No);
            prompt.CenterToMainWindow();
            bool? answer = prompt.ShowDialog();

            if(answer == true)
            {
                if(Playlist == "")
                {
                    GlobalLoader.RemoveTrack(FilePath);
                    File.Delete(FilePath);
                    foreach(var item in GlobalData.Current.Playlists.Keys)
                    {
                        GlobalData.Current.Playlists[item].Remove(FilePath);
                    }
                }
                else
                {
                    GlobalData.Current.Playlists[Playlist].Remove(FilePath);
                }
            }

            SnackbarBuilder.Show(Localization.Ready);
            GlobalData.Current.SaveConfig();
            GlobalData.Current.SaveTags();
        }

        private static void ItemNew_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PromptWindow prompt = new PromptWindow(Localization.NewPlaylist, Localization.NewPlaylistHint, Localization.Add, Localization.Cancel);
            prompt.CenterToMainWindow();
            bool? answer = prompt.ShowDialog();

            if (answer == true && !string.IsNullOrEmpty(prompt.Value))
            {
                if (!GlobalData.Current.Playlists.ContainsKey(prompt.Value))
                    GlobalData.Current.Playlists.Add(prompt.Value, new List<string>());

                GlobalData.Current.Playlists[prompt.Value].Add(FilePath);

                
            }

            SnackbarBuilder.Show(Localization.Ready);
            GlobalData.Current.SaveConfig();
        }
        #endregion
    }
}
