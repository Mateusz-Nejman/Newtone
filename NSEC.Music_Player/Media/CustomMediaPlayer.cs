﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Media;
using Android.Media.Session;
using Android.OS;
using Android.Support.V4.App;
using NSEC.Music_Player.Logic;
using NSEC.Music_Player.Models;
using Xamarin.Forms;
using Uri = Android.Net.Uri;

namespace NSEC.Music_Player.Media
{
    public class CustomMediaPlayer
    {
        private string CachePath { get; set; }
        private int CacheIndex { get; set; }
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
                MediaPlayer.Completion += MediaPlayer_Completion;
                CacheIndex = 0;
                CachePath = "";
            }
        }

        private void MediaPlayer_Completion(object sender, EventArgs e)
        {
            Next();
            TrackCompleted?.Invoke(this, e);
        }

        public void Load(System.IO.Stream stream)
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
            CachePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), $"cache{CacheIndex++}.wav");
            FileStream fileStream = File.Create(CachePath);
            stream.CopyTo(fileStream);
            fileStream.Close();

            try
            {
                MediaPlayer.SetDataSource(CachePath);
            }
            catch
            {
                try
                {
                    var context = Android.App.Application.Context;
                    MediaPlayer?.SetDataSource(context, Uri.Parse(Uri.Encode(CachePath)));
                }
                catch
                {
                    return;
                }
            }

            MediaPlayer?.Prepare();

        }


        public void Play()
        {
            MediaPlayer.Start();
            MainActivity.SetNotification(Global.CurrentTrack.Title, Global.CurrentTrack.Artist, IsPlaying);
        }

        public void Stop()
        {
            MediaPlayer.Stop();
            MainActivity.SetNotification(Global.CurrentTrack.Title, Global.CurrentTrack.Artist, IsPlaying);
        }

        public void Next()
        {
            Stop();
            Global.CurrentPlaylistPosition += 1;

            if (Global.CurrentPlaylistPosition == Global.CurrentPlaylist.Count)
                Global.CurrentPlaylistPosition = 0;

            Track track = Global.CurrentPlaylist[Global.CurrentPlaylistPosition];
            Global.CurrentTrack = track.Container;
            Global.AudioPlayerTrack = track.Id;
            Load(FileProcessing.GetStreamFromFile(track.Container.FilePath));
            Helpers.AddToCounter(track.Container.FilePath, 1);
            Helpers.AddToLast(track.Container.FilePath);
            Play();
            
            MainActivity.SetNotification(track.Container.Title, track.Container.Artist, IsPlaying);
        }

        public void Prev()
        {
            Stop();
            Global.CurrentPlaylistPosition -= 1;

            if (Global.CurrentPlaylistPosition == -1)
                Global.CurrentPlaylistPosition = Global.CurrentPlaylist.Count-1;

            Track track = Global.CurrentPlaylist[Global.CurrentPlaylistPosition];
            
            Global.CurrentTrack = track.Container;
            Global.AudioPlayerTrack = track.Id;
            Load(FileProcessing.GetStreamFromFile(track.Container.FilePath));
            Helpers.AddToCounter(track.Container.FilePath, 1);
            Helpers.AddToLast(track.Container.FilePath);
            Play();
            MainActivity.SetNotification(track.Container.Title, track.Container.Artist, IsPlaying);
            
        }

        public void Pause()
        {
            MediaPlayer.Pause();
            MainActivity.SetNotification(Global.CurrentTrack.Title, Global.CurrentTrack.Artist, IsPlaying);
            
        }

        public void Seek(double seek)
        {
            if(CanSeek)
                MediaPlayer.SeekTo((int)seek * 1000);
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
            Console.WriteLine("MediaPlayerReceiver "+intent.Action);
        }
    }
}