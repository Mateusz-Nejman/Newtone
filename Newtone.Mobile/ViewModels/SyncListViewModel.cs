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
using Newtone.Core.Models;
using Newtone.Core.Processing;
using Newtone.Mobile.Models;
using TrackModel = Newtone.Mobile.Models.TrackModel;

namespace Newtone.Mobile.ViewModels
{
    public class SyncListViewModel:PropertyChangedBase
    {
        #region Fields
        private bool isRefreshing;
        #endregion
        #region Properties
        public ObservableCollection<TrackModel> Items { get; private set; }
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
                        ConsoleDebug.WriteLine("[Refresh] SyncListViewModel");
                        IsRefreshing = true;
                        Items = new ObservableCollection<TrackModel>();
                        IsRefreshing = false;
                    });
                return refresh;
            }
        }
        #endregion
        #region Constructors
        public SyncListViewModel()
        {
            Items = new ObservableCollection<TrackModel>();
        }
        #endregion
        #region Public Methods

        public void Tick()
        {
            if (Items.Count != SyncProcessing.Audios.Count)
            {
                Items.Clear();
                foreach (var item in SyncProcessing.Audios)
                    Items.Add(new TrackModel(GlobalData.Current.Audios[item]));
            }

            foreach (var item in Items)
                item.CheckChanges();
        }
        #endregion
    }
}