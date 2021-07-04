using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Data;
using Nejman.Newtone.Core.Localization;
using Nejman.Newtone.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Nejman.Newtone.Mobile.ViewModels
{
    public class DownloadsViewModel : PropertyChangedBase
    {
        #region Fields
        private string title;
        #endregion
        #region Properties
        public ObservableCollection<DownloadModel> Items { get; private set; }
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Constructors
        public DownloadsViewModel()
        {
            Items = new ObservableCollection<DownloadModel>();
            Title = Localization.TitleDownloads;
        }
        #endregion
        #region Public Methods

        public void Tick()
        {
            if (Items.Count != DownloadAction.GetBadgeCount())
            {
                Items.Clear();
                foreach (var item in DownloadAction.Get())
                    Items.Add(item);
            }

            for (int a = 0; a < Items.Count; a++)
            {
                Items[a].Progress = DownloadAction.GetProgress(Items[a].Id);
            }
        }
        #endregion
    }
}
