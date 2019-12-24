using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSEC.Music_Player.Services
{
    public interface IDataStore<T>
    {
        int Count();
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        bool Clear();
    }
}
