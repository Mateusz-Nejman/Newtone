using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LobbyPage : TabbedPage
    {
        public LobbyPage()
        {
            InitializeComponent();
            App.IsInLobby = true;
            Global.MostTracks = new Models.TrackCounter[0];
            Global.LastTracks = new Models.TrackCounter[0];
        }
    }
}