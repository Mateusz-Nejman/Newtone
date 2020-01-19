using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.CustomViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExploreTab : ContentPage
    {
        public ExploreTab()
        {
            InitializeComponent();
            Appearing += ExploreTab_Appearing;
        }

        private void ExploreTab_Appearing(object sender, EventArgs e)
        {
            Refresh(mostView, Global.MostTracks);
            Refresh(lastView, Global.LastTracks);
        }

        public void Refresh(StackLayout layout, TrackCounter[] counters)
        {
            List<TrackCounter> tracks = new List<TrackCounter>(counters);
            tracks = tracks.OrderByDescending(o => o.Count).ToList();

            layout.Children.Clear();
            for(int a = 0; a < tracks.Count; a++)
            {
                if(a < 5)
                {
                    TrackView trackView = new TrackView
                    {
                        FilePath = tracks[a].Track
                    };

                    layout.Children.Add(trackView);
                }
            }
        }
        
    }
}