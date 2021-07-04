﻿using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Media;
using Newtone.Desktop.Processing;
using Newtone.Desktop.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YoutubeExplode;
using YoutubeExplode.Common;

namespace Newtone.Desktop.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        #region Fields
        private string snackbarText;
        private Visibility snackbarVisibility = Visibility.Hidden;
        #endregion
        #region Properties
        public string SnackbarText
        {
            get => snackbarText;
            set
            {
                snackbarText = value;
                OnPropertyChanged();
            }
        }
        public Visibility SnackbarVisibility
        {
            get => snackbarVisibility;
            set
            {
                snackbarVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsNormalWindow { get; set; }
        #endregion
        #region Constructors
        public MainViewModel()
        {
            InitializeGlobalVariables();
            GlobalData.Current.LoadTags();
            GlobalData.Current.LoadSavedTracks();
            Task task = Task.Run(async () =>
            {
                if (CacheLoader.IsCacheAvailable())
                    CacheLoader.LoadCache();

                await GlobalLoader.Load();
            });

            task.ContinueWith(t =>
            {
                GlobalData.Current.LoadConfig();

                if (GlobalData.Current.AutoDownload)
                {
                    Task.Run(async () =>
                    {
                        try
                        {
                            YoutubeClient client = new YoutubeClient();
                            foreach (var key in GlobalData.Current.WebToLocalPlaylists.Keys.ToList())
                            {
                                if (GlobalData.Current.Playlists.ContainsKey(GlobalData.Current.WebToLocalPlaylists[key]))
                                    DownloadProcessing.AddRange(await client.Playlists.GetVideosAsync(key), GlobalData.Current.WebToLocalPlaylists[key], key, true);
                            }
                        }
                        catch
                        {
                            //Ignore
                        }
                    });
                }
            });
        }
        #endregion
        #region Public Methods
        public void ShowSnackbar(string text)
        {
            new Task(() =>
            {
                SnackbarVisibility = Visibility.Visible;
                SnackbarText = text;
                Thread.Sleep((int)new TimeSpan(0, 0, 3).TotalMilliseconds);
                SnackbarVisibility = Visibility.Hidden;
                SnackbarText = text;
            }).Start();
        }

        public void StateChanged(MainWindow window)
        {
            if (window.WindowState == WindowState.Normal)
            {
                (window.container.Children[0] as IWindowContent).ChangeMaximizeIcon(ImageProcessing.FromArray(Properties.Resources.MaximizeIcon));
                window.mainGrid.Margin = new Thickness(0);
            }
            else if (window.WindowState == WindowState.Maximized)
            {
                (window.container.Children[0] as IWindowContent).ChangeMaximizeIcon(ImageProcessing.FromArray(Properties.Resources.Maximize1Icon));
                window.mainGrid.Margin = new Thickness(6);
            }
        }

        public void SetContainer(MainWindow window, UserControl control)
        {
            IsNormalWindow = control is NormalWindow;
            window.container.Children.Clear();
            window.container.Children.Add(control);
            StateChanged(window);
        }

        public void TopBarButtonClicked(object sender, TitleBarButtonEventArgs e)
        {
            if (e.ButtonIndex == TitleBarButton.Back)
            {
                SetContainer((sender as MainWindow), new NormalWindow());
            }
            else if (e.ButtonIndex == TitleBarButton.Minimize)
            {
                (sender as MainWindow).WindowState = WindowState.Minimized;
            }
            else if (e.ButtonIndex == TitleBarButton.Maximize)
            {
                (sender as MainWindow).WindowState = (sender as MainWindow).WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }
            else if (e.ButtonIndex == TitleBarButton.Close)
            {
                (sender as MainWindow).Close();
            }
        }
        #endregion
        #region Private Methods
        private void InitializeGlobalVariables()
        {
            GlobalData.Current.Initialize();
            GlobalData.Current.Messenger = new Core.Logic.MessageGenerator(new CoreMessenger());
            GlobalData.Current.MusicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\NSEC.Newtone";
            Directory.CreateDirectory(GlobalData.Current.DataPath);
            Directory.CreateDirectory(GlobalData.Current.MusicPath);
            GlobalData.Current.MediaPlayer = new Core.Media.CrossPlayer(new DesktopMediaPlayer());
            GlobalData.Current.MediaPlayer.SetNativeActions(GlobalData.Current.MediaPlayer.Play);
            GlobalData.Current.IncludedPaths = new List<string>()
            {
                GlobalData.Current.MusicPath,
                Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
            };
        }
        #endregion
        #region Nested Classes
        public class TitleBarButtonEventArgs : EventArgs
        {
            public TitleBarButton ButtonIndex { get; set; } //-1 = back, 0 = minimize, 1 = maximize, 2 = close

        }
        #endregion
        #region Enums
        public enum TitleBarButton
        {
            Back = -1,
            Minimize = 0,
            Maximize = 1,
            Close = 2
        }
        #endregion
    }
}
