﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Loaders;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using NSEC.Music_Player.Processing;
using NSEC.Music_Player.Views;
using NSEC.Music_Player.Views.Custom;
using Xamarin.Forms;

namespace NSEC.Music_Player.ViewModels
{
    public class NormalViewModel : PropertyChangedBase
    {
        #region Fields
        private string pageTitle;
        private bool badgeSyncVisible;
        private string badgeSync;
        private bool badgeVisible;
        private string badge;
        
        private bool stopTimer = false;
        private int currentButtonIndex = -1;

        private bool tracksButtonToggled;
        private bool artistsButtonToggled;
        private bool playlistsButtonToggled;
        private bool searchButtonToggled;
        private bool settingsButtonToggled;
        private PlayerPanel playerPanel;
        #endregion

        #region Properties
        public string PageTitle
        {
            get => pageTitle;
            set
            {
                pageTitle = value;
                OnPropertyChanged();
            }
        }

        public bool BadgeSyncVisible
        {
            get => badgeSyncVisible;
            set
            {
                badgeSyncVisible = value;
                OnPropertyChanged();
            }
        }

        public string BadgeSync
        {
            get => badgeSync;
            set
            {
                badgeSync = value;
                OnPropertyChanged();
            }
        }

        public bool BadgeVisible
        {
            get => badgeVisible;
            set
            {
                badgeVisible = value;
                OnPropertyChanged();
            }
        }

        public string Badge
        {
            get => badge;
            set
            {
                badge = value;
                OnPropertyChanged();
            }
        }

        public Grid Container { get; private set; }

        public bool TracksButtonToggled
        {
            get => tracksButtonToggled;
            set
            {
                tracksButtonToggled = value;
                OnPropertyChanged();
            }
        }

        public bool ArtistsButtonToggled
        {
            get => artistsButtonToggled;
            set
            {
                artistsButtonToggled = value;
                OnPropertyChanged();
            }
        }

        public bool PlaylistsButtonToggled
        {
            get => playlistsButtonToggled;
            set
            {
                playlistsButtonToggled = value;
                OnPropertyChanged();
            }
        }

        public bool SearchButtonToggled
        {
            get => searchButtonToggled;
            set
            {
                searchButtonToggled = value;
                OnPropertyChanged();
            }
        }

        public bool SettingsButtonToggled
        {
            get => settingsButtonToggled;
            set
            {
                settingsButtonToggled = value;
                OnPropertyChanged();
            }
        }

        public PlayerPanel PlayerPanel
        {
            get => playerPanel;
            set
            {
                playerPanel = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private ICommand gotoPlayerCommand;
        public ICommand GotoPlayer
        {
            get
            {
                if (gotoPlayerCommand == null)
                    gotoPlayerCommand = new ActionCommand(async(parameter) =>
                    {
                        if (GlobalData.MediaSource != null)
                        {
                            await NormalPage.NavigationInstance.PushModalAsync(new FullScreenPage());
                        }
                    });
                return gotoPlayerCommand;
            }
        }

        private ICommand gotoTracksCommand;
        public ICommand GotoTracks
        {
            get
            {
                if (gotoTracksCommand == null)
                    gotoTracksCommand = new ActionCommand(parameter =>
                    {
                        if(currentButtonIndex != 0)
                        {
                            SetContainer(new TracksPage(), Localization.Tracks);
                            Toggle(0);
                        }
                    });

                return gotoTracksCommand;
            }
        }

        private ICommand gotoArtistsCommand;
        public ICommand GotoArtists
        {
            get
            {
                if (gotoArtistsCommand == null)
                    gotoArtistsCommand = new ActionCommand(parameter =>
                    {
                        if (currentButtonIndex != 1)
                        {
                            SetContainer(new ArtistPage(), Localization.Artists);
                            Toggle(1);
                        }
                    });

                return gotoArtistsCommand;
            }
        }

        private ICommand gotoPlaylistsCommand;
        public ICommand GotoPlaylists
        {
            get
            {
                if (gotoPlaylistsCommand == null)
                    gotoPlaylistsCommand = new ActionCommand(parameter =>
                    {
                        if (currentButtonIndex != 2)
                        {
                            SetContainer(new PlaylistPage(), Localization.Playlists);
                            Toggle(2);
                        }
                    });

                return gotoPlaylistsCommand;
            }
        }

        private ICommand gotoSearchCommand;
        public ICommand GotoSearch
        {
            get
            {
                if (gotoSearchCommand == null)
                    gotoSearchCommand = new ActionCommand(parameter =>
                    {
                        if (currentButtonIndex != 3)
                        {
                            SetContainer(new SearchPage(), Localization.Search);
                            Toggle(3);
                        }
                    });

                return gotoSearchCommand;
            }
        }

        private ICommand gotoSettingsCommand;
        public ICommand GotoSettings
        {
            get
            {
                if (gotoSettingsCommand == null)
                    gotoSettingsCommand = new ActionCommand(parameter =>
                    {
                        if (currentButtonIndex != 4)
                        {
                            SetContainer(new SettingsPage(), Localization.Settings);
                            Toggle(4);
                        }
                    });

                return gotoSettingsCommand;
            }
        }

        private ICommand gotoSyncCommand;
        public ICommand GotoSync
        {
            get
            {
                if (gotoSyncCommand == null)
                    gotoSyncCommand = new ActionCommand(async(parameter) =>
                    {
                        await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new SyncPage(), Localization.SyncSending, false));
                    });

                return gotoSyncCommand;
            }
        }

        private ICommand gotoDownloadCommand;
        public ICommand GotoDownload
        {
            get
            {
                if (gotoDownloadCommand == null)
                    gotoDownloadCommand = new ActionCommand(async (parameter) =>
                    {
                        await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new DownloadPage(), Localization.TitleDownloads, false));
                    });

                return gotoDownloadCommand;
            }
        }
        #endregion
        #region Constructors
        public NormalViewModel(Grid container, PlayerPanel panel)
        {
            Container = container;
            PlayerPanel = panel;

            Directory.CreateDirectory(GlobalData.MusicPath);
            if (!MainActivity.Loaded)
            {
                GlobalData.LoadTags();
                Task.Run(async () => await GlobalLoader.Load()).Wait();
                GlobalData.LoadConfig();
                MainActivity.Loaded = true;
            }
        }
        #endregion
        #region Public Methods
        public void Appearing()
        {
            Device.StartTimer(TimeSpan.FromSeconds(0.2), TimerTick);
            stopTimer = false;
        }

        public void Disappearing()
        {
            stopTimer = true;
        }
        #endregion


        #region Private Methods
        private bool TimerTick()
        {
            Badge = DownloadProcessing.BadgeCount.ToString();
            BadgeVisible = DownloadProcessing.BadgeCount > 0;

            BadgeSyncVisible = SyncProcessing.Audios.Count > 0;
            BadgeSync = SyncProcessing.Audios.Count.ToString();
            PlayerPanel?.Tick();

            if (Container.Children.Count > 0 && Container.Children[0] is ITimerContent)
                ((ITimerContent)Container.Children[0]).Tick();

            return !stopTimer;
        }

        private void Toggle(int buttonIndex = 0)
        {
            TracksButtonToggled = buttonIndex == 0;
            ArtistsButtonToggled = buttonIndex == 1;
            PlaylistsButtonToggled = buttonIndex == 2;
            SearchButtonToggled = buttonIndex == 3;
            SettingsButtonToggled = buttonIndex == 4;
            currentButtonIndex = buttonIndex;
        }

        private void SetContainer(ContentView content, string title)
        {
            Container.Children.Clear();
            Container.Children.Add(content);
            PageTitle = title;
        }

        #endregion
    }
}