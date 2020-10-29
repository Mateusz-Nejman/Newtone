using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Mobile.Media;
using Xamarin.Forms;
using TrackModel = Newtone.Mobile.Models.TrackModel;

namespace Newtone.Mobile.ViewModels
{
    public class TrackViewModel:PropertyChangedBase
    {
        #region Fields
        private bool isRefreshing;
        #endregion
        #region Properties
        public ObservableCollection<TrackModel> Items { get; set; }
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
                        IsRefreshing = true;
                        List<TrackModel> beforeSort = new List<TrackModel>();
                        foreach (var track in GlobalData.Current.Audios.Values)
                        {
                            beforeSort.Add(new TrackModel(track).CheckChanges());
                        }
                        Items = new ObservableCollection<TrackModel>(beforeSort.OrderBy(item => item.TrackString));
                        IsRefreshing = false;
                    });
                return refresh;
            }
        }
        #endregion
        #region Constructors
        public TrackViewModel()
        {
            List<TrackModel> beforeSort = new List<TrackModel>();
            foreach (var track in GlobalData.Current.Audios.Values.ToList())
            {
                beforeSort.Add(new TrackModel(track).CheckChanges());
            }
            Items = new ObservableCollection<TrackModel>(beforeSort.OrderBy(item => item.TrackString));
        }
        #endregion
        #region Public Methods

        public void Tick()
        {
            if(Items.Count != GlobalData.Current.Audios.Count)
            {
                Items.Clear();
                List<TrackModel> beforeSort = new List<TrackModel>();
                foreach (var track in GlobalData.Current.Audios.Values.ToList())
                {
                    beforeSort.Add(new TrackModel(track).CheckChanges());
                }
                foreach(var item in beforeSort.OrderBy(item => item.TrackString))
                {
                    Items.Add(item);
                }
            }
            foreach (var model in Items.ToList())
            {

                if (GlobalData.Current.Audios.ContainsKey(model.FilePath))
                {
                    var source = GlobalData.Current.Audios[model.FilePath];
                    if (model.Artist != source.Artist || model.Title != source.Title)
                    {
                        int index = Items.IndexOf(model);
                        Items[index].Title = source.Title;
                        Items[index].Artist = source.Artist;
                    }
                    model.CheckChanges();
                }
                else
                {
                    Items.Remove(model);
                }
            }

        }

        public void Track_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            int index = e.SelectedItemIndex;

            if (index >= 0 && index < Items.Count)
            {
                GlobalData.Current.MediaPlayer.LoadPlaylist(Items.Select(item => item.FilePath).ToList(), index, true, true);
                (sender as Xamarin.Forms.ListView).SelectedItem = null;
            }
        }

        #endregion
    }
}