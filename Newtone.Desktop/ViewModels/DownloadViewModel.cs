using Newtone.Core.Models;
using Newtone.Core.Processing;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Newtone.Desktop.ViewModels
{
    public class DownloadViewModel
    {
        #region Properties
        public ObservableCollection<DownloadModel> Items { get; set; }
        #endregion
        #region Constructors
        public DownloadViewModel()
        {
            Items = new ObservableCollection<DownloadModel>();
        }
        #endregion
        #region Public Methods
        public void Tick(ListView listView)
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
            }

            listView.Items.Refresh();
        }
        #endregion
    }
}
