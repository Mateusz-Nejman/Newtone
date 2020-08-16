using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Mobile.Media;
using Newtone.Mobile.Models;
using Xamarin.Forms;
using TrackModel = Newtone.Mobile.Models.TrackModel;

namespace Newtone.Mobile.ViewModels
{
    public class CurrentTracksViewModel : PropertyChangedBase
    {
        #region Fields
        private bool isRefreshing;
        private List<string> tracks;
        private string playlistName;
        #endregion
        #region Properties
        public ObservableCollection<TrackModel> TrackItems { get; private set; }
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
        #region Commands
        private ICommand refresh;
        public ICommand Refresh
        {
            get
            {
                if (refresh == null)
                    refresh = new ActionCommand(parameter =>
                    {
                        ConsoleDebug.WriteLine("[Refresh] CurrentTracksViewModel");
                        IsRefreshing = true;
                        List<TrackModel> beforeSort = new List<TrackModel>();
                        foreach (string track in tracks)
                        {
                            if (GlobalData.Audios.ContainsKey(track))
                            {
                                beforeSort.Add(new TrackModel(GlobalData.Audios[track], playlistName).CheckChanges());
                            }
                        }
                        TrackItems = new ObservableCollection<TrackModel>(playlistName == "" ? beforeSort.OrderBy(item => item.TrackString).ToList() : beforeSort);
                        IsRefreshing = false;
                    });
                return refresh;
            }
        }
        #endregion
        #region Constructors
        public CurrentTracksViewModel(List<string> tracks, string playlistName)
        {
            this.tracks = tracks;
            this.playlistName = playlistName;
            List<TrackModel> beforeSort = new List<TrackModel>();
            foreach (string track in tracks)
            {
                if (GlobalData.Audios.ContainsKey(track))
                {
                    beforeSort.Add(new TrackModel(GlobalData.Audios[track], playlistName).CheckChanges());
                }
            }
            TrackItems = new ObservableCollection<TrackModel>(playlistName == "" ? beforeSort.OrderBy(item => item.TrackString).ToList() : beforeSort);
        }
        #endregion
        #region Public Methods

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

        public void TrackListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < TrackItems.Count)
            {
                var model = TrackItems[index];

                GlobalData.MediaSource = GlobalData.Audios[model.FilePath];
                GlobalData.CurrentPlaylist.Clear();
                GlobalData.PlaylistPosition = index;
                foreach (var item in TrackItems)
                {
                    GlobalData.CurrentPlaylist.Add(GlobalData.Audios[item.FilePath]);
                }
                GlobalData.MediaPlayer.Load(model.FilePath);
                MediaPlayerHelper.Play();
                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }
        #endregion
    }
}