using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using NSEC.Music_Player.Languages;
using NSEC.Music_Player.Loaders;
using NSEC.Music_Player.Logic;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;
using static Android.Support.V4.Media.App.NotificationCompat;

namespace NSEC.Music_Player.Media
{
    public class CustomMediaPlayer
    {
        private Random Random { get; set; }
        public MediaPlayer MediaPlayer { get; set; }

        public bool IsPlaying
        {
            get
            {
                return MediaPlayer.IsPlaying;
            }
        }

        public double Duration
        {
            get
            {
                return ((double)MediaPlayer.Duration) / 1000.0;
            }
        }

        public double CurrentPosition
        {
            get
            {
                return ((double)MediaPlayer.CurrentPosition) / 1000.0;
            }
        }

        public bool CanSeek
        {
            get
            {
                return MediaPlayer != null;
            }
        }
        private IPlayerController PlayerController;
        public CustomMediaPlayer()
        {
            if (MediaPlayer == null)
            {
                MediaPlayer = new MediaPlayer();
                MediaPlayer.SetWakeMode(Global.Context, WakeLockFlags.Partial);
                MediaPlayer.Completion += MediaPlayer_Completion;
                MediaPlayer.Prepared += MediaPlayer_Prepared;
            }

            Random = new Random(Global.PASSWORD.GetHashCode());
        }

        public void SetPlayerController(IPlayerController playerController)
        {
            PlayerController = playerController;
        }

        private void MediaPlayer_Prepared(object sender, EventArgs e)
        {
            PlayerController?.Prepared(this);
        }

        private void MediaPlayer_Completion(object sender, EventArgs e)
        {
            if(CurrentPosition > 0 && CurrentPosition <= Duration)
            PlayerController?.Completed(this);

            //TrackCompleted?.Invoke(this, e);
        }

        public void Load(string filename)
        {
            MediaPlayer.Reset();

            PlayerController?.Load(this, filename);

            try
            {
                MediaPlayer?.PrepareAsync();
            }
            catch
            {
                SnackbarBuilder.Show(Localization.FileCorrupted);
            }
        }

        public void Play()
        {
            MediaPlayer.Start();
            SetNotification(Global.MediaSource);
        }

        public void Stop()
        {
            MediaPlayer.Stop();
            SetNotification(Global.MediaSource);
        }

        public void Next()
        {
            if (Global.CurrentPlaylist.Count > 0)
            {
                MediaSource track;
                if (Global.CurrentQueue.Count > 0 && Global.QueuePosition < Global.CurrentQueue.Count)
                {
                    track = Global.CurrentQueue[Global.QueuePosition];
                }
                else
                {
                    Global.CurrentQueue.Clear();
                    Global.QueuePosition = 0;
                    if (Global.CurrentPlaylist.Count > 1)
                    {
                        Global.PlaylistPosition += Global.PlayerMode == PlayerMode.All ? 1 : Random.Next(0, Global.CurrentPlaylist.Count);

                        if (Global.PlaylistPosition >= Global.CurrentPlaylist.Count)
                            Global.PlaylistPosition -= Global.CurrentPlaylist.Count;
                    }

                    track = Global.CurrentPlaylist[Global.PlaylistPosition];

                }

                if (Global.PlaylistType == MediaSource.SourceType.Local)
                {
                    
                    if (File.Exists(track.FilePath))
                    {
                        Load(track.FilePath);
                        Global.MediaSource = track;
                        GlobalLoader.AddToCounter(track.FilePath, 1);
                        GlobalLoader.AddToLast(track.FilePath);
                    }
                    else
                    {
                        Console.WriteLine("CustomMediaPlayer Next");
                        SnackbarBuilder.Show(Localization.SnackFileExists);
                        track = null;
                    }
                }
                else
                {
                    Load(track.FilePath);
                    Global.MediaSource = track;
                }

                SetNotification(track);


            }
        }

        public void Prev()
        {
            if (Global.CurrentPlaylist.Count > 0)
            {
                if (Global.CurrentPlaylist.Count > 1)
                {
                    Global.PlaylistPosition -= Global.PlayerMode == PlayerMode.All ? 1 : Random.Next(0, Global.CurrentPlaylist.Count);

                    if (Global.PlaylistPosition < 0)
                        Global.PlaylistPosition = Global.CurrentPlaylist.Count - Global.PlaylistPosition;
                }

                MediaSource track = Global.CurrentPlaylist[Global.PlaylistPosition];


                if (Global.PlaylistType == MediaSource.SourceType.Local)
                {

                    if (File.Exists(track.FilePath))
                    {
                        Load(track.FilePath);
                        Global.MediaSource = track;
                        GlobalLoader.AddToCounter(track.FilePath, 1);
                        GlobalLoader.AddToLast(track.FilePath);
                    }
                    else
                    {
                        Console.WriteLine("CustomMediaPlayer Prev");
                        SnackbarBuilder.Show(Localization.SnackFileExists);
                        track = null;
                    }
                }
                else
                {
                    Load(track.FilePath);
                    Global.MediaSource = track;
                }

                SetNotification(track);

            }

        }

        public void Pause()
        {
            MediaPlayer.Pause();
            SetNotification(Global.MediaSource);

        }

        public void Seek(double seek)
        {
            if (CanSeek)
                MediaPlayer.SeekTo((int)seek * 1000);
        }

        public void SetVolume(float volume)
        {
            MediaPlayer.SetVolume(volume, volume);
        }

        public void SetNotification(MediaSource container)
        {
            if (container != null)
            {
                PendingIntent prevIntent = PendingIntent.GetBroadcast(Global.Context, 0, new Intent("prev"), PendingIntentFlags.Immutable);
                PendingIntent playIntent = PendingIntent.GetBroadcast(Global.Context, 0, new Intent("play"), PendingIntentFlags.Immutable);
                PendingIntent pauseIntent = PendingIntent.GetBroadcast(Global.Context, 0, new Intent("pause"), PendingIntentFlags.Immutable);
                PendingIntent nextIntent = PendingIntent.GetBroadcast(Global.Context, 0, new Intent("next"), PendingIntentFlags.Immutable);
                PendingIntent stopIntent = PendingIntent.GetBroadcast(Global.Context, 0, new Intent("close"), PendingIntentFlags.Immutable);
                PendingIntent openIntent = PendingIntent.GetActivity(Global.Context, 0, new Intent(Global.Context, typeof(MainActivity)), PendingIntentFlags.OneShot);

                NotificationCompat.Action actionPrev = new NotificationCompat.Action(Resource.Drawable.PrevIconNotification, "Prev", prevIntent);
                NotificationCompat.Action actionPlay = new NotificationCompat.Action(!IsPlaying ? Resource.Drawable.PlayIconNotification : Resource.Drawable.PauseIconNotification, "Play", !IsPlaying ? playIntent : pauseIntent);
                NotificationCompat.Action actionNext = new NotificationCompat.Action(Resource.Drawable.NextIconNotification, "Next", nextIntent);
                NotificationCompat.Action actionStop = new NotificationCompat.Action(Resource.Drawable.StopIconNotification, "Stop", stopIntent);
                Bitmap largeIcon;

                if (container.Picture != null)
                    largeIcon = BitmapFactory.DecodeByteArray(container.Picture, 0, container.Picture.Length);
                else
                    largeIcon = BitmapFactory.DecodeResource(Global.Context.Resources, Resource.Drawable.EmptyTrack);

                NotificationCompat.Builder builder = new NotificationCompat.Builder(Global.Context, "nsec music_player notification").
                    SetContentTitle(container.Title).
                    SetContentText(container.Artist).
                    SetSmallIcon(Resource.Drawable.PlayIconNotification).
                    AddAction(actionPrev).
                    AddAction(actionPlay).
                    AddAction(actionNext).
                    AddAction(actionStop).
                    SetContentIntent(openIntent).
                    SetSound(null).
                    SetStyle(new MediaStyle()).
                    SetLargeIcon(largeIcon).
                    SetVisibility(NotificationCompat.VisibilityPublic).SetOngoing(true);
                Notification notification = builder.Build();

                //Instance.StartService(prevIntent);
                Global.NotificationManager.Notify(0, notification);
            }
            else
            {
                Global.NotificationManager.Cancel(0);
            }
        }
    }
}