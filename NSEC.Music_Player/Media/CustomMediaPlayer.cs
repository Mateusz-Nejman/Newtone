using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Media;
using Android.Media.Session;
using Android.OS;
using Android.Support.V4.App;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using NSEC.Music_Player.Views.CustomViews;
using Xamarin.Forms;
using static Android.Support.V4.Media.App.NotificationCompat;
using Uri = Android.Net.Uri;

namespace NSEC.Music_Player.Media
{
    public class CustomMediaPlayer
    {
        private string CachePath { get; set; }
        private int CacheIndex { get; set; }
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

        public EventHandler TrackCompleted;
        public CustomMediaPlayer()
        {
            if (MediaPlayer == null)
            {
                MediaPlayer = new MediaPlayer();
                MediaPlayer.SetWakeMode(Global.Context, WakeLockFlags.Partial);
                MediaPlayer.Completion += MediaPlayer_Completion;

                CacheIndex = 0;
                CachePath = "";
            }

            Random = new Random(Global.password.GetHashCode());
        }

        private void MediaPlayer_Completion(object sender, EventArgs e)
        {
            if(Global.PlayerMode == PlayerMode.One)
            {
                MediaPlayer.SeekTo(0);
                MediaPlayer.Start();
            }
            else
            {
                if(Global.CurrentQueue.Count > 0)
                {
                    Global.CurrentQueuePosition += 1;
                }

                Next();
            }
            
            TrackCompleted?.Invoke(this, e);
        }

        public void Load(System.IO.Stream stream, string filename)
        {
            MediaPlayer.Reset();
            if (CachePath != "")
            {
                try
                {
                    File.Delete(CachePath);
                }
                catch
                {
                    Console.WriteLine("Error deleting cache : " + CachePath);
                }
            }
            CachePath = System.IO.Path.Combine(Global.MusicPath, $"cache{CacheIndex++}.wav");
            FileStream fileStream = File.Create(CachePath);
            stream.CopyTo(fileStream);
            fileStream.Close();

            try
            {
                
                //MediaPlayer.SetDataSource(filename);
                MediaPlayer.SetDataSource(filename);
            }
            catch
            {
                try
                {
                    var context = Android.App.Application.Context;
                    MediaPlayer?.SetDataSource(Global.Context, Uri.Parse(Uri.Encode(filename)));
                    
                }
                catch
                {
                    return;
                }
            }

            Console.WriteLine("MediaPlayer " + filename);
           try
            {
                MediaPlayer?.Prepare();
            }
            catch
            {
                SnackbarBuilder.Show("Nie można otworzyc pliku");
            }

        }


        public void Play()
        {
            MediaPlayer.Start();
            SetNotification(Global.CurrentTrack);
        }

        public void Stop()
        {
            MediaPlayer.Stop();
            SetNotification(Global.CurrentTrack);
        }

        public void Next()
        {
            if(Global.CurrentPlaylist.Count > 0)
            {
                Track track;
                if (Global.CurrentQueue.Count > 0)
                {
                    track = Global.CurrentQueue[Global.CurrentQueuePosition];
                    Global.CurrentTrack = track.Container;
                    Global.AudioPlayerTrack = track.Id;
                }
                else
                {
                    if (Global.CurrentPlaylist.Count > 1)
                    {
                        Global.CurrentPlaylistPosition += Global.PlayerMode == PlayerMode.All ? 1 : Random.Next(0, Global.CurrentPlaylist.Count);

                        if (Global.CurrentPlaylistPosition >= Global.CurrentPlaylist.Count)
                            Global.CurrentPlaylistPosition -= Global.CurrentPlaylist.Count;
                    }

                    track = Global.CurrentPlaylist[Global.CurrentPlaylistPosition];
                    Global.CurrentTrack = track.Container;
                    Global.AudioPlayerTrack = track.Id;
                }

                Load(FileProcessing.GetStreamFromFile(track.Container.FilePath), track.Container.FilePath);
                if (Global.LastPlayerClick)
                    Play();
                Helpers.AddToCounter(track.Container.FilePath, 1);
                Helpers.AddToLast(track.Container.FilePath);

                SetNotification(track);
            }
        }

        public void Prev()
        {
            if(Global.CurrentPlaylist.Count > 0)
            {
                if (Global.CurrentPlaylist.Count > 1)
                {
                    Global.CurrentPlaylistPosition -= Global.PlayerMode == PlayerMode.All ? 1 : Random.Next(0, Global.CurrentPlaylist.Count);

                    if (Global.CurrentPlaylistPosition < 0)
                        Global.CurrentPlaylistPosition = Global.CurrentPlaylist.Count - Global.CurrentPlaylistPosition;
                }

                Track track = Global.CurrentPlaylist[Global.CurrentPlaylistPosition];

                Global.CurrentTrack = track.Container;
                Global.AudioPlayerTrack = track.Id;
                Load(FileProcessing.GetStreamFromFile(track.Container.FilePath), track.Container.FilePath);
                if (Global.LastPlayerClick)
                    Play();
                Helpers.AddToCounter(track.Container.FilePath, 1);
                Helpers.AddToLast(track.Container.FilePath);
                SetNotification(track);

            }
            
        }

        public void Pause()
        {
            MediaPlayer.Pause();
            SetNotification(Global.CurrentTrack);
            
        }

        public void Seek(double seek)
        {
            if(CanSeek)
                MediaPlayer.SeekTo((int)seek * 1000);
        }

        public void SetVolume(float volume)
        {
            MediaPlayer.SetVolume(volume, volume);
        }

        public void SetNotification(Track track)
        {
            SetNotification(track?.Container);
        }
        public void SetNotification(MediaProcessing.MediaTag container)
        {
            if(container != null)
            {
                PendingIntent prevIntent = PendingIntent.GetBroadcast(Global.Context, 1, new Intent("prev"), PendingIntentFlags.Immutable);
                PendingIntent playIntent = PendingIntent.GetBroadcast(Global.Context, 0, new Intent("play"), PendingIntentFlags.Immutable);
                PendingIntent pauseIntent = PendingIntent.GetBroadcast(Global.Context, 0, new Intent("pause"), PendingIntentFlags.Immutable);
                PendingIntent nextIntent = PendingIntent.GetBroadcast(Global.Context, 0, new Intent("next"), PendingIntentFlags.Immutable);
                PendingIntent stopIntent = PendingIntent.GetBroadcast(Global.Context, 0, new Intent("close"), PendingIntentFlags.Immutable);
                PendingIntent openIntent = PendingIntent.GetActivity(Global.Context, 0, new Intent(Global.Context, typeof(MainActivity)), PendingIntentFlags.UpdateCurrent);

                NotificationCompat.Action actionPrev = new NotificationCompat.Action(Resource.Drawable.prevIconNotification, "Prev", prevIntent);
                NotificationCompat.Action actionPlay = new NotificationCompat.Action(!IsPlaying ? Resource.Drawable.playiconNotification : Resource.Drawable.pauseIconNotification, "Play", !IsPlaying ? playIntent : pauseIntent);
                NotificationCompat.Action actionNext = new NotificationCompat.Action(Resource.Drawable.nextIconNotification, "Next", nextIntent);
                NotificationCompat.Action actionStop = new NotificationCompat.Action(Resource.Drawable.stopIcon, "Stop", stopIntent);


                NotificationCompat.Builder builder = new NotificationCompat.Builder(Global.Context, "nsec music_player notification").
                    SetContentTitle(container.Title).
                    SetContentText(container.Artist).
                    SetSmallIcon(Resource.Drawable.playIconWhite).
                    AddAction(actionPrev).
                    AddAction(actionPlay).
                    AddAction(actionNext).
                    AddAction(actionStop).
                    SetContentIntent(openIntent).
                    SetSound(null).
                    SetStyle(new MediaStyle()).
                    SetLargeIcon(BitmapFactory.DecodeResource(Global.Context.Resources, Resource.Drawable.emptyTrack)).
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

    [Service]
    public class MediaPlayerReceiver : BroadcastReceiver
    {
        public MediaPlayerReceiver()
        {
        }

        public override void OnReceive(Context context, Intent intent)
        {

            if (intent.Action == "prev")
                Global.MediaPlayer.Prev();
            else if (intent.Action == "next")
                Global.MediaPlayer.Next();
            else if (intent.Action == "play")
                Global.MediaPlayer.Play();
            else if (intent.Action == "pause")
                Global.MediaPlayer.Pause();
            else if(intent.Action == "open")
            {
                
            }
            else if(intent.Action == "close")
            {
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            }
            Console.WriteLine("MediaPlayerReceiver "+intent.Action);
        }
    }
}