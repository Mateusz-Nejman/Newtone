using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Data;
using Nejman.Newtone.Core.Localization;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Mobile.Models;
using Nejman.Newtone.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nejman.Newtone.Mobile.ViewModels
{
    [QueryProperty(nameof(ArtistName), nameof(ArtistName))]
    [QueryProperty(nameof(PlaylistName), nameof(PlaylistName))]
    [QueryProperty(nameof(CurrentPlaylist), nameof(CurrentPlaylist))]
    [QueryProperty(nameof(AllTracks), nameof(AllTracks))]
    public class TracksListViewModel : PropertyChangedBase
    {
        #region Fields
        private bool isRefreshing;
        private string artistName;
        private string playlistName;
        private bool currentPlaylist;
        private bool allTracks;
        private IDisposable listener;
        private readonly IList<MediaSource> playlist;
        private string title;
        #endregion
        #region Properties
        public BindableObject Handler { get; set; }
        public ObservableCollection<TrackModel> Items { get; set; }

        public string ArtistName
        {
            get => artistName;
            set
            {
                artistName = value;
                playlistName = null;
                currentPlaylist = false;
                allTracks = false;
                Title = artistName;
                InitializeListener(2);
            }
        }

        public string PlaylistName
        {
            get => playlistName;
            set
            {
                artistName = null;
                playlistName = value;
                currentPlaylist = false;
                allTracks = false;
                Title = playlistName;
                InitializeListener(3);
            }
        }

        public bool CurrentPlaylist
        {
            get => currentPlaylist;
            set
            {
                artistName = null;
                playlistName = null;
                currentPlaylist = value;
                allTracks = false;
                Title = Localization.Tracks;
                InitializeListener(1);
            }
        }

        public bool AllTracks
        {
            get => allTracks;
            set
            {
                artistName = null;
                playlistName = null;
                currentPlaylist = false;
                allTracks = value;
                Title = Localization.Tracks;
                InitializeListener();
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Constructors
        public TracksListViewModel()
        {
            Items = new ObservableCollection<TrackModel>();
            playlist = new List<MediaSource>();

            listener = Observable.Timer(TimeSpan.FromSeconds(0.5)).Subscribe(x => AllTracks = true);
        }
        #endregion
        #region Public Methods
        public void Appearing()
        {
            if(allTracks)
            {
                AllTracks = allTracks;
            }

            if(artistName != null)
            {
                ArtistName = artistName;
            }

            if(playlistName != null)
            {
                PlaylistName = playlistName;
            }

            if(currentPlaylist)
            {
                CurrentPlaylist = currentPlaylist;
            }
        }

        public void Disappearing()
        {
            listener?.Dispose();
            listener = null;
        }
        public async Task Track_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                await CoreGlobal.MediaPlayer.LoadPlaylist(playlist,index);

                (sender as ListView).SelectedItem = null;
            }
        }

        #endregion
        #region Private Methods
        private void InitializeListener(int mode = 0) //0 = all tracks, 1 = current playlist, 2 = artist, 3 = playlist
        {
            IsRefreshing = false;
            listener?.Dispose();
            listener = null;

            if (mode == 0)
            {
                listener = new AggregateDisposable(
                    CoreGlobal.TracksRefresh.Subscribe(x => Refresh()),
                    Observable.Interval(TimeSpan.FromMilliseconds(500)).Subscribe(x => CheckChanges())
                    );
                Refresh();
                ShellHelpers.SetTitleView(Handler, new BaseTitleView());
            }
            else if(mode == 1)
            {
                listener = new AggregateDisposable(
                    CoreGlobal.TracksRefresh.Subscribe(x => RefreshCurrent()),
                    Observable.Interval(TimeSpan.FromMilliseconds(500)).Subscribe(x => CheckChanges())
                    );
                RefreshCurrent();
                ShellHelpers.SetTitleView(Handler, null);
            }
            else if(mode == 2)
            {
                listener = new AggregateDisposable(
                    CoreGlobal.ArtistsRefresh.Subscribe(artist =>
                    {
                        if (artist == ArtistName)
                        {
                            RefreshArtist();
                        }
                    }),
                    Observable.Interval(TimeSpan.FromMilliseconds(500)).Subscribe(x => CheckChanges())
                    );
                RefreshArtist();
                ShellHelpers.SetTitleView(Handler, null);
            }
            else if(mode == 3)
            {
                listener = new AggregateDisposable(
                    CoreGlobal.PlaylistsRefresh.Subscribe(playlist =>
                    {
                        if (playlist == PlaylistName)
                        {
                            RefreshPlaylist();
                        }
                    }),
                    Observable.Interval(TimeSpan.FromMilliseconds(500)).Subscribe(x => CheckChanges())
                    );
                RefreshPlaylist();
                ShellHelpers.SetTitleView(Handler, null);
            }
        }

        private void CheckChanges()
        {
            Items.ForEach(item => item.CheckChanges());
        }
        private void Refresh()
        {
            if(IsRefreshing)
            {
                return;
            }

            IsRefreshing = true;
            Items.Clear();
            playlist.Clear();

            var sorted = TracksAction.GetSorted();

            foreach(var item in sorted)
            {
                var source = TracksAction.Get(item.Path);

                if(source != null)
                {
                    Items.Add(new TrackModel(source));
                    playlist.Add(source);
                }
            }

            IsRefreshing = false;
        }

        private void RefreshCurrent()
        {
            if (IsRefreshing)
            {
                return;
            }

            IsRefreshing = true;
            Items.Clear();
            playlist.Clear();

            var sorted = PlaylistsAction.GetCurrentPlaylist();

            foreach (var item in sorted)
            {
                var source = TracksAction.Get(item.Path);

                if (source != null)
                {
                    Items.Add(new TrackModel(source));
                    playlist.Add(source);
                }
            }

            IsRefreshing = false;
        }

        private void RefreshArtist()
        {
            if (IsRefreshing)
            {
                return;
            }

            IsRefreshing = true;
            var artistTracks = ArtistsAction.GetArtist(ArtistName);

            if(artistTracks.Count == 0)
            {
                ShellHelpers.GoTo("..");
                return;
            }

            Items.Clear();
            playlist.Clear();
            foreach(var track in artistTracks)
            {
                Items.Add(new TrackModel(track));
                playlist.Add(track);
            }

            IsRefreshing = false;
        }

        private void RefreshPlaylist()
        {
            if (IsRefreshing)
            {
                return;
            }

            IsRefreshing = true;
            var playlistTracks = PlaylistsAction.GetPlaylist(PlaylistName);

            if (playlistTracks.Count == 0)
            {
                ShellHelpers.GoTo("..");
                return;
            }

            Items.Clear();
            foreach (var track in playlistTracks)
            {
                var source = TracksAction.Get(track.Path);
                Items.Add(new TrackModel(source));
                playlist.Add(source);
            }

            IsRefreshing = false;
        }
        #endregion
    }
}
