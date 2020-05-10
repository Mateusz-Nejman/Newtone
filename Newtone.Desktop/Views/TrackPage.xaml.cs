using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    /// Logika interakcji dla klasy TrackPage.xaml
    /// </summary>
    public partial class TrackPage : UserControl, ITimerContent
    {
        private ObservableCollection<TrackModel> TrackItems { get; set; }

        private string CurrentTrackPath
        {
            get
            {
                return TrackItems.Count == 0 ? "" : TrackItems[trackListView.SelectedIndex].FilePath;
            }
        }
        public TrackPage()
        {
            InitializeComponent();

            trackListView.ItemsSource = TrackItems = new ObservableCollection<TrackModel>();

            foreach(var source in GlobalData.Audios.Values)
            {
                TrackItems.Add(new TrackModel(source));
            }
        }

        private void TrackListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int index = trackListView.SelectedIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                MediaSource source = GlobalData.Audios[CurrentTrackPath];
                GlobalData.CurrentPlaylist.Clear();

                GlobalData.CurrentPlaylist.AddRange(GlobalData.Audios.Values);

                GlobalData.MediaSource = source;
                GlobalData.PlaylistPosition = index;
                GlobalData.PlaylistType = MediaSource.SourceType.Local;

                GlobalData.MediaPlayer.Stop();
                GlobalData.MediaPlayer.Reset();
                GlobalData.MediaPlayer.Load(source.FilePath);
                GlobalData.MediaPlayer.Play();
            }
            trackListView.SelectedItem = null;
        }

        private void TrackListView_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            int index = trackListView.SelectedIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                ContextMenu menu = ContextMenuBuilder.BuildForTrack(CurrentTrackPath);
                menu.IsOpen = true;
                menu.PlacementTarget = trackListView;
            }
            
        }

        public void Tick()
        {
            bool needRefresh = false;
            foreach(var model in TrackItems.ToList())
            {
                
                if (GlobalData.Audios.ContainsKey(model.FilePath))
                {
                    MediaSource source = GlobalData.Audios[model.FilePath];
                    if(model.Artist != source.Artist || model.Title != source.Title)
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
            if(needRefresh)
                trackListView.Items.Refresh();
        }
    }
}
