using NSEC.Music_Player.Models;

namespace NSEC.Music_Player.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            //Title = item?.Text;
            Title = "Title";
            Item = item;
        }
    }
}
