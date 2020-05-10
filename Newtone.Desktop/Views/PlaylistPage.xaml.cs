using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Desktop.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PlaylistPage.xaml
    /// </summary>
    public partial class PlaylistPage : UserControl, ITimerContent
    {
        private ObservableCollection<PlaylistModel> PlaylistItems { get; set; }
        private ObservableCollection<Newtone.Desktop.Models.TrackModel> TrackItems { get; set; }

        private string CurrentPlaylistName
        {
            get
            {
                return PlaylistItems.Count == 0 || listView.SelectedIndex == -1 ? "" : PlaylistItems[listView.SelectedIndex].Name;
            }
        }

        private string CurrentTrackPath
        {
            get
            {
                return TrackItems.Count == 0 ? "" : TrackItems[trackListView.SelectedIndex].FilePath;
            }
        }
        public PlaylistPage()
        {
            InitializeComponent();

            listView.ItemsSource = PlaylistItems = new ObservableCollection<PlaylistModel>();
            trackListView.ItemsSource = TrackItems = new ObservableCollection<Newtone.Desktop.Models.TrackModel>();

            foreach (string playlist in GlobalData.Playlists.Keys)
            {
                PlaylistItems.Add(new PlaylistModel() { Name = playlist, TrackCount = GlobalData.Playlists[playlist].Count });
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listView.SelectedIndex;
            TrackItems.Clear();

            if (index >= 0 && index < PlaylistItems.Count)
            {
                foreach (string path in GlobalData.Playlists[CurrentPlaylistName])
                {
                    if (GlobalData.Audios.ContainsKey(path))
                    {
                        TrackItems.Add(new Models.TrackModel(GlobalData.Audios[path]));
                    }

                }
            }
        }

        public void Tick()
        {
            if (EditWindow.AfterEdit)
            {
                string oldArtist = CurrentPlaylistName;
                PlaylistItems.Clear();
                foreach (string playlist in GlobalData.Playlists.Keys)
                {
                    if(GlobalData.Playlists[playlist].Count > 0)
                        PlaylistItems.Add(new PlaylistModel() { Name = playlist, TrackCount = GlobalData.Playlists[playlist].Count });
                }

                listView.SelectedIndex = -1;

                for (int a = 0; a < PlaylistItems.Count; a++)
                {
                    if (PlaylistItems[a].Name == oldArtist)
                    {
                        listView.SelectedIndex = a;
                        break;
                    }

                }

                EditWindow.AfterEdit = false;
            }

            if (CurrentPlaylistName != "")
            {
                bool needRefresh = false;
                foreach (var model in TrackItems.ToList())
                {
                    
                    if (GlobalData.Audios.ContainsKey(model.FilePath))
                    {
                        MediaSource source = GlobalData.Audios[model.FilePath];
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

        private void TrackListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int index = trackListView.SelectedIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                MediaSource source = GlobalData.Audios[CurrentTrackPath];
                GlobalData.CurrentPlaylist.Clear();

                foreach (string path in GlobalData.Playlists[CurrentPlaylistName])
                {
                    if (GlobalData.Audios.ContainsKey(path))
                        GlobalData.CurrentPlaylist.Add(GlobalData.Audios[path]);
                }

                GlobalData.MediaSource = source;
                GlobalData.PlaylistPosition = index;
                GlobalData.PlaylistType = MediaSource.SourceType.Local;

                GlobalData.MediaPlayer.Stop();
                GlobalData.MediaPlayer.Reset();
                GlobalData.MediaPlayer.Load(source.FilePath);
                GlobalData.MediaPlayer.Play();
            }
        }

        private void TrackListView_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            int index = trackListView.SelectedIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                var menu = ContextMenuBuilder.BuildForTrack(TrackItems[index].FilePath, CurrentPlaylistName);
                menu.IsOpen = true;
                menu.PlacementTarget = trackListView;
            }
        }
    }
}
