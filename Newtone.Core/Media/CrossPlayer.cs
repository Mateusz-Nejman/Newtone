using Newtone.Core.Languages;
using Newtone.Core.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        #endregion
        #region Constructors
        public CrossPlayer(IBasePlayer basePlayer)
        {
            BasePlayer = basePlayer;
            webPC = new WebPlayerController();
            localPC = new LocalPlayerController();

            Random = new Random(GlobalData.PASSWORD.GetHashCode());
        }
        #endregion
        #region Public Methods
        public void Load(string filename)
        {
            BasePlayer.Reset();
            SetPlayerController(filename.Length == 11 ? webPC : localPC);

            if(filename.Length == 11)
            {
                if(GlobalData.Current.DownloadedIds.Contains(filename))
                {
                    try
                    {
                        var filepath = GlobalData.Current.AudioTags.Keys.First(filepath =>
                        {
                            return GlobalData.Current.AudioTags[filepath].Id == filename;
                        });
                        filename = filepath;
                        SetPlayerController(localPC);
                    }
                    catch
                    {

                    }
                }
            }

            PlayerController?.Load(this, filename);

            try
            {
                BasePlayer?.Prepare();
            }
            catch
            {
                Error(GlobalData.ERROR_CORRUPTED);
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
            ConsoleDebug.WriteLine("[CrossPlayer] Next" + GlobalData.Current.CurrentPlaylist.Count + " " + GlobalData.Current.PlaylistPosition);
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

                if (GlobalData.Current.PlaylistType == MediaSource.SourceType.Local)
                {

                    if (File.Exists(track.FilePath))
                    {
                        Load(track.FilePath);
                        GlobalData.Current.MediaSource = track;
                        BasePlayer?.AfterNext();
                    }
                    else
                    {
                        //ConsoleDebug.WriteLine("CustomMediaPlayer Next");
                        Error(GlobalData.ERROR_FILE_EXISTS);
                    }
                }
                else
                {
                    Load(track.FilePath);
                    GlobalData.Current.MediaSource = track;
                }

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


                if (GlobalData.Current.PlaylistType == MediaSource.SourceType.Local)
                {

                    if (File.Exists(track.FilePath))
                    {
                        Load(track.FilePath);
                        GlobalData.Current.MediaSource = track;
                        BasePlayer?.AfterPrev();
                    }
                    else
                    {
                        //ConsoleDebug.WriteLine("CustomMediaPlayer Prev");
                        Error(GlobalData.ERROR_FILE_EXISTS);
                        track = null;
                    }
                }
                else
                {
                    Load(track.FilePath);
                    GlobalData.Current.MediaSource = track;
                }

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
            ConsoleDebug.WriteLine("Seek " + seek);
            if (BasePlayer.GetCanSeek())
                BasePlayer?.Seek(seek);
                //BasePlayer.Seek((int)seek * 1000);
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
        #endregion
    }
}
