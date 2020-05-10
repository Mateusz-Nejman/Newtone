using Newtone.Core;
using Newtone.Core.Loaders;
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
                Header = "Edytuj"
            };
            menuEdit.Click += MenuEdit_Click;
            menu.Items.Add(menuEdit);

            MenuItem ItemNew = new MenuItem
            {
                Header = "Nowa playlista"
            };
            ItemNew.Click += ItemNew_Click;
            MenuItem menuAdd = new MenuItem
            {
                Header = "Dodaj do playlisty"
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

            MenuItem menuDelete = new MenuItem
            {
                Header = "Usuń"
            };
            menuDelete.Click += MenuDelete_Click;

            menu.Items.Add(menuAdd);
            menu.Items.Add(menuDelete);

            return menu;
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
            AlertWindow prompt = new AlertWindow("Uwaga", "Usunąć plik "+fileInfo.Name+(Playlist == "" ? "?" : " z playlisty"))
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
            PromptWindow prompt = new PromptWindow("Nowa playlista", "Nazwa playlisty", "Dodaj","Anuluj")
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
