﻿using ATL;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Models;
using Newtone.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Newtone.Desktop.ViewModels
{
    public class ArtistViewModel : PropertyChangedBase
    {
        #region Fields
        private ObservableCollection<ArtistModel> artistItems;
        private ObservableCollection<Models.TrackModel> trackItems;
        #endregion
        #region Properties
        public ObservableCollection<ArtistModel> ArtistItems
        {
            get => artistItems;
            set
            {
                artistItems = value;
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
        public ArtistViewModel()
        {
            ArtistItems = new ObservableCollection<ArtistModel>();
            TrackItems = new ObservableCollection<Newtone.Desktop.Models.TrackModel>();

            foreach (string artist in GlobalData.Artists.Keys)
            {
                //ConsoleDebug.WriteLine(artist);
                if(GlobalData.Artists[artist].Count > 0)
                    ArtistItems.Add(new ArtistModel() { Name = artist, TrackCount = GlobalData.Artists[artist].Count });
            }
        }
        #endregion
        #region Public Methods
        public void Tick(ListView listView, ListView trackListView)
        {
            if (EditWindow.AfterEdit)
            {
                string oldArtist = ArtistItems.Count == 0 || listView.SelectedIndex == -1 ? "" : ArtistItems[listView.SelectedIndex].Name;
                ArtistItems.Clear();
                foreach (string artist in GlobalData.Artists.Keys)
                {
                    //ConsoleDebug.WriteLine(artist);
                    if (GlobalData.Artists[artist].Count > 0)
                        ArtistItems.Add(new ArtistModel() { Name = artist, TrackCount = GlobalData.Artists[artist].Count });
                }

                listView.SelectedIndex = -1;

                for (int a = 0; a < ArtistItems.Count; a++)
                {
                    if (ArtistItems[a].Name == oldArtist)
                    {
                        listView.SelectedIndex = a;
                        break;
                    }

                }

                EditWindow.AfterEdit = false;
            }

            if ((ArtistItems.Count == 0 || listView.SelectedIndex == -1 ? "" : ArtistItems[listView.SelectedIndex].Name) != "")
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

        public void ListView_SelectionChanged(ListView listView, SelectionChangedEventArgs e)
        {
            int index = listView.SelectedIndex;
            TrackItems.Clear();

            if (index >= 0 && index < ArtistItems.Count)
            {
                foreach (string path in GlobalData.Artists[ArtistItems.Count == 0 || listView.SelectedIndex == -1 ? "" : ArtistItems[listView.SelectedIndex].Name])
                {
                    if (GlobalData.Audios.ContainsKey(path))
                    {
                        TrackItems.Add(new Models.TrackModel(GlobalData.Audios[path]));
                    }

                }
            }
        }

        public void TrackListView_PreviewMouseLeftButtonUp(ListView listView, ListView trackListView)
        {
            int index = trackListView.SelectedIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                MediaSource source = GlobalData.Audios[TrackItems.Count == 0 ? "" : TrackItems[trackListView.SelectedIndex].FilePath];
                GlobalData.CurrentPlaylist.Clear();

                foreach (string path in GlobalData.Artists[ArtistItems.Count == 0 || listView.SelectedIndex == -1 ? "" : ArtistItems[listView.SelectedIndex].Name])
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

        public void TrackListView_PreviewMouseRightButtonUp(ListView listView, ListView trackListView)
        {
            int index = trackListView.SelectedIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                var menu = ContextMenuBuilder.BuildForTrack(TrackItems[index].FilePath);
                menu.IsOpen = true;
                menu.PlacementTarget = trackListView;
            }
        }
        #endregion
    }
}
