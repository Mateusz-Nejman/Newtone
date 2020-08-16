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
using Newtone.Core.Models;
using Newtone.Core.Processing;

namespace Newtone.Mobile.ViewModels
{
    public class DownloadViewModel
    {
        #region Properties
        public ObservableCollection<DownloadModel> Items { get; private set; }
        #endregion
        #region Constructors
        public DownloadViewModel()
        {
            Items = new ObservableCollection<DownloadModel>();
        }
        #endregion
        #region Public Methods

        public void Tick()
        {
            if (Items.Count != DownloadProcessing.GetDownloads().Count)
            {
                Items.Clear();
                foreach (var item in DownloadProcessing.GetModels())
                    Items.Add(item);
            }

            for (int a = 0; a < Items.Count; a++)
            {
                Items[a].Progress = DownloadProcessing.GetDownloads()[Items[a].Id].Progress;
                //ConsoleDebug.WriteLine(Items[a].Progress);
            }
        }
        #endregion
    }
}