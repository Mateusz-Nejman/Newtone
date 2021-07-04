namespace Nejman.Newtone.Core.Models
{
    public class PlaylistModel
    {
        public string Name { get; }
        public byte[] Image { get; }
        internal PlaylistModel(string name, byte[] image)
        {
            Name = name;
            Image = image;
        }
    }
}
