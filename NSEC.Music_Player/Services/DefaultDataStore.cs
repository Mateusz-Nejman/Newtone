using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSEC.Music_Player.Models;

namespace NSEC.Music_Player.Services
{
    public class DefaultDataStore : IDataStore<Track>
    {
        readonly List<Track> items;

        public DefaultDataStore()
        {
            items = new List<Track>();
            //items = new List<Item>();
        }

        public async Task<bool> AddItemAsync(Track item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Track item)
        {
            var oldItem = items.Where((Track arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);


            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            //var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            //items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Track> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Track>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public int Count()
        {
            return items.Count;
        }

        public bool Clear()
        {
            items.Clear();
            return true;
        }
    }
}