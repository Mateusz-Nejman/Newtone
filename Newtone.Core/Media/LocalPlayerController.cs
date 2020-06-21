using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Newtone.Core.Media
{
    public class LocalPlayerController : IPlayerController
    {
        #region Public Methods
        public void Completed(CrossPlayer player)
        {
            player.Next();
        }

        public void Load(CrossPlayer player, string filepath)
        {
            player.BasePlayer.Load(filepath);
        }

        public void Prepared(CrossPlayer player)
        {
            player.Play();
        }
        #endregion
    }
}
