using Newtone.Core.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Newtone.Core.Media
{
    public class CrossPlayer
    {
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

        public CrossPlayer(IBasePlayer basePlayer)
        {
            BasePlayer = basePlayer;

            Random = new Random(GlobalData.PASSWORD.GetHashCode());
        }

        public void SetPlayerController(IPlayerController playerController)
        {
            PlayerController = playerController;
        }

        public void Load(string filename)
        {
            BasePlayer.Reset();
            PlayerController?.Load(this, filename);

            try
            {
                BasePlayer?.Prepare();
            }
            catch
            {
                BasePlayer?.Error(GlobalData.ERROR_CORRUPTED);
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
            ConsoleDebug.WriteLine("[CrossPlayer] Next" + GlobalData.CurrentPlaylist.Count + " " + GlobalData.PlaylistPosition);
            if (GlobalData.CurrentPlaylist.Count > 0)
            {
                MediaSource track;
                if (GlobalData.CurrentQueue.Count > 0 && GlobalData.QueuePosition < GlobalData.CurrentQueue.Count)
                {
                    track = GlobalData.CurrentQueue[GlobalData.QueuePosition];
                }
                else
                {
                    GlobalData.CurrentQueue.Clear();
                    GlobalData.QueuePosition = 0;
                    if (GlobalData.CurrentPlaylist.Count > 1)
                    {
                        int addValue = 0;
                        if (GlobalData.PlayerMode == PlayerMode.All)
                            addValue = 1;
                        else if (GlobalData.PlayerMode == PlayerMode.Random)
                            addValue = Random.Next(0, GlobalData.CurrentPlaylist.Count);
                        GlobalData.PlaylistPosition += addValue;

                        GlobalData.PlaylistPosition = Logic.Range.GetRangeInt(0, GlobalData.CurrentPlaylist.Count - 1, GlobalData.PlaylistPosition);
                    }

                    track = GlobalData.CurrentPlaylist[GlobalData.PlaylistPosition];

                }

                if (GlobalData.PlaylistType == MediaSource.SourceType.Local)
                {

                    if (File.Exists(track.FilePath))
                    {
                        Load(track.FilePath);
                        GlobalData.MediaSource = track;
                        BasePlayer?.AfterNext();
                    }
                    else
                    {
                        //ConsoleDebug.WriteLine("CustomMediaPlayer Next");
                        BasePlayer?.Error(GlobalData.ERROR_FILE_EXISTS);
                        track = null;
                    }
                }
                else
                {
                    Load(track.FilePath);
                    GlobalData.MediaSource = track;
                }

                BasePlayer?.SetNotification(true);


            }
        }

        public void Prev()
        {
            if (GlobalData.CurrentPlaylist.Count > 0)
            {
                if (GlobalData.CurrentPlaylist.Count > 1)
                {
                    int addValue = 0;
                    if (GlobalData.PlayerMode == PlayerMode.All)
                        addValue = 1;
                    else if (GlobalData.PlayerMode == PlayerMode.Random)
                        addValue = Random.Next(0, GlobalData.CurrentPlaylist.Count);
                    GlobalData.PlaylistPosition -= addValue;

                    GlobalData.PlaylistPosition = Logic.Range.GetRangeInt(0, GlobalData.CurrentPlaylist.Count - 1, GlobalData.PlaylistPosition);
                }

                MediaSource track = GlobalData.CurrentPlaylist[GlobalData.PlaylistPosition];


                if (GlobalData.PlaylistType == MediaSource.SourceType.Local)
                {

                    if (File.Exists(track.FilePath))
                    {
                        Load(track.FilePath);
                        GlobalData.MediaSource = track;
                        BasePlayer?.AfterPrev();
                    }
                    else
                    {
                        //ConsoleDebug.WriteLine("CustomMediaPlayer Prev");
                        BasePlayer?.Error(GlobalData.ERROR_FILE_EXISTS);
                        track = null;
                    }
                }
                else
                {
                    Load(track.FilePath);
                    GlobalData.MediaSource = track;
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
            BasePlayer?.Error(error);
        }
    }
}
