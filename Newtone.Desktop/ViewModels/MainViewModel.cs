﻿using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Models;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Media;
using Newtone.Desktop.Processing;
using Newtone.Desktop.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static Newtone.Desktop.Views.MainWindow;

namespace Newtone.Desktop.ViewModels
{
    public class MainViewModel:PropertyChangedBase
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
            GlobalData.LoadTags();
            Task.Run(async () => await GlobalLoader.Load()).Wait();
            GlobalData.LoadConfig();
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
            GlobalData.Artists = new Dictionary<string, List<string>>();
            GlobalData.Audios = new Dictionary<string, Core.Media.MediaSource>();
            GlobalData.AudioTags = new Dictionary<string, Core.Media.MediaSourceTag>();
            GlobalData.DownloadedIds = new List<string>();
            GlobalData.CurrentPlaylist = new List<Core.Media.MediaSource>();
            GlobalData.CurrentQueue = new List<Core.Media.MediaSource>();
            GlobalData.DataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NSEC.Newtone";
            GlobalData.MusicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\NSEC.Newtone";

            //ConsoleDebug.WriteLine(GlobalData.DataPath);
            //ConsoleDebug.WriteLine(GlobalData.MusicPath);

            Directory.CreateDirectory(GlobalData.DataPath);
            Directory.CreateDirectory(GlobalData.MusicPath);

            GlobalData.History = new List<Core.Models.HistoryModel>();
            GlobalData.LastTracks = new Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST];
            GlobalData.MostTracks = new Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST];

            GlobalData.PlayerMode = Core.Media.PlayerMode.All;
            GlobalData.Playlists = new Dictionary<string, List<string>>();
            GlobalData.PlaylistType = Core.Media.MediaSource.SourceType.Local;
            GlobalData.MediaPlayer = new Core.Media.CrossPlayer(new DesktopMediaPlayer());

            GlobalData.ExcludedPaths = new List<string>();
            GlobalData.IncludedPaths = new List<string>()
            {
                GlobalData.MusicPath,
                Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
            };
            //GlobalData.MediaPlayer.Load("D:\\chillwagon - @ (trailer).m4a");
            //GlobalData.MediaPlayer.Play();
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
