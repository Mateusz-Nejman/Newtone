using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NSEC.Music_Player.Models;

namespace NSEC.Music_Player.Download
{
    public interface IDownload
    {
        public Task<string> Download(string id, string url);
        public Task AddToDownload(string id, string url, object additional = null);
        public Task Search(string text, ObservableCollection<SearchResultModel> model);

    }
}