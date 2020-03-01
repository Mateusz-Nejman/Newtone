using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Loaders;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Media;
using NSEC.Music_Player.Models;
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
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace NSEC.Music_Player.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StreamPlayerPage : ContentPage
    {
        private ObservableCollection<SearchResultModel> Items { get; set; }
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

        private readonly MediaSource source;
        private readonly object playlist;
        private readonly int index;
        public StreamPlayerPage(MediaSource source, List<MediaSource> playlist, int index)
        {
            InitializeComponent();
            nextTrackList.ItemsSource = Items = new ObservableCollection<SearchResultModel>();
            titleLabel.Text = source.Title;
            authorLabel.Text = source.Artist;
            menuButton.Tag = source.FilePath;
            Global.PlaylistType = MediaSource.SourceType.Web;
            Global.PlaylistPosition = index;
            MediaSource = source;
            trackImage.Source = source.ImageSource;
            this.source = source;
            this.playlist = playlist;
            this.index = index;
            Device.StartTimer(TimeSpan.FromSeconds(1), InitTimer);
            Appearing += StreamPlayerPage_Appearing;
            
        }

        private void StreamPlayerPage_Appearing(object sender, EventArgs e)
        {
            Global.MediaPlayer.SetPlayerController(new WebPlayerController());
        }

        public StreamPlayerPage(MediaSource source, List<SearchResultModel> playlist, int index)
        {
            InitializeComponent();
            nextTrackList.ItemsSource = Items = new ObservableCollection<SearchResultModel>();
            titleLabel.Text = source.Title;
            authorLabel.Text = source.Artist;
            menuButton.Tag = source.FilePath;
            Global.PlaylistType = MediaSource.SourceType.Web;
            Global.PlaylistPosition = index;
            MediaSource = source;
            trackImage.Source = source.ImageSource;
            this.source = source;
            this.playlist = playlist;
            this.index = index;
            Device.StartTimer(TimeSpan.FromSeconds(1), InitTimer);
            Appearing += StreamPlayerPage_Appearing;

        }

        private bool InitTimer()
        {
            Initialize(source, playlist, index);
            return false;
        }

        private void Initialize(MediaSource source, object playlist, int index)
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            downloadLayout.GestureRecognizers.Add(tapGestureRecognizer);
            
            if (playlist is List<MediaSource>)
                Global.CurrentPlaylist = new List<MediaSource>((List<MediaSource>)playlist);
            else
            {
                Global.CurrentPlaylist.Clear();
                foreach(var elem in (List<SearchResultModel>)playlist)
                {
                    Global.CurrentPlaylist.Add(new MediaSource()
                    {
                        Artist = elem.Author,
                        Duration = elem.Duration,
                        FilePath = elem.Id,
                        ImageSource = elem.Picture,
                        Picture = elem.ImageData,
                        Title = elem.Title,
                        Type = MediaSource.SourceType.Web
                    });
                }
            }

            SetListWithFirst(index);

            MediaSource = source;
            Global.PlaylistPosition = index;
            Global.MediaSource = source;

            if(Global.CurrentAudioPath == source.FilePath)
            {
                BindPlayerControls();
                Start = UpdatePosition();
                Start = Global.MediaPlayer.IsPlaying;
            }
            else
            {
                Global.MediaPlayer?.Stop();

                Global.CurrentAudioPath = source.FilePath;

                BindPlayerControls();
                Global.MediaPlayer.Load(source.FilePath);
            }

            if (source.Picture != null)
                trackImage.Source = ImageSource.FromStream(() => new MemoryStream(source.Picture));
            else
                trackImage.Source = source.ImageSource;

            Device.StartTimer(TimeSpan.FromMilliseconds(300), UpdatePosition);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DownloadPage());
        }

        private void MediaPlayer_TrackPrepared(object sender, EventArgs e)
        {
            Play();
            Start = true;
            Global.LastPlayerClick = Start;
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
            DownloadProcessing.AddToDownloadTask(Global.MediaSource.FilePath, Global.MediaSource.Title, true, $"https://youtube.com/watch?v={Global.MediaSource.FilePath}");
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
            downloadLayout.IsVisible = DownloadProcessing.GetDownloads().Count > 0;
            downloadLabel.Text = DownloadProcessing.BadgeCount < 10 ? DownloadProcessing.BadgeCount.ToString() : "9+";
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
                trackImage.Source = track.Picture == null ? track.ImageSource : ImageSource.FromStream(() => new MemoryStream(track.Picture));
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
            Console.WriteLine("StreamPlayerPage Next");
            Global.PlaylistPosition += 1;

            if (Global.PlaylistPosition == Global.CurrentPlaylist.Count)
                Global.PlaylistPosition = 0;

            MediaSource track = Global.CurrentPlaylist[Global.PlaylistPosition];
            MediaSource = track;
            Pause();
            Global.MediaPlayer.Load(track.FilePath);
            Global.MediaSource = track;
            Global.CurrentAudioPath = track.FilePath;
            SetSliderPosition(0);
            if (Global.LastPlayerClick)
                Play();

        }

        private void Prev()
        {
            Console.WriteLine("StreamPlayerPage Prev");
            Global.PlaylistPosition -= 1;

            if (Global.PlaylistPosition == -1)
                Global.PlaylistPosition = Global.CurrentPlaylist.Count - 1;

            MediaSource track = Global.CurrentPlaylist[Global.PlaylistPosition];
            MediaSource = track;
            Pause();
            Global.MediaPlayer.Load(track.FilePath);
            Global.MediaSource = track;
            Global.CurrentAudioPath = track.FilePath;
            SetSliderPosition(0);
            if (Global.LastPlayerClick)
                Play();
        }

        private void Pause()
        {
            Global.MediaPlayer.Pause();
        }

        private void SetSliderPosition(double position)
        {
            slider.ValueChanged -= Slider_ValueChanged;
            slider.ValueChanged -= Slider_ValueChanged;
            slider.Maximum = 1;
            slider.Value = position;
            slider.ValueChanged += Slider_ValueChanged;
        }

        private void SetListWithFirst(int firstIndex)
        {
            Items.Clear();
            for(int a = 0; a < Global.CurrentPlaylist.Count; a++)
            {
                int newIndex = a + firstIndex;

                if (newIndex >= Global.CurrentPlaylist.Count)
                    newIndex -= Global.CurrentPlaylist.Count;

                MediaSource source = Global.CurrentPlaylist[newIndex];

                Items.Add(new SearchResultModel()
                {
                    Author = source.Artist,
                    Duration = source.Duration,
                    Id = source.FilePath,
                    ImageData = source.Picture,
                    Picture = source.ImageSource,
                    Title = source.Title,
                    Youtube = true,
                    VideoData = $"{source.Title}{Global.SEPARATOR}https://youtube.com/watch?v={source.FilePath}"
                });
            }
        }
    }
}