using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Loaders;
using Newtone.Core.Processing;
using Newtone.Desktop.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace Newtone.Desktop.Logic
{
    public static class ContextMenuBuilder
    {
        private static string FilePath { get; set; }
        private static string Playlist { get; set; }
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
            foreach(var item in GlobalData.Playlists.Keys)
            {
                MenuItem playlistItem = new MenuItem
                {
                    Header = item
                };
                playlistItem.Click += (sender, e) =>
                {
                   if(!GlobalData.Playlists[item].Contains(FilePath))
                    {
                        GlobalData.Playlists[item].Add(FilePath);
                        GlobalData.SaveConfig();
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
            menuLangPL.Click += (sender, e) => { GlobalData.CurrentLanguage = "pl"; Localization.RefreshLanguage(); GlobalData.SaveConfig(); };
            MenuItem menuLangEN = new MenuItem
            {
                Header = Localization.LanguageEN
            };
            menuLangEN.Click += (sender, e) => { GlobalData.CurrentLanguage = "en"; Localization.RefreshLanguage(); GlobalData.SaveConfig(); };
            MenuItem menuLangRU = new MenuItem
            {
                Header = Localization.LanguageRU
            };
            menuLangRU.Click += (sender, e) => { GlobalData.CurrentLanguage = "ru"; Localization.RefreshLanguage(); GlobalData.SaveConfig(); };


            menu.Items.Add(menuLangPL);
            menu.Items.Add(menuLangEN);
            menu.Items.Add(menuLangRU);

            return menu;
        }

        private static void MenuSyncClear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SyncProcessing.Audios.Clear();
        }

        private static void MenuSyncDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SyncProcessing.Audios.Remove(FilePath);
        }

        private static void MenuSyncPlaylist_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SyncProcessing.AddFiles(GlobalData.Playlists[Playlist]);
        }

        private static void MenuSync_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SyncProcessing.AddFile(FilePath);
        }

        private static void MenuEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow(FilePath)
            {
                Owner = MainWindow.Instance,
                Left = MainWindow.Instance.Left,
                Top = MainWindow.Instance.Top
            };
            editWindow.ShowDialog();
            //editWindow.Show();
        }

        private static void MenuDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FileInfo fileInfo = new FileInfo(FilePath);
            AlertWindow prompt = new AlertWindow(Localization.Warning, Localization.QuestionDelete + " "+fileInfo.Name+(Playlist == "" ? "?" : " "+  Localization.QuestionDeleteFromPlaylist+"?"))
            {
                Owner = MainWindow.Instance,
                Left = MainWindow.Instance.Left,
                Top = MainWindow.Instance.Top
            };
            bool? answer = prompt.ShowDialog();

            if(answer == true)
            {
                if(Playlist == "")
                {
                    GlobalLoader.RemoveTrack(FilePath);
                    File.Delete(FilePath);
                    foreach(var item in GlobalData.Playlists.Keys)
                    {
                        GlobalData.Playlists[item].Remove(FilePath);
                    }
                }
                else
                {
                    GlobalData.Playlists[Playlist].Remove(FilePath);
                }
            }

            GlobalData.SaveConfig();
            GlobalData.SaveTags();
        }

        private static void ItemNew_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PromptWindow prompt = new PromptWindow(Localization.NewPlaylist, Localization.NewPlaylistHint,Localization.Add,Localization.Cancel)
            {
                Owner = MainWindow.Instance,
                Left = MainWindow.Instance.Left,
                Top = MainWindow.Instance.Top
            };
            bool? answer = prompt.ShowDialog();

            if (answer == true && !string.IsNullOrEmpty(prompt.Value))
            {
                if (!GlobalData.Playlists.ContainsKey(prompt.Value))
                    GlobalData.Playlists.Add(prompt.Value, new List<string>());

                GlobalData.Playlists[prompt.Value].Add(FilePath);

                
            }
            GlobalData.SaveConfig();
        }
    }
}
