﻿using Android.Graphics;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TracksPage : ContentView, ITimerContent
    {
        private ObservableCollection<TrackModel> TrackItems { get; set; }
        public TracksPage()
        {
            InitializeComponent();

            trackListView.ItemsSource = TrackItems = new ObservableCollection<TrackModel>();

            foreach(var track in GlobalData.Audios.Values)
            {
                TrackItems.Add(new TrackModel(track));
            }
        }

        public void Tick()
        {
            foreach (var model in TrackItems.ToList())
            {

                if (GlobalData.Audios.ContainsKey(model.FilePath))
                {
                    var source = GlobalData.Audios[model.FilePath];
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
                }
            }

        }

        private void TrackListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if(index >= 0 && index < TrackItems.Count)
            {
                var model = TrackItems[index];

                GlobalData.MediaPlayer.SetPlayerController(new LocalPlayerController());
                GlobalData.MediaSource = GlobalData.Audios[model.FilePath];
                GlobalData.CurrentPlaylist.Clear();
                GlobalData.PlaylistPosition = index;
                foreach(var item in TrackItems)
                {
                    GlobalData.CurrentPlaylist.Add(GlobalData.Audios[item.FilePath]);
                }
                GlobalData.MediaPlayer.Load(model.FilePath);
                MediaPlayerHelper.Play();
                trackListView.SelectedItem = null;
            }
        }
    }
}