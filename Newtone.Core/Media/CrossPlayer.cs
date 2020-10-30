using Newtone.Core.Languages;
using Newtone.Core.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;

namespace Newtone.Core.Media
{
    public class CrossPlayer
    {
        #region Fields
        private readonly IPlayerController webPC;
        private readonly IPlayerController localPC;
        private readonly List<int> randomIndexes = new List<int>();
        #endregion
        #region Properties
        public IBasePlayer BasePlayer { get; private set; }
        private IPlayerController PlayerController { get; set; }
        private Random Random { get; set; }
        public bool IsPlaying
        {
            get
            {
                return BasePlayer.GetIsPlaying();
            }
        }

        public double Duration
        {
            get
            {
                return BasePlayer.GetDuration();
            }
        }

        public double CurrentPosition
        {
            get
            {
                return BasePlayer.GetCurrentPosition();
            }
        }

        public bool CanSeek
        {
            get
            {
                return BasePlayer.GetCanSeek();
            }
        }

        public bool IsLoading { get; set; } = false;

        public bool IsLocalFile
        {
            get => PlayerController is LocalPlayerController;
        }

        public Action NativePlay { get; private set; }
        #endregion
        #region Constructors
        public CrossPlayer(IBasePlayer basePlayer)
        {
            BasePlayer = basePlayer;
            webPC = new WebPlayerController();
            localPC = new LocalPlayerController();

            Random = new Random(GlobalData.NSEC_HASH.GetHashCode());
            IsLoading = false;
        }
        #endregion
        #region Public Methods
        public void SetNativeActions(Action play = null)
        {
            NativePlay = play;
        }
        public void LoadPlaylist(List<string> playlist, int currentIndex, bool load, bool play)
        {
            LoadPlaylist(() =>
            {
                List<MediaSource> newPlaylist = new List<MediaSource>();

                playlist.ForEach(track => newPlaylist.Add(GlobalData.Current.Audios[track]));

                return newPlaylist;
            }, currentIndex, load, play);
        }

        public void LoadPlaylist(string playlistUrl, int currentIndex, MediaSource initial, bool load, bool play)
        {
            GlobalData.Current.CurrentPlaylist.Clear();
            GlobalData.Current.CurrentPlaylist.Add(initial);
            GlobalData.Current.MediaSource = initial;
            GlobalData.Current.PlaylistPosition = currentIndex;
            GlobalData.Current.QueuePosition = currentIndex;
            new Task(() =>
            {
                if (load)
                    Load(GlobalData.Current.MediaSourcePath);
                if (play)
                    NativePlay?.Invoke();
            }).Start();
            new Task(async () =>
            {
                YoutubeClient youtubeClient = new YoutubeClient();
                var playlist = await youtubeClient.Playlists.GetVideosAsync(playlistUrl).BufferAsync(20);

                if (playlist.Count > 0)
                {
                    using WebClient client = new WebClient();
                    GlobalData.Current.CurrentPlaylist.Clear();
                    GlobalData.Current.PlaylistPosition = 0;
                    foreach (var _item in playlist)
                    {
                        byte[] data = client.DownloadData(_item.Thumbnails.MediumResUrl);
                        GlobalData.Current.CurrentPlaylist.Add(new Newtone.Core.Media.MediaSource()
                        {
                            Artist = _item.Author,
                            Duration = _item.Duration,
                            FilePath = _item.Id,
                            Image = data,
                            Title = _item.Title,
                            Type = Newtone.Core.Media.MediaSource.SourceType.Web
                        });
                    }
                }
            }).Start();
        }

        public void LoadPlaylist(Func<List<MediaSource>> playlist, int currentIndex, bool load, bool play)
        {
            randomIndexes.Clear();
            GlobalData.Current.CurrentPlaylist = playlist();
            GlobalData.Current.PlaylistPosition = currentIndex;
            GlobalData.Current.MediaSource = GlobalData.Current.CurrentPlaylist[currentIndex];

            if (load)
                Load(GlobalData.Current.MediaSource.FilePath);
            if(play)
                NativePlay?.Invoke();
        }
        public void Load(string filename)
        {
            IsLoading = true;
            BasePlayer.Reset();
            SetPlayerController(filename.Length == 11 ? webPC : localPC);

            if(filename.Length == 11 && GlobalData.Current.DownloadedIds.Contains(filename))
            {
                try
                {
                    var filepath = GlobalData.Current.AudioTags.Keys.First(file =>
                    {
                        return GlobalData.Current.AudioTags[file].Id == filename;
                    });
                    filename = filepath;
                    SetPlayerController(localPC);
                }
                catch
                {
                    //If can't load stream audio from local file, continue
                }
            }

            Console.WriteLine("Load " + filename + " using " + (PlayerController is WebPlayerController ? "WebPlayerController" : "LocalPlayerControler"));
            PlayerController?.Load(this, filename);
            Console.WriteLine("Loaded");
            try
            {
                Console.WriteLine("Prepare");
                BasePlayer?.Prepare();
                PlayerController?.Prepared(this);
                Console.WriteLine("Prepared");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error in " + (PlayerController is WebPlayerController ? "WebPlayerController" : "LocalPlayerController"));
                Error(GlobalData.ERROR_CORRUPTED);
                IsLoading = false;
            }
        }

        public void Play()
        {
            BasePlayer?.Play();
            BasePlayer?.SetNotification(true);
        }

        public void Stop()
        {
            BasePlayer?.Stop();
            BasePlayer?.SetNotification(false);
        }

        public void Pause()
        {
            BasePlayer?.Pause();
            BasePlayer?.SetNotification(false);
        }

        public void Next()
        {
            if (GlobalData.Current.CurrentPlaylist.Count > 0)
            {
                MediaSource track;
                if (GlobalData.Current.CurrentPlaylist.Count > 1)
                {
                    int addValue = 0;
                    if (GlobalData.Current.PlayerMode == PlayerMode.All)
                        addValue = 1;

                    GlobalData.Current.PlaylistPosition += addValue;

                    if (GlobalData.Current.PlayerMode == PlayerMode.Random)
                        GlobalData.Current.PlaylistPosition = GetRandom(GlobalData.Current.CurrentPlaylist.Count);

                    GlobalData.Current.PlaylistPosition = Logic.Range.GetRangeInt(0, GlobalData.Current.CurrentPlaylist.Count - 1, GlobalData.Current.PlaylistPosition);
                }

                track = GlobalData.Current.CurrentPlaylist[GlobalData.Current.PlaylistPosition];

                if (IsLocalPath(track.FilePath) && !File.Exists(track.FilePath))
                {
                    Error(GlobalData.ERROR_FILE_EXISTS);
                }

                try
                {
                    Load(track.FilePath);
                }
                catch
                {
                    Next();
                    return;
                }
                
                GlobalData.Current.MediaSource = track;
                BasePlayer?.AfterNext();

                BasePlayer?.SetNotification(true);
            }
        }

        public void Prev()
        {
            if (GlobalData.Current.CurrentPlaylist.Count > 0)
            {
                if (GlobalData.Current.CurrentPlaylist.Count > 1)
                {
                    int addValue = 0;
                    if (GlobalData.Current.PlayerMode == PlayerMode.All)
                        addValue = 1;

                    GlobalData.Current.PlaylistPosition -= addValue;

                    if (GlobalData.Current.PlayerMode == PlayerMode.Random)
                        GlobalData.Current.PlaylistPosition = GetRandom(GlobalData.Current.CurrentPlaylist.Count);
                    

                    GlobalData.Current.PlaylistPosition = Logic.Range.GetRangeInt(0, GlobalData.Current.CurrentPlaylist.Count - 1, GlobalData.Current.PlaylistPosition);
                }

                MediaSource track = GlobalData.Current.CurrentPlaylist[GlobalData.Current.PlaylistPosition];

                if (IsLocalPath(track.FilePath) && !File.Exists(track.FilePath))
                {
                    Error(GlobalData.ERROR_FILE_EXISTS);
                }

                Load(track.FilePath);
                GlobalData.Current.MediaSource = track;
                BasePlayer?.AfterPrev();

                BasePlayer?.SetNotification(true);

            }
        }

        public void Reset()
        {
            Stop();
        }

        public void Seek(double seek)
        {
            if (BasePlayer.GetCanSeek())
                BasePlayer?.Seek(seek);
        }

        public void SetVolume(float volume)
        {
            BasePlayer?.SetVolume(volume);
        }

        public float GetVolume()
        {
            return BasePlayer.GetVolume();
        }

        public void Error(string error)
        {
            string errorText = error;

            if (error == GlobalData.ERROR_FILE_EXISTS)
                errorText = Localization.SnackFileExists;
            else if (error == GlobalData.ERROR_CORRUPTED)
                errorText = Localization.FileCorrupted;

            GlobalData.Current.Messenger.Show(MessageGenerator.EMessageType.Snackbar, errorText);
        }
        #endregion
        #region Private Methods
        private int GetRandom(int max)
        {
            if (randomIndexes.Count >= max || randomIndexes.Count == 0)
            {
                randomIndexes.Clear();
                for(int a = 0; a < max; a++)
                {
                    randomIndexes.Add(a);
                }
            }

            int randomNumber = Random.Next(0,max);

            if (randomIndexes.Contains(randomNumber))
            {
                randomIndexes.Remove(randomNumber);
                return randomNumber;
            }
            else
            {
                return GetRandom(max);
            }
        }
        private void SetPlayerController(IPlayerController playerController)
        {
            PlayerController = playerController;
        }

        private bool IsLocalPath(string filepath)
        {
            return filepath.Length > 11;
        }
        #endregion
    }
}
