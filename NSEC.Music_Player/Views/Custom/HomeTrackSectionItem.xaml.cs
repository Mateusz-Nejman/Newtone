using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTrackSectionItem : ContentView
    {
        private readonly string FilePath;
        private readonly int Index;
        private readonly bool Most;
        public HomeTrackSectionItem(string title, string author, string filePath, int index, bool mostTrack, ImageSource imageSource = null)
        {
            InitializeComponent();

            titleLabel.Text = title;
            authorLabel.Text = author;
            FilePath = filePath;
            Index = index;
            Most = mostTrack;
            if (imageSource != null)
                image.Source = imageSource;

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;

            GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            List<MediaSource> playlist = new List<MediaSource>();

            foreach(TrackCounter item in (Most ? Global.MostTracks : Global.LastTracks))
            {
                if(Global.Audios.ContainsKey(item.Media.FilePath))
                    playlist.Add(Global.Audios[item.Media.FilePath]);
            }
            Navigation.PushAsync(new PlayerPage(Global.Audios[FilePath], playlist, Index));
        }
    }
}