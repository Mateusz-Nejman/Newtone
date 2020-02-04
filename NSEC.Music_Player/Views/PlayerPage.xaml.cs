using Android.App;
using Android.Support.V4.App;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.CustomViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Support.V4.Media.App.NotificationCompat;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        private string oldTrack = "";
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

                playStopButton.ImageSource = start ? ImageSource.FromFile("pauseIcon.png") : ImageSource.FromFile("playIcon.png");
            }
        }

        private PlayerMode playerMode = PlayerMode.All;
        private PlayerMode PlayerMode
        {
            get
            {
                return playerMode;
            }
            set
            {
                playerMode = value;

                if (playerMode == PlayerMode.All)
                    modeButton.ImageSource = ImageSource.FromFile("repeatIcon.png");
                else if (playerMode == PlayerMode.One)
                    modeButton.ImageSource = ImageSource.FromFile("repeatOneIcon.png");
                else
                    modeButton.ImageSource = ImageSource.FromFile("randomIcon");
            }
        }
        private MediaProcessing.MediaTag TrackContainer { get; set; }

        public PlayerPage(Track track, List<Track> playlist, int playlistPosition)
        {
            InitializeComponent();
            Console.WriteLine("PlayerPage.xaml.cs: " + track.Id + ", position = " + playlistPosition);

            TrackContainer = track.Container;

            Console.WriteLine("PlayerPage " + TrackContainer.Title);
            titleLabel.Text = TrackContainer.Title;
            artistLabel.Text = TrackContainer.Artist;
            menuButton.Tag = TrackContainer.FilePath;

            Global.CurrentPlaylist = new List<Track>(playlist);
            Console.WriteLine("PlayerPage PlaylistPosition " + playlistPosition);
            Global.CurrentPlaylistPosition = playlistPosition;
            Global.CurrentTrack = TrackContainer;
            this.Appearing += PlayerPage_Appearing;


            if (track.Id == Global.AudioPlayerTrack)
            {
                Console.WriteLine("PlayerPage the same");
                BindPlayerControls();
                Start = UpdatePosition();
                Start = Global.MediaPlayer.IsPlaying;

            }
            else
            {
                if (Global.MediaPlayer != null)
                    Global.MediaPlayer.Stop();



                if (File.Exists(track.Container.FilePath))
                {
                    Global.AudioPlayerTrack = track.Id;
                    Helpers.AddToCounter(track.Container.FilePath, 1);
                    Helpers.AddToLast(track.Container.FilePath);
                    BindPlayerControls();
                    Global.MediaPlayer.Load(FileProcessing.GetStreamFromFile(track.Container.FilePath), track.Container.FilePath);
                    Play();
                    Start = true;
                    Global.LastPlayerClick = Start;
                }
                else
                    SnackbarBuilder.Show(Localization.SnackFileExists);

            }

            if (track.Container.Picture != null)
            {
                trackImage.Source = ImageSource.FromStream(() => new MemoryStream(track.Container.Picture));
            }



            Device.StartTimer(TimeSpan.FromSeconds(0.5), UpdatePosition);

        }

        private void PlayerPage_Appearing(object sender, EventArgs e)
        {
            TrackContainer = Global.CurrentTrack;
            titleLabel.Text = TrackContainer.Title;
            artistLabel.Text = TrackContainer.Artist;
            trackImage.Source = TrackContainer.Picture != null ? ImageSource.FromStream(() => new MemoryStream(TrackContainer.Picture)) : Global.EmptyTrack;
            Start = Global.MediaPlayer.IsPlaying;
            SetSliderPosition(Global.MediaPlayer.CurrentPosition / Global.MediaPlayer.Duration);
        }

        private void PrevButton_Clicked(object sender, EventArgs e)
        {
            Prev();
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            Next();
        }

        private void BindPlayerControls()
        {
            trackSlider.Maximum = 1;
            trackSlider.ValueChanged += TrackSlider_ValueChanged;

            playStopButton.Clicked += PlayStopButton_Clicked;
        }

        private void PlayStopButton_Clicked(object sender, EventArgs e)
        {
            trackSlider.Maximum = 1;
            trackSlider.IsEnabled = Global.MediaPlayer.CanSeek;
            if (Start)
                Pause();
            else
                Global.MediaPlayer.Play();

            Start = !Start;
            Global.LastPlayerClick = Start;
        }
        bool UpdatePosition()
        {
            Track track = Global.CurrentPlaylist[Global.CurrentPlaylistPosition];
            TrackContainer = track.Container;
            titleLabel.Text = TrackContainer.Title;
            artistLabel.Text = TrackContainer.Artist;
            //lblPosition.Text = $"Postion: {(int)player.CurrentPosition} / {(int)player.Duration}";

            SetSliderPosition(Global.MediaPlayer.CurrentPosition / Global.MediaPlayer.Duration);

            maximumLabel.Text = TickParser.FormatTick(Global.MediaPlayer.Duration);
            currentLabel.Text = TickParser.FormatTick(Global.MediaPlayer.CurrentPosition);
            Start = Global.MediaPlayer.IsPlaying;
            PlayerMode = Global.PlayerMode;

            if (oldTrack != track.Container.FilePath)
            {
                oldTrack = track.Container.FilePath;
                trackImage.Source = track.Picture;
            }

            return true;
        }

        private void TrackSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (trackSlider.Value != 1)
                Global.MediaPlayer.Seek(trackSlider.Value * Global.MediaPlayer.Duration);
        }


        private void Play()
        {
            Global.MediaPlayer.Play();
            Start = true;
            SetSliderPosition(0);
            trackSlider.Maximum = 1;
            trackSlider.IsEnabled = Global.MediaPlayer.CanSeek;
            Global.SaveConfig();
        }

        private void Next()
        {
            Global.CurrentPlaylistPosition += 1;

            if (Global.CurrentPlaylistPosition == Global.CurrentPlaylist.Count)
                Global.CurrentPlaylistPosition = 0;

            Track track = Global.CurrentPlaylist[Global.CurrentPlaylistPosition];
            TrackContainer = track.Container;
            if (File.Exists(TrackContainer.FilePath))
            {
                Global.MediaPlayer.Load(FileProcessing.GetStreamFromFile(track.Container.FilePath), track.Container.FilePath);
                Global.CurrentTrack = track.Container;
                Global.AudioPlayerTrack = track.Id;
                SetSliderPosition(0);
                if (Global.LastPlayerClick)
                    Play();
            }
            else
            {
                Next();
            }

        }

        private void Prev()
        {
            Global.CurrentPlaylistPosition -= 1;

            if (Global.CurrentPlaylistPosition == -1)
                Global.CurrentPlaylistPosition = Global.CurrentPlaylist.Count - 1;

            Track track = Global.CurrentPlaylist[Global.CurrentPlaylistPosition];
            TrackContainer = track.Container;
            if (File.Exists(TrackContainer.FilePath))
            {
                Global.MediaPlayer.Load(FileProcessing.GetStreamFromFile(track.Container.FilePath), track.Container.FilePath);
                Global.CurrentTrack = track.Container;
                Global.AudioPlayerTrack = track.Id;
                SetSliderPosition(0);
                if (Global.LastPlayerClick)
                    Play();
            }
            else
            {
                Prev();
            }
        }

        private void Pause()
        {
            Global.MediaPlayer.Pause();
        }

        private void SetSliderPosition(double position)
        {
            trackSlider.ValueChanged -= TrackSlider_ValueChanged;
            trackSlider.Maximum = 1;
            trackSlider.Value = position;
            trackSlider.ValueChanged += TrackSlider_ValueChanged;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Track> tracks = new ObservableCollection<Track>();

            foreach (Track track in Global.CurrentPlaylist)
            {
                tracks.Add(track);
            }

            menuButton.Tag = Global.CurrentTrack.FilePath;
            TrackProcessing.Process(sender, tracks, this);
        }

        private void ModeButton_Clicked(object sender, EventArgs e)
        {
            int oldMode = (int)PlayerMode;
            int newMode = oldMode + 1;
            if (newMode == 3)
                newMode = 0;

            PlayerMode = (PlayerMode)newMode;
            Global.PlayerMode = PlayerMode;
            Global.SaveConfig();
        }
    }
}