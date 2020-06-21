using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtone.Core;
using Newtone.Core.Processing;
using NSEC.Music_Player.Models;

namespace NSEC.Music_Player.ViewModels
{
    public class SyncListViewModel
    {
        #region Properties
        public ObservableCollection<TrackModel> Items { get; private set; }
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
                    Items.Add(new TrackModel(GlobalData.Audios[item]));
            }

            foreach (var item in Items)
                item.CheckChanges();
        }
        #endregion
    }
}