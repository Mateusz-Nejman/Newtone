using System;
using System.Collections.Generic;
using System.Text;

namespace Newtone.Core.Media
{
    public interface IPlayerController
    {
        public void Load(CrossPlayer player, string filepath);
        public void Prepared(CrossPlayer player);
        public void Completed(CrossPlayer player);
    }
}
