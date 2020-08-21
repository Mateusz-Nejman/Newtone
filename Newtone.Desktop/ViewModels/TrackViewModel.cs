using Newtone.Core;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Models;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Newtone.Desktop.ViewModels
{
    public class TrackViewModel : PropertyChangedBase
    {
        #region Fields
        private ObservableCollection<Models.TrackModel> items;
        #endregion
        #region Properties
        public ObservableCollection<Models.TrackModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand selectedItemLeft;
        public ICommand SelectedItemLeft
        {
            get
            {
                if (selectedItemLeft == null)
                    selectedItemLeft = new ActionCommand(parameter =>
                    {
                        var listView = parameter as ListView;
                        int index = listView.SelectedIndex;

                        if (index >= 0 && index < Items.Count)
                        {
                            MediaSource source = GlobalData.Current.Audios[Items.Count == 0 ? "" : Items[listView.SelectedIndex].FilePath];
                            GlobalData.Current.CurrentPlaylist.Clear();
                            Items.ForEach(item => GlobalData.Current.CurrentPlaylist.Add(GlobalData.Current.Audios[item.FilePath]));
                            //GlobalData.Current.CurrentPlaylist.AddRange(GlobalData.Current.Audios.Values);

                            GlobalData.Current.MediaSource = source;
                            GlobalData.Current.PlaylistPosition = listView.SelectedIndex;
                            GlobalData.Current.PlaylistType = MediaSource.SourceType.Local;

                            GlobalData.Current.MediaPlayer.Stop();
                            GlobalData.Current.MediaPlayer.Reset();
                            GlobalData.Current.MediaPlayer.Load(source.FilePath);
                            GlobalData.Current.MediaPlayer.Play();
                        }
                        listView.SelectedItem = null;
                    });
                return selectedItemLeft;
            }
        }
        private ICommand selectedItemRight;
        public ICommand SelectedItemRight
        {
            get
            {
                if (selectedItemRight == null)
                    selectedItemRight = new ActionCommand(parameter =>
                    {
                        var listView = parameter as ListView;
                        int index = listView.SelectedIndex;

                        if (index >= 0 && index < Items.Count)
                        {
                            ContextMenu menu = ContextMenuBuilder.BuildForTrack(Items.Count == 0 ? "" : Items[listView.SelectedIndex].FilePath);
                            menu.IsOpen = true;
                            menu.PlacementTarget = listView;
                        }

                    });
                return selectedItemRight;
            }
        }
        #endregion
        #region Constructors
        public TrackViewModel()
        {
            List<Models.TrackModel> beforeSort = new List<Models.TrackModel>();
            foreach (var source in GlobalData.Current.Audios.Values)
            {
                beforeSort.Add(new Models.TrackModel(source).CheckChanges());
            }
            Items = new ObservableCollection<Models.TrackModel>(beforeSort.OrderBy(item => item.TrackString));
        }
        #endregion
        #region Public Methods
        public void Tick(ListView listView)
        {
            bool needRefresh = false;
            foreach (var model in Items.ToList())
            {

                if (GlobalData.Current.Audios.ContainsKey(model.FilePath))
                {
                    MediaSource source = GlobalData.Current.Audios[model.FilePath];
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
                    needRefresh = true;
                }
            }
            if (needRefresh)
                listView.Items.Refresh();
        }
        #endregion
    }
}
