using System;
using System.Collections.Generic;
using System.Text;

namespace Nejman.Newtone.Core.Models
{
    public class ArtistModel
    {
        public string Name { get; }
        public byte[] Image { get; }
        internal ArtistModel(string name, byte[] image)
        {
            Name = name;
            Image = image;
        }
    }
}
