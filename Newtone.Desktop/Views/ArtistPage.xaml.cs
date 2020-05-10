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
    /// Logika interakcji dla klasy ArtistPage.xaml
    /// </summary>
    public partial class ArtistPage : UserControl, ITimerContent
    {
        private ObservableCollection<ArtistModel> ArtistItems { get; set; }
        private ObservableCollection<Newtone.Desktop.Models.TrackModel> TrackItems { get; set; }

        private string CurrentArtistName
        {
            get
            {
                return ArtistItems.Count == 0 || listView.SelectedIndex == -1 ? "" : ArtistItems[listView.SelectedIndex].Name;
            }
        }

        private string CurrentTrackPath
        {
            get
            {
                return TrackItems.Count == 0 ? "" : TrackItems[trackListView.SelectedIndex].FilePath;
            }
        }
        public ArtistPage()
        {
            InitializeComponent();

            listView.ItemsSource = ArtistItems = new ObservableCollection<ArtistModel>();
            trackListView.ItemsSource = TrackItems = new ObservableCollection<Newtone.Desktop.Models.TrackModel>();

            foreach(string artist in GlobalData.Artists.Keys)
            {
                //ConsoleDebug.WriteLine(artist);
                ArtistItems.Add(new ArtistModel() { Name = artist, TrackCount = GlobalData.Artists[artist].Count });
            }
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listView.SelectedIndex;
            TrackItems.Clear();

            if (index >= 0 && index < ArtistItems.Count)
            {
                foreach (string path in GlobalData.Artists[CurrentArtistName])
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
            if(EditWindow.AfterEdit)
            {
                string oldArtist = CurrentArtistName;
                ArtistItems.Clear();
                foreach (string artist in GlobalData.Artists.Keys)
                {
                    //ConsoleDebug.WriteLine(artist);
                    if(GlobalData.Artists[artist].Count > 0)
                        ArtistItems.Add(new ArtistModel() { Name = artist, TrackCount = GlobalData.Artists[artist].Count });
                }

                listView.SelectedIndex = -1;

                for(int a = 0; a < ArtistItems.Count; a++)
                {
                    if (ArtistItems[a].Name == oldArtist)
                    {
                        listView.SelectedIndex = a;
                        break;
                    }

                }

                EditWindow.AfterEdit = false;
            }

            if(CurrentArtistName != "")
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
                    }
                    else
                    {
                        TrackItems.Remove(model);
                        needRefresh = true;
                    }
                    model.CheckChanges();
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

                foreach (string path in GlobalData.Artists[CurrentArtistName])
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
                var menu = ContextMenuBuilder.BuildForTrack(TrackItems[index].FilePath);
                menu.IsOpen = true;
                menu.PlacementTarget = trackListView;
            }
        }
    }
}
