using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Loaders;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Processing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                start = value;

                playButton.ImageSource = start ? ImageSource.FromFile("PauseIcon.png") : ImageSource.FromFile("PlayIcon.png");
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
                    repeatButton.ImageSource = ImageSource.FromFile("RepeatIcon.png");
                else if (playerMode == PlayerMode.One)
                    repeatButton.ImageSource = ImageSource.FromFile("RepeatOneIcon.png");
                else
                    repeatButton.ImageSource = ImageSource.FromFile("RandomIcon.png");
            }
        }

        private MediaSource MediaSource { get; set; }
        public PlayerPage(MediaSource source, List<MediaSource> playlist, int playlistPosition)
        {
            InitializeComponent();
            Global.MediaPlayer.SetPlayerController(new LocalPlayerController());

            MediaSource = source;

            titleLabel.Text = source.Title;
            authorLabel.Text = source.Artist;
            menuButton.Tag = MediaSource.FilePath;

            Global.CurrentPlaylist = new List<MediaSource>(playlist);
            Global.PlaylistType = MediaSource.SourceType.Local;
            Global.PlaylistPosition = playlistPosition;
            Global.MediaSource = MediaSource;

            Appearing += PlayerPage_Appearing;

            if(source.FilePath == Global.CurrentAudioPath)
            {
                BindPlayerControls();
                Start = UpdatePosition();
                Start = Global.MediaPlayer.IsPlaying;
            }
            else
            {
                if (Global.MediaPlayer != null)
                    Global.MediaPlayer.Stop();

                if(File.Exists(source.FilePath))
                {
                    Global.CurrentAudioPath = source.FilePath;
                    GlobalLoader.AddToCounter(source.FilePath, 1);
                    GlobalLoader.AddToLast(source.FilePath);
                    BindPlayerControls();
                    Global.MediaPlayer.Load(source.FilePath);
                    Play();
                    Start = true;
                    Global.LastPlayerClick = Start;
                }
                else
                {
                    SnackbarBuilder.Show(Localization.SnackFileExists);
                }
            }

            if (source.Picture != null)
                trackImage.Source = ImageSource.FromStream(() => new MemoryStream(source.Picture));

            Device.StartTimer(TimeSpan.FromMilliseconds(300), UpdatePosition);
        }

        private void PlayerPage_Appearing(object sender, EventArgs e)
        {
            Global.MediaPlayer.SetPlayerController(new LocalPlayerController());
            MediaSource = Global.MediaSource;
            titleLabel.Text = MediaSource.Title;
            authorLabel.Text = MediaSource.Artist;
            trackImage.Source = MediaSource.Picture != null ? ImageSource.FromStream(() => new MemoryStream(MediaSource.Picture)) : Global.EmptyTrack;
            Start = Global.MediaPlayer.IsPlaying;
            SetSliderPosition(Global.MediaPlayer.CurrentPosition / Global.MediaPlayer.Duration);
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void RepeatButton_Clicked(object sender, EventArgs e)
        {
            int oldMode = (int)PlayerMode;
            int newMode = oldMode + 1;
            if (newMode == 3)
                newMode = 0;

            PlayerMode = (PlayerMode)newMode;
            Global.PlayerMode = PlayerMode;
            Global.SaveConfig();
        }

        private void PrevButton_Clicked(object sender, EventArgs e)
        {
            Prev();
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            slider.Maximum = 1;
            slider.IsEnabled = Global.MediaPlayer.CanSeek;
            if (Start)
                Pause();
            else
                Global.MediaPlayer.Play();

            Start = !Start;
            Global.LastPlayerClick = Start;
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            Next();
        }

        private void MenuButton_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<MediaSource> tracks = new ObservableCollection<MediaSource>();

            foreach (MediaSource track in Global.CurrentPlaylist)
            {
                tracks.Add(track);
            }

            menuButton.Tag = Global.MediaSource.FilePath;
            TrackProcessing.Process(sender, tracks, this);
        }

        private void BindPlayerControls()
        {
            
            slider.Maximum = 1;
            slider.ValueChanged += Slider_ValueChanged;

            playButton.Clicked += PlayButton_Clicked;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (slider.Value != 1)
                Global.MediaPlayer.Seek(slider.Value * Global.MediaPlayer.Duration);
        }

        private bool UpdatePosition()
        {
            MediaSource track = Global.CurrentPlaylist[Global.PlaylistPosition];
            MediaSource = track;
            titleLabel.Text = MediaSource.Title;
            authorLabel.Text = MediaSource.Artist;
            //lblPosition.Text = $"Postion: {(int)player.CurrentPosition} / {(int)player.Duration}";

            SetSliderPosition(Global.MediaPlayer.CurrentPosition / Global.MediaPlayer.Duration);

            endLabel.Text = TickParser.FormatTick(Global.MediaPlayer.Duration);
            startLabel.Text = TickParser.FormatTick(Global.MediaPlayer.CurrentPosition);
            Start = Global.MediaPlayer.IsPlaying;
            PlayerMode = Global.PlayerMode;

            if (oldTrack != track.FilePath)
            {
                oldTrack = track.FilePath;
                trackImage.Source = track.Picture == null ? Global.EmptyTrack : ImageSource.FromStream(() => new MemoryStream(track.Picture));
            }

            return true;
        }

        private void Play()
        {
            Global.MediaPlayer.Play();
            Start = true;
            SetSliderPosition(0);
            slider.Maximum = 1;
            slider.IsEnabled = Global.MediaPlayer.CanSeek;
            Global.SaveConfig();
        }

        private void Next()
        {
            Global.PlaylistPosition += 1;

            if (Global.PlaylistPosition == Global.CurrentPlaylist.Count)
                Global.PlaylistPosition = 0;

            MediaSource track = Global.CurrentPlaylist[Global.PlaylistPosition];
            MediaSource = track;
            if (File.Exists(MediaSource.FilePath))
            {
                Global.MediaPlayer.Load(track.FilePath);
                Global.MediaSource = track;
                Global.CurrentAudioPath = track.FilePath;
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
            Global.PlaylistPosition -= 1;

            if (Global.PlaylistPosition == -1)
                Global.PlaylistPosition = Global.CurrentPlaylist.Count - 1;

            MediaSource track = Global.CurrentPlaylist[Global.PlaylistPosition];
            MediaSource = track;
            if (File.Exists(MediaSource.FilePath))
            {
                Global.MediaPlayer.Load(track.FilePath);
                Global.MediaSource = track;
                Global.CurrentAudioPath = track.FilePath;
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
            slider.ValueChanged -= Slider_ValueChanged;
            slider.Maximum = 1;
            slider.Value = position;
            slider.ValueChanged += Slider_ValueChanged;
        }
    }
}