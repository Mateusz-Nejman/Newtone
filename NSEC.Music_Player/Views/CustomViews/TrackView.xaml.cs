using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackView : ContentView
    {
        private Track track;
        private string filePath;
        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
                track = new Track
                {
                    Container = MP3Processing.GetMeta(filePath),
                    
                };
                track.Id = track.Container.Artist + track.Container.Title;
                trackLabel.Text = track.Container.Title;
                
            }
        }
        
        public TrackView()
        {
            InitializeComponent();
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            frame.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Console.WriteLine("TrackView " + track.Container.Title);
            await Navigation.PushAsync(new PlayerPage(track, new List<Track>() { track }, 0));
        }
    }
}