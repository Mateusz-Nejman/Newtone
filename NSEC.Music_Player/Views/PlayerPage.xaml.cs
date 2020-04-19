using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Loaders;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Processing;
using NSEC.Music_Player.Views.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;
using MediaSource = NSEC.Music_Player.Media.MediaSource;
using Range = NSEC.Music_Player.Logic.Range;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        public static bool Showed { get; set; }
        private string oldTrack = "";
        private bool start = false;
        private ImageSource playIcon;
        private ImageSource PlayIcon
        {
            get
            {
                if (playIcon == null)
                    playIcon = ImageSource.FromFile("PlayIcon.png");

                return playIcon;
            }
        }

        private ImageSource pauseIcon;
        private ImageSource PauseIcon
        {
            get
            {
                if (pauseIcon == null)
                    pauseIcon = ImageSource.FromFile("PauseIcon.png");

                return pauseIcon;
            }
        }
        private bool Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;

                playButton.ImageSource = start ? PauseIcon : PlayIcon;
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
        private bool stopTimer = false;

        public PlayerPage(SearchResultModel model)
        {
            InitPlayerPage((MediaSource)model, new List<MediaSource>() { (MediaSource)model }, 0);

            new Task(async () =>
            {
                string mixId = model.MixId;

                YoutubeClient client = new YoutubeClient();
                var playlist = await client.GetPlaylistAsync(mixId);

                foreach (var vid in playlist.Videos)
                {
                    Global.CurrentPlaylist.Add((MediaSource)vid);
                }
                Console.WriteLine("Playlist count " + Global.CurrentPlaylist.Count);
            }).Start();
        }
        public PlayerPage(MediaSource source, List<MediaSource> playlist, int playlistPosition)
        {
            InitPlayerPage(source, playlist, playlistPosition);
        }

        private void InitPlayerPage(MediaSource source, List<MediaSource> playlist, int playlistPosition)
        {
            Showed = true;
            InitializeComponent();


            if (source.Type == MediaSource.SourceType.Local)
                Global.MediaPlayer.SetPlayerController(new LocalPlayerController());
            else
                Global.MediaPlayer.SetPlayerController(new WebPlayerController());

            MediaSource = source;

            titleLabel.Text = source.Title;
            authorLabel.Text = source.Artist;
            menuButton.Tag = MediaSource.FilePath;

            Global.CurrentPlaylist = new List<MediaSource>(playlist);
            Global.PlaylistType = source.Type;
            Global.PlaylistPosition = playlistPosition;

            Appearing += PlayerPage_Appearing;
            Disappearing += PlayerPage_Disappearing;


            if (source.FilePath == Global.MediaSourcePath)
            {
                BindPlayerControls();
                Start = UpdatePosition();
                Start = Global.MediaPlayer.IsPlaying;
            }
            else
            {
                if (Global.MediaPlayer != null)
                    Global.MediaPlayer.Stop();

                if (source.Type == MediaSource.SourceType.Web || File.Exists(source.FilePath))
                {
                    if (source.Type == MediaSource.SourceType.Local)
                    {
                        GlobalLoader.AddToCounter(source.FilePath, 1);
                        GlobalLoader.AddToLast(source.FilePath);
                    }

                    BindPlayerControls();
                    new Task(() =>
                    {
                        Global.MediaPlayer.Load(source.FilePath);
                        Play();
                        
                    }).Start();

                    Start = true;
                    Global.LastPlayerClick = Start;

                }
                else
                {
                    SnackbarBuilder.Show(Localization.SnackFileExists);
                    Next();
                }
            }


            Global.MediaSource = MediaSource;

            if (source.Picture != null)
            {
                trackImage.Source = ImageHelper.Blur(source.Picture);
                trackImageSmall.Source = ImageSource.FromStream(() => new MemoryStream(source.Picture));
            }
            else
            {
                trackImage.Source = Global.EmptyTrackBlur;
                trackImageSmall.Source = Global.EmptyTrack;
            }
        }

        private void PlayerPage_Disappearing(object sender, EventArgs e)
        {
            Showed = false;
            stopTimer = true;
        }

        private void PlayerPage_Appearing(object sender, EventArgs e)
        {
            menuButton.ImageSource = Global.MediaSource.Type == MediaSource.SourceType.Local ? "MenuIcon.png" : "DownloadIcon.png";
            Showed = true;
            stopTimer = false;
            if (Global.MediaSource.Type == MediaSource.SourceType.Local)
                Global.MediaPlayer.SetPlayerController(new LocalPlayerController());
            else
                Global.MediaPlayer.SetPlayerController(new WebPlayerController());
            MediaSource = Global.MediaSource;
            titleLabel.Text = MediaSource.Title;
            authorLabel.Text = MediaSource.Artist;
            trackImage.Source = MediaSource.Picture != null ? ImageHelper.Blur(MediaSource.Picture) : Global.EmptyTrackBlur;
            trackImageSmall.Source = MediaSource.Picture != null ? ImageSource.FromStream(() => new MemoryStream(MediaSource.Picture)) : Global.EmptyTrack;
            Start = Global.MediaPlayer.IsPlaying;
            //BindPlayerControls();
            Device.StartTimer(TimeSpan.FromMilliseconds(300), UpdatePosition);
            Console.WriteLine("PlayerPage appearing");
            SetSliderPosition(Global.MediaPlayer.CurrentPosition / Global.MediaPlayer.Duration);
            
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
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
            if(Global.MediaSource.Type == MediaSource.SourceType.Local)
            {
                ObservableCollection<MediaSource> tracks = new ObservableCollection<MediaSource>();

                foreach (MediaSource track in Global.CurrentPlaylist)
                {
                    tracks.Add(track);
                }

                menuButton.Tag = Global.MediaSource.FilePath;
                TrackProcessing.Process(sender, tracks, this,false,"");
            }
            else
            {
                DownloadProcessing.AddToDownloadTask(Global.MediaSource.FilePath, Global.MediaSource.Title, true, $"https://youtube.com/watch?v={Global.MediaSource.FilePath}","");
                SnackbarBuilder.Show(Localization.TitleDownloads);
            }
            
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
            playButton.ImageSource = Global.MediaPlayer.IsPlaying ? PauseIcon : PlayIcon;
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
                trackImage.Source = track.Picture == null ? Global.EmptyTrackBlur : ImageHelper.Blur(track.Picture);
                trackImageSmall.Source = track.Picture == null ? Global.EmptyTrack : ImageSource.FromStream(() => new MemoryStream(track.Picture));
            }

            return !stopTimer;
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

            Global.PlaylistPosition = Range.GetRangeInt(0, Global.CurrentPlaylist.Count - 1, Global.PlaylistPosition);

            MediaSource track = Global.CurrentPlaylist[Global.PlaylistPosition];
            MediaSource = track;
            if (MediaSource.Type == MediaSource.SourceType.Web || File.Exists(MediaSource.FilePath))
            {
                Global.MediaPlayer.Load(track.FilePath);
                Global.MediaSource = track;
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

            Global.PlaylistPosition = Range.GetRangeInt(0, Global.CurrentPlaylist.Count - 1, Global.PlaylistPosition);

            MediaSource track = Global.CurrentPlaylist[Global.PlaylistPosition];
            MediaSource = track;
            if (MediaSource.Type == MediaSource.SourceType.Web || File.Exists(MediaSource.FilePath))
            {
                Global.MediaPlayer.Load(track.FilePath);
                Global.MediaSource = track;
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

        private async void ExpandButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Expand Clicked");
            await Navigation.PushModalAsync(new CurrentPlaylistPage(trackImage.Source,this));
        }

        public void ChangeTrack(int index)
        {
            if (index >= 0 && index < Global.CurrentPlaylist.Count)
            {
                MediaSource track = Global.CurrentPlaylist[index];
                MediaSource = track;
                Global.MediaPlayer.Load(track.FilePath);
                Global.MediaSource = track;
                Global.PlaylistPosition = index;
                SetSliderPosition(0);
                if (Global.LastPlayerClick)
                    Play();
            }
        }
    }
}