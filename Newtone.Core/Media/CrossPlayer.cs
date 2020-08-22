using Newtone.Core.Languages;
using Newtone.Core.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Newtone.Core.Media
{
    public class CrossPlayer
    {
        #region Fields
        private readonly IPlayerController webPC;
        private readonly IPlayerController localPC;
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
        #endregion
        #region Constructors
        public CrossPlayer(IBasePlayer basePlayer)
        {
            BasePlayer = basePlayer;
            webPC = new WebPlayerController();
            localPC = new LocalPlayerController();

            Random = new Random(GlobalData.PASSWORD.GetHashCode());
            IsLoading = false;
        }
        #endregion
        #region Public Methods
        public void Load(string filename)
        {
            IsLoading = true;
            BasePlayer.Reset();
            SetPlayerController(filename.Length == 11 ? webPC : localPC);

            if(filename.Length == 11)
            {
                if(GlobalData.Current.DownloadedIds.Contains(filename))
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

                    }
                }
            }

            Console.WriteLine("Load " + filename + " using " + (PlayerController is WebPlayerController ? "WebPlayerController" : "LocalPlayerControler"));
            PlayerController?.Load(this, filename);

            try
            {
                BasePlayer?.Prepare();
                PlayerController?.Prepared(this);
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
                if (GlobalData.Current.CurrentQueue.Count > 0 && GlobalData.Current.QueuePosition < GlobalData.Current.CurrentQueue.Count)
                {
                    track = GlobalData.Current.CurrentQueue[GlobalData.Current.QueuePosition];
                }
                else
                {
                    GlobalData.Current.CurrentQueue.Clear();
                    GlobalData.Current.QueuePosition = 0;
                    if (GlobalData.Current.CurrentPlaylist.Count > 1)
                    {
                        int addValue = 0;
                        if (GlobalData.Current.PlayerMode == PlayerMode.All)
                            addValue = 1;
                        else if (GlobalData.Current.PlayerMode == PlayerMode.Random)
                            addValue = Random.Next(0, GlobalData.Current.CurrentPlaylist.Count);
                        GlobalData.Current.PlaylistPosition += addValue;

                        GlobalData.Current.PlaylistPosition = Logic.Range.GetRangeInt(0, GlobalData.Current.CurrentPlaylist.Count - 1, GlobalData.Current.PlaylistPosition);
                    }

                    track = GlobalData.Current.CurrentPlaylist[GlobalData.Current.PlaylistPosition];

                }

                if (IsLocalPath(track.FilePath) && !File.Exists(track.FilePath))
                {
                    Error(GlobalData.ERROR_FILE_EXISTS);
                }

                Load(track.FilePath);
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
                    else if (GlobalData.Current.PlayerMode == PlayerMode.Random)
                        addValue = Random.Next(0, GlobalData.Current.CurrentPlaylist.Count);
                    GlobalData.Current.PlaylistPosition -= addValue;

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
            BasePlayer?.Stop();
            BasePlayer?.SetNotification(false);
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
