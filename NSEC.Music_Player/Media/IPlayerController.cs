using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NSEC.Music_Player.Media
{
    public interface IPlayerController
    {
        public void Load(CustomMediaPlayer player, string filepath);
        public void Prepared(CustomMediaPlayer player);
        public void Completed(CustomMediaPlayer player);
    }
}