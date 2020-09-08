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
            Items = new ObservableCollection<PlaylistModel>();
            TrackItems = new ObservableCollection<Newtone.Desktop.Models.TrackModel>();

            foreach (string playlist in GlobalData.Current.Playlists.Keys)
            {
                if(GlobalData.Current.Playlists[playlist].Count > 0)
                    Items.Add(new PlaylistModel() { Name = playlist, TrackCount = GlobalData.Current.Playlists[playlist].Count });
            }
        }
        #endregion
        #region Public Methods
        public void ListView_SelectionChanged(ListView listView, SelectionChangedEventArgs e)
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

            if ((Items.Count == 0 || listView.SelectedIndex == -1 ? "" : Items[listView.SelectedIndex].Name) != "")
            {
                bool needRefresh = false;
                foreach (var model in TrackItems.ToList())
                {

                    if (GlobalData.Current.Audios.ContainsKey(model.FilePath))
                    {
                        MediaSource source = GlobalData.Current.Audios[model.FilePath];
                        if (model.Artist != source.Artist || model.Title != source.Title)
                        {
                            int index = TrackItems.IndexOf(model);
                            TrackItems[index].Title = source.Title;
                            TrackItems[index].Artist = source.Artist;
                        }

                        model.CheckChanges();
                    }
                    else
                    {
                        TrackItems.Remove(model);
                        needRefresh = true;
                    }


                }
                if (needRefresh)
                    trackListView.Items.Refresh();
            }
        }

        public void TrackListView_PreviewMouseLeftButtonUp(ListView listView, ListView trackListView)
        {
            int index = trackListView.SelectedIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                MediaSource source = GlobalData.Current.Audios[TrackItems.Count == 0 ? "" : TrackItems[trackListView.SelectedIndex].FilePath];
                GlobalData.Current.CurrentPlaylist.Clear();

                foreach (string path in GlobalData.Current.Playlists[Items.Count == 0 || listView.SelectedIndex == -1 ? "" : Items[listView.SelectedIndex].Name])
                {
                    if (GlobalData.Current.Audios.ContainsKey(path))
                        GlobalData.Current.CurrentPlaylist.Add(GlobalData.Current.Audios[path]);
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
        #endregion
    }
}
