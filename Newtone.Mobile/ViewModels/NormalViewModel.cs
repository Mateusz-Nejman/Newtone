﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Languages;
using Newtone.Core.Loaders;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Mobile.Views;
using Newtone.Mobile.Views.Custom;
using Xamarin.Forms;

namespace Newtone.Mobile.ViewModels
{
    public class NormalViewModel : PropertyChangedBase
    {
        #region Fields
        private TracksPage tracksPage;
        private ArtistPage artistPage;
        private PlaylistPage playlistPage;
        private SettingsPage settingsPage;
        private SearchPage searchPage;

        private string pageTitle;
        private string searchPlaceholder;
        private bool badgeSyncVisible;
        private string badgeSync;
        private bool badgeVisible;
        private string badge;
        private int currentButtonIndex = -1;
        private bool titleVisible = true;
        private bool entryVisible = false;
        private string entryText;

        private bool tracksButtonToggled;
        private bool artistsButtonToggled;
        private bool playlistsButtonToggled;
        private bool searchButtonToggled;
        private bool settingsButtonToggled;
        private PlayerPanel playerPanel;
        private IDisposable loopSubscription;

        private bool searchCancelVisible;
        private ObservableCollection<HistoryModel> suggestionItems;
        private bool searchSuggestionsVisible = false;
        private readonly Entry searchEntry;
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

        public string SearchPlaceholder
        {
            get => searchPlaceholder;
            set
            {
                searchPlaceholder = value;
                OnPropertyChanged();
            }
        }
        public bool TitleVisible
        {
            get => titleVisible;
            set
            {
                titleVisible = value;
                OnPropertyChanged();
            }
        }
        public bool EntryVisible
        {
            get => entryVisible;
            set
            {
                entryVisible = value;
                OnPropertyChanged();
            }
        }
        public string EntryText
        {
            get => entryText;
            set
            {
                entryText = value;
                OnPropertyChanged();

                SearchCancelVisible = entryText.Length > 0;
            }
        }

        public bool SearchCancelVisible
        {
            get => searchCancelVisible;
            set
            {
                searchCancelVisible = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<HistoryModel> SuggestionItems
        {
            get => suggestionItems;
            set
            {
                suggestionItems = value;
                OnPropertyChanged();
            }
        }

        public bool SearchSuggestionsVisible
        {
            get => searchSuggestionsVisible;
            set
            {
                searchSuggestionsVisible = value;
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
                        if (GlobalData.Current.MediaSource != null)
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
                        if(currentButtonIndex != 0 || (parameter as bool?) == true)
                        {
                            if (tracksPage == null)
                                tracksPage = new TracksPage();
                            SetContainer(tracksPage, Localization.Tracks);
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
                            if (artistPage == null)
                                artistPage = new ArtistPage();
                            SetContainer(artistPage, Localization.Artists);
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
                            if (playlistPage == null)
                                playlistPage = new PlaylistPage();
                            SetContainer(playlistPage, Localization.Playlists);
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
                            if (searchPage == null)
                                searchPage = new SearchPage();
                            SetContainer(searchPage, Localization.Search);
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
                            if (settingsPage == null)
                                settingsPage = new SettingsPage();
                            SetContainer(settingsPage, Localization.Settings);
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

        private ICommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                    searchCommand = new ActionCommand(parameter =>
                    {
                        foreach (var children in Container.Children)
                        {
                            if (children is SearchPage page)
                                page?.SearchEntry_Completed(EntryText);
                        }
                    });

                return searchCommand;
            }
        }

        private ICommand clearSearchCommand;
        public ICommand ClearSearchText
        {
            get
            {
                if (clearSearchCommand == null)
                    clearSearchCommand = new ActionCommand(parameter =>
                    {
                        searchEntry.Unfocus();
                        EntryText = "";
                    });

                return clearSearchCommand;
            }
        }
        #endregion
        #region Constructors
        public NormalViewModel(Grid container, PlayerPanel panel, Entry searchEntry)
        {
            this.searchEntry = searchEntry;
            SuggestionItems = new ObservableCollection<HistoryModel>();
            Container = container;
            PlayerPanel = panel;

            Directory.CreateDirectory(GlobalData.Current.MusicPath);
            if (!MainActivity.Loaded)
            {
                GlobalData.Current.LoadTags();
                Task task;
                if(CacheLoader.IsCacheAvailable())
                {
                    task = Task.Run(() =>
                    {
                        CacheLoader.LoadCache();
                        Task.Run(async () => await GlobalLoader.Load());
                    });
                }
                else
                    task = Task.Run(async () => await GlobalLoader.Load());
                task.ContinueWith(t =>
                {
                    GlobalData.Current.LoadConfig();
                    MainActivity.Loaded = true;
                    NormalPage.Instance.Dispatcher.BeginInvokeOnMainThread(() => GotoTracks.Execute(true));
                });
            }
        }
        #endregion
        #region Public Methods
        public void Appearing()
        {
            var src = System.Reactive.Linq.Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(200)).Timestamp();
            loopSubscription = src.Subscribe(time => Tick());
            if (Container.Children.Count > 0)
                if (Container.Children[0] is IVisibleContent)
                    (Container.Children[0] as IVisibleContent).Appearing();

            if(GlobalData.Current.Audios.Count == 0)
            {
                GlobalData.Current.LoadTags();
                CacheLoader.LoadCache();
                GlobalData.Current.LoadConfig();
            }
        }

        public void Disappearing()
        {
            loopSubscription?.Dispose();
            loopSubscription = null;
        }

        public void Tick()
        {
            SearchPlaceholder = Localization.Search;
            Badge = DownloadProcessing.BadgeCount.ToString();
            BadgeVisible = DownloadProcessing.BadgeCount > 0;

            BadgeSyncVisible = SyncProcessing.Audios.Count > 0;
            BadgeSync = SyncProcessing.Audios.Count.ToString();
            PlayerPanel?.Tick();

            foreach(var children in Container.Children)
            {
                if (children.IsVisible && children is ITimerContent content)
                    content.Tick();
            }
        }

        public void RefreshSuggestion()
        {
            string searchedText = EntryText ?? "";
            var newList = SearchProcessing.GenerateSearchSuggestions().FindAll(item => item.ToLowerInvariant().Contains(searchedText.ToLowerInvariant()) || searchedText.ToLowerInvariant().Contains(item.ToLowerInvariant()));

            SuggestionItems.Clear();
            foreach (var item in newList)
            {
                SuggestionItems.Add(new HistoryModel() { Text = item });
            }
        }
        public async void SuggestionItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < SuggestionItems.Count)
            {
                if (MainActivity.IsInternet())
                    await NormalPage.NavigationInstance.PushModalAsync(new ModalPage(new SearchResultPage(SuggestionItems[index].Text), SuggestionItems[index].Text));
                else
                    await NormalPage.Instance.DisplayAlert(Localization.Warning, Localization.NoConnection, Localization.Cancel);

                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }

        #endregion


        #region Private Methods
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
            EntryVisible = content == searchPage;
            TitleVisible = !(content == searchPage);

            if (!Container.Children.Contains(content))
                Container.Children.Add(content);
            else
            {
                Container.Children.Remove(content);
                Container.Children.Add(content);
            }
            if(Container.Children.Count > 0)
            {
                foreach(var children in Container.Children)
                {
                    
                    if(children.IsVisible)
                    {
                        if(children is IVisibleContent)
                            (children as IVisibleContent).Disappearing();
                        children.IsVisible = false;
                    }

                    if (children == content)
                    {
                        if(children is IVisibleContent)
                            (children as IVisibleContent).Appearing();
                        children.IsVisible = true;

                    }
                    else
                        children.IsVisible = false;
                }
            }
            PageTitle = title;
        }

        #endregion
    }
}