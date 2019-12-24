using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        private bool start = false;
        private bool Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value; ///TODO

                playStopButton.ImageSource = start ? ImageSource.FromFile("pause.png") : ImageSource.FromFile("play.png");
            }
        }
        private MP3Processing.Container TrackContainer { get; set; }

        private Task ClockTask { get; set; }

        public PlayerPage(Track track, List<Track> playlist, int playlistPosition)
        {
            InitializeComponent();
            Console.WriteLine("PlayerPage.xaml.cs: " + track.Id + ", position = " + playlistPosition);

            TrackContainer = track.Container;
            titleLabel.Text = TrackContainer.Title;
            artistLabel.Text = TrackContainer.Author;
            menuButton.Tag = TrackContainer.FilePath;

            Global.CurrentPlaylist = playlist;
            Global.CurrentPlaylistPosition = playlistPosition;
            Global.CurrentTrack = TrackContainer;
            this.Appearing += PlayerPage_Appearing;


            if (track.Id == Global.AudioPlayerTrack)
            {
                BindPlayerControls();
                UpdatePosition();
                Start = Global.AudioPlayer.IsPlaying;
            }
            else
            {
                if (Global.AudioPlayer != null)
                    Global.AudioPlayer.Stop();
                var stream = FileProcessing.GetStreamFromFile(TrackContainer.FilePath);
                Global.AudioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                Global.AudioPlayer.Load(stream);
                Global.AudioPlayer.PlaybackEnded += Global.AudioPlayer_PlaybackEnded;
                Global.AudioPlayerTrack = track.Id;
                BindPlayerControls();
                Start = true;
                Play();
            }



            Device.StartTimer(TimeSpan.FromSeconds(0.5), UpdatePosition);

        }

        private void PlayerPage_Appearing(object sender, EventArgs e)
        {
            TrackContainer = Global.CurrentTrack;
            titleLabel.Text = TrackContainer.Title;
            artistLabel.Text = TrackContainer.Author;
            Start = Global.AudioPlayer.IsPlaying;
            SetSliderPosition(Global.AudioPlayer.CurrentPosition);
        }

        private void prevButton_Clicked(object sender, EventArgs e)
        {
            Prev();
        }

        private void nextButton_Clicked(object sender, EventArgs e)
        {
            Next();
        }

        private void BindPlayerControls()
        {
            trackSlider.Maximum = Global.AudioPlayer.Duration;
            trackSlider.ValueChanged += TrackSlider_ValueChanged;

            playStopButton.Clicked += PlayStopButton_Clicked;
        }

        private void PlayStopButton_Clicked(object sender, EventArgs e)
        {
            if (Start)
                Global.AudioPlayer.Pause();
            else
            {
                //Play();
                Global.AudioPlayer.Play();
            }

            Start = !Start;
        }
        bool UpdatePosition()
        {
            //lblPosition.Text = $"Postion: {(int)player.CurrentPosition} / {(int)player.Duration}";

            SetSliderPosition(Global.AudioPlayer.CurrentPosition);

            return Global.AudioPlayer.IsPlaying;
        }

        private void TrackSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (trackSlider.Value != Global.AudioPlayer.Duration)
                Global.AudioPlayer.Seek(trackSlider.Value);
        }


        private void Play()
        {
            Global.AudioPlayer.Play();
            SetSliderPosition(0);
            trackSlider.Maximum = Global.AudioPlayer.Duration;
            trackSlider.IsEnabled = Global.AudioPlayer.CanSeek;
            Global.SaveConfig();
        }

        private void Next()
        {
            Global.AudioPlayer.Stop();
            Global.CurrentPlaylistPosition += 1;

            if (Global.CurrentPlaylistPosition == Global.CurrentPlaylist.Count)
                Global.CurrentPlaylistPosition = 0;

            Track track = Global.CurrentPlaylist[Global.CurrentPlaylistPosition];
            TrackContainer = track.Container;
            var stream = FileProcessing.GetStreamFromFile(TrackContainer.FilePath);
            Global.AudioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            Global.AudioPlayer.PlaybackEnded += Global.AudioPlayer_PlaybackEnded;
            Global.AudioPlayer.Load(stream);
            Global.AudioPlayerTrack = track.Id;
            titleLabel.Text = TrackContainer.Title;
            artistLabel.Text = TrackContainer.Author;
            SetSliderPosition(0);
            Play();
        }

        private void Prev()
        {
            Global.AudioPlayer.Stop();
            Global.CurrentPlaylistPosition -= 1;

            if (Global.CurrentPlaylistPosition == -1)
                Global.CurrentPlaylistPosition = Global.CurrentPlaylist.Count;

            Track track = Global.CurrentPlaylist[Global.CurrentPlaylistPosition];
            TrackContainer = track.Container;
            var stream = FileProcessing.GetStreamFromFile(TrackContainer.FilePath);
            Global.AudioPlayer = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            Global.AudioPlayer.PlaybackEnded += Global.AudioPlayer_PlaybackEnded;
            Global.AudioPlayer.Load(stream);
            Global.AudioPlayerTrack = track.Id;
            titleLabel.Text = TrackContainer.Title;
            artistLabel.Text = TrackContainer.Author;
            SetSliderPosition(0);
            Play();
        }

        private void Pause()
        {
            Global.AudioPlayer.Pause();
        }

        private void SetSliderPosition(double position)
        {
            trackSlider.ValueChanged -= TrackSlider_ValueChanged;
            trackSlider.Value = position;
            trackSlider.ValueChanged += TrackSlider_ValueChanged;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Track> tracks = new ObservableCollection<Track>();

            foreach(Track track in Global.CurrentPlaylist)
            {
                tracks.Add(track);
            }

            TrackProcessing.Process(sender, tracks, this);
        }
    }
}