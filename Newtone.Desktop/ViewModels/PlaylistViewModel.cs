using Newtone.Core;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Newtone.Desktop.ViewModels
{
    public class PlaylistViewModel : PropertyChangedBase
    {
        #region Fields
        private ObservableCollection<PlaylistModel> items;
        private ObservableCollection<Models.TrackModel> trackItems;
        #endregion
        #region Properties
        public ObservableCollection<PlaylistModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Models.TrackModel> TrackItems
        {
            get => trackItems;
            set
            {
                trackItems = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public PlaylistViewModel()
        {
            //TODO
            Items = new ObservableCollection<PlaylistModel>();
            TrackItems = new ObservableCollection<Newtone.Desktop.Models.TrackModel>();

            foreach (string playlist in GlobalData.Current.Playlists.Keys)
            {
                if (GlobalData.Current.Playlists[playlist].Count > 0)
                    Items.Add(new PlaylistModel() { Name = playlist, TrackCount = GlobalData.Current.Playlists[playlist].Count });
            }
        }
        #endregion
        #region Public Methods
        public void ListView_SelectionChanged(ListView listView)
        {
            int index = listView.SelectedIndex;
            TrackItems.Clear();

            if (index >= 0 && index < Items.Count)
            {
                foreach (string path in GlobalData.Current.Playlists[Items.Count == 0 || listView.SelectedIndex == -1 ? "" : Items[listView.SelectedIndex].Name])
                {
                    if (GlobalData.Current.Audios.ContainsKey(path))
                    {
                        TrackItems.Add(new Models.TrackModel(GlobalData.Current.Audios[path]));
                    }
                    else if(path.Length == 11 && GlobalData.Current.SavedTracks.ContainsKey(path))
                    {
                        TrackItems.Add(new Models.TrackModel(GlobalData.Current.SavedTracks[path]));
                    }
                }
            }
        }

        public void Tick(ListView listView, ListView trackListView)
        {
            if (EditWindow.AfterEdit)
            {
                string oldArtist = Items.Count == 0 || listView.SelectedIndex == -1 ? "" : Items[listView.SelectedIndex].Name;
                Items.Clear();
                foreach (string playlist in GlobalData.Current.Playlists.Keys)
                {
                    if (GlobalData.Current.Playlists[playlist].Count > 0)
                        Items.Add(new PlaylistModel() { Name = playlist, TrackCount = GlobalData.Current.Playlists[playlist].Count });
                }

                listView.SelectedIndex = -1;

                for (int a = 0; a < Items.Count; a++)
                {
                    if (Items[a].Name == oldArtist)
                    {
                        listView.SelectedIndex = a;
                        break;
                    }

                }

                EditWindow.AfterEdit = false;
            }

            if(GlobalData.Current.PlaylistsNeedRefresh)
            {
                trackListView.SelectedIndex = -1;
                listView.SelectedIndex = -1;

                Items.Clear();
                TrackItems.Clear();

                foreach (string playlist in GlobalData.Current.Playlists.Keys)
                {
                    if (GlobalData.Current.Playlists[playlist].Count > 0)
                        Items.Add(new PlaylistModel() { Name = playlist, TrackCount = GlobalData.Current.Playlists[playlist].Count });
                }

                listView.Items.Refresh();
                trackListView.Items.Refresh();
                GlobalData.Current.PlaylistsNeedRefresh = false;
                trackListView.Items.Refresh();
            }
        }

        public void TrackListView_PreviewMouseLeftButtonUp(ListView listView, ListView trackListView)
        {
            int index = trackListView.SelectedIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                string filePath = TrackItems.Count == 0 ? "" : TrackItems[trackListView.SelectedIndex].FilePath;
                MediaSource source = filePath.Length == 11 ? GlobalData.Current.SavedTracks[filePath] : GlobalData.Current.Audios[filePath];
                GlobalData.Current.CurrentPlaylist.Clear();

                foreach (string path in GlobalData.Current.Playlists[Items.Count == 0 || listView.SelectedIndex == -1 ? "" : Items[listView.SelectedIndex].Name])
                {
                    if (GlobalData.Current.Audios.ContainsKey(path))
                        GlobalData.Current.CurrentPlaylist.Add(GlobalData.Current.Audios[path]);
                    else if (path.Length == 11 && GlobalData.Current.SavedTracks.ContainsKey(path))
                        GlobalData.Current.CurrentPlaylist.Add(GlobalData.Current.SavedTracks[path]);
                }

                GlobalData.Current.MediaSource = source;
                GlobalData.Current.PlaylistPosition = index;

                GlobalData.Current.MediaPlayer.Stop();
                GlobalData.Current.MediaPlayer.Reset();
                GlobalData.Current.MediaPlayer.Load(source.FilePath);
                GlobalData.Current.MediaPlayer.Play();
            }
        }

        public void TrackListView_PreviewMouseRightButtonUp(ListView listView, ListView trackListView)
        {
            int index = trackListView.SelectedIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                var menu = ContextMenuBuilder.BuildForTrack(TrackItems[index].FilePath, Items.Count == 0 || listView.SelectedIndex == -1 ? "" : Items[listView.SelectedIndex].Name);
                menu.IsOpen = true;
                menu.PlacementTarget = trackListView;
            }
        }

        public void PlaylistListView_PreviewMouseRightButtonUp(ListView listView)
        {
            int index = listView.SelectedIndex;

            if (index >= 0 && index < Items.Count)
            {
                var menu = ContextMenuBuilder.BuildForPlaylist(Items[index].Name);
                menu.IsOpen = true;
                menu.PlacementTarget = listView;
            }
        }
        #endregion
    }
}
