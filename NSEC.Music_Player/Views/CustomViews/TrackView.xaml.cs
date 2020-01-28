using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        private bool lastTracks = false;
        private List<Track> Playlist;
        public bool LastTracks
        {
            get
            {
                return lastTracks;
            }
            set
            {
                lastTracks = value;

                Playlist = new List<Track>();

                TrackCounter[] trackCounters = lastTracks ? Global.LastTracks : Global.MostTracks;

                for (int a = 0; a < trackCounters.Length; a++)
                {
                    Playlist.Add(new Track() { Container = Global.Audios[trackCounters[a].Track] });
                }
            }
        }
        public int PlaylistIndex { get; set; }
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
                    Container = Global.Audios[filePath],

                };
                track.Id = track.Container.Artist + track.Container.Title;
                trackLabel.Text = track.Container.Title;
                trackImage.Source = track.Picture;

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

            if (File.Exists(track.Container.FilePath))
                await Navigation.PushAsync(new PlayerPage(track, Playlist, PlaylistIndex));
            else
                SnackbarBuilder.Show(Localization.SnackFileExists);
        }
    }
}