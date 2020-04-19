using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NSEC.Music_Player.Models;

namespace NSEC.Music_Player.Download
{
    public class SoundcloudDownload : IDownload
    {
        public Task AddToDownload(string id, string url, object additional = null)
        {
            throw new NotImplementedException();
        }

        public Task<string> Download(string id, string url)
        {
            throw new NotImplementedException();
        }
        public Task Search(string text, ObservableCollection<SearchResultModel> model)
        {
            throw new NotImplementedException();
        }
    }
}